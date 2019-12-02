using System;
using System.Windows.Forms;

namespace CommonLibrary.UserControls
{
    public partial class UctlHotKeyTextBox : TextBox
    {
        #region Delegates

        public delegate void del_OnNewHotKey(UctlHotKeyTextBox sender, string key);

        #endregion

        public bool IsCreated;
        private string _prevTextValue = string.Empty;
        private string _shortCut = UctlHotKeysSettings.NONE_HOTEKEY;

        public UctlHotKeyTextBox()
        {
            CtrlText = string.Empty;

            InitializeComponent();
            Text = _shortCut;
            ReadOnly = true;
            LoadEvents();
        }

        public string PrevTextValue
        {
            get { return _prevTextValue; }
            set { _prevTextValue = value; }
        }


        public string CtrlText { get; set; }

        public string ShortCut
        {
            get { return _shortCut; }
            set
            {
                Action A = () =>
                               {
                                   Text = value;
                                   _shortCut = value;
                               };
                if (InvokeRequired)
                    BeginInvoke(A);
                else
                    A();
            }
        }

        public event del_OnNewHotKey OnNewHotKey;

        private void LoadEvents()
        {
            Enter += uctlHotKeyTextBox_Enter;
            TextChanged += uctlHotKeyTextBox_TextChanged;
            KeyPress += uctlHotKeyTextBox_KeyPress;
            KeyDown += uctlHotKeyTextBox_KeyDown;
        }

        private void uctlHotKeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var tt = (TextBox) sender;
            if (e.KeyValue == (int) Keys.Escape)
            {
                tt.Text = UctlHotKeysSettings.NONE_HOTEKEY;
                return;
            }

            string testString = "";
            if (e.Control)
                testString += "Ctrl+";
            if (e.Shift)
                testString += "Shift+";
            if (e.Alt)
                testString += "Alt+";

            if (testString == "")
            {
                if (e.KeyValue >= 48 && e.KeyValue <= 57)
                {
                    tt.Text = "";
                    return;
                }
                else if (e.KeyValue >= 65 && e.KeyValue <= 90)
                {
                    tt.Text = "";
                    return;
                }
                else if (e.KeyValue >= 112 && e.KeyValue <= 123)
                {
                    tt.Text = "";
                }
            }
            if (e.KeyValue >= 48 && e.KeyValue <= 57)
            {
                string strn = e.KeyCode.ToString();
                strn = strn.Substring(1, 1);
                tt.Text = testString + strn;
            }
            else if (e.KeyValue >= 65 && e.KeyValue <= 90)
            {
                tt.Text = testString + ((Keys) e.KeyValue).ToString();
            }
            else if (e.KeyValue >= 112 && e.KeyValue <= 126)
            {
                tt.Text = testString + ((Keys) e.KeyValue).ToString();
            }
        }

        private void uctlHotKeyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        private void uctlHotKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            var tt = (TextBox) sender;

            if (tt.Text == PrevTextValue)
            {
                return;
            }
            if (CtrlText == PrevTextValue)
            {
                CtrlText = tt.Text;
            }
            if (CtrlText == UctlHotKeysSettings.NONE_HOTEKEY)
            {
                {
                }
            }

            if (tt.Text.Trim() == "")
            {
                tt.Text = PrevTextValue;
                return;
            }
            //if (clsHotKeyManager.INSTANCE.MasterHotKeyHashTable.ContainsValue(tt.Text))
            //{
            //    tt.Text = clsHotKeyManager.INSTANCE.PrevTextValue;
            //    MessageBox.Show("Same key");
            //    return;
            //}
            //clsHotKeyManager.INSTANCE.MasterHotKeyHashTable[tt.Name] = tt.Text;


            if (IsCreated)
                OnNewHotKey(this, tt.Text);
        }

        private void uctlHotKeyTextBox_Enter(object sender, EventArgs e)
        {
            var tt = (TextBox) sender;
            PrevTextValue = tt.Text;
            CtrlText = PrevTextValue;
        }
    }
}