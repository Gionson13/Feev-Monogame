using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Xml;

namespace Feev.DesktopGL.Utils.Xml
{
    static class XmlParser
    {
        public static XmlAnimationResult[] ParseSpriteAnimation(XmlDocument xmlDocument)
        {
            if (xmlDocument.ChildNodes.Count > 1)
                throw new XmlException("You can only have 1 animation group per file.");

            List<XmlAnimationResult> xmlAnimations = new List<XmlAnimationResult>();

            XmlNode animationGroup = xmlDocument.ChildNodes[0];
            if (animationGroup.Name == "AnimationGroup")
            {
                foreach (XmlNode animationNode in animationGroup.ChildNodes)
                {
                    if (animationNode.Name == "Animation")
                    {
                        string name = animationNode.Attributes["name"].Value;
                        if (!float.TryParse(animationNode.Attributes["frame_duration"].Value, out float frameDuration))
                            throw new XmlException("frame_duration must be of type float.");

                        List<Rectangle> rectangles = new List<Rectangle>();
                        string filename = "";
                        int numberOfFrames = 0;

                        int spriteSheetCounter = 0;
                        foreach (XmlNode frames in animationNode.ChildNodes)
                        {
                            if (frames.Name == "SpriteSheet")
                            {
                                if (spriteSheetCounter == 0)
                                    filename = frames.Attributes["filename"].Value;
                                else
                                    throw new XmlException("You can only have 1 spritesheet per animation.");

                                if (frames.Attributes.Count > 1)
                                {
                                    if (int.TryParse(frames.Attributes["number_of_frames"].Value, out numberOfFrames))
                                        break;
                                    else
                                        throw new XmlException("number_of_frames must be of type int.");
                                }
                            }
                            else if (frames.Name == "Frame")
                            {
                                if (!int.TryParse(frames.Attributes["x"].Value, out int x))
                                    throw new XmlException("x must be of type int.");
                                if (!int.TryParse(frames.Attributes["y"].Value, out int y))
                                    throw new XmlException("y must be of type int.");
                                if (!int.TryParse(frames.Attributes["width"].Value, out int w))
                                    throw new XmlException("width must be of type int.");
                                if (!int.TryParse(frames.Attributes["height"].Value, out int h))
                                    throw new XmlException("height must be of type int.");

                                rectangles.Add(new Rectangle(x, y, w, h));
                            }
                            else
                                throw new XmlException($"{frames.Name} is not a valid tag.");
                        }
                        if (string.IsNullOrWhiteSpace(filename))
                            throw new XmlException("filename must have a value.");
                        if (numberOfFrames == 0)
                            xmlAnimations.Add(new XmlAnimationResult(name, filename, frameDuration, rectangles.ToArray()));
                        else
                            xmlAnimations.Add(new XmlAnimationResult(name, filename, frameDuration, numberOfFrames));

                    }
                    else
                        throw new XmlException($"{animationNode.Name} is not a valid tag.");
                }
            }
            else
                throw new XmlException($"{animationGroup.Name} is not a valid Tag.");

            return xmlAnimations.ToArray();
        }
    }
}
