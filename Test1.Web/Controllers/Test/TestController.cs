using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test1.Core.Sample;
using Test1.Core.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Test1.Web.Controllers.Sample.Dto;
using AutoMapper;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Test1.Controllers.Test
{
  [Route("api/v1/[controller]")]
  public class TestController : Controller
  {
    private SampleManager _sampleManager;

    public TestController(
      SampleManager sampleManager
    )
    {
      _sampleManager = sampleManager;
    }

    // GET
    [HttpGet]
    [SwaggerOperation("GetTestById")]
    [ProducesResponseType(typeof(MySampleDto), 200)]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetTestById([FromRoute]Guid id)
    {
      var result = await _sampleManager.GetSampleByIdAsync(id);
      return new ObjectResult(Mapper.Map<MySample, MySampleDto>(result));
    }

    // GET
    [HttpGet]
    [SwaggerOperation("GetTestes")]
    [ProducesResponseType(typeof(List<MySampleDto>), 200)]
    public async Task<IActionResult> GetTests()
    {
      var result = await _sampleManager.GetAllSamples().ToListAsync();
      return new ObjectResult(Mapper.Map<List<MySample>, List<MySampleDto>>(result));
    }

    // POST
    [HttpPost]
    [SwaggerOperation("CreateTest")]
    [ProducesResponseType(typeof(List<MySampleDto>), 200)]
    public async Task<IActionResult> CreateTest([FromBody]MySampleDto dto)
    {
      if (!(ModelState.IsValid)){
        return BadRequest(ModelState);
      }

      var mySample = new MySample(
        dto.Value
      );
      var result = await _sampleManager.CreateAsync(mySample);

      return new ObjectResult(Mapper.Map<MySample, MySampleDto>(result));
    }

    // PUT
    [HttpPut]
    [SwaggerOperation("UpdateTest")]
    [ProducesResponseType(typeof(List<MySampleDto>), 200)]
    public async Task<IActionResult> UpdateTest([FromBody]MySampleDto dto)
    {
      if (!(ModelState.IsValid))
      {
        return BadRequest(ModelState);
      }
      var mySample = await _sampleManager.GetSampleByIdAsync(dto.Id);
      if (mySample == null)
      {
        return NotFound(dto.Id);
      }

      mySample.Update(
        dto.Value
      );

      var result = await _sampleManager.UpdateAsync(mySample);

      return new ObjectResult(Mapper.Map<MySample, MySampleDto>(result));
    }
  }
}
