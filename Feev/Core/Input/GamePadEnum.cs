using Microsoft.Xna.Framework.Input;
using System;

using MonoGamePadType = Microsoft.Xna.Framework.Input.GamePadType;

namespace Feev.Input
{
    public enum Player
    {
        One = 0,
        Two = 1,
        Three = 2,
        Four = 3
    }

    /// <summary>
    /// Defines the buttons on gamepad.
    /// Uses xbox controller names but can be used for other controller.
    /// </summary>
    [Flags]
    public enum GamePadButtons
    {
        /// <summary>
        /// Directional pad up.
        /// </summary>
        DPadUp = Buttons.DPadUp,

        /// <summary>
        /// Directional pad down.
        /// </summary>
        DPadDown = Buttons.DPadDown,

        /// <summary>
        /// Directional pad left.
        /// </summary>
        DPadLeft = Buttons.DPadLeft,

        /// <summary>
        /// Directional pad right.
        /// </summary>
        DPadRight = Buttons.DPadRight,

        /// <summary>
        /// START button.
        /// </summary>
        Start = Buttons.Start,

        /// <summary>
        /// BACK button.
        /// </summary>
        Back = Buttons.Back,

        /// <summary>
        /// Left stick button (pressing the left stick).
        /// </summary>
        LeftStick = Buttons.LeftStick,

        /// <summary>
        /// Right stick button (pressing the right stick).
        /// </summary>
        RightStick = Buttons.RightStick,

        /// <summary>
        /// Left bumper (shoulder) button.
        /// </summary>
        LeftShoulder = Buttons.LeftShoulder,

        /// <summary>
        /// Right bumper (shoulder) button.
        /// </summary>
        RightShoulder = Buttons.RightShoulder,

        /// <summary>
        /// Big button.
        /// </summary>    
        BigButton = Buttons.BigButton,

        /// <summary>
        /// A button.
        /// </summary>
        A = Buttons.A,

        /// <summary>
        /// B button.
        /// </summary>
        B = Buttons.B,

        /// <summary>
        /// X button.
        /// </summary>
        X = Buttons.X,

        /// <summary>
        /// Y button.
        /// </summary>
        Y = Buttons.Y,

        /// <summary>
        /// Left stick is towards the left.
        /// </summary>
        LeftThumbstickLeft = Buttons.LeftThumbstickLeft,

        /// <summary>
        /// Right trigger.
        /// </summary>
        RightTrigger = Buttons.RightTrigger,

        /// <summary>
        /// Left trigger.
        /// </summary>
        LeftTrigger = Buttons.LeftTrigger,

        /// <summary>
        /// Right stick is towards up.
        /// </summary>   
        RightThumbstickUp = Buttons.RightThumbstickUp,

        /// <summary>
        /// Right stick is towards down.
        /// </summary>   
        RightThumbstickDown = Buttons.RightThumbstickDown,

        /// <summary>
        /// Right stick is towards the right.
        /// </summary>
        RightThumbstickRight = Buttons.RightThumbstickRight,

        /// <summary>
        /// Right stick is towards the left.
        /// </summary>
        RightThumbstickLeft = Buttons.RightThumbstickLeft,

        /// <summary>
        /// Left stick is towards up.
        /// </summary>  
        LeftThumbstickUp = Buttons.LeftThumbstickUp,

        /// <summary>
        /// Left stick is towards down.
        /// </summary>  
        LeftThumbstickDown = Buttons.LeftThumbstickDown,

        /// <summary>
        /// Left stick is towards the right.
        /// </summary>
        LeftThumbstickRight = Buttons.LeftThumbstickRight
    }

    /// <summary>
    /// Defines a type of gamepad.
    /// </summary>
    public enum GamePadType
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = MonoGamePadType.Unknown,

        /// <summary>
        /// GamePad is the XBOX controller.
        /// </summary>
        GamePad = MonoGamePadType.GamePad,

        /// <summary>
        /// GamePad is a wheel.
        /// </summary>
        Wheel = MonoGamePadType.Wheel,

        /// <summary>
        /// GamePad is an arcade stick.
        /// </summary>
        ArcadeStick = MonoGamePadType.ArcadeStick,

        /// <summary>
        /// GamePad is a flight stick.
        /// </summary>
        FlightStick = MonoGamePadType.FlightStick,

        /// <summary>
        /// GamePad is a dance pad.
        /// </summary>
        DancePad = MonoGamePadType.DancePad,

        /// <summary>
        /// GamePad is a guitar.
        /// </summary>
        Guitar = MonoGamePadType.Guitar,

        /// <summary>
        /// GamePad is an alternate guitar.
        /// </summary>
        AlternateGuitar = MonoGamePadType.AlternateGuitar,

        /// <summary>
        /// GamePad is a drum kit.
        /// </summary>
        DrumKit = MonoGamePadType.DrumKit,

        /// <summary>
        /// GamePad is a big button pad.
        /// </summary>
        BigButtonPad = MonoGamePadType.BigButtonPad
    }
}