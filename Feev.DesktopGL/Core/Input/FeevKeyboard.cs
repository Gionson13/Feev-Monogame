using Microsoft.Xna.Framework.Input;

namespace Feev.DesktopGL.Input
{
    public static class FeevKeyboard
    {
        private static KeyboardState _state = new KeyboardState();
        private static KeyboardState _previousState = new KeyboardState();

        /// <summary>
        /// Gets wheter a key is up or not.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><c>true</c> if the specified key is not pressed.</returns>
        public static bool IsKeyUp(Keys key)
        {
            return _state.IsKeyUp(key);
        }

        /// <summary>
        /// Gets wheter a key is down or not.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><c>true</c> if the specified key is pressed.</returns>
        public static bool IsKeyDown(Keys key)
        {
            return _state.IsKeyDown(key);
        }

        /// <summary>
        /// Gets wheter a key has just been pressed or not.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><c>true</c> if the specified key has just been pressed.</returns>
        public static bool IsKeyJustPressed(Keys key)
        {
            return _state.IsKeyDown(key) && !_previousState.IsKeyDown(key);
        }

        /// <summary>
        /// Gets wheter a key has just been released or not.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><c>true</c> if the specified key has just been released.</returns>
        public static bool IsKeyJustReleased(Keys key)
        {
            return _state.IsKeyUp(key) && !_previousState.IsKeyUp(key);
        }

        internal static void Update()
        {
            _previousState = _state;
            _state = Keyboard.GetState();
        }
    }
}
