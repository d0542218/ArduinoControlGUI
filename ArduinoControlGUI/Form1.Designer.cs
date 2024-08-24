namespace ArduinoControlGUI
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.btn_allOn = new System.Windows.Forms.Button();
            this.btn_allOff = new System.Windows.Forms.Button();
            this.btn_allFind = new System.Windows.Forms.Button();
            this.tb_dTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_server_ref = new System.Windows.Forms.TextBox();
            this.btn_output = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_server_fre = new System.Windows.Forms.TextBox();
            this.tb_server_inc = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cb_server_num = new System.Windows.Forms.ComboBox();
            this.lb_findRef = new System.Windows.Forms.ListBox();
            this.btn_NarrowBeamFind = new System.Windows.Forms.Button();
            this.btn_WideBeamFind = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_delayTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_com = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.phi2 = new System.Windows.Forms.Label();
            this.tb_server_ref_phi = new System.Windows.Forms.TextBox();
            this.phi1 = new System.Windows.Forms.Label();
            this.tb_server_inc_phi = new System.Windows.Forms.TextBox();
            this.theta2 = new System.Windows.Forms.Label();
            this.theta1 = new System.Windows.Forms.Label();
            this.tb_server_ref_combox = new System.Windows.Forms.ComboBox();
            this.tb_server_feed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_server_default = new System.Windows.Forms.CheckBox();
            this.tb_server_fre_combox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkImg = new System.Windows.Forms.PictureBox();
            this.btn_IPrefresh = new System.Windows.Forms.Button();
            this.btn_espIPset = new System.Windows.Forms.Button();
            this.tb_EspIP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.nUpDnPort = new System.Windows.Forms.NumericUpDown();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cboAvaiableIPaddr = new System.Windows.Forms.ComboBox();
            this.btn_LogClr = new System.Windows.Forms.Button();
            this.Phase = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDnPort)).BeginInit();
            this.Phase.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(215, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 21);
            this.label6.TabIndex = 20;
            this.label6.Text = "Incidence";
            // 
            // btn_allOn
            // 
            this.btn_allOn.Location = new System.Drawing.Point(220, 175);
            this.btn_allOn.Name = "btn_allOn";
            this.btn_allOn.Size = new System.Drawing.Size(75, 23);
            this.btn_allOn.TabIndex = 23;
            this.btn_allOn.Text = "All ON";
            this.btn_allOn.UseVisualStyleBackColor = true;
            this.btn_allOn.Click += new System.EventHandler(this.btn_allOn_Click);
            // 
            // btn_allOff
            // 
            this.btn_allOff.Location = new System.Drawing.Point(220, 205);
            this.btn_allOff.Name = "btn_allOff";
            this.btn_allOff.Size = new System.Drawing.Size(75, 23);
            this.btn_allOff.TabIndex = 24;
            this.btn_allOff.Text = "All OFF";
            this.btn_allOff.UseVisualStyleBackColor = true;
            this.btn_allOff.Click += new System.EventHandler(this.btn_allOff_Click);
            // 
            // btn_allFind
            // 
            this.btn_allFind.Location = new System.Drawing.Point(130, 205);
            this.btn_allFind.Name = "btn_allFind";
            this.btn_allFind.Size = new System.Drawing.Size(75, 23);
            this.btn_allFind.TabIndex = 25;
            this.btn_allFind.Text = "All Find";
            this.btn_allFind.UseVisualStyleBackColor = true;
            this.btn_allFind.Click += new System.EventHandler(this.btn_allFind_Click);
            // 
            // tb_dTime
            // 
            this.tb_dTime.Location = new System.Drawing.Point(25, 205);
            this.tb_dTime.Name = "tb_dTime";
            this.tb_dTime.Size = new System.Drawing.Size(100, 22);
            this.tb_dTime.TabIndex = 26;
            this.tb_dTime.Text = "1000";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(25, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 21);
            this.label12.TabIndex = 27;
            this.label12.Text = "Delay Time";
            // 
            // tb_server_ref
            // 
            this.tb_server_ref.Location = new System.Drawing.Point(315, 115);
            this.tb_server_ref.Name = "tb_server_ref";
            this.tb_server_ref.Size = new System.Drawing.Size(55, 22);
            this.tb_server_ref.TabIndex = 29;
            this.tb_server_ref.Text = "0";
            this.tb_server_ref.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_server_ref.Leave += new System.EventHandler(this.tb_server_ref_Leave);
            // 
            // btn_output
            // 
            this.btn_output.Location = new System.Drawing.Point(413, 92);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(119, 45);
            this.btn_output.TabIndex = 28;
            this.btn_output.Text = "Output";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(315, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 21);
            this.label13.TabIndex = 30;
            this.label13.Text = "Reflection";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(105, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 21);
            this.label14.TabIndex = 32;
            this.label14.Text = "Frequency";
            // 
            // tb_server_fre
            // 
            this.tb_server_fre.Location = new System.Drawing.Point(105, 115);
            this.tb_server_fre.Name = "tb_server_fre";
            this.tb_server_fre.Size = new System.Drawing.Size(55, 22);
            this.tb_server_fre.TabIndex = 33;
            this.tb_server_fre.Text = "4.7";
            this.tb_server_fre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_server_fre.Visible = false;
            // 
            // tb_server_inc
            // 
            this.tb_server_inc.Location = new System.Drawing.Point(215, 115);
            this.tb_server_inc.Name = "tb_server_inc";
            this.tb_server_inc.Size = new System.Drawing.Size(55, 22);
            this.tb_server_inc.TabIndex = 34;
            this.tb_server_inc.Text = "0";
            this.tb_server_inc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_server_inc.Leave += new System.EventHandler(this.tb_server_inc_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label15.Location = new System.Drawing.Point(166, 117);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 21);
            this.label15.TabIndex = 35;
            this.label15.Text = "GHz";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(25, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 21);
            this.label16.TabIndex = 36;
            this.label16.Text = "Num";
            // 
            // cb_server_num
            // 
            this.cb_server_num.FormattingEnabled = true;
            this.cb_server_num.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_server_num.Items.AddRange(new object[] {
            "20X20",
            "40X40",
            "32X64"});
            this.cb_server_num.Location = new System.Drawing.Point(25, 115);
            this.cb_server_num.Name = "cb_server_num";
            this.cb_server_num.Size = new System.Drawing.Size(72, 20);
            this.cb_server_num.TabIndex = 38;
            this.cb_server_num.Text = "20X20";
            this.cb_server_num.SelectedIndexChanged += new System.EventHandler(this.cb_server_num_SelectedIndexChanged);
            // 
            // lb_findRef
            // 
            this.lb_findRef.ColumnWidth = 3;
            this.lb_findRef.FormattingEnabled = true;
            this.lb_findRef.ItemHeight = 12;
            this.lb_findRef.Items.AddRange(new object[] {
            "degree -20",
            "degree   0",
            "degree   20",
            "All"});
            this.lb_findRef.Location = new System.Drawing.Point(19, 414);
            this.lb_findRef.Name = "lb_findRef";
            this.lb_findRef.Size = new System.Drawing.Size(120, 64);
            this.lb_findRef.TabIndex = 14;
            this.lb_findRef.Visible = false;
            // 
            // btn_NarrowBeamFind
            // 
            this.btn_NarrowBeamFind.Location = new System.Drawing.Point(32, 88);
            this.btn_NarrowBeamFind.Name = "btn_NarrowBeamFind";
            this.btn_NarrowBeamFind.Size = new System.Drawing.Size(88, 38);
            this.btn_NarrowBeamFind.TabIndex = 15;
            this.btn_NarrowBeamFind.Text = "Narrow Beam";
            this.btn_NarrowBeamFind.UseVisualStyleBackColor = true;
            this.btn_NarrowBeamFind.Click += new System.EventHandler(this.btn_NarrowBeamFind_Click);
            // 
            // btn_WideBeamFind
            // 
            this.btn_WideBeamFind.Location = new System.Drawing.Point(32, 359);
            this.btn_WideBeamFind.Name = "btn_WideBeamFind";
            this.btn_WideBeamFind.Size = new System.Drawing.Size(88, 38);
            this.btn_WideBeamFind.TabIndex = 13;
            this.btn_WideBeamFind.Text = "Wide Beam";
            this.btn_WideBeamFind.UseVisualStyleBackColor = true;
            this.btn_WideBeamFind.Visible = false;
            this.btn_WideBeamFind.Click += new System.EventHandler(this.btn_WideBeamFind_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(28, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 21);
            this.label7.TabIndex = 21;
            // 
            // tb_delayTime
            // 
            this.tb_delayTime.Location = new System.Drawing.Point(10, 50);
            this.tb_delayTime.Name = "tb_delayTime";
            this.tb_delayTime.Size = new System.Drawing.Size(100, 22);
            this.tb_delayTime.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(116, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 21);
            this.label8.TabIndex = 23;
            // 
            // tb_com
            // 
            this.tb_com.Location = new System.Drawing.Point(148, 22);
            this.tb_com.Multiline = true;
            this.tb_com.Name = "tb_com";
            this.tb_com.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_com.Size = new System.Drawing.Size(239, 447);
            this.tb_com.TabIndex = 19;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(312, 475);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 19;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.phi2);
            this.tabPage1.Controls.Add(this.tb_server_ref_phi);
            this.tabPage1.Controls.Add(this.phi1);
            this.tabPage1.Controls.Add(this.tb_server_inc_phi);
            this.tabPage1.Controls.Add(this.theta2);
            this.tabPage1.Controls.Add(this.theta1);
            this.tabPage1.Controls.Add(this.tb_server_ref_combox);
            this.tabPage1.Controls.Add(this.tb_server_feed);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tb_server_default);
            this.tabPage1.Controls.Add(this.tb_server_fre_combox);
            this.tabPage1.Controls.Add(this.btn_allFind);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.tb_dTime);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.btn_output);
            this.tabPage1.Controls.Add(this.tb_server_ref);
            this.tabPage1.Controls.Add(this.tb_server_inc);
            this.tabPage1.Controls.Add(this.btn_allOff);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.btn_allOn);
            this.tabPage1.Controls.Add(this.cb_server_num);
            this.tabPage1.Controls.Add(this.linkImg);
            this.tabPage1.Controls.Add(this.tb_server_fre);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.btn_IPrefresh);
            this.tabPage1.Controls.Add(this.btn_espIPset);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.tb_EspIP);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.btnDisConnect);
            this.tabPage1.Controls.Add(this.nUpDnPort);
            this.tabPage1.Controls.Add(this.btnConnect);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.cboAvaiableIPaddr);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(724, 253);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // phi2
            // 
            this.phi2.AutoSize = true;
            this.phi2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.phi2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.phi2.Location = new System.Drawing.Point(376, 141);
            this.phi2.Name = "phi2";
            this.phi2.Size = new System.Drawing.Size(31, 21);
            this.phi2.TabIndex = 49;
            this.phi2.Text = "φ";
            // 
            // tb_server_ref_phi
            // 
            this.tb_server_ref_phi.Enabled = false;
            this.tb_server_ref_phi.Location = new System.Drawing.Point(315, 141);
            this.tb_server_ref_phi.Name = "tb_server_ref_phi";
            this.tb_server_ref_phi.Size = new System.Drawing.Size(55, 22);
            this.tb_server_ref_phi.TabIndex = 48;
            this.tb_server_ref_phi.Text = "0";
            this.tb_server_ref_phi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // phi1
            // 
            this.phi1.AutoSize = true;
            this.phi1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.phi1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.phi1.Location = new System.Drawing.Point(266, 139);
            this.phi1.Name = "phi1";
            this.phi1.Size = new System.Drawing.Size(31, 21);
            this.phi1.TabIndex = 47;
            this.phi1.Text = "φ";
            // 
            // tb_server_inc_phi
            // 
            this.tb_server_inc_phi.Location = new System.Drawing.Point(215, 139);
            this.tb_server_inc_phi.Name = "tb_server_inc_phi";
            this.tb_server_inc_phi.Size = new System.Drawing.Size(55, 22);
            this.tb_server_inc_phi.TabIndex = 46;
            this.tb_server_inc_phi.Text = "0";
            this.tb_server_inc_phi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_server_inc_phi.Leave += new System.EventHandler(this.tb_server_inc_phi_Leave);
            // 
            // theta2
            // 
            this.theta2.AutoSize = true;
            this.theta2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.theta2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.theta2.Location = new System.Drawing.Point(376, 114);
            this.theta2.Name = "theta2";
            this.theta2.Size = new System.Drawing.Size(31, 21);
            this.theta2.TabIndex = 45;
            this.theta2.Text = "θ";
            // 
            // theta1
            // 
            this.theta1.AutoSize = true;
            this.theta1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.theta1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.theta1.Location = new System.Drawing.Point(266, 114);
            this.theta1.Name = "theta1";
            this.theta1.Size = new System.Drawing.Size(31, 21);
            this.theta1.TabIndex = 44;
            this.theta1.Text = "θ";
            // 
            // tb_server_ref_combox
            // 
            this.tb_server_ref_combox.FormattingEnabled = true;
            this.tb_server_ref_combox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tb_server_ref_combox.Items.AddRange(new object[] {
            "-60",
            "-50",
            "-40",
            "-30",
            "-20",
            "-10",
            "0",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60"});
            this.tb_server_ref_combox.Location = new System.Drawing.Point(319, 115);
            this.tb_server_ref_combox.Name = "tb_server_ref_combox";
            this.tb_server_ref_combox.Size = new System.Drawing.Size(55, 20);
            this.tb_server_ref_combox.TabIndex = 43;
            this.tb_server_ref_combox.Text = "0";
            this.tb_server_ref_combox.Visible = false;
            // 
            // tb_server_feed
            // 
            this.tb_server_feed.Location = new System.Drawing.Point(311, 202);
            this.tb_server_feed.Name = "tb_server_feed";
            this.tb_server_feed.Size = new System.Drawing.Size(55, 22);
            this.tb_server_feed.TabIndex = 41;
            this.tb_server_feed.Text = "0";
            this.tb_server_feed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(311, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 21);
            this.label1.TabIndex = 42;
            this.label1.Text = "Feed";
            // 
            // tb_server_default
            // 
            this.tb_server_default.AutoSize = true;
            this.tb_server_default.Location = new System.Drawing.Point(25, 141);
            this.tb_server_default.Name = "tb_server_default";
            this.tb_server_default.Size = new System.Drawing.Size(58, 16);
            this.tb_server_default.TabIndex = 40;
            this.tb_server_default.Text = "Default";
            this.tb_server_default.UseVisualStyleBackColor = true;
            this.tb_server_default.CheckedChanged += new System.EventHandler(this.tb_server_default_CheckedChanged);
            // 
            // tb_server_fre_combox
            // 
            this.tb_server_fre_combox.FormattingEnabled = true;
            this.tb_server_fre_combox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tb_server_fre_combox.Items.AddRange(new object[] {
            "4.7",
            "28"});
            this.tb_server_fre_combox.Location = new System.Drawing.Point(105, 115);
            this.tb_server_fre_combox.Name = "tb_server_fre_combox";
            this.tb_server_fre_combox.Size = new System.Drawing.Size(55, 20);
            this.tb_server_fre_combox.TabIndex = 39;
            this.tb_server_fre_combox.Text = "4.7";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ArduinoControlGUI.Properties.Resources.中正;
            this.pictureBox1.Location = new System.Drawing.Point(550, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // linkImg
            // 
            this.linkImg.Image = global::ArduinoControlGUI.Properties.Resources.disconnect;
            this.linkImg.InitialImage = null;
            this.linkImg.Location = new System.Drawing.Point(500, 3);
            this.linkImg.Name = "linkImg";
            this.linkImg.Size = new System.Drawing.Size(32, 32);
            this.linkImg.TabIndex = 35;
            this.linkImg.TabStop = false;
            // 
            // btn_IPrefresh
            // 
            this.btn_IPrefresh.Location = new System.Drawing.Point(419, 6);
            this.btn_IPrefresh.Name = "btn_IPrefresh";
            this.btn_IPrefresh.Size = new System.Drawing.Size(75, 23);
            this.btn_IPrefresh.TabIndex = 34;
            this.btn_IPrefresh.Text = "Refresh";
            this.btn_IPrefresh.UseVisualStyleBackColor = true;
            this.btn_IPrefresh.Click += new System.EventHandler(this.btn_IPrefresh_Click);
            // 
            // btn_espIPset
            // 
            this.btn_espIPset.Location = new System.Drawing.Point(338, 35);
            this.btn_espIPset.Name = "btn_espIPset";
            this.btn_espIPset.Size = new System.Drawing.Size(75, 23);
            this.btn_espIPset.TabIndex = 33;
            this.btn_espIPset.Text = "Set";
            this.btn_espIPset.UseVisualStyleBackColor = true;
            this.btn_espIPset.Click += new System.EventHandler(this.btn_espIPset_Click);
            // 
            // tb_EspIP
            // 
            this.tb_EspIP.Location = new System.Drawing.Point(244, 34);
            this.tb_EspIP.Name = "tb_EspIP";
            this.tb_EspIP.Size = new System.Drawing.Size(88, 22);
            this.tb_EspIP.TabIndex = 32;
            this.tb_EspIP.Text = "192.168.1.1";
            this.tb_EspIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(186, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "ESP32 IP:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "Server IP :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "Port:";
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.Location = new System.Drawing.Point(335, 6);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(78, 25);
            this.btnDisConnect.TabIndex = 25;
            this.btnDisConnect.Text = "Shut down";
            this.btnDisConnect.UseVisualStyleBackColor = true;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // nUpDnPort
            // 
            this.nUpDnPort.Location = new System.Drawing.Point(85, 35);
            this.nUpDnPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nUpDnPort.Minimum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nUpDnPort.Name = "nUpDnPort";
            this.nUpDnPort.Size = new System.Drawing.Size(71, 22);
            this.nUpDnPort.TabIndex = 23;
            this.nUpDnPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUpDnPort.Value = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(244, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(88, 25);
            this.btnConnect.TabIndex = 24;
            this.btnConnect.Text = "Listen ...";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cboAvaiableIPaddr
            // 
            this.cboAvaiableIPaddr.FormattingEnabled = true;
            this.cboAvaiableIPaddr.Location = new System.Drawing.Point(85, 9);
            this.cboAvaiableIPaddr.Name = "cboAvaiableIPaddr";
            this.cboAvaiableIPaddr.Size = new System.Drawing.Size(133, 20);
            this.cboAvaiableIPaddr.TabIndex = 22;
            // 
            // btn_LogClr
            // 
            this.btn_LogClr.Location = new System.Drawing.Point(6, 6);
            this.btn_LogClr.Name = "btn_LogClr";
            this.btn_LogClr.Size = new System.Drawing.Size(117, 44);
            this.btn_LogClr.TabIndex = 26;
            this.btn_LogClr.Text = "Clear";
            this.btn_LogClr.UseVisualStyleBackColor = true;
            this.btn_LogClr.Click += new System.EventHandler(this.btn_LogClr_Click);
            // 
            // Phase
            // 
            this.Phase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Phase.Controls.Add(this.tabPage1);
            this.Phase.Controls.Add(this.tabPage2);
            this.Phase.Location = new System.Drawing.Point(12, 15);
            this.Phase.Name = "Phase";
            this.Phase.SelectedIndex = 0;
            this.Phase.Size = new System.Drawing.Size(732, 279);
            this.Phase.TabIndex = 22;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBoxLog);
            this.tabPage2.Controls.Add(this.btn_LogClr);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(724, 253);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLog.Location = new System.Drawing.Point(6, 55);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBoxLog.Size = new System.Drawing.Size(712, 192);
            this.richTextBoxLog.TabIndex = 1;
            this.richTextBoxLog.Text = "";
            this.richTextBoxLog.WordWrap = false;
            this.richTextBoxLog.TextChanged += new System.EventHandler(this.richTextBoxLog_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 306);
            this.Controls.Add(this.Phase);
            this.Name = "Form1";
            this.Text = "Arduino GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDnPort)).EndInit();
            this.Phase.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btn_allOn;
        private System.Windows.Forms.Button btn_allOff;
        private System.Windows.Forms.Button btn_allFind;
        private System.Windows.Forms.TextBox tb_dTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_server_ref;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_server_fre;
        private System.Windows.Forms.TextBox tb_server_inc;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cb_server_num;
        private System.Windows.Forms.ListBox lb_findRef;
        private System.Windows.Forms.Button btn_NarrowBeamFind;
        private System.Windows.Forms.Button btn_WideBeamFind;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox tb_delayTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_com;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_IPrefresh;
        private System.Windows.Forms.Button btn_espIPset;
        private System.Windows.Forms.Button btn_LogClr;
        private System.Windows.Forms.TextBox tb_EspIP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDisConnect;
        public System.Windows.Forms.NumericUpDown nUpDnPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cboAvaiableIPaddr;
        private System.Windows.Forms.TabControl Phase;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox linkImg;
        private System.Windows.Forms.ComboBox tb_server_fre_combox;
        private System.Windows.Forms.CheckBox tb_server_default;
        private System.Windows.Forms.TextBox tb_server_feed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tb_server_ref_combox;
        private System.Windows.Forms.Label theta1;
        private System.Windows.Forms.Label theta2;
        private System.Windows.Forms.Label phi2;
        private System.Windows.Forms.TextBox tb_server_ref_phi;
        private System.Windows.Forms.Label phi1;
        private System.Windows.Forms.TextBox tb_server_inc_phi;
    }
}

