using FluentAssertions;
using SimpleFactory;

namespace SimpleFactoryTest
{
    public class SimpleFactoryTetsts
    {
        [Fact]
        public void Test1()
        {
            var factory = new AnimalFactory();

            factory.Create<Dog>().Should().BeOfType<Dog>();
            factory.Create<Cat>().Should().BeOfType<Cat>();
            factory.Create<Cow>().Should().BeOfType<Cow>();
            factory.Create<Fish>().Should().BeOfType<Fish>();
            factory.Create< Bird>().Should().BeOfType<Bird>();
        }
        //[Fact]
        //public void Test1()
        //{
        //    var factory = new AnimalFactory();

        //    factory.Create("Dog").Should().BeOfType<Dog>();
        //    factory.Create("Cat").Should().BeOfType<Cat>();
        //    factory.Create("Cow").Should().BeOfType<Cow>();
        //    factory.Create("Fish").Should().BeOfType<Fish>();
        //    factory.Create("Bird").Should().BeOfType<Bird>();
        //}
    }
}