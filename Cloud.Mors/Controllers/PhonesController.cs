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
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneServices _phoneServices;
        public PhoneController(IPhoneServices phoneServices)
        {
            _phoneServices = phoneServices;
        }

        [HttpGet]
        public IActionResult GetPhones()
        {
            return Ok(_phoneServices.GetPhones());
        }

        [HttpGet("{id}", Name = "GetPhone")]
        public IActionResult GetPhone(string id)
        {
            return Ok(_phoneServices.GetPhone(id));
        }

        [HttpPost]
        public IActionResult AddPhone(Phone phone)
        {
            _phoneServices.AddPhone(phone);
            return CreatedAtRoute("GetPhone", new { id = phone.Id }, phone);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePhone(string id)
        {
            _phoneServices.DeletePhone(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdatePhone(Phone phone)
        {
            return Ok(_phoneServices.UpdatePhone(phone));
        }
    }
}
