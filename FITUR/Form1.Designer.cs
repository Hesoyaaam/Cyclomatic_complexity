namespace FITUR
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.txtOutput2 = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnHitung = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtdirectory = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(334, 36);
            this.label2.TabIndex = 33;
            this.label2.Text = "Cyclomatic Complexity";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(24, 401);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 35);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(547, 22);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 35);
            this.btnHelp.TabIndex = 30;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // txtOutput2
            // 
            this.txtOutput2.Location = new System.Drawing.Point(389, 117);
            this.txtOutput2.Multiline = true;
            this.txtOutput2.Name = "txtOutput2";
            this.txtOutput2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput2.Size = new System.Drawing.Size(233, 319);
            this.txtOutput2.TabIndex = 29;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(141, 117);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(242, 319);
            this.txtOutput.TabIndex = 28;
            // 
            // btnHitung
            // 
            this.btnHitung.Location = new System.Drawing.Point(24, 117);
            this.btnHitung.Name = "btnHitung";
            this.btnHitung.Size = new System.Drawing.Size(111, 35);
            this.btnHitung.TabIndex = 27;
            this.btnHitung.Text = "Run";
            this.btnHitung.UseVisualStyleBackColor = true;
            this.btnHitung.Click += new System.EventHandler(this.btnHitung_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(24, 71);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(111, 35);
            this.btnOpen.TabIndex = 26;
            this.btnOpen.Text = "Upload File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtdirectory
            // 
            this.txtdirectory.Location = new System.Drawing.Point(141, 71);
            this.txtdirectory.Multiline = true;
            this.txtdirectory.Name = "txtdirectory";
            this.txtdirectory.Size = new System.Drawing.Size(481, 35);
            this.txtdirectory.TabIndex = 25;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(24, 360);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 35);
            this.btnExport.TabIndex = 34;
            this.btnExport.Text = "Export CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 448);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.txtOutput2);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnHitung);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtdirectory);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox txtOutput2;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnHitung;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtdirectory;
        private System.Windows.Forms.Button btnExport;
    }
}

