namespace Fractals
{
    partial class FractalRenderWindow
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.depthUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.widthUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.ratioLabel = new System.Windows.Forms.Label();
            this.angleLabel1 = new System.Windows.Forms.Label();
            this.angleLabel2 = new System.Windows.Forms.Label();
            this.ratioUpDown = new System.Windows.Forms.NumericUpDown();
            this.angleUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.angleUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.colorButton1 = new System.Windows.Forms.Button();
            this.colorButton2 = new System.Windows.Forms.Button();
            this.separator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratioUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(612, 472);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // depthUpDown
            // 
            this.depthUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.depthUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.depthUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.depthUpDown.ForeColor = System.Drawing.Color.White;
            this.depthUpDown.Location = new System.Drawing.Point(638, 30);
            this.depthUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.depthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.depthUpDown.Name = "depthUpDown";
            this.depthUpDown.Size = new System.Drawing.Size(124, 19);
            this.depthUpDown.TabIndex = 1;
            this.depthUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.depthUpDown.ValueChanged += new System.EventHandler(this.depthUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(638, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Глубина рекурсии";
            // 
            // widthLabel
            // 
            this.widthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.widthLabel.AutoSize = true;
            this.widthLabel.ForeColor = System.Drawing.Color.White;
            this.widthLabel.Location = new System.Drawing.Point(638, 52);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(52, 15);
            this.widthLabel.TabIndex = 2;
            this.widthLabel.Text = "Ширина";
            // 
            // widthUpDown
            // 
            this.widthUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.widthUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.widthUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.widthUpDown.ForeColor = System.Drawing.Color.White;
            this.widthUpDown.Location = new System.Drawing.Point(638, 70);
            this.widthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthUpDown.Name = "widthUpDown";
            this.widthUpDown.Size = new System.Drawing.Size(124, 19);
            this.widthUpDown.TabIndex = 1;
            this.widthUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.widthUpDown.ValueChanged += new System.EventHandler(this.widthUpDown_ValueChanged);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(638, 447);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(124, 37);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ratioLabel
            // 
            this.ratioLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ratioLabel.AutoSize = true;
            this.ratioLabel.ForeColor = System.Drawing.Color.White;
            this.ratioLabel.Location = new System.Drawing.Point(638, 92);
            this.ratioLabel.Name = "ratioLabel";
            this.ratioLabel.Size = new System.Drawing.Size(124, 15);
            this.ratioLabel.TabIndex = 2;
            this.ratioLabel.Text = "Отношение отрезков";
            // 
            // angleLabel1
            // 
            this.angleLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angleLabel1.AutoSize = true;
            this.angleLabel1.ForeColor = System.Drawing.Color.White;
            this.angleLabel1.Location = new System.Drawing.Point(638, 132);
            this.angleLabel1.Name = "angleLabel1";
            this.angleLabel1.Size = new System.Drawing.Size(42, 15);
            this.angleLabel1.TabIndex = 2;
            this.angleLabel1.Text = "Угол 1";
            // 
            // angleLabel2
            // 
            this.angleLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angleLabel2.AutoSize = true;
            this.angleLabel2.ForeColor = System.Drawing.Color.White;
            this.angleLabel2.Location = new System.Drawing.Point(638, 172);
            this.angleLabel2.Name = "angleLabel2";
            this.angleLabel2.Size = new System.Drawing.Size(42, 15);
            this.angleLabel2.TabIndex = 2;
            this.angleLabel2.Text = "Угол 2";
            // 
            // ratioUpDown
            // 
            this.ratioUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ratioUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ratioUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ratioUpDown.DecimalPlaces = 2;
            this.ratioUpDown.ForeColor = System.Drawing.Color.White;
            this.ratioUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ratioUpDown.Location = new System.Drawing.Point(638, 110);
            this.ratioUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.ratioUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ratioUpDown.Name = "ratioUpDown";
            this.ratioUpDown.Size = new System.Drawing.Size(124, 19);
            this.ratioUpDown.TabIndex = 4;
            this.ratioUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            this.ratioUpDown.ValueChanged += new System.EventHandler(this.ratioUpDown_ValueChanged);
            // 
            // angleUpDown1
            // 
            this.angleUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angleUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.angleUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.angleUpDown1.ForeColor = System.Drawing.Color.White;
            this.angleUpDown1.Location = new System.Drawing.Point(638, 150);
            this.angleUpDown1.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.angleUpDown1.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.angleUpDown1.Name = "angleUpDown1";
            this.angleUpDown1.Size = new System.Drawing.Size(124, 19);
            this.angleUpDown1.TabIndex = 5;
            this.angleUpDown1.Value = new decimal(new int[] {
            60,
            0,
            0,
            -2147483648});
            this.angleUpDown1.ValueChanged += new System.EventHandler(this.angleUpDown1_ValueChanged);
            // 
            // angleUpDown2
            // 
            this.angleUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angleUpDown2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.angleUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.angleUpDown2.ForeColor = System.Drawing.Color.White;
            this.angleUpDown2.Location = new System.Drawing.Point(638, 190);
            this.angleUpDown2.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.angleUpDown2.Name = "angleUpDown2";
            this.angleUpDown2.Size = new System.Drawing.Size(124, 19);
            this.angleUpDown2.TabIndex = 6;
            this.angleUpDown2.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.angleUpDown2.ValueChanged += new System.EventHandler(this.angleUpDown2_ValueChanged);
            // 
            // colorButton1
            // 
            this.colorButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.colorButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.colorButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton1.ForeColor = System.Drawing.Color.White;
            this.colorButton1.Location = new System.Drawing.Point(638, 405);
            this.colorButton1.Name = "colorButton1";
            this.colorButton1.Size = new System.Drawing.Size(60, 36);
            this.colorButton1.TabIndex = 7;
            this.colorButton1.Text = "Цвет 1";
            this.colorButton1.UseVisualStyleBackColor = false;
            this.colorButton1.Click += new System.EventHandler(this.colorButton1_Click);
            // 
            // colorButton2
            // 
            this.colorButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.colorButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.colorButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton2.ForeColor = System.Drawing.Color.White;
            this.colorButton2.Location = new System.Drawing.Point(702, 405);
            this.colorButton2.Name = "colorButton2";
            this.colorButton2.Size = new System.Drawing.Size(60, 36);
            this.colorButton2.TabIndex = 8;
            this.colorButton2.Text = "Цвет 2";
            this.colorButton2.UseVisualStyleBackColor = false;
            this.colorButton2.Click += new System.EventHandler(this.colorButton2_Click);
            // 
            // separator
            // 
            this.separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.separator.Location = new System.Drawing.Point(630, 15);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(2, 472);
            this.separator.TabIndex = 9;
            // 
            // FractalRenderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(774, 496);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.colorButton2);
            this.Controls.Add(this.colorButton1);
            this.Controls.Add(this.angleUpDown2);
            this.Controls.Add(this.angleUpDown1);
            this.Controls.Add(this.ratioUpDown);
            this.Controls.Add(this.angleLabel2);
            this.Controls.Add(this.angleLabel1);
            this.Controls.Add(this.ratioLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.widthUpDown);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.depthUpDown);
            this.Controls.Add(this.pictureBox);
            this.KeyPreview = true;
            this.Name = "FractalRenderWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отрисовка фрактала";
            this.Load += new System.EventHandler(this.FractalRenderWindow_Load);
            this.Shown += new System.EventHandler(this.FractalRenderWindow_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FractalRenderWindow_KeyPress);
            this.Resize += new System.EventHandler(this.FractalRenderWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratioUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown depthUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.NumericUpDown widthUpDown;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label ratioLabel;
        private System.Windows.Forms.Label angleLabel1;
        private System.Windows.Forms.Label angleLabel2;
        private System.Windows.Forms.NumericUpDown ratioUpDown;
        private System.Windows.Forms.NumericUpDown angleUpDown1;
        private System.Windows.Forms.NumericUpDown angleUpDown2;
        private System.Windows.Forms.Button colorButton1;
        private System.Windows.Forms.Button colorButton2;
        private System.Windows.Forms.Label separator;
    }
}