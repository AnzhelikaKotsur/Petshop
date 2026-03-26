using PetShopApp.Database;
using PetShopApp.Properties;
using PetShopApp.ProductWindow;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PetShopApp.MainForms
{
    public sealed class AdminMainForm : Form
    {
        private readonly Button _addButton;
        private readonly Button _editButton;
        private readonly Button _deleteButton;
        private readonly Button _categoriesButton;
        private readonly Button _exitButton;
        private readonly Label _userLabel;
        private readonly TextBox _searchBox;
        private readonly DataGridView _grid;
        private readonly string _searchPlaceholder;

        public AdminMainForm()
        {
            Text = Resources.ResourceManager.GetString("AdminMain_Title") ?? string.Empty;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1600, 1200);
            BackColor = AppColors.MainGradientTop;
            _searchPlaceholder = Resources.ResourceManager.GetString("AdminMain_SearchPlaceholder") ?? string.Empty;

            _addButton = BuildTopButton(Resources.ResourceManager.GetString("AdminMain_Add") ?? string.Empty, 24, 34, 180);
            _editButton = BuildTopButton(Resources.ResourceManager.GetString("AdminMain_Edit") ?? string.Empty, 204, 34, 270);
            _deleteButton = BuildTopButton(Resources.ResourceManager.GetString("AdminMain_Delete") ?? string.Empty, 474, 34, 180);

            _userLabel = new Label
            {
                Text = Resources.ResourceManager.GetString("AdminMain_UserCaption") ?? string.Empty,
                Location = new Point(654, 34),
                Size = new Size(745, 82),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = AppColors.Text,
                BackColor = AppColors.HeaderCell,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Century", 18F, FontStyle.Regular, GraphicsUnit.Point, 204)
            };

            _exitButton = BuildTopButton(Resources.ResourceManager.GetString("AdminMain_Exit") ?? string.Empty, 1399, 34, 177);
            _categoriesButton = BuildTopButton(Resources.ResourceManager.GetString("AdminMain_CategoryList") ?? string.Empty, 1157, 116, 419);
            _categoriesButton.Height = 102;

            _searchBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Font = new Font("Century", 21F, FontStyle.Regular, GraphicsUnit.Point, 204),
                ForeColor = Color.White,
                BackColor = AppColors.AdminSearchFill,
                Location = new Point(44, 149),
                Width = 566,
                Text = _searchPlaceholder
            };
            _searchBox.Enter += (s, e) =>
            {
                if (_searchBox.Text == _searchPlaceholder)
                    _searchBox.Text = string.Empty;
            };
            _searchBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(_searchBox.Text))
                    _searchBox.Text = _searchPlaceholder;
            };
            _searchBox.TextChanged += (s, e) => ReloadProducts();

            _grid = new DataGridView
            {
                Location = new Point(24, 218),
                Size = new Size(1552, 958),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                BackgroundColor = AppColors.AdminTableBackground,
                BorderStyle = BorderStyle.FixedSingle,
                GridColor = AppColors.AdminTableLine,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 90,
                RowTemplate = { Height = 130 },
                CellBorderStyle = DataGridViewCellBorderStyle.Single,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            };
            _grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = AppColors.AdminTableBackground,
                ForeColor = AppColors.Text,
                Font = new Font("Century", 21F, FontStyle.Regular, GraphicsUnit.Point, 204),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            _grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = AppColors.AdminTableBackground,
                ForeColor = AppColors.Text,
                Font = new Font("Century", 18F, FontStyle.Regular, GraphicsUnit.Point, 204),
                SelectionBackColor = AppColors.GridSelection,
                SelectionForeColor = AppColors.Text
            };
            _grid.Columns.Add("Article", Resources.ResourceManager.GetString("AdminMain_Col_Article") ?? string.Empty);
            _grid.Columns.Add("Name", Resources.ResourceManager.GetString("AdminMain_Col_Name") ?? string.Empty);
            _grid.Columns.Add("Category", Resources.ResourceManager.GetString("AdminMain_Col_Category") ?? string.Empty);
            _grid.Columns.Add("Unit", Resources.ResourceManager.GetString("AdminMain_Col_Unit") ?? string.Empty);
            _grid.Columns.Add("Price", Resources.ResourceManager.GetString("AdminMain_Col_Price") ?? string.Empty);
            _grid.Columns.Add("Stock", Resources.ResourceManager.GetString("AdminMain_Col_Stock") ?? string.Empty);
            _grid.Columns[0].Width = 200;
            _grid.Columns[1].Width = 270;
            _grid.Columns[2].Width = 320;
            _grid.Columns[3].Width = 350;
            _grid.Columns[4].Width = 215;
            _grid.Columns[5].Width = 197;

            _addButton.Click += (s, e) =>
            {
                using (var form = new AddProduct())
                    form.ShowDialog(this);
                ReloadProducts();
            };
            _editButton.Click += (s, e) =>
            {
                using (var form = new EditProduct())
                    form.ShowDialog(this);
                ReloadProducts();
            };
            _deleteButton.Click += (s, e) =>
            {
                using (var form = new global::PetShopApp.DeleteProduct())
                    form.ShowDialog(this);
                ReloadProducts();
            };
            _categoriesButton.Click += (s, e) => new CategoryWindow.CategoryList().ShowDialog(this);
            _exitButton.Click += (s, e) => Close();

            Controls.Add(_searchBox);
            Controls.Add(_addButton);
            Controls.Add(_editButton);
            Controls.Add(_deleteButton);
            Controls.Add(_userLabel);
            Controls.Add(_exitButton);
            Controls.Add(_categoriesButton);
            Controls.Add(_grid);

            ReloadProducts();
        }

        private void ReloadProducts()
        {
            var search = NormalizeSearch(_searchBox.Text);
            using (var db = new PetShopContext())
            {
                var query = db.Products.AsQueryable();

                if (!string.IsNullOrEmpty(search))
                    query = query.Where(p => p.Name.ToLower().Contains(search.ToLower()));

                var products = query.OrderBy(p => p.Name).ToList();

                _grid.Rows.Clear();
                var rowCount = 0;
                foreach (var p in products)
                {
                    _grid.Rows.Add(
                        p.Article ?? string.Empty,
                        p.Name ?? string.Empty,
                        p.CategoryName ?? string.Empty,
                        p.Unit ?? string.Empty,
                        p.Price?.ToString() ?? string.Empty,
                        p.Stock.ToString()
                    );
                    rowCount++;
                }

                while (rowCount < 7)
                {
                    _grid.Rows.Add(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    rowCount++;
                }
            }
        }

        private string NormalizeSearch(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text == _searchPlaceholder)
                return null;
            return text.Trim();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var brush = new LinearGradientBrush(
                ClientRectangle,
                AppColors.MainGradientTop,
                AppColors.MainGradientBottom,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            using (var topBrush = new SolidBrush(AppColors.AdminOverlayPanel))
            {
                e.Graphics.FillRectangle(topBrush, new Rectangle(24, 34, 1552, 184));
            }
        }

        private static Button BuildTopButton(string text, int x, int y, int width)
        {
            return new Button
            {
                Text = text,
                Size = new Size(width, 82),
                Location = new Point(x, y),
                FlatStyle = FlatStyle.Flat,
                BackColor = AppColors.HeaderCell,
                FlatAppearance = { BorderColor = AppColors.HeaderBorder, BorderSize = 1 },
                ForeColor = Color.White,
                Font = new Font("Century", 18F, FontStyle.Regular, GraphicsUnit.Point, 204),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoEllipsis = false
            };
        }
    }
}
