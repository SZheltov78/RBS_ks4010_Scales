namespace ВесыУдалениеТоваров
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.product_name_TB = new System.Windows.Forms.TextBox();
            this.shelf_num_TB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.product_code_TB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.original_price_TB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // product_name_TB
            // 
            this.product_name_TB.Location = new System.Drawing.Point(106, 6);
            this.product_name_TB.Name = "product_name_TB";
            this.product_name_TB.Size = new System.Drawing.Size(287, 20);
            this.product_name_TB.TabIndex = 1;
            // 
            // shelf_num_TB
            // 
            this.shelf_num_TB.Location = new System.Drawing.Point(106, 84);
            this.shelf_num_TB.Name = "shelf_num_TB";
            this.shelf_num_TB.Size = new System.Drawing.Size(287, 20);
            this.shelf_num_TB.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Кнопка на весах";
            // 
            // product_code_TB
            // 
            this.product_code_TB.Location = new System.Drawing.Point(106, 58);
            this.product_code_TB.Name = "product_code_TB";
            this.product_code_TB.Size = new System.Drawing.Size(287, 20);
            this.product_code_TB.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Штрих код";
            // 
            // original_price_TB
            // 
            this.original_price_TB.Location = new System.Drawing.Point(106, 32);
            this.original_price_TB.Name = "original_price_TB";
            this.original_price_TB.Size = new System.Drawing.Size(287, 20);
            this.original_price_TB.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Цена";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "POST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 140);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.original_price_TB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.product_code_TB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.shelf_num_TB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.product_name_TB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение продукта";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox product_name_TB;
        private System.Windows.Forms.TextBox shelf_num_TB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox product_code_TB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox original_price_TB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}