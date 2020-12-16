namespace Puzzlegame
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonImageBrowse = new System.Windows.Forms.Button();
            this.textboxImagePath = new System.Windows.Forms.TextBox();
            this.groupboxPuzzle = new System.Windows.Forms.GroupBox();
            this.picBoxPuzzle = new Puzzlegame.MyPictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Autosolvebtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupboxPuzzle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPuzzle)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonImageBrowse);
            this.groupBox1.Controls.Add(this.textboxImagePath);
            this.groupBox1.Location = new System.Drawing.Point(39, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Image";
            // 
            // buttonImageBrowse
            // 
            this.buttonImageBrowse.Location = new System.Drawing.Point(587, 27);
            this.buttonImageBrowse.Name = "buttonImageBrowse";
            this.buttonImageBrowse.Size = new System.Drawing.Size(63, 26);
            this.buttonImageBrowse.TabIndex = 1;
            this.buttonImageBrowse.Text = "...";
            this.buttonImageBrowse.UseVisualStyleBackColor = true;
            this.buttonImageBrowse.Click += new System.EventHandler(this.buttonImageBrowse_Click);
            // 
            // textboxImagePath
            // 
            this.textboxImagePath.Location = new System.Drawing.Point(23, 31);
            this.textboxImagePath.Name = "textboxImagePath";
            this.textboxImagePath.Size = new System.Drawing.Size(540, 20);
            this.textboxImagePath.TabIndex = 0;
            // 
            // groupboxPuzzle
            // 
            this.groupboxPuzzle.Controls.Add(this.picBoxPuzzle);
            this.groupboxPuzzle.Location = new System.Drawing.Point(39, 141);
            this.groupboxPuzzle.Name = "groupboxPuzzle";
            this.groupboxPuzzle.Size = new System.Drawing.Size(400, 400);
            this.groupboxPuzzle.TabIndex = 1;
            this.groupboxPuzzle.TabStop = false;
            this.groupboxPuzzle.Text = "Puzzle";
            // 
            // picBoxPuzzle
            // 
            this.picBoxPuzzle.ImageIndex = 0;
            this.picBoxPuzzle.Index = 0;
            this.picBoxPuzzle.Location = new System.Drawing.Point(3, 13);
            this.picBoxPuzzle.Name = "picBoxPuzzle";
            this.picBoxPuzzle.Size = new System.Drawing.Size(397, 391);
            this.picBoxPuzzle.TabIndex = 0;
            this.picBoxPuzzle.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(501, 141);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 160);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Diffciulty";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(116, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Play Game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(246, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(43, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(246, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(43, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            // 
            // Autosolvebtn
            // 
            this.Autosolvebtn.Location = new System.Drawing.Point(541, 332);
            this.Autosolvebtn.Name = "Autosolvebtn";
            this.Autosolvebtn.Size = new System.Drawing.Size(310, 38);
            this.Autosolvebtn.TabIndex = 9;
            this.Autosolvebtn.Text = "Autosolve";
            this.Autosolvebtn.UseVisualStyleBackColor = true;
            this.Autosolvebtn.Click += new System.EventHandler(this.Autosolvebtn_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 569);
            this.Controls.Add(this.Autosolvebtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupboxPuzzle);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupboxPuzzle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPuzzle)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textboxImagePath;
        private System.Windows.Forms.Button buttonImageBrowse;
        private System.Windows.Forms.GroupBox groupboxPuzzle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Autosolvebtn;
        private MyPictureBox picBoxPuzzle;
    }
}

