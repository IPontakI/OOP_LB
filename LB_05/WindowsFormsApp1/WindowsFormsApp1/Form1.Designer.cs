namespace WindowsFormsApp1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGetA = new System.Windows.Forms.TextBox();
            this.tbGetB = new System.Windows.Forms.TextBox();
            this.tbGetC = new System.Windows.Forms.TextBox();
            this.btn1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIntegerOut = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "String a";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "String c";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "String b";
            // 
            // tbGetA
            // 
            this.tbGetA.Location = new System.Drawing.Point(29, 54);
            this.tbGetA.Margin = new System.Windows.Forms.Padding(6);
            this.tbGetA.Name = "tbGetA";
            this.tbGetA.Size = new System.Drawing.Size(180, 29);
            this.tbGetA.TabIndex = 3;
            this.tbGetA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGetA_KeyPress);
            // 
            // tbGetB
            // 
            this.tbGetB.Location = new System.Drawing.Point(224, 54);
            this.tbGetB.Margin = new System.Windows.Forms.Padding(6);
            this.tbGetB.Name = "tbGetB";
            this.tbGetB.Size = new System.Drawing.Size(180, 29);
            this.tbGetB.TabIndex = 4;
            this.tbGetB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGetA_KeyPress);
            // 
            // tbGetC
            // 
            this.tbGetC.Location = new System.Drawing.Point(418, 54);
            this.tbGetC.Margin = new System.Windows.Forms.Padding(6);
            this.tbGetC.Name = "tbGetC";
            this.tbGetC.Size = new System.Drawing.Size(180, 29);
            this.tbGetC.TabIndex = 5;
            this.tbGetC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGetA_KeyPress);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(612, 24);
            this.btn1.Margin = new System.Windows.Forms.Padding(6);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(156, 135);
            this.btn1.TabIndex = 6;
            this.btn1.Text = "click";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(25, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "INTEGER =";
            // 
            // lblIntegerOut
            // 
            this.lblIntegerOut.AutoSize = true;
            this.lblIntegerOut.Location = new System.Drawing.Point(134, 135);
            this.lblIntegerOut.Name = "lblIntegerOut";
            this.lblIntegerOut.Size = new System.Drawing.Size(60, 24);
            this.lblIntegerOut.TabIndex = 8;
            this.lblIntegerOut.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 187);
            this.Controls.Add(this.lblIntegerOut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.tbGetC);
            this.Controls.Add(this.tbGetB);
            this.Controls.Add(this.tbGetA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbGetA;
        private System.Windows.Forms.TextBox tbGetB;
        private System.Windows.Forms.TextBox tbGetC;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIntegerOut;
    }
}

