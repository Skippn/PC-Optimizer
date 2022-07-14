namespace Optimizer
{
    partial class Optimizer
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
            this.brandLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.windowsTempButton = new System.Windows.Forms.Button();
            this.CleanAppTemp = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // brandLabel
            // 
            this.brandLabel.AutoSize = true;
            this.brandLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.brandLabel.Location = new System.Drawing.Point(18, 16);
            this.brandLabel.Name = "brandLabel";
            this.brandLabel.Size = new System.Drawing.Size(102, 21);
            this.brandLabel.TabIndex = 0;
            this.brandLabel.Text = "PC Optimizer";
            this.brandLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.brandLabel_MouseDown);
            this.brandLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.brandLabel_MouseMove);
            this.brandLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.brandLabel_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(966, -1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(45, 43);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "x";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.minimizeButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.minimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeButton.ForeColor = System.Drawing.Color.Black;
            this.minimizeButton.Location = new System.Drawing.Point(916, -7);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(45, 49);
            this.minimizeButton.TabIndex = 2;
            this.minimizeButton.Text = "_";
            this.minimizeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 50);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // windowsTempButton
            // 
            this.windowsTempButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.windowsTempButton.Location = new System.Drawing.Point(22, 77);
            this.windowsTempButton.Name = "windowsTempButton";
            this.windowsTempButton.Size = new System.Drawing.Size(169, 53);
            this.windowsTempButton.TabIndex = 4;
            this.windowsTempButton.Text = "Clean Windows Temp";
            this.windowsTempButton.UseVisualStyleBackColor = true;
            this.windowsTempButton.Click += new System.EventHandler(this.windowsTempButton_Click);
            // 
            // CleanAppTemp
            // 
            this.CleanAppTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CleanAppTemp.Location = new System.Drawing.Point(22, 136);
            this.CleanAppTemp.Name = "CleanAppTemp";
            this.CleanAppTemp.Size = new System.Drawing.Size(169, 53);
            this.CleanAppTemp.TabIndex = 5;
            this.CleanAppTemp.Text = "Clean AppData Temp";
            this.CleanAppTemp.UseVisualStyleBackColor = true;
            this.CleanAppTemp.Click += new System.EventHandler(this.CleanAppTemp_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 457);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(494, 206);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(525, 457);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(473, 206);
            this.textBox2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Deleted:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(521, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Locked:";
            // 
            // Optimizer
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1010, 675);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CleanAppTemp);
            this.Controls.Add(this.windowsTempButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.brandLabel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Optimizer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Optimizer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Label brandLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button windowsTempButton;
        private System.Windows.Forms.Button CleanAppTemp;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

