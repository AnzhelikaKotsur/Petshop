using PetShopApp.Frontend;
using PetShopApp.Properties;
using System.Windows.Forms;

namespace PetShopApp.CategoryWindow
{
    public partial class DeleteCategory : BaseForm3
    {
        protected override string TitleText => Resources.ResourceManager.GetString("DeleteCategory_Title") ?? string.Empty;
        protected override string ActionText => Resources.ResourceManager.GetString("DeleteCategory_Action") ?? string.Empty;
        protected override string[] InputPlaceholders =>
            new[] { Resources.ResourceManager.GetString("DeleteCategory_Input1") ?? string.Empty };

        protected override void OnActionClicked()
        {
            var values = GetInputValues();
            var name = values.Length > 0 ? values[0] : string.Empty;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите/выберите категорию.");
                return;
            }

            Database.CategoryRepository.DeleteByName(name);
            Close();
        }
    }
}
