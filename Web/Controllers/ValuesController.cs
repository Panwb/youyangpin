using System.Collections.Generic;
using System.Web.Http;
using Infrastructure.Repository;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IDatabaseFactory _databaseFactory;
        //

        public ValuesController(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            //_logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
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
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
