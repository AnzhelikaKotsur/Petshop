using PetShopApp.Database;
using PetShopApp.ProductWindow;
using PetShopApp.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PetShopApp.MainForms
{
    public sealed class StorekeeperMainForm : Form
    {
        private readonly Button _shipmentButton;
        private readonly Button _exitButton;
        private readonly Label _userLabel;
        private readonly TextBox _searchBox;
        private readonly DataGridView _grid;
        private readonly string _searchPlaceholder;

        public StorekeeperMainForm()
        {
            Text = Resources.ResourceManager.GetString("StorekeeperMain_Title") ?? string.Empty;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1600, 1200);
            BackColor = AppColors.MainGradientTop;
            _searchPlaceholder = Resources.ResourceManager.GetString("StorekeeperMain_SearchPlaceholder") ?? string.Empty;

            _shipmentButton = BuildTopButton(Resources.ResourceManager.GetString("StorekeeperMain_Shipment") ?? string.Empty, 24, 34, 400);
            _userLabel = new Label
            {
                Text = Resources.ResourceManager.GetString("StorekeeperMain_UserCaption") ?? string.Empty,
                Location = new Point(424, 34),
                Size = new Size(975, 82),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = AppColors.Text,
                BackColor = AppColors.HeaderCell,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Century", 18F, FontStyle.Regular, GraphicsUnit.Point, 204)
            };
            _exitButton = BuildTopButton(Resources.ResourceManager.GetString("StorekeeperMain_Exit") ?? string.Empty, 1399, 34, 177);

            _searchBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Font = new Font("Century", 21F, FontStyle.Regular, GraphicsUnit.Point, 204),
                ForeColor = AppColors.Text,
                BackColor = AppColors.AdminSearchFill,
                Location = new Point(44, 149),
                Width = 566,
                Text = _searchPlaceholder
            };
            _searchBox.Enter += (s, e) =>
            {
                if (_searchBox.Text == _searchPlaceholder) _searchBox.Text = string.Empty;
            };
            _searchBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(_searchBox.Text)) _searchBox.Text = _searchPlaceholder;
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

            _shipmentButton.Click += (s, e) => new ShipmentGeneration().ShowDialog(this);
            _exitButton.Click += (s, e) => Close();

            Controls.Add(_searchBox);
            Controls.Add(_shipmentButton);
            Controls.Add(_userLabel);
            Controls.Add(_exitButton);
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
                ForeColor = AppColors.Text,
                Font = new Font("Century", 18F, FontStyle.Regular, GraphicsUnit.Point, 204),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoEllipsis = false
            };
        }
    }
}
