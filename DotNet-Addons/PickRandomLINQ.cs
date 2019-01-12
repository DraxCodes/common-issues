// This class contains an extension method to any IEnumerable.
// This will allow you to append "PickRandom()" to any collection.

// You can place the method inside any class that is static.
// For an example here, we create a new "Extensions" class.
public static class Extensions
{
    // In order to keep this snippet modular, this class has
    // its own random. However, feel free to use any Random
    // you might already have.
    private static Random rnd = new Random();

    public static T PickRandom<T>(this IEnumerable<T> collection)
        => collection.ElementAt(rnd.Next(0,collection.Count()));
}

// =====================================
// Usage:
public class UsageDemonstration
{
    public void Foo()
    {
        var choices = new []{ "one", "two", "three" };
        var random = choices.PickRandom();
    }
}
