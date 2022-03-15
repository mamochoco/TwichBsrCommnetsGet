
namespace TwichComentGetAndDL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BCURLLabel = new System.Windows.Forms.Label();
            this.BCNameTextBox = new System.Windows.Forms.TextBox();
            this.AccessButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DLButton = new System.Windows.Forms.Button();
            this.ArchiveList = new System.Windows.Forms.ComboBox();
            this.BsrInfoCheckBox = new System.Windows.Forms.CheckedListBox();
            this.FilePathtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.保存先 = new System.Windows.Forms.Label();
            this.BSRGetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BCURLLabel
            // 
            this.BCURLLabel.AutoSize = true;
            this.BCURLLabel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BCURLLabel.Location = new System.Drawing.Point(21, 20);
            this.BCURLLabel.Name = "BCURLLabel";
            this.BCURLLabel.Size = new System.Drawing.Size(72, 21);
            this.BCURLLabel.TabIndex = 0;
            this.BCURLLabel.Text = "ユーザー名";
            // 
            // BCNameTextBox
            // 
            this.BCNameTextBox.Location = new System.Drawing.Point(99, 20);
            this.BCNameTextBox.Name = "BCNameTextBox";
            this.BCNameTextBox.Size = new System.Drawing.Size(508, 23);
            this.BCNameTextBox.TabIndex = 1;
            // 
            // AccessButton
            // 
            this.AccessButton.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AccessButton.Location = new System.Drawing.Point(613, 18);
            this.AccessButton.Name = "AccessButton";
            this.AccessButton.Size = new System.Drawing.Size(96, 31);
            this.AccessButton.TabIndex = 2;
            this.AccessButton.Text = "検索";
            this.AccessButton.UseVisualStyleBackColor = true;
            this.AccessButton.Click += new System.EventHandler(this.AccessButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 334);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(508, 69);
            this.textBox1.TabIndex = 3;
            // 
            // DLButton
            // 
            this.DLButton.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DLButton.Location = new System.Drawing.Point(613, 225);
            this.DLButton.Name = "DLButton";
            this.DLButton.Size = new System.Drawing.Size(96, 31);
            this.DLButton.TabIndex = 2;
            this.DLButton.Text = "ダウンロード";
            this.DLButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DLButton.UseVisualStyleBackColor = true;
            this.DLButton.Click += new System.EventHandler(this.DLButton_Click);
            // 
            // ArchiveList
            // 
            this.ArchiveList.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ArchiveList.FormattingEnabled = true;
            this.ArchiveList.Location = new System.Drawing.Point(99, 59);
            this.ArchiveList.Name = "ArchiveList";
            this.ArchiveList.Size = new System.Drawing.Size(508, 29);
            this.ArchiveList.TabIndex = 4;
            // 
            // BsrInfoCheckBox
            // 
            this.BsrInfoCheckBox.FormattingEnabled = true;
            this.BsrInfoCheckBox.Location = new System.Drawing.Point(99, 139);
            this.BsrInfoCheckBox.Name = "BsrInfoCheckBox";
            this.BsrInfoCheckBox.Size = new System.Drawing.Size(508, 184);
            this.BsrInfoCheckBox.TabIndex = 5;
            // 
            // FilePathtextBox
            // 
            this.FilePathtextBox.Location = new System.Drawing.Point(99, 110);
            this.FilePathtextBox.Name = "FilePathtextBox";
            this.FilePathtextBox.Size = new System.Drawing.Size(508, 23);
            this.FilePathtextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "アーカイブ";
            // 
            // 保存先
            // 
            this.保存先.AutoSize = true;
            this.保存先.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.保存先.Location = new System.Drawing.Point(21, 112);
            this.保存先.Name = "保存先";
            this.保存先.Size = new System.Drawing.Size(58, 21);
            this.保存先.TabIndex = 0;
            this.保存先.Text = "保存先";
            // 
            // BSRGetButton
            // 
            this.BSRGetButton.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BSRGetButton.Location = new System.Drawing.Point(613, 58);
            this.BSRGetButton.Name = "BSRGetButton";
            this.BSRGetButton.Size = new System.Drawing.Size(96, 29);
            this.BSRGetButton.TabIndex = 7;
            this.BSRGetButton.Text = "ログ取得";
            this.BSRGetButton.UseVisualStyleBackColor = true;
            this.BSRGetButton.Click += new System.EventHandler(this.BSRGetButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BSRGetButton);
            this.Controls.Add(this.FilePathtextBox);
            this.Controls.Add(this.BsrInfoCheckBox);
            this.Controls.Add(this.ArchiveList);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DLButton);
            this.Controls.Add(this.AccessButton);
            this.Controls.Add(this.BCNameTextBox);
            this.Controls.Add(this.保存先);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BCURLLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BCURLLabel;
        private System.Windows.Forms.TextBox BCNameTextBox;
        private System.Windows.Forms.Button AccessButton;
        private System.Windows.Forms.Button DLButton;
        private System.Windows.Forms.ComboBox ArchiveList;
        private System.Windows.Forms.CheckedListBox BsrInfoCheckBox;
        private System.Windows.Forms.TextBox FilePathtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label 保存先;
        private System.Windows.Forms.Button BSRGetButton;
        public System.Windows.Forms.TextBox textBox1;
    }
}

