#if N_ATF_TESTS
using NUnit.Framework;
using N.Package.ATF;
using N.Package.Core.Tests;

public class ServiceTests : TestCase
{
  private class ServiceTestFixture
  {
    public IDebugService Debug { get; set; }
  }

  [Test]
  public void test_current_services()
  {
    Service.Rebuild();
    var instance = Service.Registry.CreateInstance<ServiceTestFixture>();
    Assert(instance.Debug != null);
  }
}
#endif