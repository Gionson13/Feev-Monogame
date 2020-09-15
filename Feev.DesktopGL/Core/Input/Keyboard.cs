using Microsoft.Xna.Framework.Input;

using MonoKeys = Microsoft.Xna.Framework.Input.Keys;
using MonoKeyboard = Microsoft.Xna.Framework.Input.Keyboard;

namespace Feev.DesktopGL.Input
{
    public static class Keyboard
    {
        private static KeyboardState _state = new KeyboardState();
        private static KeyboardState _previousState = new KeyboardState();

        public static bool CapsLock { get { return _state.CapsLock; } }
        public static bool NumLock { get { return _state.NumLock; } }

        /// <summary>
        /// Gets wheter a key is up or not.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><c>true</c> if the specified key is not pressed.</returns>
        public static bool IsKeyUp(Keys key)
        {
            return _state.IsKeyUp((MonoKeys)(int)key);
        }

        /// <summary>
        /// Gets wheter a key is down or not.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><c>true</c> if the specified key is pressed.</returns>
        public static bool IsKeyDown(Keys key)
        {
            return _state.IsKeyDown((MonoKeys)(int)key);
        }

        /// <summary>
        /// Gets wheter a key has just been pressed or not.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><c>true</c> if the specified key has just been pressed.</returns>
        public static bool IsKeyJustPressed(Keys key)
        {
            return _state.IsKeyDown((MonoKeys)(int)key) && !_previousState.IsKeyDown((MonoKeys)(int)key);
        }

        /// <summary>
        /// Gets wheter a key has just been released or not.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><c>true</c> if the specified key has just been released.</returns>
        public static bool IsKeyJustReleased(Keys key)
        {
            return _state.IsKeyUp((MonoKeys)(int)key) && !_previousState.IsKeyUp((MonoKeys)(int)key);
        }

        /// <summary>
        /// Gets all the pressed keys.
        /// </summary>
        /// <returns>An array with all the pressed keys.</returns>
        public static Keys[] GetPressedKeys()
        {
            var pressedKeys = _state.GetPressedKeys();
            Keys[] keys = new Keys[pressedKeys.Length];

            for (int i = 0; i < keys.Length; i++)
                keys[i] = (Keys)(int)pressedKeys[i];

            return keys;
        }

        internal static void Update()
        {
            _previousState = _state;
            _state = MonoKeyboard.GetState();
        }
    }
}
