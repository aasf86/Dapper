﻿using System;
using System.Collections.Generic;
using System.Linq;

#if DOTNET5_2
using ApplicationException = System.InvalidOperationException;
#endif

namespace SqlMapper
{
    static class Assert
    {

        public static void IsEqualTo<T>(this T obj, T other)
        {
            if (!Equals(obj, other))
            {
                throw new ApplicationException($"{obj} should be equals to {other}");
            }
        }

        public static void IsSequenceEqualTo<T>(this IEnumerable<T> obj, IEnumerable<T> other)
        {
            if (!(obj ?? new T[0]).SequenceEqual(other ?? new T[0]))
            {
                throw new ApplicationException($"{obj} should be equals to {other}");
            }
        }

        public static void Fail()
        {
            throw new ApplicationException("Expectation failed");
        }
        public static void IsFalse(this bool b)
        {
            if (b)
            {
                throw new ApplicationException("Expected false");
            }
        }

        public static void IsTrue(this bool b)
        {
            if (!b)
            {
                throw new ApplicationException("Expected true");
            }
        }

        public static void IsNull(this object obj)
        {
            if (obj != null)
            {
                throw new ApplicationException("Expected null");
            }
        }

        public static void IsNotNull(this object obj)
        {
            if (obj == null)
            {
                throw new ApplicationException("Expected not null");
            }
        }
    }
}