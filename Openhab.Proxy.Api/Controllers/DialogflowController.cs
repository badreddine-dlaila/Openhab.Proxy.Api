using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Openhab.Client.Api;
using Openhab.Proxy.Api.Configuration;
using Openhab.Proxy.Api.Models;

namespace Openhab.Proxy.Api.Controllers
{
    [ApiController]
    [AuthorizeWithToken]
    [Route("api/[controller]")]
    public class DialogflowController : ControllerBase, ITokenController
    {
        private readonly IItemsApi _itemsApi;
        public Guid Uuid { get; set; }
        public string Token { get; set; }
        public string Group { get; set; }

        private readonly Regex _zoneItemPattern = new Regex(@"(?<home>\w*)_(?<zone>\w*)");
        private readonly Regex _roomItemPattern = new Regex(@"(?<home>\w*)_(?<zone>\w*)_(?<room>\w*)?");

        public DialogflowController(IItemsApi itemsApi)
        {
            _itemsApi = itemsApi;
        }

        /// <summary>
        /// Get dialogflow entity configuration for zones
        /// </summary>
        /// <remarks></remarks>
        /// <response code="202">Accepted</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(HomeConfiguration), 200)]
        [ProducesResponseType(500)]
        [HttpGet]
        [Route("entities/zone")]
        public async Task<IActionResult> DialogflowZoneEntity(bool preferCsv)
        {
            var openhabItems = await _itemsApi.GetItemsAsync(metadata: "dialogflow", tags: Token, recursive: true);
            var rootGroup = openhabItems.Single(ohi => ohi.Tags.Contains("Building"));
            var zones = openhabItems.Where(ohi => ohi.GroupNames.Count == 1 && ohi.GroupNames.Any(s => s == rootGroup.Name) && ohi.Type == "Group" && ohi.Metadata == null).ToList();


            var dialogflowEntityAsCsv = string.Join(Environment.NewLine, zones.Select(d => $"\"{d.Name}\",\"{d.Name}\",\"{d.Label}\""));
            var dialogflowEntityAsJson = zones.Select(d => new
            {
                Value = d.Name,
                Synonyms = new List<string> { d.Name, d.Label, $"{((dynamic)d.Metadata?["dialogflow"])?.config.room} {d.Label}" }
            });

            return preferCsv ? Ok(dialogflowEntityAsCsv) : Ok(dialogflowEntityAsJson);
        }

        /// <summary>
        /// Get dialogflow entity configuration for zones
        /// </summary>
        /// <remarks></remarks>
        /// <response code="202">Accepted</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(HomeConfiguration), 200)]
        [ProducesResponseType(500)]
        [HttpGet]
        [Route("entities/room")]
        public async Task<IActionResult> DialogflowRoomEntity(bool preferCsv)
        {
            var openhabItems = await _itemsApi.GetItemsAsync(metadata: "dialogflow", tags: Token, recursive: true);
            var rootGroup = openhabItems.Single(ohi => ohi.Tags.Contains("Building"));
            var rooms = openhabItems.Where(ohi => ohi.GroupNames.Count == 2 && ohi.GroupNames.Any(s => s == rootGroup.Name) && ohi.Type == "Group" && ohi.Metadata == null).ToList();

            var dialogflowEntityAsCsv = string.Join(Environment.NewLine, rooms.Select(d => $"\"{d.Name}\",\"{d.Name}\",\"{d.Label}\""));
            var dialogflowEntityAsJson = rooms.Select(d => new
            {
                Value = d.Name,
                Synonyms = new List<string> { d.Name, d.Label, $"{((dynamic)d.Metadata?["dialogflow"])?.config.room} {d.Label}" }
            });

            return preferCsv ? Ok(dialogflowEntityAsCsv) : Ok(dialogflowEntityAsJson);
        }

        /// <summary>
        /// Get dialogflow entity configuration for device type
        /// </summary>
        /// <remarks></remarks>
        /// <response code="202">Accepted</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(HomeConfiguration), 200)]
        [ProducesResponseType(500)]
        [HttpGet]
        [Route("entities/deviceType")]
        public async Task<IActionResult> DialogflowDeviceTypeEntity(bool preferCsv)
        {
            var openhabItems = await _itemsApi.GetItemsAsync(metadata: "dialogflow", tags: Token, recursive: true);
            var devices = openhabItems.Where(i => ((dynamic)i.Metadata?["dialogflow"])?.config.zone != null && ((dynamic)i.Metadata?["dialogflow"])?.config.zone != "Internal")
                .Select(d => new Device
                {
                    Id = d.Name,
                    Description = d.Label,
                    Room = ((dynamic)d.Metadata?["dialogflow"])?.config.room,
                    Zone = ((dynamic)d.Metadata?["dialogflow"])?.config.zone,
                    Type = ((dynamic)d.Metadata?["dialogflow"])?.config.type,
                    OpenhabType = d.Type
                }).ToList();

            var deviceTypes = devices.Select(d => d.Type).Distinct().ToList();

            if (preferCsv)
            {
                var dialogflowEntityAsCsv = string.Empty;
                foreach (var deviceType in deviceTypes)
                {
                    var synonyms = $"{deviceType}\"";
                    if (deviceType != deviceType.Humanize(LetterCasing.Title))
                        synonyms += $",\"{deviceType.Humanize(LetterCasing.Title)}";
                    var entityRow = $"\"{deviceType}\",\"{synonyms}\"";
                    dialogflowEntityAsCsv += entityRow + Environment.NewLine;
                }
                return Ok(dialogflowEntityAsCsv);
            }

            var dialogflowEntityAsObject = new List<object>();
            foreach (var deviceType in deviceTypes)
            {
                var synonyms = new List<string> { deviceType };
                if (deviceType != deviceType.Humanize(LetterCasing.Title))
                    synonyms.Add(deviceType.Humanize(LetterCasing.Title));
                dynamic entityObject = new
                {
                    Value = deviceType,
                    Synonyms = synonyms
                };
                dialogflowEntityAsObject.Add((entityObject));
            }
            return Ok(dialogflowEntityAsObject);
        }

        /// <summary>
        /// Get dialogflow entity configuration for rooms
        /// </summary>
        /// <remarks></remarks>
        /// <response code="202">Accepted</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(HomeConfiguration), 200)]
        [ProducesResponseType(500)]
        [HttpGet]
        [Route("entities/device")]
        public async Task<IActionResult> DialogflowDeviceEntity(bool preferCsv)
        {
            var openhabItems = await _itemsApi.GetItemsAsync(metadata: "dialogflow", tags: Token, recursive: true);
            var devices = openhabItems.Where(i => ((dynamic)i.Metadata?["dialogflow"])?.config.zone != null && ((dynamic)i.Metadata?["dialogflow"])?.config.zone != "Internal").ToList();

            var dialogflowEntityAsCsv = string.Join(Environment.NewLine, devices.Select(d => $"\"{d.Name}\",\"{d.Name}\",\"{d.Label}\""));
            var dialogflowEntityAsJson = devices.Select(d => new
            {
                Value = d.Name,
                Synonyms = new List<string> { d.Name, $"{((dynamic)d.Metadata?["dialogflow"])?.config.room} {d.Label}" }
            });

            return preferCsv ? Ok(dialogflowEntityAsCsv) : Ok(dialogflowEntityAsJson);
        }
    }
}