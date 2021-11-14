
namespace AsterixDecoder
{
    partial class Welcome
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonMap = new System.Windows.Forms.Button();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.buttonLoadDecoder = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.buttonMap);
            this.panel1.Controls.Add(this.buttonLoadFile);
            this.panel1.Controls.Add(this.buttonLoadDecoder);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 1055);
            this.panel1.TabIndex = 0;
            // 
            // buttonMap
            // 
            this.buttonMap.FlatAppearance.BorderSize = 0;
            this.buttonMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.buttonMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMap.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonMap.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonMap.Location = new System.Drawing.Point(0, 238);
            this.buttonMap.Name = "buttonMap";
            this.buttonMap.Size = new System.Drawing.Size(267, 77);
            this.buttonMap.TabIndex = 3;
            this.buttonMap.Text = "MAP VIEWER";
            this.buttonMap.UseVisualStyleBackColor = true;
            this.buttonMap.Click += new System.EventHandler(this.buttonMap_Click);
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.FlatAppearance.BorderSize = 0;
            this.buttonLoadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.buttonLoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadFile.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLoadFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLoadFile.Location = new System.Drawing.Point(0, 88);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(267, 77);
            this.buttonLoadFile.TabIndex = 2;
            this.buttonLoadFile.Text = "LOAD FILE";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // buttonLoadDecoder
            // 
            this.buttonLoadDecoder.FlatAppearance.BorderSize = 0;
            this.buttonLoadDecoder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.buttonLoadDecoder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadDecoder.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLoadDecoder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLoadDecoder.Location = new System.Drawing.Point(0, 163);
            this.buttonLoadDecoder.Name = "buttonLoadDecoder";
            this.buttonLoadDecoder.Size = new System.Drawing.Size(267, 77);
            this.buttonLoadDecoder.TabIndex = 1;
            this.buttonLoadDecoder.Text = "DATA VIEWER";
            this.buttonLoadDecoder.UseVisualStyleBackColor = true;
            this.buttonLoadDecoder.Click += new System.EventHandler(this.buttonLoadDecoder_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 84);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(8, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "PUT LOGO HERE";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panelTitleBar.Controls.Add(this.label1);
            this.panelTitleBar.Location = new System.Drawing.Point(265, -1);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1520, 88);
            this.panelTitleBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(582, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "WELCOME PAGE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(443, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(441, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "PUT THE INSTRUCTIONS FOR USE HERE";
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(68)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1782, 1053);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panel1);
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonLoadDecoder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonMap;
    }
}

