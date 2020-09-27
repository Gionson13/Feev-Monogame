using Microsoft.Xna.Framework;
using System;

namespace Feev.Extension
{
    public static class RandomExtension
    {
        /// <summary>
        /// Make a random value in a range.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <param name="min">The minimum value (Included).</param>
        /// <param name="max">The maximum value (Included).</param>
        /// <returns>A random number between the two given floats.</returns>
        public static float Range(this Random random, float min, float max)
        {
            return random.NextFloat() * (max - min) + min;
        }

        /// <summary>
        /// Make a random float between 0.0f and 1.0f.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <returns>A single-precision floating point number between 0.0f and 1.0f.</returns>
        public static float NextFloat(this Random random)
        {
            return (float)random.NextDouble();
        }

        /// <summary>
        /// Make a random color.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <returns>A random color.</returns>
        public static Color NextColor(this Random random)
        {
            float r = random.NextFloat();
            float g = random.NextFloat();
            float b = random.NextFloat();
            float a = random.NextFloat();

            return new Color(r, g, b, a);
        }

        /// <summary>
        /// Make a random color between two colors.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <param name="minColor">The minimum color.</param>
        /// <param name="maxColor">The maximum color.</param>
        /// <returns>A random color between two colors.</returns>
        public static Color NextColor(this Random random, Color minColor, Color maxColor)
        {
            int r = random.Next(minColor.R, maxColor.R);
            int g = random.Next(minColor.G, maxColor.G);
            int b = random.Next(minColor.B, maxColor.B);
            int a = random.Next(minColor.A, maxColor.A);

            return new Color(r, g, b, a);
        }
    }
}
