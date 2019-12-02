using System.Drawing;
using System.Xml.Serialization;

namespace CommonLibrary.Cls
{
    public class ClsCustomizeSettings : XmlSerializer
    {
        public ClsCustomizeSettings()
        {
        }

        public ClsCustomizeSettings(string name, int position, string fontName, float fontSize, string headerText,
                                    Color backColor, Color foreColor, FontStyle fontStyle)
        {
            Name = name;
            Position = position;
            FontName = fontName;
            FontSize = fontSize;
            HeaderText = headerText;
            BackColor = backColor;
            ForeColor = foreColor;
            FontStyle = fontStyle;
        }

        public string Name { get; set; }

        public int Position { get; set; }

        public string FontName { get; set; }

        public float FontSize { get; set; }

        public string HeaderText { get; set; }

        public Color BackColor { get; set; }

        public Color ForeColor { get; set; }

        public FontStyle FontStyle { get; set; }
    }
}