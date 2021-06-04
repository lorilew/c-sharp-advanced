# C# Advanced Topics

Notes from Udemy course C# Advanced Topics by Mosh Hamedani.

## Lesson 1 - Generics
Generics allow for code reusabililty and efficiency.

example:
```c#
    ...
    public class GenericDictionary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {
            ...
        }
    }
    ...
    var bookDict = new GenericDictionary<string, int>();
    bookDict.Add(book.ISBN, 1);
    ...
```

You can add constraints on generics:
```c#
    // where T : IComparable (interface)
    // where T : Product (class or subclass)
    // where T : struct (eg. int...)
    // where T : class
    // where T : new() (constructor type)
```

example code can be found in `Generic.cs`.


