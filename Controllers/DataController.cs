using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Interfaces;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private List<DataModel> Values = new List<DataModel>()
        {
            new DataModel { Id = 1, Name = "Value0", Value = 0},
            new DataModel { Id = 2, Name = "Value1", Value = 1},
        };

        public IDataRepository _dataRepo { get; set; }

        public DataController(IDataRepository dataRepo)
        {
            _dataRepo = dataRepo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<DataModel> Get()
        {
            return _dataRepo.GetAll();
        }

         public IEnumerable<DataModel> GetAllData()
        {
            return Values;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var valueData = _dataRepo.Get(id);

            return valueData.Value.ToString();
        }

        // POST api/data
        [HttpPost]
        public IActionResult Post(DataModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }

            _dataRepo.Add(model);

            //ar response = Request.

            return CreatedAtRoute("api/data", new { id = model.Id }, model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int Id, DataModel model)
        {
        
            if(model == null || model.Id != Id)
            {
                return BadRequest();        
            }

            var item = _dataRepo.Get(Id);

            if(item == null)
            {
                return NotFound();
            }

            _dataRepo.Update(model);

            return new NoContentResult();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
