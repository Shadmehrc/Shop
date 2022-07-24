using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.IPhoneCrudServices;
using Core.ApiResponse;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Shop_Products.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class PhoneController : ControllerBase
    {
        private readonly IPhoneCrudService _iPhoneCrudService;

        public PhoneController(IPhoneCrudService iPhoneCrudService)
        {
            this._iPhoneCrudService = iPhoneCrudService;
        }

        [HttpPost]
        [Route("AddPhone")]
        public async Task<IActionResult> AddProductAsync([FromQuery] AddPhoneModel addPhoneModel)
        {
            var result = await _iPhoneCrudService.AddPhoneAsync(addPhoneModel);
            return result ? new ApiResponse().Success("Phone successfully added.")
                : new ApiResponse().FailedToFind("Phone already exists or some data are missed.");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ShowPhoneByIdAsync(int id)
        {
            var result = await _iPhoneCrudService.ShowPhoneAsync(id);
            return result !=null ? new ApiResponse().Success(result)
                : new ApiResponse().FailedToFind("Phone doesn't exists.");
        }


        [HttpGet]
        public async Task<IActionResult> ShowPhoneAllAsync([FromQuery] GetAllPhonesModel model)
        {
            var result = await _iPhoneCrudService.ShowPhoneAllAsync(model);
            return Ok(result);
        }

        [HttpPut]
        [Route("EditPhone")]
        public async Task<IActionResult> EditPhoneAsync([FromQuery]EditPhoneModel editPhoneModel)
        {
            var result = await _iPhoneCrudService.EditPhoneAsync(editPhoneModel);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeletePhone/{id}")]
        public async Task<IActionResult> DeletePhoneAsync(int id)
        {
            var result = await _iPhoneCrudService.DeletePhoneAsync(id);
            return Ok(result);
        }
    }
}
