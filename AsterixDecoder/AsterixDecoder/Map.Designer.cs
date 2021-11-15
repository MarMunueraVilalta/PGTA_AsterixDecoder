
namespace AsterixDecoder
{
    partial class Map
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMap = new System.Windows.Forms.Button();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.buttonLoadDecoder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.dateTimePicker_to = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_from = new System.Windows.Forms.DateTimePicker();
            this.play_btn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox_SMR = new System.Windows.Forms.CheckBox();
            this.checkBox_MLAT = new System.Windows.Forms.CheckBox();
            this.checkBox_ADS_B = new System.Windows.Forms.CheckBox();
            this.pause_btn = new System.Windows.Forms.Button();
            this.resume_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 54);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "PUT LOGO HERE";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panelTitleBar.Controls.Add(this.label1);
            this.panelTitleBar.Location = new System.Drawing.Point(197, -1);
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1140, 57);
            this.panelTitleBar.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(436, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "MAP VIEWER";
            // 
            // buttonMap
            // 
            this.buttonMap.BackColor = System.Drawing.Color.LightSeaGreen;
            this.buttonMap.FlatAppearance.BorderSize = 0;
            this.buttonMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.buttonMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMap.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.buttonMap.ForeColor = System.Drawing.SystemColors.Desktop;
            this.buttonMap.Location = new System.Drawing.Point(0, 154);
            this.buttonMap.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMap.Name = "buttonMap";
            this.buttonMap.Size = new System.Drawing.Size(200, 50);
            this.buttonMap.TabIndex = 3;
            this.buttonMap.Text = "MAP VIEWER";
            this.buttonMap.UseVisualStyleBackColor = false;
            this.buttonMap.Click += new System.EventHandler(this.buttonMap_Click);
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.FlatAppearance.BorderSize = 0;
            this.buttonLoadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.buttonLoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadFile.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.buttonLoadFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLoadFile.Location = new System.Drawing.Point(0, 57);
            this.buttonLoadFile.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(200, 50);
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
            this.buttonLoadDecoder.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.buttonLoadDecoder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLoadDecoder.Location = new System.Drawing.Point(0, 106);
            this.buttonLoadDecoder.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadDecoder.Name = "buttonLoadDecoder";
            this.buttonLoadDecoder.Size = new System.Drawing.Size(200, 50);
            this.buttonLoadDecoder.TabIndex = 1;
            this.buttonLoadDecoder.Text = "DATA VIEWER";
            this.buttonLoadDecoder.UseVisualStyleBackColor = true;
            this.buttonLoadDecoder.Click += new System.EventHandler(this.buttonLoadDecoder_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.buttonMap);
            this.panel1.Controls.Add(this.buttonLoadFile);
            this.panel1.Controls.Add(this.buttonLoadDecoder);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 686);
            this.panel1.TabIndex = 5;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(204, 123);
            this.gMapControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 18;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = false;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(1124, 552);
            this.gMapControl1.TabIndex = 7;
            this.gMapControl1.Zoom = 5D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // dateTimePicker_to
            // 
            this.dateTimePicker_to.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_to.Location = new System.Drawing.Point(229, 93);
            this.dateTimePicker_to.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_to.Name = "dateTimePicker_to";
            this.dateTimePicker_to.ShowUpDown = true;
            this.dateTimePicker_to.Size = new System.Drawing.Size(67, 20);
            this.dateTimePicker_to.TabIndex = 30;
            this.dateTimePicker_to.Value = new System.DateTime(2021, 11, 3, 8, 1, 0, 0);
            // 
            // dateTimePicker_from
            // 
            this.dateTimePicker_from.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_from.Location = new System.Drawing.Point(229, 72);
            this.dateTimePicker_from.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_from.Name = "dateTimePicker_from";
            this.dateTimePicker_from.ShowUpDown = true;
            this.dateTimePicker_from.Size = new System.Drawing.Size(67, 20);
            this.dateTimePicker_from.TabIndex = 29;
            this.dateTimePicker_from.Value = new System.DateTime(2021, 11, 3, 8, 0, 0, 0);
            // 
            // play_btn
            // 
            this.play_btn.Image = ((System.Drawing.Image)(resources.GetObject("play_btn.Image")));
            this.play_btn.Location = new System.Drawing.Point(304, 78);
            this.play_btn.Margin = new System.Windows.Forms.Padding(2);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(46, 26);
            this.play_btn.TabIndex = 31;
            this.play_btn.Text = "play";
            this.play_btn.UseVisualStyleBackColor = true;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox_SMR
            // 
            this.checkBox_SMR.AutoSize = true;
            this.checkBox_SMR.Location = new System.Drawing.Point(429, 72);
            this.checkBox_SMR.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_SMR.Name = "checkBox_SMR";
            this.checkBox_SMR.Size = new System.Drawing.Size(80, 17);
            this.checkBox_SMR.TabIndex = 32;
            this.checkBox_SMR.Text = "Show SMR";
            this.checkBox_SMR.UseVisualStyleBackColor = true;
            // 
            // checkBox_MLAT
            // 
            this.checkBox_MLAT.AutoSize = true;
            this.checkBox_MLAT.Location = new System.Drawing.Point(429, 97);
            this.checkBox_MLAT.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_MLAT.Name = "checkBox_MLAT";
            this.checkBox_MLAT.Size = new System.Drawing.Size(85, 17);
            this.checkBox_MLAT.TabIndex = 33;
            this.checkBox_MLAT.Text = "Show MLAT";
            this.checkBox_MLAT.UseVisualStyleBackColor = true;
            // 
            // checkBox_ADS_B
            // 
            this.checkBox_ADS_B.AutoSize = true;
            this.checkBox_ADS_B.Location = new System.Drawing.Point(523, 72);
            this.checkBox_ADS_B.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_ADS_B.Name = "checkBox_ADS_B";
            this.checkBox_ADS_B.Size = new System.Drawing.Size(88, 17);
            this.checkBox_ADS_B.TabIndex = 34;
            this.checkBox_ADS_B.Text = "Show ADS-B";
            this.checkBox_ADS_B.UseVisualStyleBackColor = true;
            // 
            // pause_btn
            // 
            this.pause_btn.Image = ((System.Drawing.Image)(resources.GetObject("pause_btn.Image")));
            this.pause_btn.Location = new System.Drawing.Point(304, 78);
            this.pause_btn.Margin = new System.Windows.Forms.Padding(2);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(46, 26);
            this.pause_btn.TabIndex = 35;
            this.pause_btn.Text = "Pause";
            this.pause_btn.UseVisualStyleBackColor = true;
            this.pause_btn.Click += new System.EventHandler(this.pause_btn_Click);
            // 
            // resume_btn
            // 
            this.resume_btn.Image = ((System.Drawing.Image)(resources.GetObject("resume_btn.Image")));
            this.resume_btn.Location = new System.Drawing.Point(304, 78);
            this.resume_btn.Margin = new System.Windows.Forms.Padding(2);
            this.resume_btn.Name = "resume_btn";
            this.resume_btn.Size = new System.Drawing.Size(58, 26);
            this.resume_btn.TabIndex = 36;
            this.resume_btn.Text = "Resume";
            this.resume_btn.UseVisualStyleBackColor = true;
            this.resume_btn.Click += new System.EventHandler(this.resume_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Image = ((System.Drawing.Image)(resources.GetObject("stop_btn.Image")));
            this.stop_btn.Location = new System.Drawing.Point(366, 78);
            this.stop_btn.Margin = new System.Windows.Forms.Padding(2);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(45, 26);
            this.stop_btn.TabIndex = 37;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1336, 684);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.resume_btn);
            this.Controls.Add(this.pause_btn);
            this.Controls.Add(this.checkBox_ADS_B);
            this.Controls.Add(this.checkBox_MLAT);
            this.Controls.Add(this.checkBox_SMR);
            this.Controls.Add(this.play_btn);
            this.Controls.Add(this.dateTimePicker_to);
            this.Controls.Add(this.dateTimePicker_from);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Map";
            this.Text = "Map";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonMap;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.Button buttonLoadDecoder;
        private System.Windows.Forms.Panel panel1;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_to;
        private System.Windows.Forms.DateTimePicker dateTimePicker_from;
        private System.Windows.Forms.Button play_btn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox_SMR;
        private System.Windows.Forms.CheckBox checkBox_MLAT;
        private System.Windows.Forms.CheckBox checkBox_ADS_B;
        private System.Windows.Forms.Button pause_btn;
        private System.Windows.Forms.Button resume_btn;
        private System.Windows.Forms.Button stop_btn;
    }
}