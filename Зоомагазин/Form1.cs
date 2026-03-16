using Зоомагазин.Database;

namespace Зоомагазин
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Connection.TestConnection();
        }
    }
}
