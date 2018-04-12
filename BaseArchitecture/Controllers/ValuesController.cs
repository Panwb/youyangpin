using System.Collections.Generic;
using Architecture.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IDatabaseFactory _databaseFactory;
        private readonly ILogger _logger;

        public ValuesController(IDatabaseFactory databaseFactory,
            ILogger<ValuesController> logger)
        {
            _databaseFactory = databaseFactory;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var conn = _databaseFactory.GetConnection();
            _logger.LogTrace("trace");
            _logger.LogDebug("debug");
            _logger.LogInformation("information");
            _logger.LogWarning("warning");
            _logger.LogError("error");
            _logger.LogCritical("critical");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
