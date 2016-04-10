#if N_ATF_TESTS
using NUnit.Framework;
using N.Package.ATF;

public class ServiceTests : N.Tests.Test
{
    private class ServiceTestFixture
    {
        public IDebugService Debug { get; set; }
        public IEventService Events { get; set; }
        public IFilterService Filters { get; set; }
        public ITriggerService Triggers { get; set; }
    }

    [Test]
    public void test_current_services()
    {
        Service.Rebuild();
        var instance = Service.Registry.CreateInstance<ServiceTestFixture>();
        Assert(instance.Debug != null);
        Assert(instance.Events != null);
        Assert(instance.Filters != null);
        Assert(instance.Triggers != null);
    }
}
#endif
