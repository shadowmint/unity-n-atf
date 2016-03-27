#if N_ATF_TESTS
using System.Collections.Generic;
using NUnit.Framework;
using N.ATF;
using N.ATF.Internal;

public interface ITestTrigger : ITrigger {}

public interface ITestBinding {}

public class TestTriggerHigh : TriggerTemplate, ITestTrigger
{
    public ITestBinding Test { get; set; }
    public override int Priority { get { return 1; } }
    public override string Description { get { return "Test trigger"; } }
    public override void Execute()
    {
        TriggerTests.triggered.Add("High");
        if (Test == null) { throw new System.Exception("Invalid bind"); }
        Complete();
    }
}

public class TestTriggerLow : TriggerTemplate, ITestTrigger
{
    public ITestBinding Test { get; set; }
    public override int Priority { get { return 0; } }
    public override string Description { get { return "Test trigger"; } }
    public override void Execute()
    {
        TriggerTests.triggered.Add("Low");
        if (Test == null) { throw new System.Exception("Invalid bind"); }
        Complete();
    }
}

public class TriggerTests : N.Tests.Test
{
    public static List<string> triggered = new List<string>();

    public class TestBinding : ITestBinding {}

    private class TestFixture
    {
        public ITriggerService Triggers { get; set; }
    }

    private void setupRegistry()
    {
        Service.Registry.Reset();
        Service.Registry.Register<IEventService, DefaultEventService>();
        Service.Registry.Register<ITriggerService, DefaultTriggerService>();
        Service.Registry.Register<ITestBinding, TestBinding>();
    }

    [Test]
    public void test_create_service()
    {
        setupRegistry();
        var instance = Service.Registry.CreateInstance<TestFixture>();
        Assert(instance.Triggers != null);
        Assert(instance.Triggers.HasTrigger<TestTriggerLow>());
        Assert(instance.Triggers.HasTrigger<TestTriggerHigh>());
    }

    [Test]
    public void test_run_trigger()
    {
        setupRegistry();
        triggered.Clear();
        var instance = Service.Registry.CreateInstance<TestFixture>();
        instance.Triggers.Trigger<ITestTrigger>();
        Assert(triggered.Count == 2);
        Assert(triggered[0] == "High");
        Assert(triggered[1] == "Low");
    }
}
#endif
