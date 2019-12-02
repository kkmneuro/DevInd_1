using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;

namespace PALSA.Cls
{
    public class WinApi
    {
        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private const int SWP_SHOWWINDOW = 64; // 0x0040
        private static readonly IntPtr HWND_TOP = IntPtr.Zero;

        public static int ScreenX
        {
            get { return GetSystemMetrics(SM_CXSCREEN); }
        }

        public static int ScreenY
        {
            get { return GetSystemMetrics(SM_CYSCREEN); }
        }

        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int which);

        [DllImport("user32.dll")]
        public static extern void
            SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter,
                         int X, int Y, int width, int height, uint flags);

        public static void SetWinFullScreen(IntPtr hwnd, int captionH, int bottomBorder, int lborder, int fborder)
        {
            SetWindowPos(hwnd, HWND_TOP, -3, 1, ScreenX + captionH + bottomBorder, ScreenY + lborder + fborder,
                         SWP_SHOWWINDOW);
        }
    }

    /// <summary>
    /// Class used to preserve / restore state of the form
    /// </summary>
    public class FormState
    {
        private int bottomBorder;
        private Rectangle bounds;
        private FormBorderStyle brdStyle;
        private int captionH;
        private int leftBorder;
        private int rightBorder;
        private bool topMost;
        private FormWindowState winState;

        //private bool IsMaximized = false;

        public void Maximize(NForm targetForm)
        {
            //IsMaximized = true;
            Save(targetForm);
            targetForm.WindowState = FormWindowState.Maximized;
            targetForm.FormBorderStyle = FormBorderStyle.None;
            targetForm.CurrentFrameAppearance.CaptionHeight = 0;
            targetForm.CurrentFrameAppearance.LeftBorder = 0;
            targetForm.CurrentFrameAppearance.RightBorder = 0;
            targetForm.CurrentFrameAppearance.BottomBorder = 0;
            targetForm.Sizable = false;
            targetForm.TopMost = true;
            WinApi.SetWinFullScreen(targetForm.Handle, captionH, bottomBorder, leftBorder, rightBorder);
        }

        public void Save(NForm targetForm)
        {
            captionH = targetForm.CurrentFrameAppearance.CaptionHeight;
            leftBorder = targetForm.CurrentFrameAppearance.LeftBorder;
            rightBorder = targetForm.CurrentFrameAppearance.RightBorder;
            bottomBorder = targetForm.CurrentFrameAppearance.BottomBorder;
            winState = targetForm.WindowState;
            brdStyle = targetForm.FormBorderStyle;
            topMost = targetForm.TopMost;
            bounds = targetForm.Bounds;
        }

        public void Restore(NForm targetForm)
        {
            targetForm.CurrentFrameAppearance.CaptionHeight = captionH;
            targetForm.CurrentFrameAppearance.LeftBorder = leftBorder;
            targetForm.CurrentFrameAppearance.RightBorder = rightBorder;
            targetForm.CurrentFrameAppearance.BottomBorder = bottomBorder;
            targetForm.Sizable = true;
            targetForm.WindowState = winState;
            targetForm.FormBorderStyle = brdStyle;
            targetForm.TopMost = topMost;
            targetForm.Bounds = bounds;

            //IsMaximized = false;
        }
    }
}