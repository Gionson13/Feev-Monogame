using MonoGamePadCapabilities = Microsoft.Xna.Framework.Input.GamePadCapabilities;

namespace Feev.Input
{
    public struct GamePadCapabilities
    {
        public bool HasLeftStickButton { get; }
        public bool HasRightVibrationMotor { get; }
        public bool HasLeftVibrationMotor { get; }
        public bool HasRightTrigger { get; }
        public bool HasLeftTrigger { get; }
        public bool HasRightYThumbStick { get; }
        public bool HasRightXThumbStick { get; }
        public bool HasLeftYThumbStick { get; }
        public bool HasLeftXThumbStick { get; }
        public bool HasBigButton { get; }
        public bool HasYButton { get; }
        public bool HasXButton { get; }
        public bool HasStartButton { get; }
        public bool HasRightStickButton { get; }
        public bool HasRightShoulderButton { get; }
        public bool HasVoiceSupport { get; }
        public GamePadType GamePadType { get; }
        public bool HasDPadUpButton { get; }
        public bool HasDPadRightButton { get; }
        public bool HasDPadLeftButton { get; }
        public bool HasDPadDownButton { get; }
        public bool HasBButton { get; }
        public bool HasBackButton { get; }
        public bool HasAButton { get; }
        public string Identifier { get; }
        public string DisplayName { get; }
        public bool IsConnected { get; }
        public bool HasLeftShoulderButton { get; }

        internal GamePadCapabilities(MonoGamePadCapabilities gamePadCapabilities)
        {
            HasLeftStickButton = gamePadCapabilities.HasLeftStickButton;
            HasRightVibrationMotor = gamePadCapabilities.HasRightVibrationMotor;
            HasLeftVibrationMotor = gamePadCapabilities.HasLeftVibrationMotor;
            HasRightTrigger = gamePadCapabilities.HasRightTrigger;
            HasLeftTrigger = gamePadCapabilities.HasLeftTrigger;
            HasRightYThumbStick = gamePadCapabilities.HasRightYThumbStick;
            HasRightXThumbStick = gamePadCapabilities.HasRightXThumbStick;
            HasLeftYThumbStick = gamePadCapabilities.HasLeftYThumbStick;
            HasLeftXThumbStick = gamePadCapabilities.HasLeftXThumbStick;
            HasBigButton = gamePadCapabilities.HasBigButton;
            HasYButton = gamePadCapabilities.HasYButton;
            HasXButton = gamePadCapabilities.HasXButton;
            HasStartButton = gamePadCapabilities.HasStartButton;
            HasRightStickButton = gamePadCapabilities.HasRightStickButton;
            HasRightShoulderButton = gamePadCapabilities.HasRightShoulderButton;
            HasVoiceSupport = gamePadCapabilities.HasVoiceSupport;
            GamePadType = (GamePadType)(int)gamePadCapabilities.GamePadType;
            HasDPadUpButton = gamePadCapabilities.HasDPadUpButton;
            HasDPadRightButton = gamePadCapabilities.HasDPadRightButton;
            HasDPadLeftButton = gamePadCapabilities.HasDPadLeftButton;
            HasDPadDownButton = gamePadCapabilities.HasDPadDownButton;
            HasBButton = gamePadCapabilities.HasBButton;
            HasBackButton = gamePadCapabilities.HasBackButton;
            HasAButton = gamePadCapabilities.HasAButton;
            Identifier = gamePadCapabilities.Identifier;
            DisplayName = gamePadCapabilities.DisplayName;
            IsConnected = gamePadCapabilities.IsConnected;
            HasLeftShoulderButton = gamePadCapabilities.HasLeftShoulderButton;
        }
    }
}
