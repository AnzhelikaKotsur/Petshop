using PetShopApp.Frontend;
using PetShopApp.Properties;
using System.Windows.Forms;

namespace PetShopApp.ErrorWindow
{
    public partial class UnableDeleteCategory : BaseForm2
    {
        protected override string TitleText => Resources.ResourceManager.GetString("UnableDeleteCategory_Title") ?? string.Empty;
        protected override string SubtitleText => Resources.ResourceManager.GetString("UnableDeleteCategory_Subtitle") ?? string.Empty;
        protected override string ExitText => Resources.ResourceManager.GetString("UnableDeleteCategory_Exit") ?? string.Empty;

        private void card_Paint(object sender, PaintEventArgs e) { }
        private void btnExit_Click(object sender, System.EventArgs e) { }
    }
}
