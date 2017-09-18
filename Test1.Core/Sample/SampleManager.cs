using System;
using System.Collections.Generic;
using System.Text;
using Test1.Core.Common.Dependencies;

namespace Test1.Core.Sample
{
	public class SampleManager : IManager
	{
		private ISampleService _sampleService;

		public SampleManager(ISampleService sampleService)
		{
			_sampleService = sampleService;
		}

		public string SayHello()
		{
			return _sampleService.SayHello();
		}
	}
}
