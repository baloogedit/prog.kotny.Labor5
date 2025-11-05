namespace Labor_5
{
    partial class FormSellProduct
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numQuantityToSell = new System.Windows.Forms.NumericUpDown();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityToSell)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductInfo
            // 
            this.lblProductInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductInfo.Location = new System.Drawing.Point(28, 26);
            this.lblProductInfo.Name = "lblProductInfo";
            this.lblProductInfo.Size = new System.Drawing.Size(490, 80);
            this.lblProductInfo.TabIndex = 0;
            this.lblProductInfo.Text = "Selling: [Product Name]\r\n(Current Stock: [Qty])";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantity to Sell:";
            // 
            // numQuantityToSell
            // 
            this.numQuantityToSell.Location = new System.Drawing.Point(203, 124);
            this.numQuantityToSell.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantityToSell.Name = "numQuantityToSell";
            this.numQuantityToSell.Size = new System.Drawing.Size(130, 31);
            this.numQuantityToSell.TabIndex = 2;
            this.numQuantityToSell.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(249, 193);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(126, 44);
            this.btnSell.TabIndex = 3;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(392, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(126, 44);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormSellProduct
            // 
            this.AcceptButton = this.btnSell;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(546, 267);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.numQuantityToSell);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProductInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSellProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sell Product";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityToSell)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numQuantityToSell;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnCancel;
    }
}