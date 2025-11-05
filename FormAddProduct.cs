using Labor_5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Labor_5
{
    public partial class FormAddProduct : Form
    {
        // Public property to hold the new product
        public Product NewProduct { get; private set; }

        public FormAddProduct()
        {
            InitializeComponent();

            // Set default dates
            dtpStoreEntry.Value = DateTime.Now;
            dtpExpiration.Value = DateTime.Now.AddDays(30);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // --- Validation ---
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Product Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpExpiration.Value <= dtpStoreEntry.Value)
            {
                MessageBox.Show("Expiration Date must be after the Store Entry Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Create Product ---
            NewProduct = new Product
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Quantity = (int)numQuantity.Value,
                StoreEntryDate = dtpStoreEntry.Value,
                ExpirationDate = dtpExpiration.Value
            };

            // Set DialogResult to OK and close the form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}