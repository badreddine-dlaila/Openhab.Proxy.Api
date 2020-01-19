using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Openhab.Client.Api;
using Openhab.Proxy.Api.Configuration;
using Openhab.Proxy.Api.Models;

namespace Openhab.Proxy.Api.Controllers
{
    [ApiController]
    [AuthorizeWithToken]
    [Route("api/[controller]")]
    public class ConfigurationController : ControllerBase, ITokenController
    {
        private readonly IItemsApi _itemsApi;
        public Guid Uuid { get; set; }
        public string Token { get; set; }
        public string Group { get; set; }

        private readonly Regex _zoneItemPattern = new Regex(@"(?<home>\w*)_(?<zone>\w*)");
        private readonly Regex _roomItemPattern = new Regex(@"(?<home>\w*)_(?<zone>\w*)_(?<room>\w*)?");

        public ConfigurationController(IItemsApi itemsApi)
        {
            _itemsApi = itemsApi;
        }

        /// <summary>
        /// Get home configuration
        /// </summary>
        /// <remarks></remarks>
        /// <response code="202">Accepted</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(HomeConfiguration), 200)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var openhabItems = await _itemsApi.GetItemsAsync(metadata: "dialogflow", tags: Token, recursive: true);
            var rootGroup = openhabItems.Single(ohi => ohi.Tags.Contains("Building"));

            var zones = openhabItems.Where(ohi => ohi.GroupNames.Count == 1 && ohi.GroupNames.Any(s => s == rootGroup.Name) && ohi.Type == "Group" && ohi.Metadata == null);
            var rooms = openhabItems.Where(ohi => ohi.GroupNames.Count == 2 && ohi.GroupNames.Any(s => s == rootGroup.Name) && ohi.Type == "Group" && ohi.Metadata == null);
            var devices = openhabItems.Where(i => ((dynamic)i.Metadata?["dialogflow"])?.config.zone != null && ((dynamic)i.Metadata?["dialogflow"])?.config.zone != "Internal").ToList();

            var configuration = new HomeConfiguration
            {
                Id = Group,
                Uuid = Uuid,
                Token = Token,
                Zones = zones.Select(z => new Zone
                {
                    Id = z.Name,
                    Name = _zoneItemPattern.Match(z.Name).Groups["zone"].Value,
                    Description = z.Label,
                    Rooms = rooms.Where(r => r.GroupNames.Contains(z.Name)).Select(r => new Room
                    {
                        Id = r.Name,
                        Name = _roomItemPattern.Match(r.Name).Groups["room"].Value,
                        Description = r.Label,
                        Devices = devices.Where(d => d.GroupNames.Contains(r.Name)).Select(d => new Device
                        {
                            Id = d.Name,
                            Description = d.Label,
                            Room = ((dynamic)d.Metadata?["dialogflow"])?.config.room,
                            Zone = ((dynamic)d.Metadata?["dialogflow"])?.config.zone,
                            Type = ((dynamic)d.Metadata?["dialogflow"])?.config.type,
                            OpenhabType = d.Type
                        })
                    })
                })
            };

            return Ok(configuration);
        }
    }
}