using System;
using AttributeDI;

namespace TestApi.Services
{
    [InjectionComponent(ParentType = typeof(ITestService))]
    public class TestService : ITestService
    {
        public double DoStuff()
        {
            var random = new Random();
            return random.NextDouble();
        }
    }
}