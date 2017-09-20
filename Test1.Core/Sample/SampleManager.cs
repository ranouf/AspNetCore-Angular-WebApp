using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.Core.Common.Dependencies;
using Test1.Core.Common.Repositories;
using Test1.Core.Common.UnitOWork;
using Test1.Core.Sample.Entities;

namespace Test1.Core.Sample
{
  public class SampleManager : IManager
  {
    private ISampleService _sampleService;
    private IUnitOfWork _unitOfWork;
    private IRepository<MySample> _sampleRepository;

    public SampleManager(
      ISampleService sampleService,
      IUnitOfWork unitOfWork)
    {
      _sampleService = sampleService;
      _unitOfWork = unitOfWork;
      _sampleRepository = _unitOfWork.GetRepository<MySample>();
    }

    public async Task<MySample> GetByIdAsync(Guid id)
    {
      var result = await _sampleRepository.FirstOrDefaultAsync(s => s.Id == id);
      if (result == null)
      {
        throw new ArgumentException();
      }

      return result;
    }

    public IQueryable<MySample> GetAllSamples()
    {
      return _sampleRepository.GetAll();
    }
  }
}
