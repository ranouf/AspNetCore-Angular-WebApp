using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test1.Core.Sample;
using Test1.Core.Sample.Entities;
using Microsoft.EntityFrameworkCore;

namespace Test1.Controllers
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
    [ProducesResponseType(typeof(MySample), 200)]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetSampleById([FromRoute]Guid id)
    {
      return new ObjectResult(await _sampleManager.GetByIdAsync(id));
    }

    // GET
    [HttpGet]
    [ProducesResponseType(typeof(List<MySample>), 200)]
    public async Task<IActionResult> GetSamples()
    {
      var result = await _sampleManager.GetAllSamples().ToListAsync();
      return new ObjectResult(result);
    }
  }
}
