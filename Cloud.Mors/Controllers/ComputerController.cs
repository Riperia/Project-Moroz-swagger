using Cloud.Moroz.Models;
using Cloud.Moroz.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.Mors.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputerController : Controller
    {
        private readonly IComputerService _computerServices;
        public ComputerController(IComputerService computerService)
        {
            _computerServices = computerService;
        }

        [HttpGet]
        public IActionResult GetComputers()
        {
            return Ok(_computerServices.GetComputers());
        }

        [HttpGet("{id}", Name = "GetComputer")]
        public IActionResult GetComputer(string id)
        {
            return Ok(_computerServices.GetComputer(id));
        }

        [HttpPost]
        public IActionResult AddComputer(Computer computer)
        {
            _computerServices.AddComputer(computer);
            return CreatedAtRoute("GetComputer", new { id = computer.Id }, computer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComputer(string id)
        {
            _computerServices.DeleteComputer(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateComputer(Computer computer)
        {
            return Ok(_computerServices.UpdateComputer(computer));
        }
    }
}
