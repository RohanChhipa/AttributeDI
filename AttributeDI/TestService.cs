using Lib;

namespace AttributeDI
{
    [InjectionComponent(ParentType = typeof(ITestService))]
    public class TestService : ITestService
    {
        public string DoStuff()
        {
            return "Mlem";
        }
    }
}