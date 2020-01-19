using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Openhab.Client.Api;
using Openhab.Client.Client;
using Openhab.Client.Model;
using Openhab.Proxy.Api.Configuration;

namespace Openhab.Proxy.Api.Controllers
{
    [ApiController]
    [AuthorizeWithToken]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase, ITokenController
    {
        private readonly IItemsApi _itemsApi;
        public string Token { get; set; }
        public string Group { get; set; }

        public ItemsController(IItemsApi itemsApi)
        {
            _itemsApi = itemsApi;
        }

        /// <summary>
        /// Get all available items.
        /// </summary>
        /// <remarks></remarks>
        /// <response code="202">Accepted</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal server error</response>
        /// <param name="type">item type filter</param>
        /// <param name="tags">item tag filter (comma separated)</param>
        /// <param name="metadata">	metadata selector (comma separated)</param>
        /// <param name="fields">limit output to the given fields (comma separated)</param>
        /// <param name="recursive">get member items recursively</param>
        [ProducesResponseType(typeof(IEnumerable<EnrichedItemDTO>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<IActionResult> Get(string type, string tags, string metadata, string fields, bool recursive = false)
        {
            var items = await _itemsApi.GetItemsAsync(type: type,
                tags: tags != null ? string.Join(",", Token, tags) : Token,
                metadata: metadata != null ? string.Join(",", "dialogflow", metadata) : "dialogflow",
                fields: fields,
                recursive: recursive);
            return Ok(items);
        }

        /// <summary>
        /// Gets a single item.
        /// </summary>
        /// <remarks></remarks>
        /// <response code="202">Accepted</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal server error</response>
        /// <param name="name">item name</param>
        /// <param name="metadata">	metadata selector (comma separated)</param>
        [ProducesResponseType(typeof(EnrichedItemDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetItemData(string name, string metadata)
        {
            var item = await _itemsApi.GetItemDataAsync(name, metadata: metadata != null ? string.Join(",", "dialogflow", metadata) : "dialogflow");
            return Ok(item);
        }

        /// <summary>
        /// Gets the state of an item.
        /// </summary>
        /// <remarks></remarks>
        /// <response code="202">Accepted</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal server error</response>
        /// <param name="name">item name</param>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet]
        [Route("{name}/state")]
        public async Task<IActionResult> GetItemState(string name)
        {
            var state = await _itemsApi.GetPlainItemStateAsync(name);
            return Ok(state);
        }

        /// <summary>
        /// Updates the state of an item.
        /// </summary>
        /// <remarks></remarks>
        /// <response code="202">Accepted</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal server error</response>
        /// <param name="name">item name</param>
        /// <param name="state">valid item state (e.g. ON, OFF, 0, 55)</param>
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPut]
        [Route("{name}/state")]
        public async Task<IActionResult> UpdateItemState(string name, [FromBody] string state)
        {
            var result = await _itemsApi.PutItemStateAsyncWithHttpInfo(name, state);
            return new StatusCodeResult(result.StatusCode);
        }

        /// <summary>
        /// Sends a command to an item
        /// </summary>
        /// <remarks></remarks>
        /// <response code="202">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal server error</response>
        /// <param name="name">item name</param>
        /// <param name="command">valid item command (e.g. ON, OFF, UP, DOWN, REFRESH)</param>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        [Route("{name}/state")]
        public async Task<IActionResult> SendCommand(string name, [FromBody] string command)
        {
            var result = await _itemsApi.PostItemCommandAsyncWithHttpInfo(name, command);
            return new StatusCodeResult(result.StatusCode);
        }

    }
}
