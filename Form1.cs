using Labor_5.Data;
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

namespace Labor_5
{
    public partial class Form1 : Form
    {
        private readonly StoreContext _context;

        public Form1()
        {
            InitializeComponent();

            _context = new StoreContext();

            // Load products when the form first opens
            LoadProducts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadProducts()
        {
            try
            {
                // .AsNoTracking() is good practice for read-only lists
                var products = _context.Products
                                       .AsNoTracking()
                                       .ToList();

                // Set the DataGridView's data source
                dgvProducts.DataSource = products;

                // Optional: Auto-resize columns
                dgvProducts.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Event Handlers ---

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Re-load the data from the database
            LoadProducts();
        }

        private void menuStripAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add new product form will open here.");
        }

        private void menuStripSell_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sell product form will open here.");
        }

        private void menuStripSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search form will open here.");
        }

        // Ensure the context is disposed of when the form closes
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosing(e);
        }


    }
}
