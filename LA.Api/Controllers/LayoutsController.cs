using System.Collections.Generic;
using System.Text.Json;
using LA.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LayoutsController : ControllerBase
    {
        private readonly ILayoutService _service;

        #region CTOR

        public LayoutsController(ILayoutService layoutService)
        {
            _service = layoutService;
        }

        #endregion

        #region Actions
        // GET: api/Layout
        [HttpGet]
        public IEnumerable<LayoutViewModel> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Layout/5
        [HttpGet("{id}", Name = "Get")]
        public LayoutViewModel Get(int id)
        {
            return _service.GetDefault();
        }

        // POST: api/Layout
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Post([FromBody] JsonElement model)
        //public IActionResult Post(LayoutViewModel model)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(model);

            _service.Add(new LayoutViewModel()
            {
                Content = json
            });

            return Ok();
        }

        // PUT: api/Layout/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
    }
}
