namespace Singleton;

public class Singleton
{
    public DateTime CreatedAt { get; }

    private Singleton() => CreatedAt = DateTime.Now;

    private static readonly Lazy<Singleton> Lazy = new(() => new Singleton());

    public static Singleton GetInstance() => Lazy.Value;
}

// public class Singleton
// {
//     private static volatile Singleton _instance = new();
//
//     public DateTime CreatedAt { get; }
//
//     private Singleton() => CreatedAt = DateTime.Now;
//
//     public static Singleton GetInstance() => _instance;
// }

// public class Singleton
// {
//     private static readonly object PadLock = new();
//
//     private static volatile Singleton _instance;
//
//     public DateTime CreatedAt { get; }
//
//     private Singleton() => CreatedAt = DateTime.Now;
//
//     public static Singleton GetInstance()
//     {
//         if (_instance != null) return _instance;
//         
//         lock (PadLock)
//         {
//             if (_instance == null)
//                 _instance = new Singleton();
//         }
//
//         return _instance;
//     }
// }

// public class Singleton
// {
//     private static object padLock = new object();
//
//     private static Singleton _instance;
//
//     public DateTime CreatedAt { get; }
//
//     private Singleton() => CreatedAt = DateTime.Now;
//
//     public static Singleton GetInstance()
//     {
//         lock (padLock)
//         {
//             if (_instance == null)
//                 _instance = new Singleton();
//         }
//
//         return _instance;
//     }
// }

// public class Singleton
// {
//     private static Singleton _instance;
//
//     public DateTime CreatedAt { get; }
//
//     private Singleton() => CreatedAt = DateTime.Now;
//
//     public static Singleton GetInstance()
//     {
//         if (_instance == null)
//             _instance = new Singleton();
//
//         return _instance;
//     }
// }