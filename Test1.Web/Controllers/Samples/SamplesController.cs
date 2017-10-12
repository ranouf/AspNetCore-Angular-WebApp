using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test1.Core.Sample;
using Test1.Core.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Test1.Web.Controllers.Samples.Dto;
using AutoMapper;
using System.Net.Http;
using Test1.Web.Controllers;
using Test1.Core.Runtime.Session;
using System.Linq;
using Test1.Web.Common.Dto;
using Test1.Web.Common.Extensions;

namespace Test1.Controllers.Samples
{
  [Route("api/v1/[controller]")]
  public class SamplesController : BaseController
  {
    private SampleManager _sampleManager;

    public SamplesController(
      [FromServices]IAppSession session,
      SampleManager sampleManager
    ) : base()
    {
      _sampleManager = sampleManager;
    }

    // GET
    [HttpGet]
    [ProducesResponseType(typeof(MySampleDto), 200)]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetSampleById([FromRoute]Guid id)
    {
      if (!(ModelState.IsValid))
      {
        return BadRequest(ModelState);
      }

      var result = await _sampleManager.GetSampleByIdAsync(id);
      return new ObjectResult(Mapper.Map<MySample, MySampleDto>(result));
    }

    // GET
    [HttpGet]
    [ProducesResponseType(typeof(PagedResultDto<MySampleDto>), 200)]
    public async Task<IActionResult> GetSamples(GetSamplesRequestDto dto)
    {
      var query = _sampleManager.GetAllSamples();

      query = query.Sort(dto);

      return new ObjectResult(
        await query.ToPageResultAsync<MySample, MySampleDto>(dto)
      );
    }

    // POST
    [HttpPost]
    [ProducesResponseType(typeof(MySampleDto), 200)]
    public async Task<IActionResult> CreateSample([FromBody]MySampleDto dto)
    {
      if (!(ModelState.IsValid))
      {
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
    [ProducesResponseType(typeof(MySampleDto), 200)]
    public async Task<IActionResult> UpdateSample([FromBody]MySampleDto dto)
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

    // DEL
    [HttpDelete]
    [ProducesResponseType(typeof(object), 200)]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteSample([FromRoute]Guid id)
    {
      var mySample = await _sampleManager.GetSampleByIdAsync(id);
      if (mySample == null)
      {
        return NotFound(id);
      }

      await _sampleManager.DeleteAsync(mySample);

      return Ok();
    }
  }
}
