using PetShopApp.Frontend;
using PetShopApp.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace PetShopApp
{
    public partial class DeleteProduct : BaseForm3
    {
        protected override string TitleText => Resources.ResourceManager.GetString("DeleteProduct_Title") ?? string.Empty;
        protected override string ActionText => Resources.ResourceManager.GetString("DeleteProduct_Action") ?? string.Empty;
        protected override Size CardSize => new System.Drawing.Size(870, 860);
        protected override int TitleTop => 95;
        protected override int TitleHeight => 78;
        protected override int InputWidth => 430;
        protected override int InputHeight => 52;
        protected override int FirstInputY => 330;
        protected override int InputStepY => 84;
        protected override int InputTextTop => 14;
        protected override int ButtonWidth => 170;
        protected override int ButtonHeight => 64;
        protected override int ButtonsTopOffsetFromLastInput => 120;
        protected override int ButtonHorizontalMargin => 130;
        protected override string[] InputPlaceholders =>
            new[] { Resources.ResourceManager.GetString("DeleteProduct_Input1") ?? string.Empty };

        protected override void OnActionClicked()
        {
            var values = GetInputValues();
            var article = values.Length > 0 ? values[0] : string.Empty;
            if (string.IsNullOrWhiteSpace(article))
            {
                MessageBox.Show(Resources.ResourceManager.GetString("DeleteProduct_Message_FillArticle") ?? string.Empty);
                return;
            }

            Database.ProductRepository.DeleteByArticle(article);
            Close();
        }
    }
}
