using PetShopApp.Frontend;
using PetShopApp.Properties;
using System.Windows.Forms;

namespace PetShopApp.ErrorWindow
{
    public partial class ProductError : BaseForm2
    {
        protected override string TitleText => Resources.ResourceManager.GetString("ProductError_Title") ?? string.Empty;
        protected override string SubtitleText => Resources.ResourceManager.GetString("ProductError_Subtitle") ?? string.Empty;
        protected override string ExitText => Resources.ResourceManager.GetString("ProductError_Exit") ?? string.Empty;

        // Эти методы остаются только чтобы компиляция проходила
        // (на них подписан .Designer.cs), но реальная отрисовка делается в BaseForm2.
        private void card_Paint(object sender, PaintEventArgs e) { }
        private void btnExit_Click(object sender, System.EventArgs e) { }
    }
}