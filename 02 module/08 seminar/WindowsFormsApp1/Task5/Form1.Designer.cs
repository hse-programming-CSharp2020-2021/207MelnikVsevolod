namespace Task5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.showList = new System.Windows.Forms.Button();
            this.showNewList = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // showList
            // 
            this.showList.Location = new System.Drawing.Point(13, 13);
            this.showList.Name = "showList";
            this.showList.Size = new System.Drawing.Size(186, 23);
            this.showList.TabIndex = 0;
            this.showList.Text = "Показать исходный список";
            this.showList.UseVisualStyleBackColor = true;
            this.showList.Click += new System.EventHandler(this.showList_Click);
            // 
            // showNewList
            // 
            this.showNewList.Location = new System.Drawing.Point(13, 151);
            this.showNewList.Name = "showNewList";
            this.showNewList.Size = new System.Drawing.Size(186, 23);
            this.showNewList.TabIndex = 1;
            this.showNewList.Text = "Показать изменённый список";
            this.showNewList.UseVisualStyleBackColor = true;
            this.showNewList.Click += new System.EventHandler(this.showNewList_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 42);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 103);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 187);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.showNewList);
            this.Controls.Add(this.showList);
            this.Name = "Form1";
            this.Text = "TextBox";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showList;
        private System.Windows.Forms.Button showNewList;
        private System.Windows.Forms.TextBox textBox1;
    }
}

