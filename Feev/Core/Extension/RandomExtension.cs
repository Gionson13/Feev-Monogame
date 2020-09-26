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
        /// <param name="random">Th <see cref="Random"/> instance.</param>
        /// <returns>A single-precision floating point number between 0.0f and 1.0f.</returns>
        public static float NextFloat(this Random random)
        {
            return (float)random.NextDouble();
        }
    }
}
