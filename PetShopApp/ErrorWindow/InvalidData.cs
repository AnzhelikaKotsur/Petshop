using PetShopApp.Frontend;
using PetShopApp.Properties;
using System.Windows.Forms;

namespace PetShopApp.ErrorWindow
{
    public partial class InvalidData : BaseForm2
    {
        protected override string TitleText => Resources.ResourceManager.GetString("InvalidData_Title") ?? string.Empty;
        protected override string SubtitleText => Resources.ResourceManager.GetString("InvalidData_Subtitle") ?? string.Empty;
        protected override string ExitText => Resources.ResourceManager.GetString("InvalidData_Exit") ?? string.Empty;

        private void card_Paint(object sender, PaintEventArgs e) { }
        private void btnExit_Click(object sender, System.EventArgs e) { }
    }
}
