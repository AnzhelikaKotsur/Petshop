using System.Linq;
using PetShopApp.Frontend;
using PetShopApp.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace PetShopApp.ProductWindow
{
    public partial class AddProduct : BaseForm3
    {
        protected override string TitleText => Resources.ResourceManager.GetString("AddProduct_Title") ?? string.Empty;
        protected override string ActionText => Resources.ResourceManager.GetString("AddProduct_Action") ?? string.Empty;
        protected override Size CardSize => new System.Drawing.Size(870, 930);
        protected override int TitleTop => 95;
        protected override int TitleHeight => 78;
        protected override int InputWidth => 430;
        protected override int InputHeight => 52;
        protected override int FirstInputY => 250;
        protected override int InputStepY => 84;
        protected override int InputTextTop => 14;
        protected override int ButtonWidth => 170;
        protected override int ButtonHeight => 64;
        protected override int ButtonsTopOffsetFromLastInput => 104;
        protected override int ButtonHorizontalMargin => 130;
        protected override string[] InputPlaceholders => new[]
        {
            Resources.ResourceManager.GetString("AddProduct_Input1") ?? string.Empty,
            Resources.ResourceManager.GetString("AddProduct_Input2") ?? string.Empty,
            Resources.ResourceManager.GetString("AddProduct_Input3") ?? string.Empty,
            Resources.ResourceManager.GetString("AddProduct_Input4") ?? string.Empty,
            Resources.ResourceManager.GetString("AddProduct_Input5") ?? string.Empty
        };

        protected override void OnActionClicked()
        {
            var v = GetInputValues();
            var article = v.ElementAtOrDefault(0) ?? string.Empty;
            var name = v.ElementAtOrDefault(1) ?? string.Empty;
            var category = v.ElementAtOrDefault(2) ?? string.Empty;
            var unit = v.ElementAtOrDefault(3) ?? string.Empty;
            var priceText = v.ElementAtOrDefault(4) ?? string.Empty;

            if (string.IsNullOrWhiteSpace(article) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(Resources.ResourceManager.GetString("AddProduct_Message_FillRequired") ?? string.Empty);
                return;
            }

            decimal price = 0m;
            if (!string.IsNullOrWhiteSpace(priceText) && !decimal.TryParse(priceText.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out price))
            {
                MessageBox.Show(Resources.ResourceManager.GetString("AddProduct_Message_InvalidPrice") ?? string.Empty);
                return;
            }

            if (!string.IsNullOrWhiteSpace(category))
                Database.CategoryRepository.Add(category);

            Database.ProductRepository.Add(article, name, category, unit, price);
            Close();
        }
    }
}
