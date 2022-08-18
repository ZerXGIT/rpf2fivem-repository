namespace rpf2fivem
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearQueue = new System.Windows.Forms.Button();
            this.queueList = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddQueue = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CompressCheck = new System.Windows.Forms.CheckBox();
            this.gta5mods_status = new System.Windows.Forms.Label();
            this.fivemresname_tb = new System.Windows.Forms.TextBox();
            this.VmenuCheck = new System.Windows.Forms.CheckBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tsBar = new System.Windows.Forms.ProgressBar();
            this.log = new System.Windows.Forms.TextBox();
            this.reslua = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnConvertFromFolder = new System.Windows.Forms.Button();
            this.comp_folder = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tsStatus = new System.Windows.Forms.TextBox();
            this.tsQueue = new System.Windows.Forms.TextBox();
            this.jobTime = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearQueue);
            this.groupBox1.Controls.Add(this.queueList);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 457);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RPF Selector";
            // 
            // btnClearQueue
            // 
            this.btnClearQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(105)))), ((int)(((byte)(255)))));
            this.btnClearQueue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(105)))), ((int)(((byte)(255)))));
            this.btnClearQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearQueue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.btnClearQueue.Location = new System.Drawing.Point(347, 428);
            this.btnClearQueue.Name = "btnClearQueue";
            this.btnClearQueue.Size = new System.Drawing.Size(102, 23);
            this.btnClearQueue.TabIndex = 19;
            this.btnClearQueue.Text = "Clear queue";
            this.btnClearQueue.UseVisualStyleBackColor = false;
            this.btnClearQueue.Click += new System.EventHandler(this.button4_Click);
            // 
            // queueList
            // 
            this.queueList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.queueList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.queueList.ForeColor = System.Drawing.Color.White;
            this.queueList.FormattingEnabled = true;
            this.queueList.ItemHeight = 16;
            this.queueList.Location = new System.Drawing.Point(6, 283);
            this.queueList.Name = "queueList";
            this.queueList.Size = new System.Drawing.Size(443, 144);
            this.queueList.TabIndex = 17;
            this.queueList.SelectedIndexChanged += new System.EventHandler(this.queueList_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnAddQueue);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.CompressCheck);
            this.groupBox3.Controls.Add(this.gta5mods_status);
            this.groupBox3.Controls.Add(this.fivemresname_tb);
            this.groupBox3.Controls.Add(this.VmenuCheck);
            this.groupBox3.Controls.Add(this.textBox6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.groupBox3.Location = new System.Drawing.Point(6, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(443, 233);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resource";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Link";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnAddQueue
            // 
            this.btnAddQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(105)))), ((int)(((byte)(255)))));
            this.btnAddQueue.Enabled = false;
            this.btnAddQueue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(105)))), ((int)(((byte)(255)))));
            this.btnAddQueue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddQueue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.btnAddQueue.Location = new System.Drawing.Point(6, 200);
            this.btnAddQueue.Name = "btnAddQueue";
            this.btnAddQueue.Size = new System.Drawing.Size(99, 23);
            this.btnAddQueue.TabIndex = 18;
            this.btnAddQueue.Text = "Add to queue";
            this.btnAddQueue.UseVisualStyleBackColor = false;
            this.btnAddQueue.Click += new System.EventHandler(this.btnAddQueue_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.checkBox1.Location = new System.Drawing.Point(6, 174);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(267, 20);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "store converted vehicles in one resource";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(86)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(6, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(431, 15);
            this.textBox1.TabIndex = 20;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "FiveM Resource name";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // CompressCheck
            // 
            this.CompressCheck.AutoSize = true;
            this.CompressCheck.Checked = true;
            this.CompressCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CompressCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.CompressCheck.Location = new System.Drawing.Point(6, 148);
            this.CompressCheck.Name = "CompressCheck";
            this.CompressCheck.Size = new System.Drawing.Size(325, 20);
            this.CompressCheck.TabIndex = 18;
            this.CompressCheck.Text = "compress/downsize textures (might reduce quality)";
            this.CompressCheck.UseVisualStyleBackColor = true;
            this.CompressCheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // gta5mods_status
            // 
            this.gta5mods_status.AutoSize = true;
            this.gta5mods_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gta5mods_status.ForeColor = System.Drawing.Color.Crimson;
            this.gta5mods_status.Location = new System.Drawing.Point(373, 26);
            this.gta5mods_status.Name = "gta5mods_status";
            this.gta5mods_status.Size = new System.Drawing.Size(64, 13);
            this.gta5mods_status.TabIndex = 10;
            this.gta5mods_status.Text = "BAD LINK";
            // 
            // fivemresname_tb
            // 
            this.fivemresname_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.fivemresname_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fivemresname_tb.Location = new System.Drawing.Point(6, 92);
            this.fivemresname_tb.Name = "fivemresname_tb";
            this.fivemresname_tb.Size = new System.Drawing.Size(249, 15);
            this.fivemresname_tb.TabIndex = 13;
            this.fivemresname_tb.Text = "default";
            this.fivemresname_tb.TextChanged += new System.EventHandler(this.fivemresname_tb_TextChanged);
            // 
            // VmenuCheck
            // 
            this.VmenuCheck.AutoSize = true;
            this.VmenuCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.VmenuCheck.Checked = true;
            this.VmenuCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VmenuCheck.Enabled = false;
            this.VmenuCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.VmenuCheck.Location = new System.Drawing.Point(6, 122);
            this.VmenuCheck.Name = "VmenuCheck";
            this.VmenuCheck.Size = new System.Drawing.Size(372, 20);
            this.VmenuCheck.TabIndex = 14;
            this.VmenuCheck.Text = "vMenu / server.cfg helper (check directory after converting)\r\n";
            this.VmenuCheck.UseVisualStyleBackColor = false;
            this.VmenuCheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(261, 92);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(176, 15);
            this.textBox6.TabIndex = 16;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(258, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Custom vehicle in-game name";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(194)))), ((int)(((byte)(212)))));
            this.label8.Location = new System.Drawing.Point(2, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Queue";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tsBar);
            this.groupBox2.Controls.Add(this.tsStatus);
            this.groupBox2.Controls.Add(this.log);
            this.groupBox2.Controls.Add(this.tsQueue);
            this.groupBox2.Controls.Add(this.reslua);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.groupBox2.Location = new System.Drawing.Point(476, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(603, 522);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // tsBar
            // 
            this.tsBar.Location = new System.Drawing.Point(6, 499);
            this.tsBar.Name = "tsBar";
            this.tsBar.Size = new System.Drawing.Size(590, 15);
            this.tsBar.TabIndex = 12;
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.log.ForeColor = System.Drawing.Color.White;
            this.log.Location = new System.Drawing.Point(6, 17);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(591, 440);
            this.log.TabIndex = 0;
            // 
            // reslua
            // 
            this.reslua.Location = new System.Drawing.Point(40, 68);
            this.reslua.Multiline = true;
            this.reslua.Name = "reslua";
            this.reslua.Size = new System.Drawing.Size(525, 274);
            this.reslua.TabIndex = 10;
            this.reslua.Text = resources.GetString("reslua.Text");
            this.reslua.Visible = false;
            this.reslua.TextChanged += new System.EventHandler(this.reslua_TextChanged);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(202)))), ((int)(((byte)(104)))));
            this.btnStart.Enabled = false;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(14, 475);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnConvertFromFolder
            // 
            this.btnConvertFromFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(105)))), ((int)(((byte)(255)))));
            this.btnConvertFromFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(105)))), ((int)(((byte)(255)))));
            this.btnConvertFromFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertFromFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.btnConvertFromFolder.Location = new System.Drawing.Point(95, 475);
            this.btnConvertFromFolder.Name = "btnConvertFromFolder";
            this.btnConvertFromFolder.Size = new System.Drawing.Size(146, 23);
            this.btnConvertFromFolder.TabIndex = 20;
            this.btnConvertFromFolder.Text = "Convert from folder";
            this.btnConvertFromFolder.UseVisualStyleBackColor = false;
            this.btnConvertFromFolder.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // comp_folder
            // 
            this.comp_folder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(105)))), ((int)(((byte)(255)))));
            this.comp_folder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(105)))), ((int)(((byte)(255)))));
            this.comp_folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comp_folder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.comp_folder.Location = new System.Drawing.Point(339, 475);
            this.comp_folder.Name = "comp_folder";
            this.comp_folder.Size = new System.Drawing.Size(131, 23);
            this.comp_folder.TabIndex = 21;
            this.comp_folder.Text = "Compress folder";
            this.comp_folder.UseVisualStyleBackColor = false;
            this.comp_folder.Click += new System.EventHandler(this.comp_folder_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // tsStatus
            // 
            this.tsStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.tsStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tsStatus.ForeColor = System.Drawing.SystemColors.Info;
            this.tsStatus.Location = new System.Drawing.Point(254, 457);
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(342, 15);
            this.tsStatus.TabIndex = 11;
            this.tsStatus.TextChanged += new System.EventHandler(this.tsStatus_TextChanged);
            // 
            // tsQueue
            // 
            this.tsQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.tsQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tsQueue.ForeColor = System.Drawing.SystemColors.Info;
            this.tsQueue.Location = new System.Drawing.Point(254, 478);
            this.tsQueue.Name = "tsQueue";
            this.tsQueue.Size = new System.Drawing.Size(342, 15);
            this.tsQueue.TabIndex = 12;
            // 
            // jobTime
            // 
            this.jobTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.jobTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jobTime.ForeColor = System.Drawing.SystemColors.Info;
            this.jobTime.Location = new System.Drawing.Point(14, 511);
            this.jobTime.Name = "jobTime";
            this.jobTime.Size = new System.Drawing.Size(342, 15);
            this.jobTime.TabIndex = 22;
            this.jobTime.TextChanged += new System.EventHandler(this.jobTime_TextChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1090, 538);
            this.Controls.Add(this.jobTime);
            this.Controls.Add(this.comp_folder);
            this.Controls.Add(this.btnConvertFromFolder);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "rpf2fivem convertor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label gta5mods_status;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox VmenuCheck;
        private System.Windows.Forms.TextBox fivemresname_tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox reslua;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox queueList;
        private System.Windows.Forms.Button btnAddQueue;
        private System.Windows.Forms.Button btnClearQueue;
        private System.Windows.Forms.Button btnConvertFromFolder;
        private System.Windows.Forms.CheckBox CompressCheck;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button comp_folder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tsStatus;
        private System.Windows.Forms.TextBox tsQueue;
        private System.Windows.Forms.TextBox jobTime;
        private System.Windows.Forms.ProgressBar tsBar;
    }
}
