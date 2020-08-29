using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Feev.DesktopGL.Input
{
    public static class FeevMouse
    {
        private static MouseState _state = new MouseState();
        private static MouseState _previousState = new MouseState();

        public static Vector2 Position
        {
            get { return _state.Position.ToVector2(); }
            set { Mouse.SetPosition((int)value.X, (int)value.Y); }
        }

        public static int ScrollWheelValue { get { return _state.ScrollWheelValue - _previousState.ScrollWheelValue; } }
        public static int TotalScrollWheelValue { get { return _state.ScrollWheelValue; } }

        /// <summary>
        /// Gets wheter a button is down or not.
        /// </summary>
        /// <param name="button">The button to check.</param>
        /// <returns><c>true</c> if the specified button is pressed.</returns>
        public static bool IsButtonDown(MouseButtons button)
        {
            return button switch
            {
                MouseButtons.Left => _state.LeftButton == ButtonState.Pressed,
                MouseButtons.Right => _state.RightButton == ButtonState.Pressed,
                MouseButtons.Middle => _state.MiddleButton == ButtonState.Pressed,
                MouseButtons.XButton1 => _state.XButton1 == ButtonState.Pressed,
                MouseButtons.XButton2 => _state.XButton2 == ButtonState.Pressed,
                _ => false,
            };
        }

        /// <summary>
        /// Gets wheter a button is up or not.
        /// </summary>
        /// <param name="button">The button to check.</param>
        /// <returns><c>true</c> if the specified button is not pressed.</returns>
        public static bool IsButtonUp(MouseButtons button)
        {
            return button switch
            {
                MouseButtons.Left => _state.LeftButton == ButtonState.Released,
                MouseButtons.Right => _state.RightButton == ButtonState.Released,
                MouseButtons.Middle => _state.MiddleButton == ButtonState.Released,
                MouseButtons.XButton1 => _state.XButton1 == ButtonState.Released,
                MouseButtons.XButton2 => _state.XButton2 == ButtonState.Released,
                _ => false,
            };
        }

        /// <summary>
        /// Gets wheter a button has just been pressed or not.
        /// </summary>
        /// <param name="button">The button to check.</param>
        /// <returns><c>true</c> if the specified button has just been pressed.</returns>
        public static bool IsButtonJustPressed(MouseButtons button)
        {
            return button switch
            {
                MouseButtons.Left => _state.LeftButton == ButtonState.Pressed && _previousState.LeftButton != ButtonState.Pressed,
                MouseButtons.Right => _state.RightButton == ButtonState.Pressed && _previousState.RightButton != ButtonState.Pressed,
                MouseButtons.Middle => _state.MiddleButton == ButtonState.Pressed && _previousState.MiddleButton != ButtonState.Pressed,
                MouseButtons.XButton1 => _state.XButton1 == ButtonState.Pressed && _previousState.XButton1 != ButtonState.Pressed,
                MouseButtons.XButton2 => _state.XButton2 == ButtonState.Pressed && _previousState.XButton2 != ButtonState.Pressed,
                _ => false,
            };
        }

        /// <summary>
        /// Gets wheter a button has just been released or not.
        /// </summary>
        /// <param name="button">The button to check.</param>
        /// <returns><c>true</c> if the specified button has just been released.</returns>
        public static bool IsButtonJustReleased(MouseButtons button)
        {
            return button switch
            {
                MouseButtons.Left => _state.LeftButton == ButtonState.Released && _previousState.LeftButton != ButtonState.Released,
                MouseButtons.Right => _state.RightButton == ButtonState.Released && _previousState.RightButton != ButtonState.Released,
                MouseButtons.Middle => _state.MiddleButton == ButtonState.Released && _previousState.MiddleButton != ButtonState.Released,
                MouseButtons.XButton1 => _state.XButton1 == ButtonState.Released && _previousState.XButton1 != ButtonState.Released,
                MouseButtons.XButton2 => _state.XButton2 == ButtonState.Released && _previousState.XButton2 != ButtonState.Released,
                _ => false,
            };
        }

        internal static void Update()
        {
            _previousState = _state;
            _state = Mouse.GetState();
        }
    }
}
