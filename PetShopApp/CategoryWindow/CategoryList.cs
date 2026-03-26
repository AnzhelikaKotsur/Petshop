using PetShopApp.Database;
using PetShopApp.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PetShopApp.CategoryWindow
{
    public sealed class CategoryList : Form
    {
        private readonly TextBox _searchBox;
        private readonly DataGridView _grid;
        private readonly Panel _editorCard;
        private readonly TextBox _editNameBox;
        private readonly Button _newCategoryButton;
        private readonly Button _backButton;
        private readonly Button _saveButton;
        private readonly Button _deleteButton;
        private readonly Button _cancelButton;
        private readonly string _searchPlaceholder;
        private readonly string _namePlaceholder;

        private int? _selectedId;

        public CategoryList()
        {
            Text = Resources.ResourceManager.GetString("CategoryList_Title") ?? string.Empty;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            ClientSize = new Size(1600, 1200);
            AutoScaleMode = AutoScaleMode.None;
            DoubleBuffered = true;
            _searchPlaceholder = Resources.ResourceManager.GetString("CategoryList_SearchPlaceholder") ?? string.Empty;
            _namePlaceholder = Resources.ResourceManager.GetString("CategoryList_NamePlaceholder") ?? string.Empty;

            var title = new Label
            {
                Text = Resources.ResourceManager.GetString("CategoryList_Title") ?? string.Empty,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new Font("Century", 58F, FontStyle.Regular, GraphicsUnit.Point, 204),
                AutoSize = true,
                Location = new Point(48, 52)
            };

            _searchBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Font = new Font("Century", 21F, FontStyle.Regular, GraphicsUnit.Point, 204),
                ForeColor = AppColors.Text,
                BackColor = AppColors.InputBackground,
                Location = new Point(49, 177),
                Width = 538,
                Text = _searchPlaceholder
            };
            _searchBox.TextChanged += (s, e) => ReloadGrid();
            _searchBox.Enter += (s, e) =>
            {
                if (_searchBox.Text == _searchPlaceholder) _searchBox.Text = string.Empty;
            };
            _searchBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(_searchBox.Text)) _searchBox.Text = _searchPlaceholder;
            };

            _newCategoryButton = BuildTopButton(Resources.ResourceManager.GetString("CategoryList_NewCategory") ?? string.Empty, new Point(648, 70));
            _newCategoryButton.Click += (s, e) =>
            {
                using (var form = new AddCategory())
                    form.ShowDialog(this);
                ReloadGrid();
                _grid.ClearSelection();
            };

            _backButton = BuildTopButton(Resources.ResourceManager.GetString("CategoryList_Back") ?? string.Empty, new Point(1111, 70));
            _backButton.Click += (s, e) => Close();

            _grid = new DataGridView
            {
                Location = new Point(35, 258),
                Size = new Size(541, 887),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoGenerateColumns = false,
                BackgroundColor = AppColors.GridBackground,
                BorderStyle = BorderStyle.FixedSingle,
                GridColor = AppColors.GridLine,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 76,
                RowTemplate = { Height = 111 },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = AppColors.GridBackground,
                    ForeColor = AppColors.Text,
                    Font = new Font("Century", 39F, FontStyle.Regular, GraphicsUnit.Point, 204),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = AppColors.GridBackground,
                    ForeColor = AppColors.Text,
                    Font = new Font("Century", 26F, FontStyle.Regular, GraphicsUnit.Point, 204),
                    SelectionBackColor = AppColors.GridSelection,
                    SelectionForeColor = AppColors.Text,
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                }
            };
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = Resources.ResourceManager.GetString("CategoryList_Grid_Id") ?? string.Empty, Width = 97 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = Resources.ResourceManager.GetString("CategoryList_Grid_Name") ?? string.Empty, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            _grid.SelectionChanged += Grid_SelectionChanged;

            _editorCard = new Panel
            {
                Location = new Point(804, 258),
                Size = new Size(651, 468),
                BackColor = AppColors.CategoryEditorBackground
            };
            _editorCard.Paint += (s, e) =>
            {
                using (var pen = new Pen(AppColors.CategoryEditorBorder, 2))
                    e.Graphics.DrawRectangle(pen, 1, 1, _editorCard.Width - 2, _editorCard.Height - 2);
            };

            var editTitle = new Label
            {
                Text = Resources.ResourceManager.GetString("CategoryList_EditTitle") ?? string.Empty,
                ForeColor = AppColors.Text,
                BackColor = Color.Transparent,
                Font = new Font("Century", 50F, FontStyle.Regular, GraphicsUnit.Point, 204),
                AutoSize = true,
                Location = new Point(29, 23)
            };

            _editNameBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Font = new Font("Century", 21F, FontStyle.Regular, GraphicsUnit.Point, 204),
                ForeColor = AppColors.Text,
                BackColor = AppColors.InputBackground,
                Location = new Point(32, 124),
                Width = 462,
                Text = _namePlaceholder
            };
            _editNameBox.Enter += (s, e) =>
            {
                if (_editNameBox.Text == _namePlaceholder) _editNameBox.Text = string.Empty;
            };
            _editNameBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(_editNameBox.Text)) _editNameBox.Text = _namePlaceholder;
            };

            _saveButton = BuildActionButton(Resources.ResourceManager.GetString("CategoryList_Save") ?? string.Empty, new Point(31, 299));
            _saveButton.Click += SaveClicked;

            _deleteButton = BuildActionButton(Resources.ResourceManager.GetString("CategoryList_Delete") ?? string.Empty, new Point(232, 299));
            _deleteButton.Click += (s, e) =>
            {
                using (var form = new DeleteCategory())
                    form.ShowDialog(this);
                ReloadGrid();
                _grid.ClearSelection();
            };

            _cancelButton = BuildActionButton(Resources.ResourceManager.GetString("CategoryList_Cancel") ?? string.Empty, new Point(433, 299));
            _cancelButton.Click += (s, e) =>
            {
                _selectedId = null;
                _editNameBox.Text = _namePlaceholder;
                _grid.ClearSelection();
            };

            _editorCard.Controls.Add(editTitle);
            _editorCard.Controls.Add(_editNameBox);
            _editorCard.Controls.Add(_saveButton);
            _editorCard.Controls.Add(_deleteButton);
            _editorCard.Controls.Add(_cancelButton);

            Controls.Add(title);
            Controls.Add(_searchBox);
            Controls.Add(_newCategoryButton);
            Controls.Add(_backButton);
            Controls.Add(_grid);
            Controls.Add(_editorCard);

            ReloadGrid();
            _grid.ClearSelection();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var brush = new LinearGradientBrush(
                ClientRectangle,
                AppColors.CategoryGradientTop,
                AppColors.CategoryGradientBottom,
                90f))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        private void ReloadGrid()
        {
            var search = NormalizeSearch(_searchBox.Text);
            var rows = CategoryRepository.GetAll(search);
            _grid.DataSource = rows;
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (_grid.CurrentRow?.DataBoundItem is CategoryRepository.CategoryRow row)
            {
                _selectedId = row.Id;
                _editNameBox.Text = row.Name;
            }
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageBox.Show(Resources.ResourceManager.GetString("CategoryList_Message_SelectCategory") ?? string.Empty);
                return;
            }

            var name = NormalizeName(_editNameBox.Text);
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(Resources.ResourceManager.GetString("CategoryList_Message_EnterName") ?? string.Empty);
                return;
            }

            CategoryRepository.UpdateName(_selectedId.Value, name);
            ReloadGrid();
        }

        private static Button BuildTopButton(string text, Point location)
        {
            return new Button
            {
                Text = text,
                Location = location,
                Size = new Size(330, 56),
                FlatStyle = FlatStyle.Flat,
                BackColor = AppColors.MainButtonBackground,
                ForeColor = Color.White,
                Font = new Font("Century", 21F, FontStyle.Regular, GraphicsUnit.Point, 204)
            };
        }

        private static Button BuildActionButton(string text, Point location)
        {
            return new Button
            {
                Text = text,
                Location = location,
                Size = new Size(196, 54),
                FlatStyle = FlatStyle.Flat,
                BackColor = AppColors.MainButtonBackground,
                ForeColor = Color.White,
                Font = new Font("Century", 21F, FontStyle.Regular, GraphicsUnit.Point, 204)
            };
        }

        private static string NormalizeSearch(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text == Resources.ResourceManager.GetString("CategoryList_SearchPlaceholder"))
                return null;
            return text.Trim();
        }

        private static string NormalizeName(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text == Resources.ResourceManager.GetString("CategoryList_NamePlaceholder"))
                return string.Empty;
            return text.Trim();
        }
    }
}
