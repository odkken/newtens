using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Common
{
    public static class Util
    {
        private static System.Random _rand;

        public static void Shuffle<T>(this IList<T> list, int seed)
        {
            var rng = new System.Random(seed);
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static T Pop<T>(this IList<T> theList)
        {
            var local = theList[theList.Count - 1];
            theList.RemoveAt(theList.Count - 1);
            return local;
        }

        public static void Push<T>(this IList<T> theList, T item)
        {
            theList.Add(item);
        }

        public static void Swap<T>(this IList<T> theList, int indexA, int indexB)
        {
            var tmp = theList[indexA];
            theList[indexA] = theList[indexB];
            theList[indexB] = tmp;
        }

        public static T Next<T>(this IList<T> theList, int currentIndex)
        {
            return currentIndex == theList.Count - 1 ? theList[0] : theList[currentIndex + 1];
        }

        public static float NextGaussian(float stdDev, float mean = 0)
        {
            if (_rand == null)
                _rand = new System.Random(); //reuse this if you are generating many
            double u1 = _rand.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = _rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal =
                         mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
            return (float)randNormal;
        }

        public static Vector2 CalculateBezierPoint(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
        {
            return Mathf.Pow((1 - t), 3) * p0 + 3 * Mathf.Pow((1 - t), 2) * t * p1 + 3 * (1 - t) * t * t * p2 + t * t * t * p3;
        }

    }
}
