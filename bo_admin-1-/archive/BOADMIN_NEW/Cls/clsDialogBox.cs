using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm;
using Nevron.UI;


namespace BOADMIN_NEW.Cls
{
    class clsDialogBox
    {

        public static DialogResult ShowMessageBox(string msg,string Title)
        {
            NTaskDialog mydialog = new NTaskDialog();
            
            mydialog.Palette.Scheme = ColorScheme.LunaBlue;
            mydialog.Title = Title;
            mydialog.Content.Text = msg;
            mydialog.Content.Image = NSystemImages.Question;
            NPushButtonElement Yes = new NPushButtonElement();
            Yes.Text = "<b>Yes</b>";
            Yes.Id = 1;
            NPushButtonElement No = new NPushButtonElement();
            No.Text = "<b>No</b>";
            No.Id = 2;

            mydialog.UserButtons = new NPushButtonElement[] { Yes, No };

            int result = mydialog.Show();

            switch (result)
            {
                case 1:
                    return DialogResult.Yes;
                case 2:
                    return DialogResult.No;
                case 3:
                    return DialogResult.Cancel;
                default:
                    return DialogResult.Cancel;

            }
        }

        public static DialogResult ShowExitMessageBox(string msg, string Title)
        {
            NTaskDialog mydialog = new NTaskDialog();

            mydialog.Palette.Scheme = ColorScheme.LunaBlue;
            mydialog.Title = Title;
            mydialog.Content.Text = msg;
            mydialog.Content.Image = NSystemImages.Question;
            NPushButtonElement Yes = new NPushButtonElement();
            Yes.Text = "<b>Yes</b>";
            Yes.Id = 1;
            NPushButtonElement No = new NPushButtonElement();
            No.Text = "<b>No</b>";
            No.Id = 2;
            NPushButtonElement Cancel = new NPushButtonElement();
            Cancel.Text = "<b>Cancel</b>";
            Cancel.Id = 3;

            mydialog.UserButtons = new NPushButtonElement[] { Yes, No, Cancel };

            int result = mydialog.Show();

            switch (result)
            {
                case 1:
                    return DialogResult.Yes;
                case 2:
                    return DialogResult.No;
                case 3:
                    return DialogResult.Cancel;
                default:
                    return DialogResult.Cancel;

            }
        }

        public static DialogResult ShowErrorBox(string msg,string Title,bool showErrorIcon)
        {
            NTaskDialog mydialog = new NTaskDialog();
            mydialog.DisplayPosition = TaskDialogDisplayPosition.CenterScreen;
            mydialog.Palette.Scheme = ColorScheme.LunaBlue;
            mydialog.Title = Title;
            mydialog.Content.Text = msg;
            if(showErrorIcon==true)
            mydialog.Content.Image = NSystemImages.Error;
            NPushButtonElement Ok = new NPushButtonElement();
            Ok.Text = "<b>Ok</b>";

            mydialog.UserButtons = new NPushButtonElement[] { Ok };

            int result = mydialog.Show();

            switch (result)
            {
                case 1:
                    return DialogResult.OK;
                default:
                    return DialogResult.OK;
            }
        }

    }
}
