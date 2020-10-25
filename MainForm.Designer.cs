namespace IFC_AddGeolocation_Ver1
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox24 = new System.Windows.Forms.TextBox();
			this.textBox23 = new System.Windows.Forms.TextBox();
			this.textBox22 = new System.Windows.Forms.TextBox();
			this.textBox21 = new System.Windows.Forms.TextBox();
			this.textBox20 = new System.Windows.Forms.TextBox();
			this.textBox19 = new System.Windows.Forms.TextBox();
			this.textBox18 = new System.Windows.Forms.TextBox();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.button9 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button12 = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.label17 = new System.Windows.Forms.Label();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.button13 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Выберите исходный файл IFC:";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Файлы IFC(*.ifc)|";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(181, 15);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Обзор";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(140, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Выберите режим расчета:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(22, 315);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(398, 150);
			this.textBox1.TabIndex = 3;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(23, 299);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Консоль приложения";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(21, 93);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(616, 17);
			this.radioButton1.TabIndex = 4;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "По базовой точке (требуются координаты точки в целевой СК из предположения, что в" +
    " данном IFC они равны нулю)";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(21, 116);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(592, 17);
			this.radioButton2.TabIndex = 4;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "По трём точкам (требуются координаты точек в исходном IFC либо из программы-экспо" +
    "ртера, и в целевой СК)";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.textBox5);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label25);
			this.groupBox1.Controls.Add(this.label24);
			this.groupBox1.Controls.Add(this.label23);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(21, 143);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(398, 153);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Среда ввода параметров трансформации  для базовой точки";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(312, 124);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(86, 23);
			this.button4.TabIndex = 4;
			this.button4.Text = "Запустить";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(9, 125);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Сбросить";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(200, 94);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(81, 21);
			this.textBox5.TabIndex = 1;
			this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(200, 70);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(81, 21);
			this.textBox4.TabIndex = 1;
			this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(200, 45);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(81, 21);
			this.textBox3.TabIndex = 1;
			this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(200, 21);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(81, 21);
			this.textBox2.TabIndex = 1;
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.Location = new System.Drawing.Point(6, 99);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(184, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Введите угол поворота в градусах:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(6, 75);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(188, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Введите смещение по оси Оz в мм:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(6, 50);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(188, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Введите смещение по оси Оy в мм:";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label25.Location = new System.Drawing.Point(287, 99);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(11, 13);
			this.label25.TabIndex = 0;
			this.label25.Text = "°";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label24.Location = new System.Drawing.Point(287, 75);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(26, 13);
			this.label24.TabIndex = 0;
			this.label24.Text = "мм.";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label23.Location = new System.Drawing.Point(287, 50);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(26, 13);
			this.label23.TabIndex = 0;
			this.label23.Text = "мм.";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label22.Location = new System.Drawing.Point(287, 26);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(26, 13);
			this.label22.TabIndex = 0;
			this.label22.Text = "мм.";
			this.label22.Click += new System.EventHandler(this.label22_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(6, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(188, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Введите смещение по оси Оx в мм:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox24);
			this.groupBox2.Controls.Add(this.textBox23);
			this.groupBox2.Controls.Add(this.textBox22);
			this.groupBox2.Controls.Add(this.textBox21);
			this.groupBox2.Controls.Add(this.textBox20);
			this.groupBox2.Controls.Add(this.textBox19);
			this.groupBox2.Controls.Add(this.textBox18);
			this.groupBox2.Controls.Add(this.textBox17);
			this.groupBox2.Controls.Add(this.textBox16);
			this.groupBox2.Controls.Add(this.textBox15);
			this.groupBox2.Controls.Add(this.label32);
			this.groupBox2.Controls.Add(this.label31);
			this.groupBox2.Controls.Add(this.label28);
			this.groupBox2.Controls.Add(this.label30);
			this.groupBox2.Controls.Add(this.textBox14);
			this.groupBox2.Controls.Add(this.label29);
			this.groupBox2.Controls.Add(this.label27);
			this.groupBox2.Controls.Add(this.label26);
			this.groupBox2.Controls.Add(this.textBox13);
			this.groupBox2.Controls.Add(this.textBox12);
			this.groupBox2.Controls.Add(this.textBox11);
			this.groupBox2.Controls.Add(this.textBox10);
			this.groupBox2.Controls.Add(this.textBox9);
			this.groupBox2.Controls.Add(this.button9);
			this.groupBox2.Controls.Add(this.button7);
			this.groupBox2.Controls.Add(this.textBox8);
			this.groupBox2.Controls.Add(this.textBox7);
			this.groupBox2.Controls.Add(this.textBox6);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.label21);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label20);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label19);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label18);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox2.Location = new System.Drawing.Point(426, 143);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(411, 322);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Среда ввода параметров трансформации для случая трех точек";
			// 
			// textBox24
			// 
			this.textBox24.Location = new System.Drawing.Point(271, 230);
			this.textBox24.Name = "textBox24";
			this.textBox24.Size = new System.Drawing.Size(69, 21);
			this.textBox24.TabIndex = 20;
			this.textBox24.TextChanged += new System.EventHandler(this.textBox24_TextChanged);
			// 
			// textBox23
			// 
			this.textBox23.Location = new System.Drawing.Point(179, 230);
			this.textBox23.Name = "textBox23";
			this.textBox23.Size = new System.Drawing.Size(69, 21);
			this.textBox23.TabIndex = 19;
			this.textBox23.TextChanged += new System.EventHandler(this.textBox23_TextChanged);
			// 
			// textBox22
			// 
			this.textBox22.Location = new System.Drawing.Point(86, 230);
			this.textBox22.Name = "textBox22";
			this.textBox22.Size = new System.Drawing.Size(69, 21);
			this.textBox22.TabIndex = 18;
			this.textBox22.TextChanged += new System.EventHandler(this.textBox22_TextChanged);
			// 
			// textBox21
			// 
			this.textBox21.Location = new System.Drawing.Point(271, 203);
			this.textBox21.Name = "textBox21";
			this.textBox21.Size = new System.Drawing.Size(69, 21);
			this.textBox21.TabIndex = 17;
			this.textBox21.TextChanged += new System.EventHandler(this.textBox21_TextChanged);
			// 
			// textBox20
			// 
			this.textBox20.Location = new System.Drawing.Point(179, 203);
			this.textBox20.Name = "textBox20";
			this.textBox20.Size = new System.Drawing.Size(69, 21);
			this.textBox20.TabIndex = 16;
			this.textBox20.TextChanged += new System.EventHandler(this.textBox20_TextChanged);
			// 
			// textBox19
			// 
			this.textBox19.Location = new System.Drawing.Point(86, 203);
			this.textBox19.Name = "textBox19";
			this.textBox19.Size = new System.Drawing.Size(69, 21);
			this.textBox19.TabIndex = 15;
			this.textBox19.TextChanged += new System.EventHandler(this.textBox19_TextChanged);
			// 
			// textBox18
			// 
			this.textBox18.Location = new System.Drawing.Point(271, 177);
			this.textBox18.Name = "textBox18";
			this.textBox18.Size = new System.Drawing.Size(69, 21);
			this.textBox18.TabIndex = 14;
			this.textBox18.TextChanged += new System.EventHandler(this.textBox18_TextChanged);
			// 
			// textBox17
			// 
			this.textBox17.Location = new System.Drawing.Point(179, 177);
			this.textBox17.Name = "textBox17";
			this.textBox17.Size = new System.Drawing.Size(69, 21);
			this.textBox17.TabIndex = 13;
			this.textBox17.TextChanged += new System.EventHandler(this.textBox17_TextChanged);
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(86, 177);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(69, 21);
			this.textBox16.TabIndex = 12;
			this.textBox16.TextChanged += new System.EventHandler(this.textBox16_TextChanged);
			// 
			// textBox15
			// 
			this.textBox15.Location = new System.Drawing.Point(140, 264);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(61, 21);
			this.textBox15.TabIndex = 11;
			this.textBox15.TextChanged += new System.EventHandler(this.textBox15_TextChanged);
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label32.Location = new System.Drawing.Point(207, 269);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(18, 13);
			this.label32.TabIndex = 0;
			this.label32.Text = "м.";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label31.Location = new System.Drawing.Point(346, 235);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(26, 13);
			this.label31.TabIndex = 0;
			this.label31.Text = "мм.";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label28.Location = new System.Drawing.Point(346, 137);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(26, 13);
			this.label28.TabIndex = 0;
			this.label28.Text = "мм.";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label30.Location = new System.Drawing.Point(346, 208);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(26, 13);
			this.label30.TabIndex = 0;
			this.label30.Text = "мм.";
			// 
			// textBox14
			// 
			this.textBox14.Location = new System.Drawing.Point(271, 132);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(69, 21);
			this.textBox14.TabIndex = 10;
			this.textBox14.TextChanged += new System.EventHandler(this.textBox14_TextChanged);
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label29.Location = new System.Drawing.Point(346, 182);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(26, 13);
			this.label29.TabIndex = 0;
			this.label29.Text = "мм.";
			this.label29.Click += new System.EventHandler(this.label22_Click);
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label27.Location = new System.Drawing.Point(346, 109);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(26, 13);
			this.label27.TabIndex = 0;
			this.label27.Text = "мм.";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label26.Location = new System.Drawing.Point(346, 78);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(26, 13);
			this.label26.TabIndex = 0;
			this.label26.Text = "мм.";
			this.label26.Click += new System.EventHandler(this.label22_Click);
			// 
			// textBox13
			// 
			this.textBox13.Location = new System.Drawing.Point(179, 132);
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(69, 21);
			this.textBox13.TabIndex = 9;
			this.textBox13.TextChanged += new System.EventHandler(this.textBox13_TextChanged);
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(86, 132);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(69, 21);
			this.textBox12.TabIndex = 8;
			this.textBox12.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(271, 104);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(69, 21);
			this.textBox11.TabIndex = 7;
			this.textBox11.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(179, 104);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(69, 21);
			this.textBox10.TabIndex = 6;
			this.textBox10.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(86, 104);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(69, 21);
			this.textBox9.TabIndex = 5;
			this.textBox9.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(319, 291);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(86, 23);
			this.button9.TabIndex = 4;
			this.button9.Text = "Запустить";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(6, 291);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 2;
			this.button7.Text = "Сбросить";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(271, 73);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(69, 21);
			this.textBox8.TabIndex = 1;
			this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(179, 73);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(69, 21);
			this.textBox7.TabIndex = 1;
			this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(86, 73);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(69, 21);
			this.textBox6.TabIndex = 1;
			this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label12.Location = new System.Drawing.Point(268, 50);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(51, 13);
			this.label12.TabIndex = 0;
			this.label12.Text = "Коорд. Z";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label15.Location = new System.Drawing.Point(9, 269);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(125, 13);
			this.label15.TabIndex = 0;
			this.label15.Text = "Допуск сходимости, м:";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label21.Location = new System.Drawing.Point(6, 238);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(57, 13);
			this.label21.TabIndex = 0;
			this.label21.Text = "Точка №3";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label14.Location = new System.Drawing.Point(6, 131);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(57, 13);
			this.label14.TabIndex = 0;
			this.label14.Text = "Точка №3";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label11.Location = new System.Drawing.Point(176, 50);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(51, 13);
			this.label11.TabIndex = 0;
			this.label11.Text = "Коорд. Y";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label20.Location = new System.Drawing.Point(6, 211);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(57, 13);
			this.label20.TabIndex = 0;
			this.label20.Text = "Точка №2";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label13.Location = new System.Drawing.Point(6, 104);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(57, 13);
			this.label13.TabIndex = 0;
			this.label13.Text = "Точка №2";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label10.Location = new System.Drawing.Point(83, 50);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(51, 13);
			this.label10.TabIndex = 0;
			this.label10.Text = "Коорд. X";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label19.Location = new System.Drawing.Point(6, 185);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(57, 13);
			this.label19.TabIndex = 0;
			this.label19.Text = "Точка №1";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label9.Location = new System.Drawing.Point(6, 78);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(57, 13);
			this.label9.TabIndex = 0;
			this.label9.Text = "Точка №1";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label18.Location = new System.Drawing.Point(83, 156);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(203, 13);
			this.label18.TabIndex = 0;
			this.label18.Text = "Введите требуемые координаты точек";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.Location = new System.Drawing.Point(83, 26);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(224, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "Введите координаты точек в исходном IFC";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(501, 484);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 7;
			this.button5.Text = "Обновить";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(582, 484);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(92, 23);
			this.button6.TabIndex = 8;
			this.button6.Text = "Сбросить всё";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(761, 484);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(75, 23);
			this.button10.TabIndex = 9;
			this.button10.Text = "Выход";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(680, 484);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(75, 23);
			this.button11.TabIndex = 10;
			this.button11.Text = "Справка";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.button12);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.radioButton4);
			this.groupBox3.Controls.Add(this.radioButton3);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.button1);
			this.groupBox3.Location = new System.Drawing.Point(12, 5);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(548, 69);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Параметры работы с файлами";
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(181, 40);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(75, 23);
			this.button12.TabIndex = 5;
			this.button12.Text = "Сохранить";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(268, 10);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(85, 13);
			this.label16.TabIndex = 4;
			this.label16.Text = "Режим работы:";
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(271, 47);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(142, 17);
			this.radioButton4.TabIndex = 3;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "Создать новую версию";
			this.radioButton4.UseVisualStyleBackColor = true;
			this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(271, 26);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(251, 17);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Изменять исходный файл (пока недоступно)";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(15, 45);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(111, 13);
			this.label17.TabIndex = 0;
			this.label17.Text = "Сохранить файл IFC:";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Файлы IFC(*.ifc)|";
			this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(566, 15);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(124, 23);
			this.button13.TabIndex = 5;
			this.button13.Text = "Экспорт настроек";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(567, 45);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(123, 23);
			this.button3.TabIndex = 12;
			this.button3.Text = "Импорт настроек";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click_1);
			// 
			// saveFileDialog2
			// 
			this.saveFileDialog2.Filter = "Таблица, разделенная запятми (*.csv)|";
			this.saveFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog2_FileOk);
			// 
			// openFileDialog2
			// 
			this.openFileDialog2.FileName = "openFileDialog2";
			this.openFileDialog2.Filter = "Таблица, разделенная запятми (*.csv)|";
			this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(843, 516);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button13);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Рабочее пространство";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button button10;
		private System.Windows.Forms.TextBox textBox15;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox textBox24;
		private System.Windows.Forms.TextBox textBox23;
		private System.Windows.Forms.TextBox textBox22;
		private System.Windows.Forms.TextBox textBox21;
		private System.Windows.Forms.TextBox textBox20;
		private System.Windows.Forms.TextBox textBox19;
		private System.Windows.Forms.TextBox textBox18;
		private System.Windows.Forms.TextBox textBox17;
		private System.Windows.Forms.TextBox textBox16;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}