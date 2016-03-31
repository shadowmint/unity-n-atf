#if N_ATF_TESTS
using NUnit.Framework;
using N.ATF;
using N.ATF.Internal;

public class ActionsTests : N.Tests.Test
{
    private class TestFixture
    {
        public IEventService Events { get; set; }
    }

    private interface ITestBinding {}

    private class TestBinding : ITestBinding {}

    private class TestAction : ActionTemplate
    {
        public ITestBinding Test { get; set; }
        public override string Description { get { return "Test action"; } }
        public override void Execute() { done = true; }
        public override bool Configure<T>(T c) { return false; }
        public void ForceComplete() { Complete(); }
        public bool done = false;
    }

    private void setupRegistry()
    {
        Service.Registry.Reset();
        Service.Registry.Register<IEventService, DefaultEventService>();
        Service.Registry.Register<ITestBinding, TestBinding>();
    }

    [Test]
    public void test_run_action()
    {
        setupRegistry();
        var instance = Service.Registry.CreateInstance<TestFixture>();
        var action = instance.Events.Action<TestAction>();
        Assert(action.done == true);
        Assert(action.Test != null);
    }

    [Test]
    public void test_run_action_with_callback()
    {
        setupRegistry();
        var instance = Service.Registry.CreateInstance<TestFixture>();
        var action = instance.Events.Action<TestAction>(false);
        var done = false;

        instance.Events.Actions.Execute(action, (ep) =>
        { if (ep.Is(action)) { done = true; } });
        Assert(done == false);

        action.ForceComplete();
        Assert(done == true);
    }
}
#endif
