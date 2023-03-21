namespace LR__automats_
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
            this.vhodnayaStrokaButton = new System.Windows.Forms.Button();
            this.analizButton = new System.Windows.Forms.Button();
            this.semantikaButton = new System.Windows.Forms.Button();
            this.vvodTextBox = new System.Windows.Forms.TextBox();
            this.repeatButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.spisokIdentTextBox = new System.Windows.Forms.TextBox();
            this.spisokConstTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // vhodnayaStrokaButton
            // 
            this.vhodnayaStrokaButton.Enabled = false;
            this.vhodnayaStrokaButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.vhodnayaStrokaButton.Location = new System.Drawing.Point(-2, -1);
            this.vhodnayaStrokaButton.Name = "vhodnayaStrokaButton";
            this.vhodnayaStrokaButton.Size = new System.Drawing.Size(340, 120);
            this.vhodnayaStrokaButton.TabIndex = 0;
            this.vhodnayaStrokaButton.Text = "Входная строка";
            this.vhodnayaStrokaButton.UseVisualStyleBackColor = true;
            // 
            // analizButton
            // 
            this.analizButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.analizButton.ForeColor = System.Drawing.Color.Black;
            this.analizButton.Location = new System.Drawing.Point(335, -1);
            this.analizButton.Name = "analizButton";
            this.analizButton.Size = new System.Drawing.Size(340, 120);
            this.analizButton.TabIndex = 1;
            this.analizButton.Text = "Анализ";
            this.analizButton.UseVisualStyleBackColor = true;
            this.analizButton.Click += new System.EventHandler(this.analizButton_Click);
            // 
            // semantikaButton
            // 
            this.semantikaButton.Enabled = false;
            this.semantikaButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.semantikaButton.Location = new System.Drawing.Point(672, -1);
            this.semantikaButton.Name = "semantikaButton";
            this.semantikaButton.Size = new System.Drawing.Size(340, 120);
            this.semantikaButton.TabIndex = 2;
            this.semantikaButton.Text = "Семантика";
            this.semantikaButton.UseVisualStyleBackColor = true;
            this.semantikaButton.Click += new System.EventHandler(this.semantikaButton_Click);
            // 
            // vvodTextBox
            // 
            this.vvodTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.vvodTextBox.Location = new System.Drawing.Point(193, 219);
            this.vvodTextBox.Name = "vvodTextBox";
            this.vvodTextBox.Size = new System.Drawing.Size(619, 39);
            this.vvodTextBox.TabIndex = 3;
            this.vvodTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // repeatButton
            // 
            this.repeatButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.repeatButton.Location = new System.Drawing.Point(864, 219);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(123, 39);
            this.repeatButton.TabIndex = 4;
            this.repeatButton.Text = "Repeat";
            this.repeatButton.UseVisualStyleBackColor = true;
            this.repeatButton.Visible = false;
            this.repeatButton.Click += new System.EventHandler(this.repeatButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.errorLabel.Location = new System.Drawing.Point(-2, 283);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(1014, 44);
            this.errorLabel.TabIndex = 6;
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spisokIdentTextBox
            // 
            this.spisokIdentTextBox.Location = new System.Drawing.Point(106, 355);
            this.spisokIdentTextBox.Multiline = true;
            this.spisokIdentTextBox.Name = "spisokIdentTextBox";
            this.spisokIdentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.spisokIdentTextBox.Size = new System.Drawing.Size(366, 227);
            this.spisokIdentTextBox.TabIndex = 7;
            this.spisokIdentTextBox.Visible = false;
            // 
            // spisokConstTextBox
            // 
            this.spisokConstTextBox.Location = new System.Drawing.Point(532, 355);
            this.spisokConstTextBox.Multiline = true;
            this.spisokConstTextBox.Name = "spisokConstTextBox";
            this.spisokConstTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.spisokConstTextBox.Size = new System.Drawing.Size(374, 227);
            this.spisokConstTextBox.TabIndex = 8;
            this.spisokConstTextBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 593);
            this.Controls.Add(this.spisokConstTextBox);
            this.Controls.Add(this.spisokIdentTextBox);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.repeatButton);
            this.Controls.Add(this.vvodTextBox);
            this.Controls.Add(this.semantikaButton);
            this.Controls.Add(this.analizButton);
            this.Controls.Add(this.vhodnayaStrokaButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button vhodnayaStrokaButton;
        private Button analizButton;
        private Button semantikaButton;
        private TextBox vvodTextBox;
        private Button repeatButton;
        private Label errorLabel;
        private TextBox spisokIdentTextBox;
        private TextBox spisokConstTextBox;
    }
}