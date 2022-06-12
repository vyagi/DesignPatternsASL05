using FluentAssertions;

namespace SingletonTests;

public class SingletonTests
{
    [Fact]
    public void Instance_can_be_created_and_date_is_correct()
    {
        var s = Singleton.Singleton.GetInstance();

        s.Should().NotBeNull();
        s.CreatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(100));
    }

    [Fact]
    public void There_should_be_only_one_instance()
    {
        var s1 = Singleton.Singleton.GetInstance();
        var s2 = Singleton.Singleton.GetInstance();

        s1.CreatedAt.Should().Be(s2.CreatedAt);
        ReferenceEquals(s1, s2).Should().BeTrue();
    }

    [Fact]
    public void There_should_be_only_one_instance_in_multithreaded_environment()
    {
        Singleton.Singleton s1 = null, s2 = null;

        Task task1 = Task.Factory.StartNew(() => s1 = Singleton.Singleton.GetInstance());
        Task task2 = Task.Factory.StartNew(() => s2 = Singleton.Singleton.GetInstance());

        Task.WaitAll(task1, task2);

        s1.CreatedAt.Should().Be(s2.CreatedAt);
        ReferenceEquals(s1, s2).Should().BeTrue();
    }
}