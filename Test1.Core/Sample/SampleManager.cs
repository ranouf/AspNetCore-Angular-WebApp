using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Test1.Core.Common.Dependencies;
using MyRepository = Test1.Core.Common.Repositories;
using MyUnitOWork = Test1.Core.Common.UnitOWork;
using Test1.Core.Sample.Entities;

namespace Test1.Core.Sample
{
  public class SampleManager : IManager
  {
    private ISampleService _sampleService;
    private MyUnitOWork.IUnitOfWork _unitOfWork;
    private MyRepository.IRepository<MySample> _sampleRepository;

    public SampleManager(
      ISampleService sampleService,
      MyUnitOWork.IUnitOfWork unitOfWork)
    {
      _sampleService = sampleService;
      _unitOfWork = unitOfWork;
      _sampleRepository = _unitOfWork.GetRepository<MySample>();
    }

    public IQueryable<MySample> GetAllSamples()
    {
      return _sampleRepository.GetAll()
        .Include(s => s.Author)
        .Include(s => s.Editor);
    }

    public async Task<MySample> GetSampleByIdAsync(Guid id)
    {
      var result = await GetAllSamples().FirstOrDefaultAsync(s => s.Id == id);
      if (result == null)
      {
        throw new ArgumentException();
      }

      return result;
    }

    public async Task<MySample> CreateAsync(MySample mySample)
    {
      var result = await _sampleRepository.InsertAsync(mySample);
      await _unitOfWork.SaveChangesAsync();
      return result;
    }

    public async Task<MySample> UpdateAsync(MySample mySample)
    {
      var result = await _sampleRepository.UpdateAsync(mySample);
      await _unitOfWork.SaveChangesAsync();
      return result;
    }

    public async Task DeleteAsync(MySample mySample)
    {
      await _sampleRepository.DeleteAsync(mySample);
      await _unitOfWork.SaveChangesAsync();
    }
  }
}
