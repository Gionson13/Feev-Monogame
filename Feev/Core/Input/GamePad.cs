using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MonoGamePad = Microsoft.Xna.Framework.Input.GamePad;

namespace Feev.Input
{
    public static class GamePad
    {
        private static GamePadState[] _states =
        {
            MonoGamePad.GetState(0),
            MonoGamePad.GetState(1),
            MonoGamePad.GetState(2),
            MonoGamePad.GetState(3)
        };
        private static GamePadState[] _previousStates = _states;

        /// <summary>
        /// Gets wheter the player is connected or not.
        /// </summary>
        /// <param name="playerIndex">The player to chech.</param>
        /// <returns><c>true</c> if the specified player is connected.</returns>
        public static bool IsConnected(Player playerIndex)
        {
            return _states[(int)playerIndex].IsConnected;
        }

        /// <summary>
        /// Gets wheter a button is down or not.
        /// </summary>
        /// <param name="button">The button to check.</param>
        /// <param name="playerIndex">The index of the controller.</param>
        /// <returns><c>true</c> if the specified button is pressed.</returns>
        public static bool IsButtonDown(GamePadButtons button, Player playerIndex)
        {
            return _states[(int)playerIndex].IsButtonDown((Buttons)(int)button);
        }

        /// <summary>
        /// Gets wheter a button is up or not.
        /// </summary>
        /// <param name="button">The button to check.</param>
        /// <param name="playerIndex">The index of the controller.</param>
        /// <returns><c>true</c> if the specified button is not pressed.</returns>
        public static bool IsButtonUp(GamePadButtons button, Player playerIndex)
        {
            return _states[(int)playerIndex].IsButtonUp((Buttons)(int)button);
        }

        /// <summary>
        /// Gets wheter a button has just been pressed or not.
        /// </summary>
        /// <param name="button">The button to check.</param>
        /// <param name="playerIndex">The index of the controller.</param>
        /// <returns><c>true</c> if the specified button has just been pressed.</returns>
        public static bool IsButtonJustPressed(GamePadButtons button, Player playerIndex)
        {
            return _states[(int)playerIndex].IsButtonDown((Buttons)(int)button) && !_previousStates[(int)playerIndex].IsButtonDown((Buttons)(int)button);
        }

        /// <summary>
        /// Gets wheter a button has just been released or not.
        /// </summary>
        /// <param name="button">The button to check.</param>
        /// <param name="playerIndex">The index of the controller.</param>
        /// <returns><c>true</c> if the specified button has just been released.</returns>
        public static bool IsButtonJustReleased(GamePadButtons button, Player playerIndex)
        {
            return _states[(int)playerIndex].IsButtonUp((Buttons)(int)button) && !_previousStates[(int)playerIndex].IsButtonDown((Buttons)(int)button);
        }

        /// <summary>
        /// Sets the vibration motor speeds on the controller device if supported.
        /// </summary>
        /// <param name="player">Player index that identifies the controller to set.</param>
        /// <param name="leftMotor">The speed of the left motor, between 0.0 and 1.0. This motor is a low-frequency motor.</param>
        /// <param name="rightMotor">The speed of the right motor, between 0.0 and 1.0. This motor is a high-frequency motor.</param>
        /// <returns><c>true</c> if the vibration motors were set.</returns>
        public static bool SetVibration(Player player, float leftMotor, float rightMotor)
        {
            return MonoGamePad.SetVibration((int)player, leftMotor, rightMotor);
        }

        /// <summary>
        /// Sets the vibration motor speeds on the controller device if supported.
        /// </summary>
        /// <param name="player">Player index that identifies the controller to set.</param>
        /// <param name="leftMotor">The speed of the left motor, between 0.0 and 1.0. This motor is a low-frequency motor.</param>
        /// <param name="rightMotor">The speed of the right motor, between 0.0 and 1.0. This motor is a high-frequency motor.</param>
        /// <param name="leftTrigger">(Xbox One controller only) The speed of the left trigger motor, between 0.0 and
        /// 1.0. This motor is a high-frequency motor.</param>
        /// <param name="rightTrigger">(Xbox One controller only) The speed of the right trigger motor, between 0.0
        /// and 1.0. This motor is a high-frequency motor.</param>
        /// <returns><c>true</c> if the vibration motors were set.</returns>
        public static bool SetVibration(Player player, float leftMotor, float rightMotor, float leftTrigger, float rightTrigger)
        {
            return MonoGamePad.SetVibration((int)player, leftMotor, rightMotor, leftTrigger, rightTrigger);
        }

        /// <summary>
        /// Gets the position of the left thumbstick.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>A <see cref="Vector2"/> with the coordinates of the left thumbstick.</returns>
        public static Vector2 GetLeftThumbstickPosition(Player player)
        {
            return _states[(int)player].ThumbSticks.Left;
        }

        /// <summary>
        /// Gets the position of the right thumbstick.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>A <see cref="Vector2"/> with the coordinates of the right thumbstick.</returns>
        public static Vector2 GetRightThumbstickPosition(Player player)
        {
            return _states[(int)player].ThumbSticks.Right;
        }

        /// <summary>
        /// Gets the pressed depth of the left trigger.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>A <see cref="float"/> form 0.0f to 1.0f with the pressed depth of the left trigger.</returns>
        public static float GetLeftTriggerPressedDepth(Player player)
        {
            return _states[(int)player].Triggers.Left;
        }

        /// <summary>
        /// Gets the pressed depth of the right trigger.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>A <see cref="float"/> form 0.0f to 1.0f with the pressed depth of the right trigger.</returns>
        public static float GetRightTriggerPressedDepth(Player player)
        {
            return _states[(int)player].Triggers.Right;
        }

        /// <summary>
        /// Gets the capabilities of the gamepad.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>The <see cref="GamePadCapabilities"/> of the specified controller.</returns>
        public static GamePadCapabilities GetGamePadType(Player player)
        {
            return new GamePadCapabilities(MonoGamePad.GetCapabilities((int)player));
        }

        internal static void Update()
        {
            _previousStates = _states;

            for (int i = 0; i < _states.Length; i++)
                _states[i] = MonoGamePad.GetState(i);
        }
    }
}
