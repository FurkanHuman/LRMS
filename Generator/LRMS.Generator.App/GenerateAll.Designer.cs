namespace LRMS.Generator.App
{
    partial class GenerateAll
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
            this.buttonGenerateAllRepository = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonPathGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonGenerateAllRepository
            // 
            this.buttonGenerateAllRepository.Location = new System.Drawing.Point(12, 12);
            this.buttonGenerateAllRepository.Name = "buttonGenerateAllRepository";
            this.buttonGenerateAllRepository.Size = new System.Drawing.Size(156, 42);
            this.buttonGenerateAllRepository.TabIndex = 0;
            this.buttonGenerateAllRepository.Text = "Generate All Repository!";
            this.buttonGenerateAllRepository.UseVisualStyleBackColor = true;
            this.buttonGenerateAllRepository.Click += new System.EventHandler(this.buttonGenerateAllRepository_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 60);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(851, 439);
            this.listBox1.TabIndex = 1;
            // 
            // buttonPathGenerate
            // 
            this.buttonPathGenerate.Location = new System.Drawing.Point(707, 557);
            this.buttonPathGenerate.Name = "buttonPathGenerate";
            this.buttonPathGenerate.Size = new System.Drawing.Size(239, 23);
            this.buttonPathGenerate.TabIndex = 2;
            this.buttonPathGenerate.Text = "Path Generate";
            this.buttonPathGenerate.UseVisualStyleBackColor = true;
            this.buttonPathGenerate.Click += new System.EventHandler(this.buttonPathGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(960, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // GenerateAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 657);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPathGenerate);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonGenerateAllRepository);
            this.Name = "GenerateAll";
            this.Text = "Generate";
            this.Load += new System.EventHandler(this.GenerateAll_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonGenerateAllRepository;
        private ListBox listBox1;
        private Button buttonPathGenerate;
        private Label label1;
    }
}