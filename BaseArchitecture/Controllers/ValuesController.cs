﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseArchitecture.Repository.Database;
using Microsoft.AspNetCore.Mvc;

namespace BaseArchitecture.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IDatabaseFactory _databaseFactory;

        public ValuesController(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var conn = _databaseFactory.GetConnection();
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
