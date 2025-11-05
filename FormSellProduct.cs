using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labor_5
{
    public partial class FormSellProduct : Form
    {
        // Public property to hold the result
        public int QuantityToSell { get; private set; }

        public FormSellProduct(string productName, int currentQuantity)
        {
            InitializeComponent();

            // REQ 5: Constructor receives product details
            this.Text = $"Sell Product: {productName}";
            this.lblProductInfo.Text = $"Selling: {productName}\n(Current Stock: {currentQuantity})";

            // REQ 5: Allow selecting quantity
            this.numQuantityToSell.Maximum = currentQuantity;
            this.numQuantityToSell.Value = 1;
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (numQuantityToSell.Value <= 0)
            {
                MessageBox.Show("Quantity to sell must be at least 1.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Set public property and close
            this.QuantityToSell = (int)numQuantityToSell.Value;
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