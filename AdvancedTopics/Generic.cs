using System;

namespace AdvancedTopics
{
    public class GenericList<T>
    {
        public void Add(T value)
        {
            
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class GenericDictionary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {
            
        }
    }

    // Constraints on Generics
    // where T : IComparable
    // where T : Product (or any subclass)
    // where T : struct
    // where T : class
    // where T : new()
    public class Utilities
    {
        public static T Max<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }

    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public decimal CalculateDiscount(TProduct product, decimal discountPercent)
        {
            return product.Price - (product.Price * discountPercent);
        }
    }

    // public class Nullable<T> where T : struct
    // {
    //     private object _value;
    //
    //     public Nullable()
    //     {
    //         
    //     }
    //     public Nullable(T value)
    //     {
    //         _value = value;
    //     }
    //
    //     public bool HasValue
    //     {
    //         get { return _value != null; }
    //     }
    //
    //     public T GetValueOrDefault()
    //     {
    //         if (HasValue)
    //         {
    //             return (T) _value;
    //         }
    //
    //         return default(T);
    //     }
    // }
}