namespace Notepad_
{
    partial class NotepadTabControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.tabLabel = new System.Windows.Forms.Label();
            this.textEditor1 = new Notepad_.TextEditor();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLeft
            // 
            this.buttonLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLeft.Location = new System.Drawing.Point(0, 0);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(30, 23);
            this.buttonLeft.TabIndex = 0;
            this.buttonLeft.Text = "<";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRight.Location = new System.Drawing.Point(110, 0);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(30, 23);
            this.buttonRight.TabIndex = 1;
            this.buttonRight.Text = ">";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // tabLabel
            // 
            this.tabLabel.AutoSize = true;
            this.tabLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabLabel.Location = new System.Drawing.Point(36, 4);
            this.tabLabel.Name = "tabLabel";
            this.tabLabel.Size = new System.Drawing.Size(38, 15);
            this.tabLabel.TabIndex = 2;
            this.tabLabel.Text = "label1";
            // 
            // textEditor1
            // 
            this.textEditor1.Location = new System.Drawing.Point(0, 29);
            this.textEditor1.Name = "textEditor1";
            this.textEditor1.Size = new System.Drawing.Size(598, 437);
            this.textEditor1.TabIndex = 3;
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(81, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(23, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // NotepadTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.textEditor1);
            this.Controls.Add(this.tabLabel);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Name = "NotepadTabControl";
            this.Size = new System.Drawing.Size(598, 466);
            this.Load += new System.EventHandler(this.NotepadTabControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Label tabLabel;
        private TextEditor textEditor1;
        private System.Windows.Forms.Button closeButton;
    }
}
