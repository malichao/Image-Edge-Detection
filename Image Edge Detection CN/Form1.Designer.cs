namespace 图像边缘检测
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_open = new System.Windows.Forms.Button();
            this.tab_edge = new System.Windows.Forms.TabControl();
            this.tab_robert = new System.Windows.Forms.TabPage();
            this.pictureBox_robert = new System.Windows.Forms.PictureBox();
            this.tab_sobel = new System.Windows.Forms.TabPage();
            this.pictureBox_sobel = new System.Windows.Forms.PictureBox();
            this.tab_prewitt = new System.Windows.Forms.TabPage();
            this.pictureBox_prewitt = new System.Windows.Forms.PictureBox();
            this.tab_laplacian = new System.Windows.Forms.TabPage();
            this.pictureBox_laplacian = new System.Windows.Forms.PictureBox();
            this.tab_canny = new System.Windows.Forms.TabPage();
            this.pictureBox_canny = new System.Windows.Forms.PictureBox();
            this.button_filter = new System.Windows.Forms.Button();
            this.button_sharpen = new System.Windows.Forms.Button();
            this.trackBar_fazhi = new System.Windows.Forms.TrackBar();
            this.fazhi = new System.Windows.Forms.Label();
            this.trackBar_shapen = new System.Windows.Forms.Label();
            this.button_edge = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_mid = new System.Windows.Forms.RadioButton();
            this.radio_gauss = new System.Windows.Forms.RadioButton();
            this.radio_avr = new System.Windows.Forms.RadioButton();
            this.comboBox_save = new System.Windows.Forms.ComboBox();
            this.checkBox_Boolean = new System.Windows.Forms.CheckBox();
            this.button_undo = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tab_image = new System.Windows.Forms.TabControl();
            this.tab_origin = new System.Windows.Forms.TabPage();
            this.pictureBox_Origin = new System.Windows.Forms.PictureBox();
            this.tab_gray = new System.Windows.Forms.TabPage();
            this.pictureBox_gray = new System.Windows.Forms.PictureBox();
            this.tab_filter = new System.Windows.Forms.TabPage();
            this.pictureBox_filter = new System.Windows.Forms.PictureBox();
            this.tab_sharpen = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.image_dimension = new System.Windows.Forms.Label();
            this.image_size = new System.Windows.Forms.Label();
            this.tab_edge.SuspendLayout();
            this.tab_robert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_robert)).BeginInit();
            this.tab_sobel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sobel)).BeginInit();
            this.tab_prewitt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prewitt)).BeginInit();
            this.tab_laplacian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_laplacian)).BeginInit();
            this.tab_canny.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_canny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_fazhi)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tab_image.SuspendLayout();
            this.tab_origin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Origin)).BeginInit();
            this.tab_gray.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_gray)).BeginInit();
            this.tab_filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_filter)).BeginInit();
            this.tab_sharpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(27, 38);
            this.button_open.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 42);
            this.button_open.TabIndex = 1;
            this.button_open.Text = "打开";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // tab_edge
            // 
            this.tab_edge.Controls.Add(this.tab_robert);
            this.tab_edge.Controls.Add(this.tab_sobel);
            this.tab_edge.Controls.Add(this.tab_prewitt);
            this.tab_edge.Controls.Add(this.tab_laplacian);
            this.tab_edge.Controls.Add(this.tab_canny);
            this.tab_edge.Location = new System.Drawing.Point(966, 117);
            this.tab_edge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_edge.Name = "tab_edge";
            this.tab_edge.SelectedIndex = 0;
            this.tab_edge.Size = new System.Drawing.Size(952, 978);
            this.tab_edge.TabIndex = 2;
            this.tab_edge.Tag = "";
            // 
            // tab_robert
            // 
            this.tab_robert.Controls.Add(this.pictureBox_robert);
            this.tab_robert.Location = new System.Drawing.Point(4, 29);
            this.tab_robert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_robert.Name = "tab_robert";
            this.tab_robert.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_robert.Size = new System.Drawing.Size(944, 945);
            this.tab_robert.TabIndex = 3;
            this.tab_robert.Text = "Robert算子";
            this.tab_robert.UseVisualStyleBackColor = true;
            // 
            // pictureBox_robert
            // 
            this.pictureBox_robert.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_robert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_robert.Name = "pictureBox_robert";
            this.pictureBox_robert.Size = new System.Drawing.Size(938, 925);
            this.pictureBox_robert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_robert.TabIndex = 0;
            this.pictureBox_robert.TabStop = false;
            // 
            // tab_sobel
            // 
            this.tab_sobel.Controls.Add(this.pictureBox_sobel);
            this.tab_sobel.Location = new System.Drawing.Point(4, 29);
            this.tab_sobel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_sobel.Name = "tab_sobel";
            this.tab_sobel.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_sobel.Size = new System.Drawing.Size(944, 945);
            this.tab_sobel.TabIndex = 5;
            this.tab_sobel.Text = "Sobel算子";
            this.tab_sobel.UseVisualStyleBackColor = true;
            // 
            // pictureBox_sobel
            // 
            this.pictureBox_sobel.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_sobel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_sobel.Name = "pictureBox_sobel";
            this.pictureBox_sobel.Size = new System.Drawing.Size(938, 925);
            this.pictureBox_sobel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_sobel.TabIndex = 1;
            this.pictureBox_sobel.TabStop = false;
            // 
            // tab_prewitt
            // 
            this.tab_prewitt.Controls.Add(this.pictureBox_prewitt);
            this.tab_prewitt.Location = new System.Drawing.Point(4, 29);
            this.tab_prewitt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_prewitt.Name = "tab_prewitt";
            this.tab_prewitt.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_prewitt.Size = new System.Drawing.Size(944, 945);
            this.tab_prewitt.TabIndex = 6;
            this.tab_prewitt.Text = "Prewitt算子";
            this.tab_prewitt.UseVisualStyleBackColor = true;
            // 
            // pictureBox_prewitt
            // 
            this.pictureBox_prewitt.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_prewitt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_prewitt.Name = "pictureBox_prewitt";
            this.pictureBox_prewitt.Size = new System.Drawing.Size(938, 925);
            this.pictureBox_prewitt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_prewitt.TabIndex = 2;
            this.pictureBox_prewitt.TabStop = false;
            // 
            // tab_laplacian
            // 
            this.tab_laplacian.Controls.Add(this.pictureBox_laplacian);
            this.tab_laplacian.Location = new System.Drawing.Point(4, 29);
            this.tab_laplacian.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_laplacian.Name = "tab_laplacian";
            this.tab_laplacian.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_laplacian.Size = new System.Drawing.Size(944, 945);
            this.tab_laplacian.TabIndex = 7;
            this.tab_laplacian.Text = "Laplacian算子";
            this.tab_laplacian.UseVisualStyleBackColor = true;
            // 
            // pictureBox_laplacian
            // 
            this.pictureBox_laplacian.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_laplacian.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_laplacian.Name = "pictureBox_laplacian";
            this.pictureBox_laplacian.Size = new System.Drawing.Size(938, 925);
            this.pictureBox_laplacian.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_laplacian.TabIndex = 2;
            this.pictureBox_laplacian.TabStop = false;
            // 
            // tab_canny
            // 
            this.tab_canny.Controls.Add(this.pictureBox_canny);
            this.tab_canny.Location = new System.Drawing.Point(4, 29);
            this.tab_canny.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_canny.Name = "tab_canny";
            this.tab_canny.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_canny.Size = new System.Drawing.Size(944, 945);
            this.tab_canny.TabIndex = 8;
            this.tab_canny.Text = "Canny算子";
            this.tab_canny.UseVisualStyleBackColor = true;
            // 
            // pictureBox_canny
            // 
            this.pictureBox_canny.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_canny.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_canny.Name = "pictureBox_canny";
            this.pictureBox_canny.Size = new System.Drawing.Size(938, 925);
            this.pictureBox_canny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_canny.TabIndex = 3;
            this.pictureBox_canny.TabStop = false;
            // 
            // button_filter
            // 
            this.button_filter.Location = new System.Drawing.Point(225, 38);
            this.button_filter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_filter.Name = "button_filter";
            this.button_filter.Size = new System.Drawing.Size(75, 42);
            this.button_filter.TabIndex = 3;
            this.button_filter.Text = "滤波";
            this.button_filter.UseVisualStyleBackColor = true;
            this.button_filter.Click += new System.EventHandler(this.button_filter_Click);
            // 
            // button_sharpen
            // 
            this.button_sharpen.Location = new System.Drawing.Point(309, 38);
            this.button_sharpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_sharpen.Name = "button_sharpen";
            this.button_sharpen.Size = new System.Drawing.Size(75, 42);
            this.button_sharpen.TabIndex = 4;
            this.button_sharpen.Text = "锐化";
            this.button_sharpen.UseVisualStyleBackColor = true;
            this.button_sharpen.Click += new System.EventHandler(this.button_sharpen_Click);
            // 
            // trackBar_fazhi
            // 
            this.trackBar_fazhi.Location = new System.Drawing.Point(566, 18);
            this.trackBar_fazhi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar_fazhi.Maximum = 255;
            this.trackBar_fazhi.Name = "trackBar_fazhi";
            this.trackBar_fazhi.Size = new System.Drawing.Size(255, 69);
            this.trackBar_fazhi.TabIndex = 5;
            this.trackBar_fazhi.TickFrequency = 26;
            this.trackBar_fazhi.Scroll += new System.EventHandler(this.trackBar_fazhi_Scroll);
            // 
            // fazhi
            // 
            this.fazhi.AutoSize = true;
            this.fazhi.Location = new System.Drawing.Point(774, 70);
            this.fazhi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fazhi.Name = "fazhi";
            this.fazhi.Size = new System.Drawing.Size(36, 20);
            this.fazhi.TabIndex = 45;
            this.fazhi.Text = "255";
            // 
            // trackBar_shapen
            // 
            this.trackBar_shapen.AutoSize = true;
            this.trackBar_shapen.Location = new System.Drawing.Point(687, 70);
            this.trackBar_shapen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.trackBar_shapen.Name = "trackBar_shapen";
            this.trackBar_shapen.Size = new System.Drawing.Size(89, 20);
            this.trackBar_shapen.TabIndex = 44;
            this.trackBar_shapen.Text = "检测阀值：";
            // 
            // button_edge
            // 
            this.button_edge.Location = new System.Drawing.Point(489, 38);
            this.button_edge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_edge.Name = "button_edge";
            this.button_edge.Size = new System.Drawing.Size(75, 42);
            this.button_edge.TabIndex = 46;
            this.button_edge.Text = "检测";
            this.button_edge.UseVisualStyleBackColor = true;
            this.button_edge.Click += new System.EventHandler(this.button_edge1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio_mid);
            this.groupBox1.Controls.Add(this.radio_gauss);
            this.groupBox1.Controls.Add(this.radio_avr);
            this.groupBox1.Controls.Add(this.fazhi);
            this.groupBox1.Controls.Add(this.trackBar_shapen);
            this.groupBox1.Controls.Add(this.comboBox_save);
            this.groupBox1.Controls.Add(this.checkBox_Boolean);
            this.groupBox1.Controls.Add(this.button_undo);
            this.groupBox1.Controls.Add(this.button_edge);
            this.groupBox1.Controls.Add(this.button_sharpen);
            this.groupBox1.Controls.Add(this.button_filter);
            this.groupBox1.Controls.Add(this.button_open);
            this.groupBox1.Controls.Add(this.button_save);
            this.groupBox1.Controls.Add(this.trackBar_fazhi);
            this.groupBox1.Location = new System.Drawing.Point(18, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(933, 102);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // radio_mid
            // 
            this.radio_mid.AutoSize = true;
            this.radio_mid.Checked = true;
            this.radio_mid.Location = new System.Drawing.Point(117, 45);
            this.radio_mid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radio_mid.Name = "radio_mid";
            this.radio_mid.Size = new System.Drawing.Size(98, 24);
            this.radio_mid.TabIndex = 56;
            this.radio_mid.TabStop = true;
            this.radio_mid.Text = "中值滤波";
            this.radio_mid.UseVisualStyleBackColor = true;
            this.radio_mid.Click += new System.EventHandler(this.radio_mid_Click);
            // 
            // radio_gauss
            // 
            this.radio_gauss.AutoSize = true;
            this.radio_gauss.Location = new System.Drawing.Point(117, 72);
            this.radio_gauss.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radio_gauss.Name = "radio_gauss";
            this.radio_gauss.Size = new System.Drawing.Size(98, 24);
            this.radio_gauss.TabIndex = 55;
            this.radio_gauss.Text = "高斯滤波";
            this.radio_gauss.UseVisualStyleBackColor = true;
            this.radio_gauss.Click += new System.EventHandler(this.radio_gauss_Click);
            // 
            // radio_avr
            // 
            this.radio_avr.AutoSize = true;
            this.radio_avr.Location = new System.Drawing.Point(117, 20);
            this.radio_avr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radio_avr.Name = "radio_avr";
            this.radio_avr.Size = new System.Drawing.Size(98, 24);
            this.radio_avr.TabIndex = 54;
            this.radio_avr.Text = "均值滤波";
            this.radio_avr.UseVisualStyleBackColor = true;
            this.radio_avr.Click += new System.EventHandler(this.radio_avr_Click);
            // 
            // comboBox_save
            // 
            this.comboBox_save.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_save.FormattingEnabled = true;
            this.comboBox_save.Items.AddRange(new object[] {
            "JPG",
            "BMP",
            "PNG"});
            this.comboBox_save.Location = new System.Drawing.Point(822, 60);
            this.comboBox_save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_save.Name = "comboBox_save";
            this.comboBox_save.Size = new System.Drawing.Size(91, 28);
            this.comboBox_save.TabIndex = 1;
            this.comboBox_save.SelectedIndexChanged += new System.EventHandler(this.comboBox_save_SelectedIndexChanged);
            // 
            // checkBox_Boolean
            // 
            this.checkBox_Boolean.AutoSize = true;
            this.checkBox_Boolean.Location = new System.Drawing.Point(588, 68);
            this.checkBox_Boolean.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_Boolean.Name = "checkBox_Boolean";
            this.checkBox_Boolean.Size = new System.Drawing.Size(83, 24);
            this.checkBox_Boolean.TabIndex = 51;
            this.checkBox_Boolean.Text = "二值化";
            this.checkBox_Boolean.UseVisualStyleBackColor = true;
            // 
            // button_undo
            // 
            this.button_undo.Location = new System.Drawing.Point(399, 38);
            this.button_undo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_undo.Name = "button_undo";
            this.button_undo.Size = new System.Drawing.Size(75, 42);
            this.button_undo.TabIndex = 47;
            this.button_undo.Text = "还原";
            this.button_undo.UseVisualStyleBackColor = true;
            this.button_undo.Click += new System.EventHandler(this.button_Undo_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(819, 18);
            this.button_save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(96, 38);
            this.button_save.TabIndex = 52;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(966, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(942, 102);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // tab_image
            // 
            this.tab_image.Controls.Add(this.tab_origin);
            this.tab_image.Controls.Add(this.tab_gray);
            this.tab_image.Controls.Add(this.tab_filter);
            this.tab_image.Controls.Add(this.tab_sharpen);
            this.tab_image.Location = new System.Drawing.Point(4, 117);
            this.tab_image.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_image.Multiline = true;
            this.tab_image.Name = "tab_image";
            this.tab_image.SelectedIndex = 0;
            this.tab_image.Size = new System.Drawing.Size(952, 978);
            this.tab_image.TabIndex = 48;
            // 
            // tab_origin
            // 
            this.tab_origin.Controls.Add(this.pictureBox_Origin);
            this.tab_origin.Location = new System.Drawing.Point(4, 29);
            this.tab_origin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_origin.Name = "tab_origin";
            this.tab_origin.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_origin.Size = new System.Drawing.Size(944, 945);
            this.tab_origin.TabIndex = 0;
            this.tab_origin.Text = "原图";
            this.tab_origin.UseVisualStyleBackColor = true;
            // 
            // pictureBox_Origin
            // 
            this.pictureBox_Origin.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Origin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_Origin.Name = "pictureBox_Origin";
            this.pictureBox_Origin.Size = new System.Drawing.Size(938, 925);
            this.pictureBox_Origin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Origin.TabIndex = 1;
            this.pictureBox_Origin.TabStop = false;
            // 
            // tab_gray
            // 
            this.tab_gray.Controls.Add(this.pictureBox_gray);
            this.tab_gray.Location = new System.Drawing.Point(4, 29);
            this.tab_gray.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_gray.Name = "tab_gray";
            this.tab_gray.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_gray.Size = new System.Drawing.Size(944, 945);
            this.tab_gray.TabIndex = 1;
            this.tab_gray.Text = "灰度";
            this.tab_gray.UseVisualStyleBackColor = true;
            // 
            // pictureBox_gray
            // 
            this.pictureBox_gray.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_gray.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_gray.Name = "pictureBox_gray";
            this.pictureBox_gray.Size = new System.Drawing.Size(938, 925);
            this.pictureBox_gray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_gray.TabIndex = 1;
            this.pictureBox_gray.TabStop = false;
            // 
            // tab_filter
            // 
            this.tab_filter.Controls.Add(this.pictureBox_filter);
            this.tab_filter.Location = new System.Drawing.Point(4, 29);
            this.tab_filter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_filter.Name = "tab_filter";
            this.tab_filter.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_filter.Size = new System.Drawing.Size(944, 945);
            this.tab_filter.TabIndex = 2;
            this.tab_filter.Text = "滤波";
            this.tab_filter.UseVisualStyleBackColor = true;
            // 
            // pictureBox_filter
            // 
            this.pictureBox_filter.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_filter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_filter.Name = "pictureBox_filter";
            this.pictureBox_filter.Size = new System.Drawing.Size(938, 925);
            this.pictureBox_filter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_filter.TabIndex = 1;
            this.pictureBox_filter.TabStop = false;
            // 
            // tab_sharpen
            // 
            this.tab_sharpen.Controls.Add(this.pictureBox3);
            this.tab_sharpen.Location = new System.Drawing.Point(4, 29);
            this.tab_sharpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_sharpen.Name = "tab_sharpen";
            this.tab_sharpen.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_sharpen.Size = new System.Drawing.Size(944, 945);
            this.tab_sharpen.TabIndex = 3;
            this.tab_sharpen.Text = "锐化";
            this.tab_sharpen.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(938, 925);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // image_dimension
            // 
            this.image_dimension.AutoSize = true;
            this.image_dimension.Location = new System.Drawing.Point(602, 118);
            this.image_dimension.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.image_dimension.Name = "image_dimension";
            this.image_dimension.Size = new System.Drawing.Size(77, 20);
            this.image_dimension.TabIndex = 2;
            this.image_dimension.Text = "图像尺寸:";
            // 
            // image_size
            // 
            this.image_size.AutoSize = true;
            this.image_size.Location = new System.Drawing.Point(788, 118);
            this.image_size.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.image_size.Name = "image_size";
            this.image_size.Size = new System.Drawing.Size(77, 20);
            this.image_size.TabIndex = 2;
            this.image_size.Text = "图像大小:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1926, 1103);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.image_size);
            this.Controls.Add(this.image_dimension);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tab_image);
            this.Controls.Add(this.tab_edge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图像边缘检测 v6.1-麻立超";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tab_edge.ResumeLayout(false);
            this.tab_robert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_robert)).EndInit();
            this.tab_sobel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sobel)).EndInit();
            this.tab_prewitt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prewitt)).EndInit();
            this.tab_laplacian.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_laplacian)).EndInit();
            this.tab_canny.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_canny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_fazhi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tab_image.ResumeLayout(false);
            this.tab_origin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Origin)).EndInit();
            this.tab_gray.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_gray)).EndInit();
            this.tab_filter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_filter)).EndInit();
            this.tab_sharpen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.TabControl tab_edge;
        private System.Windows.Forms.Button button_filter;
        private System.Windows.Forms.Button button_sharpen;
        private System.Windows.Forms.TrackBar trackBar_fazhi;
        private System.Windows.Forms.Label fazhi;
        private System.Windows.Forms.Label trackBar_shapen;
        private System.Windows.Forms.Button button_edge;
        private System.Windows.Forms.TabPage tab_robert;
        private System.Windows.Forms.PictureBox pictureBox_robert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tab_sobel;
        private System.Windows.Forms.PictureBox pictureBox_sobel;
        private System.Windows.Forms.Button button_undo;
        private System.Windows.Forms.CheckBox checkBox_Boolean;
        private System.Windows.Forms.TabPage tab_prewitt;
        private System.Windows.Forms.TabPage tab_laplacian;
        private System.Windows.Forms.PictureBox pictureBox_prewitt;
        private System.Windows.Forms.PictureBox pictureBox_laplacian;
        private System.Windows.Forms.TabControl tab_image;
        private System.Windows.Forms.TabPage tab_origin;
        private System.Windows.Forms.PictureBox pictureBox_Origin;
        private System.Windows.Forms.TabPage tab_gray;
        private System.Windows.Forms.PictureBox pictureBox_gray;
        private System.Windows.Forms.TabPage tab_filter;
        private System.Windows.Forms.PictureBox pictureBox_filter;
        private System.Windows.Forms.TabPage tab_sharpen;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label image_dimension;
        private System.Windows.Forms.Label image_size;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_save;
        private System.Windows.Forms.TabPage tab_canny;
        private System.Windows.Forms.PictureBox pictureBox_canny;
        private System.Windows.Forms.RadioButton radio_gauss;
        private System.Windows.Forms.RadioButton radio_avr;
        private System.Windows.Forms.RadioButton radio_mid;
    }
}

