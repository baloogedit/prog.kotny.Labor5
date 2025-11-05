namespace Labor_5
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStripAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSell = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.addNewProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToExistingStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripAdd,
            this.menuStripSell,
            this.menuStripSearch});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1356, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStripAdd
            // 
            this.menuStripAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewProductToolStripMenuItem,
            this.addToExistingStockToolStripMenuItem});
            this.menuStripAdd.Name = "menuStripAdd";
            this.menuStripAdd.Size = new System.Drawing.Size(176, 36);
            this.menuStripAdd.Text = "&Add Products";
            this.menuStripAdd.Click += new System.EventHandler(this.menuStripAdd_Click);
            // 
            // menuStripSell
            // 
            this.menuStripSell.Name = "menuStripSell";
            this.menuStripSell.Size = new System.Drawing.Size(171, 38);
            this.menuStripSell.Text = "&Sell Products";
            this.menuStripSell.Click += new System.EventHandler(this.menuStripSell_Click);
            // 
            // menuStripSearch
            // 
            this.menuStripSearch.Name = "menuStripSearch";
            this.menuStripSearch.Size = new System.Drawing.Size(204, 38);
            this.menuStripSearch.Text = "&Search Products";
            this.menuStripSearch.Click += new System.EventHandler(this.menuStripSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRefresh.Location = new System.Drawing.Point(0, 625);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(1356, 56);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 40);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 82;
            this.dgvProducts.RowTemplate.Height = 33;
            this.dgvProducts.Size = new System.Drawing.Size(1356, 585);
            this.dgvProducts.TabIndex = 2;
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellDoubleClick);
            // 
            // addNewProductToolStripMenuItem
            // 
            this.addNewProductToolStripMenuItem.Name = "addNewProductToolStripMenuItem";
            this.addNewProductToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.addNewProductToolStripMenuItem.Text = "&AddNewProduct";
            this.addNewProductToolStripMenuItem.Click += new System.EventHandler(this.menuStripAddNew_Click);
            // 
            // addToExistingStockToolStripMenuItem
            // 
            this.addToExistingStockToolStripMenuItem.Name = "addToExistingStockToolStripMenuItem";
            this.addToExistingStockToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.addToExistingStockToolStripMenuItem.Text = "&AddToExistingStock";
            this.addToExistingStockToolStripMenuItem.Click += new System.EventHandler(this.menuStripAddExisting_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 681);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStripAdd;
        private System.Windows.Forms.ToolStripMenuItem menuStripSell;
        private System.Windows.Forms.ToolStripMenuItem menuStripSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ToolStripMenuItem addNewProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToExistingStockToolStripMenuItem;
    }
}

