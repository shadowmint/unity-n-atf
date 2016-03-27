#if N_ATF_TESTS
using System.Collections.Generic;
using NUnit.Framework;
using N.ATF;
using N.ATF.Internal;

public interface ITestFilter : IFilter {}
public interface ITestFilter2 : IFilter {}

public class TestFilterHigh : FilterTemplate, ITestFilter
{
    public ITestBinding Test { get; set; }
    public override int Priority { get { return 1; } }
    public override string Description { get { return "Test High Filter"; } }
    public override bool IsValid<T>(T target)
    {
        FilterTests.filtered.Add("High");
        if (Test == null) { throw new System.Exception("Invalid bind"); }
        if (Is<T, FilterTests>())
        { return true; }
        return false;
    }
}

public class TestFilterLow : FilterTemplate, ITestFilter, ITestFilter2
{
    public ITestBinding Test { get; set; }
    public override int Priority { get { return 0; } }
    public override string Description { get { return "Test Low Filter"; } }
    public override bool IsValid<T>(T target)
    {
        FilterTests.filtered.Add("Low");
        if (Test == null) { throw new System.Exception("Invalid bind"); }
        return true;
    }
}

public class TestFilterLow2 : FilterTemplate, ITestFilter, ITestFilter2
{
    public ITestBinding Test { get; set; }
    public override int Priority { get { return 0; } }
    public override string Description { get { return "Test Low 2 Filter"; } }
    public override bool IsValid<T>(T target)
    {
        FilterTests.filtered.Add("Low2");
        if (Test == null) { throw new System.Exception("Invalid bind"); }
        return false;
    }
}

public class FilterTests : N.Tests.Test
{
    public static List<string> filtered = new List<string>();

    public class TestBinding : ITestBinding {}

    private class TestFixture
    {
        public IFilterService Filters { get; set; }
    }

    private void setupRegistry()
    {
        Service.Registry.Reset();
        Service.Registry.Register<IFilterService, DefaultFilterService>();
        Service.Registry.Register<ITestBinding, TestBinding>();
        Service.Registry.Register<IDebugService, ConsoleDebug>();
    }

    [Test]
    public void test_create_service()
    {
        setupRegistry();
        var instance = Service.Registry.CreateInstance<TestFixture>();
        Assert(instance.Filters != null);
        Assert(instance.Filters.HasFilter<TestFilterLow>());
        Assert(instance.Filters.HasFilter<TestFilterHigh>());
    }

    [Test]
    public void test_run_filter()
    {
        setupRegistry();
        filtered.Clear();
        var instance = Service.Registry.CreateInstance<TestFixture>();
        Assert(!instance.Filters.IsValid<ITestFilter2, FilterTests>(this));
    }

    [Test]
    public void test_run_filter_with_priority()
    {
        setupRegistry();
        filtered.Clear();
        var instance = Service.Registry.CreateInstance<TestFixture>();
        Assert(instance.Filters.IsValid<ITestFilter, FilterTests>(this));
        Assert(filtered.Count > 0);
        Assert(filtered[filtered.Count - 1] == "High");
    }
}
#endif
