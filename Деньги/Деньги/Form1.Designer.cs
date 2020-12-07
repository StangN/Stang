namespace Деньги
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
        public void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.obligationsText = new System.Windows.Forms.Label();
            this.stocksText = new System.Windows.Forms.Label();
            this.obligationsRate = new System.Windows.Forms.Label();
            this.stocksRate = new System.Windows.Forms.Label();
            this.riskTakingBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.obligationsRateGrowth = new System.Windows.Forms.Label();
            this.stocksRateGrowth = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 81);
            this.button1.TabIndex = 0;
            this.button1.Text = "Получение информации от инвесторов";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // obligationsText
            // 
            this.obligationsText.AutoSize = true;
            this.obligationsText.Location = new System.Drawing.Point(118, 187);
            this.obligationsText.Name = "obligationsText";
            this.obligationsText.Size = new System.Drawing.Size(74, 13);
            this.obligationsText.TabIndex = 1;
            this.obligationsText.Text = "Облигации: 0";
            // 
            // stocksText
            // 
            this.stocksText.AutoSize = true;
            this.stocksText.Location = new System.Drawing.Point(118, 221);
            this.stocksText.Name = "stocksText";
            this.stocksText.Size = new System.Drawing.Size(50, 13);
            this.stocksText.TabIndex = 2;
            this.stocksText.Text = "Акции: 0";
            // 
            // obligationsRate
            // 
            this.obligationsRate.AutoSize = true;
            this.obligationsRate.Location = new System.Drawing.Point(529, 187);
            this.obligationsRate.Name = "obligationsRate";
            this.obligationsRate.Size = new System.Drawing.Size(90, 13);
            this.obligationsRate.TabIndex = 3;
            this.obligationsRate.Text = "Курс облигаций:";
            // 
            // stocksRate
            // 
            this.stocksRate.AutoSize = true;
            this.stocksRate.Location = new System.Drawing.Point(529, 221);
            this.stocksRate.Name = "stocksRate";
            this.stocksRate.Size = new System.Drawing.Size(67, 13);
            this.stocksRate.TabIndex = 4;
            this.stocksRate.Text = "Курс акций:";
            // 
            // riskTakingBox
            // 
            this.riskTakingBox.Location = new System.Drawing.Point(270, 261);
            this.riskTakingBox.Name = "riskTakingBox";
            this.riskTakingBox.Size = new System.Drawing.Size(100, 20);
            this.riskTakingBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Априорное распределение:";
            // 
            // obligationsRateGrowth
            // 
            this.obligationsRateGrowth.AutoSize = true;
            this.obligationsRateGrowth.Location = new System.Drawing.Point(625, 187);
            this.obligationsRateGrowth.Name = "obligationsRateGrowth";
            this.obligationsRateGrowth.Size = new System.Drawing.Size(0, 13);
            this.obligationsRateGrowth.TabIndex = 7;
            // 
            // stocksRateGrowth
            // 
            this.stocksRateGrowth.AutoSize = true;
            this.stocksRateGrowth.Location = new System.Drawing.Point(602, 221);
            this.stocksRateGrowth.Name = "stocksRateGrowth";
            this.stocksRateGrowth.Size = new System.Drawing.Size(0, 13);
            this.stocksRateGrowth.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(463, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(212, 81);
            this.button2.TabIndex = 9;
            this.button2.Text = "Расчет курса";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.stocksRateGrowth);
            this.Controls.Add(this.obligationsRateGrowth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.riskTakingBox);
            this.Controls.Add(this.stocksRate);
            this.Controls.Add(this.obligationsRate);
            this.Controls.Add(this.stocksText);
            this.Controls.Add(this.obligationsText);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label obligationsText;
        public System.Windows.Forms.Label stocksText;
        private System.Windows.Forms.Label obligationsRate;
        private System.Windows.Forms.Label stocksRate;
        public System.Windows.Forms.TextBox riskTakingBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label obligationsRateGrowth;
        public System.Windows.Forms.Label stocksRateGrowth;
        private System.Windows.Forms.Button button2;
    }
}

