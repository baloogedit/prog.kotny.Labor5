using Labor_5.Data;
using Labor_5.Models; // Make sure to import your Models
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity; // Use the EF6 namespace
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic; // For the InputBox (Req 3 & 4)

namespace Labor_5
{
    public partial class Form1 : Form
    {
        private readonly StoreContext _context;

        // Used to remember the last search term for refreshing
        private string _currentSearchTerm = null;

        public Form1()
        {
            InitializeComponent();
            _context = new StoreContext();

            // We change the constructor to NOT load products.
            // We do this in Form1_Load, which can be async.
        }

        // REQ 6: LoadProducts is now async
        private async Task LoadProducts(string searchTerm = null)
        {
            try
            {
                // Keep track of the search term
                _currentSearchTerm = searchTerm;

                
                // Explicitly define the query as IQueryable<Product>.
                // This is the base query.
                IQueryable<Product> query = _context.Products;
                // --- END FIX ---

                // REQ 3: Apply search filter if one is provided
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    // This is your error line (47). Now it's valid because
                    // query.Where() returns an IQueryable, matching the variable type.
                    query = query.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
                }

                // We apply AsNoTracking() at the end, just before execution,
                // which is also a correct pattern.
                var products = await query
                                       .AsNoTracking()
                                       .OrderBy(p => p.Name)
                                       .ToListAsync();

                // Now that we are back on the UI thread, update the grid.
                dgvProducts.DataSource = products;
                dgvProducts.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Event Handlers ---

        // REQ 6: Form_Load is async so it can await the initial data load
        private async void Form1_Load(object sender, EventArgs e)
        {
            // Load products when the form first opens
            await LoadProducts();
        }

        // REQ 2 & 6: Refresh button is now async
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            // Re-load the data, using the last known search term
            await LoadProducts(_currentSearchTerm);
        }

        // REQ 3: Search menu item
        private async void menuStripSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = Interaction.InputBox("Enter search term:", "Search Products", "");

            // Pass the search term to LoadProducts
            // If the user clicks cancel, searchTerm will be "" and LoadProducts will clear the filter
            await LoadProducts(searchTerm);
        }


        // REQ 4: Add New Product
        private async void menuStripAddNew_Click(object sender, EventArgs e)
        {
            using (var form = new FormAddProduct())
            {
                // Open the new form as a dialog
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Get the new product from the form's public property
                        var newProduct = form.NewProduct;

                        _context.Products.Add(newProduct);

                        // REQ 6: SaveChanges is async
                        await _context.SaveChangesAsync();

                        // REQ 6: Refresh the grid
                        await LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving new product: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // REQ 4: Add to Existing Product Stock
        private async void menuStripAddExisting_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product from the grid first.", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Get the ID from the selected row
                int productId = (int)dgvProducts.CurrentRow.Cells["Id"].Value;
                string productName = dgvProducts.CurrentRow.Cells["Name"].Value.ToString();

                // Ask how many to add
                string input = Interaction.InputBox($"How many units to add to '{productName}'?", "Add Stock", "1");

                if (int.TryParse(input, out int quantityToAdd) && quantityToAdd > 0)
                {
                    // Find the product in the database
                    // REQ 6: FindAsync is async
                    var product = await _context.Products.FindAsync(productId);

                    if (product != null)
                    {
                        product.Quantity += quantityToAdd;

                        // REQ 6: SaveChanges is async
                        await _context.SaveChangesAsync();
                        await LoadProducts(_currentSearchTerm); // Refresh grid
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating stock: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // REQ 5: Sell Products (launched from grid double-click)
        private async void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure the user didn't double-click the header row
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvProducts.Rows[e.RowIndex];

                // Get product details from the grid
                int id = (int)row.Cells["Id"].Value;
                string name = (string)row.Cells["Name"].Value;
                int currentQuantity = (int)row.Cells["Quantity"].Value;

                if (currentQuantity <= 0)
                {
                    MessageBox.Show($"'{name}' is already out of stock.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Open the sell form, passing in the product details
                using (var form = new FormSellProduct(name, currentQuantity))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int quantityToSell = form.QuantityToSell;

                        // Find the product in the database to update it
                        // REQ 6: FindAsync
                        var productToUpdate = await _context.Products.FindAsync(id);

                        if (productToUpdate == null) return;

                        // REQ 5: If quantity becomes 0 (or less), delete the product
                        if (productToUpdate.Quantity - quantityToSell <= 0)
                        {
                            _context.Products.Remove(productToUpdate);
                            MessageBox.Show($"Sold remaining {productToUpdate.Quantity} of '{name}'. Product removed from stock.", "Product Sold Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            productToUpdate.Quantity -= quantityToSell;
                        }

                        // REQ 6: SaveChanges is async
                        await _context.SaveChangesAsync();
                        await LoadProducts(_currentSearchTerm); // Refresh grid
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selling product: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This handler is no longer used since "Add Products" is a parent menu
        private void menuStripAdd_Click(object sender, EventArgs e)
        {
            // This event is now attached to 'menuStripAddParent'
            // which doesn't need to do anything when clicked.
        }

        // This handler is not implemented per the PDF
        private void menuStripSell_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sell product form will open here.");
        }


        // Ensure the context is disposed of when the form closes
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosing(e);
        }
    }
}