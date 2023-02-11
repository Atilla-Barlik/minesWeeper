
namespace minesWeeper
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.mineCountTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.Label();
            this.CaptureScreen = new System.Windows.Forms.Button();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.sayac = new System.Windows.Forms.Label();
            this.emptyControl = new System.Windows.Forms.Label();
            this.cells = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flagCountLabel = new System.Windows.Forms.Label();
            this.flaggedMineCountLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.GameStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(60, 32);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 20);
            this.heightTextBox.TabIndex = 0;
            this.heightTextBox.TextChanged += new System.EventHandler(this.heightTextBox_TextChanged);
            // 
            // weightTextBox
            // 
            this.weightTextBox.Location = new System.Drawing.Point(166, 32);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(100, 20);
            this.weightTextBox.TabIndex = 1;
            // 
            // mineCountTextBox
            // 
            this.mineCountTextBox.Location = new System.Drawing.Point(272, 32);
            this.mineCountTextBox.Name = "mineCountTextBox";
            this.mineCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.mineCountTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Weight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mine Count";
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(387, 29);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 6;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // results
            // 
            this.results.AutoSize = true;
            this.results.Location = new System.Drawing.Point(718, 122);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(0, 13);
            this.results.TabIndex = 7;
            // 
            // CaptureScreen
            // 
            this.CaptureScreen.Location = new System.Drawing.Point(387, 55);
            this.CaptureScreen.Name = "CaptureScreen";
            this.CaptureScreen.Size = new System.Drawing.Size(75, 23);
            this.CaptureScreen.TabIndex = 8;
            this.CaptureScreen.Text = "Create";
            this.CaptureScreen.UseVisualStyleBackColor = true;
            this.CaptureScreen.Click += new System.EventHandler(this.deneme_Click);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(531, 93);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(0, 13);
            this.labelX.TabIndex = 9;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(568, 93);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(0, 13);
            this.labelY.TabIndex = 10;
            // 
            // sayac
            // 
            this.sayac.AutoSize = true;
            this.sayac.Location = new System.Drawing.Point(855, 122);
            this.sayac.Name = "sayac";
            this.sayac.Size = new System.Drawing.Size(0, 13);
            this.sayac.TabIndex = 12;
            // 
            // emptyControl
            // 
            this.emptyControl.AutoSize = true;
            this.emptyControl.Location = new System.Drawing.Point(718, 300);
            this.emptyControl.Name = "emptyControl";
            this.emptyControl.Size = new System.Drawing.Size(0, 13);
            this.emptyControl.TabIndex = 11;
            // 
            // cells
            // 
            this.cells.AutoSize = true;
            this.cells.Location = new System.Drawing.Point(960, 55);
            this.cells.Name = "cells";
            this.cells.Size = new System.Drawing.Size(0, 13);
            this.cells.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(932, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(510, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Flag Count";
            // 
            // flagCountLabel
            // 
            this.flagCountLabel.AutoSize = true;
            this.flagCountLabel.Location = new System.Drawing.Point(510, 39);
            this.flagCountLabel.Name = "flagCountLabel";
            this.flagCountLabel.Size = new System.Drawing.Size(0, 13);
            this.flagCountLabel.TabIndex = 16;
            // 
            // flaggedMineCountLabel
            // 
            this.flaggedMineCountLabel.AutoSize = true;
            this.flaggedMineCountLabel.Location = new System.Drawing.Point(595, 35);
            this.flaggedMineCountLabel.Name = "flaggedMineCountLabel";
            this.flaggedMineCountLabel.Size = new System.Drawing.Size(0, 13);
            this.flaggedMineCountLabel.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(574, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Flagged Mine Count";
            // 
            // GameStatusLabel
            // 
            this.GameStatusLabel.AutoSize = true;
            this.GameStatusLabel.Location = new System.Drawing.Point(363, 93);
            this.GameStatusLabel.Name = "GameStatusLabel";
            this.GameStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.GameStatusLabel.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 601);
            this.Controls.Add(this.GameStatusLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.flaggedMineCountLabel);
            this.Controls.Add(this.flagCountLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cells);
            this.Controls.Add(this.sayac);
            this.Controls.Add(this.emptyControl);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.CaptureScreen);
            this.Controls.Add(this.results);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mineCountTextBox);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.heightTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.TextBox mineCountTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label results;
        private System.Windows.Forms.Button CaptureScreen;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label sayac;
        private System.Windows.Forms.Label emptyControl;
        private System.Windows.Forms.Label cells;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label flagCountLabel;
        private System.Windows.Forms.Label flaggedMineCountLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label GameStatusLabel;
    }
}

