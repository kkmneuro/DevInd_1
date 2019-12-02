using System.Drawing;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using System;

namespace PALSA.Cls
{
    public class ClsPopNotify
    {
        private static ClsPopNotify _instance;
        private readonly ImageList _lstImg = new ImageList();
        internal NPopupNotify _popupNotify;

        private ClsPopNotify()
        {
            Image imgToolbar = Image.FromFile(Application.StartupPath + "\\Resx\\file-strip.png");
            _lstImg.Images.AddStrip(imgToolbar);
        }

        public static ClsPopNotify INSTANCE
        {
            get { return _instance ?? (_instance = new ClsPopNotify()); }
        }

        internal void InitPopup(string msg, string msgColor, string imgType)
        {
            _popupNotify = new NPopupNotify();
            _popupNotify.PredefinedStyle = PredefinedPopupStyle.Skinned;
            _popupNotify.Font = new Font("Tahoma", 8.0f);
            NImageAndTextItem content = _popupNotify.Content;
            content.Image = imgType == "Connected" ? _lstImg.Images[0] : _lstImg.Images[1];
            content.ImageSize = new NSize(28, 28);
            content.TextMargins = new NPadding(0, 4, 0, 0);
            content.Text = "<br><b><i><font size='10' color='" + msgColor + "'>" + msg + "</font></i></b></br>";
            NCommand comm;
            NCommandCollection coll = _popupNotify.OptionsCommands;

            for (int i = 1; i < 6; i++)
            {
                comm = new NCommand();
                comm.Properties.Text = "Options command " + i.ToString();
                coll.Add(comm);
            }
        }

        public void DisplayPopUp(string popTitle, string msg, string msgColor, string imgType)
        {
            #region "  OLD CODE "

            //InitPopup(msg, msgColor, imgType);
            //_popupNotify.Caption.Content.Text = "<b><font size='10' color='black'>" + popTitle + "</font></b>";
            //PopupAnimation animation = PopupAnimation.None;
            //animation |= PopupAnimation.Slide;
            //_popupNotify.AutoHide = true;
            //_popupNotify.Animation = animation;
            //_popupNotify.AnimationDirection = PopupAnimationDirection.BottomToTop;
            //_popupNotify.Palette.Copy(NUIManager.Palette);
            //_popupNotify.Show();

            #endregion "  OLD CODE "

            var skinPopup = new NPopupNotify();
            skinPopup.PredefinedStyle = PredefinedPopupStyle.Skinned;
            skinPopup.PreferredBounds = new Rectangle(skinPopup.PreferredBounds.Left, skinPopup.PreferredBounds.Right,
                                                      110, 50);
            skinPopup.Font = new Font("Verdana", 8.0f);
            //SkinPopup.Caption.Content.Text = "<b><font size='8' color='black'>" + popTitle + "</font></b>"; //"Connection Status";
            //SkinPopup.Caption.Content.Height = 0;
            skinPopup.Caption.Visible = false;
            NImageAndTextItem content = skinPopup.Content;
            content.Image = imgType == "Connected"
                                ? Image.FromFile(Application.StartupPath + "\\Resx\\thumb-up-20.png")
                                : Image.FromFile(Application.StartupPath + "\\Resx\\red-thumb-20.png");
            content.ImageSize = new NSize(23, 23);

            content.TextMargins = new NPadding(0, 4, 0, 0);
            content.Text = msg; //"<b><font color='" + msgColor + "'>" + msg + "</font></b>";

            PopupAnimation animation = PopupAnimation.None;
            animation |= PopupAnimation.Fade;
            animation |= PopupAnimation.Slide;

            skinPopup.AutoHide = true;
            skinPopup.VisibleSpan = 4000;
            skinPopup.Opacity = 255;
            skinPopup.Animation = animation;
            skinPopup.AnimationDirection = PopupAnimationDirection.BottomToTop;
            skinPopup.VisibleOnMouseOver = false;
            skinPopup.FullOpacityOnMouseOver = false;
            skinPopup.AnimationInterval = 20;
            skinPopup.AnimationSteps = 19;
            skinPopup.Palette.Copy(NUIManager.Palette);

            skinPopup.Show();
        }
    }
}