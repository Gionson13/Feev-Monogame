#nullable enable
using Microsoft.Xna.Framework;

namespace Feev.Utils.Xml
{
    struct XmlAnimationResult
    {
        public string Name;
        public string Filename;
        public float FrameDuration;
        public Rectangle[]? Frames;
        public int? NumberOfFrames;

        public XmlAnimationResult(string name, string filename, float frameDuration, Rectangle[] frames)
        {
            Name = name;
            Filename = filename;
            FrameDuration = frameDuration;
            Frames = frames;
            NumberOfFrames = null;
        }

        public XmlAnimationResult(string name, string filename, float frameDuration, int numberOfFrames)
        {
            Name = name;
            Filename = filename;
            FrameDuration = frameDuration;
            NumberOfFrames = numberOfFrames;
            Frames = null;
        }
    }
}
