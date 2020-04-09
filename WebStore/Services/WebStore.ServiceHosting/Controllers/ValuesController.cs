﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly List<string> __Values = Enumerable.Range(1, 10).Select(i => $"Value {i}").ToList();

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return __Values;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            if (id >= __Values.Count)
                return NotFound();
            return __Values[id];
        }

        [HttpPost]
        public void Post(string value)
        {
            __Values.Add(value);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, string value)
        {
            if (id < 0)
                return BadRequest();
            __Values[id] = value;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest();
            if (id >= __Values.Count)
                return NotFound();
            __Values.RemoveAt(id);

            return Ok();
        }

    }
}