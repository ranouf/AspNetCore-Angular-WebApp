using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test1.Core.Sample;
using Test1.Core.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Test1.Web.Controllers.Sample.Dto;
using AutoMapper;

namespace Test1.Controllers.Sample
{
  [Route("api/v1/[controller]")]
  public class SampleController : Controller
  {
    private SampleManager _sampleManager;

    public SampleController(
      SampleManager sampleManager
    )
    {
      _sampleManager = sampleManager;
    }

    // GET
    [HttpGet]
    [ProducesResponseType(typeof(MySampleDto), 200)]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetSampleById([FromRoute]Guid id)
    {
      var result = await _sampleManager.GetByIdAsync(id);
      return new ObjectResult(Mapper.Map<MySample, MySampleDto>(result));
    }

    // GET
    [HttpGet]
    [ProducesResponseType(typeof(List<MySampleDto>), 200)]
    public async Task<IActionResult> GetSamples()
    {
      var result = await _sampleManager.GetAllSamples().ToListAsync();
      return new ObjectResult(Mapper.Map<List<MySample>, List<MySampleDto>>(result));
    }
  }
}
