using PetShopApp.Database;
using PetShopApp.Properties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PetShopApp.ProductWindow
{
    public partial class ShipmentGeneration : Form
    {
        private readonly ComboBox _productBox;
        private readonly TextBox _qtyBox;
        private readonly TextBox _toBox;
        private readonly DataGridView _grid;
        private readonly List<ShipmentItem> _items = new List<ShipmentItem>();
        private readonly string _qtyPlaceholder;
        private readonly string _toPlaceholder;
        private readonly string _productPlaceholder;
        private readonly Font _inputFont = new Font("Century", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);

        public ShipmentGeneration()
        {
            InitializeComponent();
            Controls.Clear();

            Text = Resources.ResourceManager.GetString("ShipmentGeneration_Title") ?? string.Empty;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1600, 1200);
            DoubleBuffered = true;

            _productPlaceholder = Resources.ResourceManager.GetString("ShipmentGeneration_ProductPlaceholder") ?? string.Empty;
            _qtyPlaceholder = Resources.ResourceManager.GetString("ShipmentGeneration_QtyPlaceholder") ?? string.Empty;
            _toPlaceholder = Resources.ResourceManager.GetString("ShipmentGeneration_ToPlaceholder") ?? string.Empty;

            var title = new Label
            {
                Text = Resources.ResourceManager.GetString("ShipmentGeneration_Title") ?? string.Empty,
                ForeColor = AppColors.Text,
                BackColor = Color.Transparent,
                Font = new Font("Century", 52F, FontStyle.Regular, GraphicsUnit.Point, 204),
                AutoSize = false,
                Location = new Point(20, 64),
                Size = new Size(760, 130)
            };

            _productBox = new ComboBox
            {
                Location = new Point(181, 243),
                Size = new Size(429, 52),
                Font = _inputFont,
                ForeColor = AppColors.Text,
                BackColor = AppColors.InputBackground,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                DrawMode = DrawMode.OwnerDrawFixed,
                ItemHeight = 46
            };
            _productBox.DrawItem += ProductBox_DrawItem;

            _qtyBox = BuildInput(_qtyPlaceholder, new Point(181, 373), 429);
            _toBox = BuildInput(_toPlaceholder, new Point(181, 503), 429);

            var addButton = BuildButton(Resources.ResourceManager.GetString("ShipmentGeneration_AddToList") ?? string.Empty, new Point(196, 675), new Size(390, 74), 64);
            addButton.Click += (s, e) => AddToList();

            var cancelButton = BuildButton(Resources.ResourceManager.GetString("ShipmentGeneration_Cancel") ?? string.Empty, new Point(20, 1030), new Size(221, 74), 45);
            cancelButton.Click += (s, e) => Close();

            var confirmButton = BuildButton(Resources.ResourceManager.GetString("ShipmentGeneration_Confirm") ?? string.Empty, new Point(356, 1030), new Size(429, 74), 45);
            confirmButton.Click += (s, e) => ConfirmShipment();

            _grid = new DataGridView
            {
                Location = new Point(803, 20),
                Size = new Size(773, 1156),
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
                RowTemplate = { Height = 118 },
                CellBorderStyle = DataGridViewCellBorderStyle.Single,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            };
            _grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = AppColors.AdminTableBackground,
                ForeColor = AppColors.Text,
                Font = new Font("Century", 24F, FontStyle.Regular, GraphicsUnit.Point, 204),
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
            _grid.Columns.Add("Article", Resources.ResourceManager.GetString("ShipmentGeneration_Col_Article") ?? string.Empty);
            _grid.Columns.Add("Name", Resources.ResourceManager.GetString("ShipmentGeneration_Col_Name") ?? string.Empty);
            _grid.Columns.Add("To", Resources.ResourceManager.GetString("ShipmentGeneration_Col_To") ?? string.Empty);
            _grid.Columns[0].Width = 210;
            _grid.Columns[1].Width = 380;
            _grid.Columns[2].Width = 181;

            Controls.Add(title);
            Controls.Add(_productBox);
            Controls.Add(_qtyBox);
            Controls.Add(_toBox);
            Controls.Add(addButton);
            Controls.Add(cancelButton);
            Controls.Add(confirmButton);
            Controls.Add(_grid);

            SetupPlaceholderBehavior(_qtyBox, _qtyPlaceholder);
            SetupPlaceholderBehavior(_toBox, _toPlaceholder);
            RoundControl(_productBox, 48);
            RoundControl(_qtyBox, 48);
            RoundControl(_toBox, 48);
            LoadProducts();
            RebindGrid();
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
        }

        private void LoadProducts()
        {
            _productBox.Items.Clear();
            _productBox.Items.Add(_productPlaceholder);

            using (var db = new PetShopContext())
            {
                var products = db.Products
                    .OrderBy(p => p.Name)
                    .Select(p => new { p.Article, p.Name })
                    .ToList();

                foreach (var p in products)
                {
                    _productBox.Items.Add(new ProductOption
                    {
                        Article = p.Article ?? string.Empty,
                        Name = p.Name ?? string.Empty
                    });
                }
            }

            _productBox.SelectedIndex = 0;
        }

        private void AddToList()
        {
            if (!(_productBox.SelectedItem is ProductOption option))
            {
                MessageBox.Show(Resources.ResourceManager.GetString("ShipmentGeneration_Message_SelectProduct") ?? string.Empty);
                return;
            }

            if (!int.TryParse(_qtyBox.Text.Trim(), out var qty) || qty <= 0)
            {
                MessageBox.Show(Resources.ResourceManager.GetString("ShipmentGeneration_Message_InvalidQty") ?? string.Empty);
                return;
            }

            var to = NormalizeText(_toBox.Text, _toPlaceholder);
            if (string.IsNullOrWhiteSpace(to))
            {
                MessageBox.Show(Resources.ResourceManager.GetString("ShipmentGeneration_Message_FillTo") ?? string.Empty);
                return;
            }

            _items.Add(new ShipmentItem
            {
                Article = option.Article,
                Name = option.Name,
                Quantity = qty,
                To = to
            });

            RebindGrid();
            _qtyBox.Text = _qtyPlaceholder;
            _toBox.Text = _toPlaceholder;
            _productBox.SelectedIndex = 0;
        }

        private void ConfirmShipment()
        {
            if (_items.Count == 0)
            {
                MessageBox.Show(Resources.ResourceManager.GetString("ShipmentGeneration_Message_NoItems") ?? string.Empty);
                return;
            }

            using (var db = new PetShopContext())
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in _items)
                    {
                        var product = db.Products.FirstOrDefault(p => p.Article == item.Article);
                        var stock = product != null ? product.Stock : 0;

                        if (stock < item.Quantity)
                            throw new InvalidOperationException(Resources.ResourceManager.GetString("ShipmentGeneration_Message_NotEnoughStock") ?? string.Empty);

                        product.Stock -= item.Quantity;
                    }

                    db.SaveChanges();
                    tx.Commit();
                    _items.Clear();
                    RebindGrid();
                    MessageBox.Show(Resources.ResourceManager.GetString("ShipmentGeneration_Message_Done") ?? string.Empty);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RebindGrid()
        {
            _grid.Rows.Clear();
            foreach (var i in _items)
                _grid.Rows.Add(i.Article, i.Name, i.To);

            while (_grid.Rows.Count < 9)
                _grid.Rows.Add(string.Empty, string.Empty, string.Empty);
        }

        private static string NormalizeText(string value, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            var t = value.Trim();
            return t == placeholder ? string.Empty : t;
        }

        private static TextBox BuildInput(string placeholder, Point point, int width)
        {
            return new TextBox
            {
                BorderStyle = BorderStyle.None,
                Font = new Font("Century", 20F, FontStyle.Regular, GraphicsUnit.Point, 204),
                ForeColor = AppColors.Text,
                BackColor = AppColors.InputBackground,
                Location = point,
                Width = width,
                Text = placeholder
            };
        }

        private static Button BuildButton(string text, Point location, Size size, int radius)
        {
            var btn = new Button
            {
                Text = text,
                Location = location,
                Size = size,
                FlatStyle = FlatStyle.Flat,
                BackColor = AppColors.InputBackground,
                ForeColor = AppColors.Text,
                Font = new Font("Century", 21F, FontStyle.Regular, GraphicsUnit.Point, 204)
            };
            btn.FlatAppearance.BorderSize = 0;
            using (var path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                btn.Region = new Region(path);
            }
            return btn;
        }

        private static void SetupPlaceholderBehavior(TextBox box, string placeholder)
        {
            box.Enter += (s, e) =>
            {
                if (box.Text == placeholder)
                {
                    box.Text = string.Empty;
                    box.ForeColor = AppColors.Text;
                }
            };
            box.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    box.Text = placeholder;
                    box.ForeColor = AppColors.Text;
                }
            };
        }

        private static void RoundControl(Control c, int radius)
        {
            using (var path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(c.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(c.Width - radius, c.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, c.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                c.Region = new Region(path);
            }
        }

        private void ProductBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index < 0) return;

            var text = _productBox.Items[e.Index]?.ToString() ?? string.Empty;
            using (var brush = new SolidBrush(AppColors.Text))
            {
                var rect = new Rectangle(e.Bounds.X + 8, e.Bounds.Y + 8, e.Bounds.Width - 16, e.Bounds.Height - 16);
                e.Graphics.DrawString(text, _inputFont, brush, rect);
            }
            e.DrawFocusRectangle();
        }

        private sealed class ProductOption
        {
            public string Article { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private sealed class ShipmentItem
        {
            public string Article { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public string To { get; set; }
        }
    }
}
