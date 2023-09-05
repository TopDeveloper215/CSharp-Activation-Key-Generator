namespace Serial_Maker
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
            this.stbBase = new SerialBox.SerialBox();
            this.stbPass = new SerialBox.SerialBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdentifier = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // stbBase
            // 
            this.stbBase.CaptleLettersOnly = true;
            this.stbBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.stbBase.Location = new System.Drawing.Point(52, 128);
            this.stbBase.Margin = new System.Windows.Forms.Padding(4);
            this.stbBase.Name = "stbBase";
            this.stbBase.Size = new System.Drawing.Size(429, 28);
            this.stbBase.TabIndex = 0;
            // 
            // stbPass
            // 
            this.stbPass.CaptleLettersOnly = true;
            this.stbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.stbPass.Location = new System.Drawing.Point(52, 191);
            this.stbPass.Margin = new System.Windows.Forms.Padding(4);
            this.stbPass.Name = "stbPass";
            this.stbPass.Size = new System.Drawing.Size(429, 27);
            this.stbPass.TabIndex = 1;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.Lime;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.Red;
            this.btnGenerate.Location = new System.Drawing.Point(368, 287);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(391, 37);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate Key";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(80, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Indetifier:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtIdentifier
            // 
            this.txtIdentifier.Location = new System.Drawing.Point(274, 55);
            this.txtIdentifier.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdentifier.MaxLength = 3;
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.Size = new System.Drawing.Size(35, 22);
            this.txtIdentifier.TabIndex = 4;
            this.txtIdentifier.TextChanged += new System.EventHandler(this.txtIdentifier_TextChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 364);
            this.Controls.Add(this.txtIdentifier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.stbPass);
            this.Controls.Add(this.stbBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Generate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SerialBox.SerialBox stbBase;
        private SerialBox.SerialBox stbPass;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdentifier;
    }
}

