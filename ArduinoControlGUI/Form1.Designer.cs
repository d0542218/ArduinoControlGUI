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
            this.lb_refdegree = new System.Windows.Forms.ListBox();
            this.btn_gen = new System.Windows.Forms.Button();
            this.pb_phase = new System.Windows.Forms.PictureBox();
            this.pb_degree = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_port = new System.Windows.Forms.ComboBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Discon = new System.Windows.Forms.Button();
            this.btn_WideBeamFind = new System.Windows.Forms.Button();
            this.lb_findRef = new System.Windows.Forms.ListBox();
            this.btn_NarrowBeamFind = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.tb_com = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_delayTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_incdegree = new System.Windows.Forms.ListBox();
            this.btn_IPrefresh = new System.Windows.Forms.Button();
            this.btn_espIPset = new System.Windows.Forms.Button();
            this.tb_EspIP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_LogClr = new System.Windows.Forms.Button();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cboAvaiableIPaddr = new System.Windows.Forms.ComboBox();
            this.nUpDnPort = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_phase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_degree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDnPort)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_refdegree
            // 
            this.lb_refdegree.ColumnWidth = 3;
            this.lb_refdegree.FormattingEnabled = true;
            this.lb_refdegree.ItemHeight = 12;
            this.lb_refdegree.Items.AddRange(new object[] {
            "degree -60",
            "degree -50",
            "degree -40",
            "degree -30",
            "degree -20",
            "degree -10",
            "degree   0",
            "degree  10",
            "degree  20",
            "degree  30",
            "degree  40",
            "degree  50",
            "degree  60"});
            this.lb_refdegree.Location = new System.Drawing.Point(273, 171);
            this.lb_refdegree.Name = "lb_refdegree";
            this.lb_refdegree.Size = new System.Drawing.Size(120, 316);
            this.lb_refdegree.TabIndex = 2;
            this.lb_refdegree.SelectedIndexChanged += new System.EventHandler(this.lb_refdegree_SelectedIndexChanged);
            // 
            // btn_gen
            // 
            this.btn_gen.Location = new System.Drawing.Point(277, 493);
            this.btn_gen.Name = "btn_gen";
            this.btn_gen.Size = new System.Drawing.Size(111, 36);
            this.btn_gen.TabIndex = 3;
            this.btn_gen.Text = "Output";
            this.btn_gen.UseVisualStyleBackColor = true;
            this.btn_gen.Click += new System.EventHandler(this.btn_gen_Click);
            // 
            // pb_phase
            // 
            this.pb_phase.Image = global::ArduinoControlGUI.Properties.Resources.Phase_distribution_0;
            this.pb_phase.Location = new System.Drawing.Point(7, 32);
            this.pb_phase.Name = "pb_phase";
            this.pb_phase.Size = new System.Drawing.Size(244, 229);
            this.pb_phase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_phase.TabIndex = 1;
            this.pb_phase.TabStop = false;
            // 
            // pb_degree
            // 
            this.pb_degree.BackColor = System.Drawing.SystemColors.Control;
            this.pb_degree.Image = global::ArduinoControlGUI.Properties.Resources.Polar_0;
            this.pb_degree.Location = new System.Drawing.Point(7, 309);
            this.pb_degree.Name = "pb_degree";
            this.pb_degree.Size = new System.Drawing.Size(244, 240);
            this.pb_degree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_degree.TabIndex = 0;
            this.pb_degree.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ArduinoControlGUI.Properties.Resources.中正;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(101, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Phase";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(110, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Polar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(283, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Reflection";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(393, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "COM";
            // 
            // cb_port
            // 
            this.cb_port.FormattingEnabled = true;
            this.cb_port.Location = new System.Drawing.Point(454, 22);
            this.cb_port.Name = "cb_port";
            this.cb_port.Size = new System.Drawing.Size(121, 20);
            this.cb_port.TabIndex = 9;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(312, 19);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 10;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM5";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(587, 19);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 11;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Discon
            // 
            this.btn_Discon.Location = new System.Drawing.Point(668, 19);
            this.btn_Discon.Name = "btn_Discon";
            this.btn_Discon.Size = new System.Drawing.Size(75, 23);
            this.btn_Discon.TabIndex = 12;
            this.btn_Discon.Text = "Disconnect";
            this.btn_Discon.UseVisualStyleBackColor = true;
            this.btn_Discon.Click += new System.EventHandler(this.btn_Discon_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_clear);
            this.groupBox1.Controls.Add(this.tb_com);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tb_delayTime);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btn_WideBeamFind);
            this.groupBox1.Controls.Add(this.btn_NarrowBeamFind);
            this.groupBox1.Controls.Add(this.lb_findRef);
            this.groupBox1.Location = new System.Drawing.Point(416, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 504);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find RX";
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
            // tb_com
            // 
            this.tb_com.Location = new System.Drawing.Point(148, 22);
            this.tb_com.Multiline = true;
            this.tb_com.Name = "tb_com";
            this.tb_com.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_com.Size = new System.Drawing.Size(239, 447);
            this.tb_com.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(116, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 21);
            this.label8.TabIndex = 23;
            this.label8.Text = "ms";
            // 
            // tb_delayTime
            // 
            this.tb_delayTime.Location = new System.Drawing.Point(10, 50);
            this.tb_delayTime.Name = "tb_delayTime";
            this.tb_delayTime.Size = new System.Drawing.Size(100, 22);
            this.tb_delayTime.TabIndex = 22;
            this.tb_delayTime.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(28, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 21);
            this.label7.TabIndex = 21;
            this.label7.Text = "Delay Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(19, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 21);
            this.label6.TabIndex = 20;
            this.label6.Text = "Incidence";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(283, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "Incidence";
            // 
            // lb_incdegree
            // 
            this.lb_incdegree.ColumnWidth = 3;
            this.lb_incdegree.FormattingEnabled = true;
            this.lb_incdegree.ItemHeight = 12;
            this.lb_incdegree.Items.AddRange(new object[] {
            "degree -30",
            "degree   0",
            "degree   30"});
            this.lb_incdegree.Location = new System.Drawing.Point(273, 92);
            this.lb_incdegree.Name = "lb_incdegree";
            this.lb_incdegree.Size = new System.Drawing.Size(120, 52);
            this.lb_incdegree.TabIndex = 17;
            // 
            // btn_IPrefresh
            // 
            this.btn_IPrefresh.Location = new System.Drawing.Point(419, 35);
            this.btn_IPrefresh.Name = "btn_IPrefresh";
            this.btn_IPrefresh.Size = new System.Drawing.Size(75, 23);
            this.btn_IPrefresh.TabIndex = 34;
            this.btn_IPrefresh.Text = "Refresh";
            this.btn_IPrefresh.UseVisualStyleBackColor = true;
            this.btn_IPrefresh.Click += new System.EventHandler(this.btn_IPrefresh_Click);
            // 
            // btn_espIPset
            // 
            this.btn_espIPset.Location = new System.Drawing.Point(404, 66);
            this.btn_espIPset.Name = "btn_espIPset";
            this.btn_espIPset.Size = new System.Drawing.Size(75, 23);
            this.btn_espIPset.TabIndex = 33;
            this.btn_espIPset.Text = "Set";
            this.btn_espIPset.UseVisualStyleBackColor = true;
            this.btn_espIPset.Click += new System.EventHandler(this.btn_espIPset_Click);
            // 
            // tb_EspIP
            // 
            this.tb_EspIP.Location = new System.Drawing.Point(222, 66);
            this.tb_EspIP.Name = "tb_EspIP";
            this.tb_EspIP.Size = new System.Drawing.Size(176, 22);
            this.tb_EspIP.TabIndex = 32;
            this.tb_EspIP.Text = "192.168.1.1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(152, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "ESP8266 IP:";
            // 
            // btn_LogClr
            // 
            this.btn_LogClr.Location = new System.Drawing.Point(606, 44);
            this.btn_LogClr.Name = "btn_LogClr";
            this.btn_LogClr.Size = new System.Drawing.Size(117, 44);
            this.btn_LogClr.TabIndex = 26;
            this.btn_LogClr.Text = "Clear";
            this.btn_LogClr.UseVisualStyleBackColor = true;
            this.btn_LogClr.Click += new System.EventHandler(this.btn_LogClr_Click);
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLog.Location = new System.Drawing.Point(6, 94);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBoxLog.Size = new System.Drawing.Size(813, 522);
            this.richTextBoxLog.TabIndex = 1;
            this.richTextBoxLog.Text = "";
            this.richTextBoxLog.WordWrap = false;
            this.richTextBoxLog.TextChanged += new System.EventHandler(this.richTextBoxLog_TextChanged);
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.Location = new System.Drawing.Point(335, 35);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(78, 25);
            this.btnDisConnect.TabIndex = 25;
            this.btnDisConnect.Text = "Shut down";
            this.btnDisConnect.UseVisualStyleBackColor = true;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(241, 35);
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
            this.cboAvaiableIPaddr.Location = new System.Drawing.Point(85, 35);
            this.cboAvaiableIPaddr.Name = "cboAvaiableIPaddr";
            this.cboAvaiableIPaddr.Size = new System.Drawing.Size(133, 20);
            this.cboAvaiableIPaddr.TabIndex = 22;
            // 
            // nUpDnPort
            // 
            this.nUpDnPort.Location = new System.Drawing.Point(58, 67);
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
            this.nUpDnPort.Value = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "Port:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "Server IP :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(35, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(387, 22);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "0_0_n;0";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(428, 7);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 21;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(135, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(833, 657);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_IPrefresh);
            this.tabPage1.Controls.Add(this.btn_espIPset);
            this.tabPage1.Controls.Add(this.btn_LogClr);
            this.tabPage1.Controls.Add(this.btn_send);
            this.tabPage1.Controls.Add(this.tb_EspIP);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.richTextBoxLog);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.btnDisConnect);
            this.tabPage1.Controls.Add(this.nUpDnPort);
            this.tabPage1.Controls.Add(this.btnConnect);
            this.tabPage1.Controls.Add(this.cboAvaiableIPaddr);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(825, 631);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lb_incdegree);
            this.tabPage2.Controls.Add(this.pb_phase);
            this.tabPage2.Controls.Add(this.pb_degree);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btn_Connect);
            this.tabPage2.Controls.Add(this.btn_Discon);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.lb_refdegree);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btn_Refresh);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.cb_port);
            this.tabPage2.Controls.Add(this.btn_gen);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(825, 631);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Serial Port";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_allOn
            // 
            this.btn_allOn.Location = new System.Drawing.Point(23, 352);
            this.btn_allOn.Name = "btn_allOn";
            this.btn_allOn.Size = new System.Drawing.Size(75, 23);
            this.btn_allOn.TabIndex = 23;
            this.btn_allOn.Text = "All ON";
            this.btn_allOn.UseVisualStyleBackColor = true;
            this.btn_allOn.Click += new System.EventHandler(this.btn_allOn_Click);
            // 
            // btn_allOff
            // 
            this.btn_allOff.Location = new System.Drawing.Point(23, 381);
            this.btn_allOff.Name = "btn_allOff";
            this.btn_allOff.Size = new System.Drawing.Size(75, 23);
            this.btn_allOff.TabIndex = 24;
            this.btn_allOff.Text = "All OFF";
            this.btn_allOff.UseVisualStyleBackColor = true;
            this.btn_allOff.Click += new System.EventHandler(this.btn_allOff_Click);
            // 
            // btn_allFind
            // 
            this.btn_allFind.Location = new System.Drawing.Point(23, 490);
            this.btn_allFind.Name = "btn_allFind";
            this.btn_allFind.Size = new System.Drawing.Size(75, 23);
            this.btn_allFind.TabIndex = 25;
            this.btn_allFind.Text = "All Find";
            this.btn_allFind.UseVisualStyleBackColor = true;
            this.btn_allFind.Click += new System.EventHandler(this.btn_allFind_Click);
            // 
            // tb_dTime
            // 
            this.tb_dTime.Location = new System.Drawing.Point(12, 462);
            this.tb_dTime.Name = "tb_dTime";
            this.tb_dTime.Size = new System.Drawing.Size(100, 22);
            this.tb_dTime.TabIndex = 26;
            this.tb_dTime.Text = "1000";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(12, 429);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 21);
            this.label12.TabIndex = 27;
            this.label12.Text = "Delay Time";
            // 
            // tb_server_ref
            // 
            this.tb_server_ref.Location = new System.Drawing.Point(24, 197);
            this.tb_server_ref.Name = "tb_server_ref";
            this.tb_server_ref.Size = new System.Drawing.Size(55, 22);
            this.tb_server_ref.TabIndex = 29;
            this.tb_server_ref.Text = "0";
            this.tb_server_ref.TextChanged += new System.EventHandler(this.tb_server_ref_TextChanged);
            // 
            // btn_output
            // 
            this.btn_output.Location = new System.Drawing.Point(23, 299);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(75, 23);
            this.btn_output.TabIndex = 28;
            this.btn_output.Text = "Output";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(19, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 21);
            this.label13.TabIndex = 30;
            this.label13.Text = "Reflection";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(16, 235);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 21);
            this.label14.TabIndex = 32;
            this.label14.Text = "Frequency";
            // 
            // tb_server_fre
            // 
            this.tb_server_fre.Location = new System.Drawing.Point(24, 259);
            this.tb_server_fre.Name = "tb_server_fre";
            this.tb_server_fre.Size = new System.Drawing.Size(55, 22);
            this.tb_server_fre.TabIndex = 33;
            this.tb_server_fre.Text = "0";
            this.tb_server_fre.TextChanged += new System.EventHandler(this.tb_server_fre_TextChanged);
            // 
            // tb_server_inc
            // 
            this.tb_server_inc.Location = new System.Drawing.Point(23, 135);
            this.tb_server_inc.Name = "tb_server_inc";
            this.tb_server_inc.Size = new System.Drawing.Size(55, 22);
            this.tb_server_inc.TabIndex = 34;
            this.tb_server_inc.Text = "0";
            this.tb_server_inc.TextChanged += new System.EventHandler(this.tb_server_inc_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label15.Location = new System.Drawing.Point(86, 259);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 21);
            this.label15.TabIndex = 35;
            this.label15.Text = "GHz";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(825, 631);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(229, 123);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 684);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tb_server_inc);
            this.Controls.Add(this.tb_server_fre);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tb_server_ref);
            this.Controls.Add(this.btn_output);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tb_dTime);
            this.Controls.Add(this.btn_allFind);
            this.Controls.Add(this.btn_allOff);
            this.Controls.Add(this.btn_allOn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Name = "Form1";
            this.Text = "Arduino GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_phase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_degree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDnPort)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pb_degree;
        private System.Windows.Forms.PictureBox pb_phase;
        private System.Windows.Forms.ListBox lb_refdegree;
        private System.Windows.Forms.Button btn_gen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_port;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Discon;
        private System.Windows.Forms.Button btn_WideBeamFind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lb_incdegree;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_NarrowBeamFind;
        private System.Windows.Forms.ListBox lb_findRef;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_com;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btnDisConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cboAvaiableIPaddr;
        public System.Windows.Forms.NumericUpDown nUpDnPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        public System.IO.Ports.SerialPort serialPort1;
        public System.Windows.Forms.TextBox tb_delayTime;
        private System.Windows.Forms.Button btn_LogClr;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_IPrefresh;
        private System.Windows.Forms.Button btn_espIPset;
        private System.Windows.Forms.TextBox tb_EspIP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox2;
    }
}

