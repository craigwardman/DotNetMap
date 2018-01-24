using System;

namespace DotNetMap
{
    internal static class Converters
    {
        public static double DegToRad(double number) => number * Math.PI / 180;

        public static double RadToDeg(double number) => number / Math.PI * 180;
    }
}