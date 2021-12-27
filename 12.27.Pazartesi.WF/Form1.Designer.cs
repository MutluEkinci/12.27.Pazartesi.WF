
namespace _12._27.Pazartesi.WF
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.btntryfinally = new System.Windows.Forms.Button();
            this.btnThrow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 81);
            this.button1.TabIndex = 0;
            this.button1.Text = "Exception Handling";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btntryfinally
            // 
            this.btntryfinally.Location = new System.Drawing.Point(26, 121);
            this.btntryfinally.Name = "btntryfinally";
            this.btntryfinally.Size = new System.Drawing.Size(121, 81);
            this.btntryfinally.TabIndex = 1;
            this.btntryfinally.Text = "Try-Finally";
            this.btntryfinally.UseVisualStyleBackColor = true;
            this.btntryfinally.Click += new System.EventHandler(this.btntryfinally_Click);
            // 
            // btnThrow
            // 
            this.btnThrow.Location = new System.Drawing.Point(26, 208);
            this.btnThrow.Name = "btnThrow";
            this.btnThrow.Size = new System.Drawing.Size(121, 81);
            this.btnThrow.TabIndex = 2;
            this.btnThrow.Text = "Throw";
            this.btnThrow.UseVisualStyleBackColor = true;
            this.btnThrow.Click += new System.EventHandler(this.btnThrow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 515);
            this.Controls.Add(this.btnThrow);
            this.Controls.Add(this.btntryfinally);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btntryfinally;
        private System.Windows.Forms.Button btnThrow;
    }
}

