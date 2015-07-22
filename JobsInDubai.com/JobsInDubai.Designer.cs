namespace JobsInDubai.com
{
    partial class JobsInDubai
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
            this.nextPage_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.url_label = new System.Windows.Forms.Label();
            this.url_textBox = new System.Windows.Forms.TextBox();
            this.open_btn = new System.Windows.Forms.Button();
            this.quit_btn = new System.Windows.Forms.Button();
            this.start_Btn = new System.Windows.Forms.Button();
            this.result_richTextBox = new System.Windows.Forms.RichTextBox();
            this.page_no_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nextPage_label
            // 
            this.nextPage_label.AutoSize = true;
            this.nextPage_label.Location = new System.Drawing.Point(636, 441);
            this.nextPage_label.Name = "nextPage_label";
            this.nextPage_label.Size = new System.Drawing.Size(21, 13);
            this.nextPage_label.TabIndex = 20;
            this.nextPage_label.Text = "No";
            this.nextPage_label.Click += new System.EventHandler(this.nextPage_label_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Next page available ?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Total Pages:";
            // 
            // url_label
            // 
            this.url_label.AutoSize = true;
            this.url_label.Location = new System.Drawing.Point(1, 441);
            this.url_label.Name = "url_label";
            this.url_label.Size = new System.Drawing.Size(23, 13);
            this.url_label.TabIndex = 16;
            this.url_label.Text = "Url:";
            // 
            // url_textBox
            // 
            this.url_textBox.Location = new System.Drawing.Point(30, 438);
            this.url_textBox.Name = "url_textBox";
            this.url_textBox.Size = new System.Drawing.Size(194, 20);
            this.url_textBox.TabIndex = 15;
            this.url_textBox.Text = "https://www.jobsindubai.com";
            // 
            // open_btn
            // 
            this.open_btn.Location = new System.Drawing.Point(719, 436);
            this.open_btn.Name = "open_btn";
            this.open_btn.Size = new System.Drawing.Size(75, 23);
            this.open_btn.TabIndex = 14;
            this.open_btn.Text = "&Open";
            this.open_btn.UseVisualStyleBackColor = true;
            this.open_btn.Click += new System.EventHandler(this.open_btn_Click);
            // 
            // quit_btn
            // 
            this.quit_btn.Location = new System.Drawing.Point(881, 436);
            this.quit_btn.Name = "quit_btn";
            this.quit_btn.Size = new System.Drawing.Size(75, 23);
            this.quit_btn.TabIndex = 13;
            this.quit_btn.Text = "&Quit";
            this.quit_btn.UseVisualStyleBackColor = true;
            this.quit_btn.Click += new System.EventHandler(this.quit_btn_Click);
            // 
            // start_Btn
            // 
            this.start_Btn.Location = new System.Drawing.Point(800, 436);
            this.start_Btn.Name = "start_Btn";
            this.start_Btn.Size = new System.Drawing.Size(75, 23);
            this.start_Btn.TabIndex = 1;
            this.start_Btn.Text = "&Start";
            this.start_Btn.UseVisualStyleBackColor = true;
            this.start_Btn.Click += new System.EventHandler(this.start_Btn_Click);
            // 
            // result_richTextBox
            // 
            this.result_richTextBox.Location = new System.Drawing.Point(1, 2);
            this.result_richTextBox.Name = "result_richTextBox";
            this.result_richTextBox.Size = new System.Drawing.Size(960, 430);
            this.result_richTextBox.TabIndex = 12;
            this.result_richTextBox.Text = "Progress:";
            this.result_richTextBox.TextChanged += new System.EventHandler(this.result_richTextBox_TextChanged);
            // 
            // page_no_label
            // 
            this.page_no_label.AutoSize = true;
            this.page_no_label.Location = new System.Drawing.Point(303, 441);
            this.page_no_label.Name = "page_no_label";
            this.page_no_label.Size = new System.Drawing.Size(67, 13);
            this.page_no_label.TabIndex = 21;
            this.page_no_label.Text = "700 (Approx)";
            this.page_no_label.Click += new System.EventHandler(this.page_no_label_Click);
            // 
            // JobsInDubai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 461);
            this.Controls.Add(this.page_no_label);
            this.Controls.Add(this.nextPage_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.url_label);
            this.Controls.Add(this.url_textBox);
            this.Controls.Add(this.open_btn);
            this.Controls.Add(this.quit_btn);
            this.Controls.Add(this.start_Btn);
            this.Controls.Add(this.result_richTextBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(978, 500);
            this.MinimumSize = new System.Drawing.Size(978, 500);
            this.Name = "JobsInDubai";
            this.Text = "JobsInDubai.com";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nextPage_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label url_label;
        private System.Windows.Forms.TextBox url_textBox;
        private System.Windows.Forms.Button open_btn;
        private System.Windows.Forms.Button quit_btn;
        private System.Windows.Forms.Button start_Btn;
        private System.Windows.Forms.RichTextBox result_richTextBox;
        private System.Windows.Forms.Label page_no_label;
    }
}

