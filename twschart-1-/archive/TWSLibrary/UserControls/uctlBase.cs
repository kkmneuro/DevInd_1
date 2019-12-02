using System.Windows.Forms;

namespace CommonLibrary.UserControls
{
    public partial class UctlBase : UserControl
    {
        public UctlBase()
        {
            InitializeComponent();
        }

        public virtual string Title { get; set; }

        public virtual void SetLocalization()
        {
        }
    }
}