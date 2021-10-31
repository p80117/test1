namespace ADLINK_AI
{
    partial class Initial_Card
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
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Card_Number = new System.Windows.Forms.ComboBox();
            this.cb_Card_Name = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "卡片名稱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "卡片編號";
            // 
            // cb_Card_Number
            // 
            this.cb_Card_Number.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb_Card_Number.FormattingEnabled = true;
            this.cb_Card_Number.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.cb_Card_Number.Location = new System.Drawing.Point(92, 102);
            this.cb_Card_Number.Name = "cb_Card_Number";
            this.cb_Card_Number.Size = new System.Drawing.Size(121, 24);
            this.cb_Card_Number.TabIndex = 2;
            // 
            // cb_Card_Name
            // 
            this.cb_Card_Name.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb_Card_Name.FormattingEnabled = true;
            this.cb_Card_Name.Items.AddRange(new object[] {
            "PCI_9111DG",
            "PCI_9111HR",
            "PCI_9112",
            "PCI_9113",
            "PCI_9114DG",
            "PCI_9114HG",
            "PCI_9524"});
            this.cb_Card_Name.Location = new System.Drawing.Point(93, 56);
            this.cb_Card_Name.Name = "cb_Card_Name";
            this.cb_Card_Name.Size = new System.Drawing.Size(121, 24);
            this.cb_Card_Name.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(197, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Initial_Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 192);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_Card_Name);
            this.Controls.Add(this.cb_Card_Number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Initial_Card";
            this.Text = "Initial";
            this.Load += new System.EventHandler(this.Initial_Card_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_Card_Number;
        private System.Windows.Forms.ComboBox cb_Card_Name;
        private System.Windows.Forms.Button button1;
    }
}