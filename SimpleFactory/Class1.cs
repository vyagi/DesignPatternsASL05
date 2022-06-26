using System.Diagnostics;

namespace SimpleFactory
{
    public class AnimalFactory
    {
        public Animal Create<T>() where T : Animal, new () => new T();
    }

    //public class AnimalFactory
    //{
    //    public Animal Create(string type)
    //    {
    //        var actualType = Type.GetType($"SimpleFactory.{type}");
    //        return (Animal)Activator.CreateInstance(actualType);
    //    }
    //}

            //public class AnimalFactory
            //{
            //    public Animal Create(string type) =>
            //        type.ToUpperInvariant() switch
            //        {
            //            "FISH" => new Fish(),
            //            "COW" => new Cow(),
            //            "DOG" => new Dog(),
            //            "CAT" => new Cat(),
            //            _ => throw new ArgumentOutOfRangeException()
            //        };
            //}


    public abstract class Animal
    {
        public abstract string MakeSound();
    }

    public class Fish : Animal
    {
        public override string MakeSound() => "";
    }

    public class Cow : Animal
    {
        public override string MakeSound() => "Muu";
    }

    public class Dog : Animal
    {
        public override string MakeSound() => "Hau hau";
    }

    public class Cat : Animal
    {
        public override string MakeSound() => "Miał";
    }

    public class Bird : Animal
    {
        public override string MakeSound() => "Ćwir ćwir";
    }
}