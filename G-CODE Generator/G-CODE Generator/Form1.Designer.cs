namespace G_CODE_Generator
{
    partial class selection_form
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
            this.button_generate = new System.Windows.Forms.Button();
            this.base_radiobutton = new System.Windows.Forms.RadioButton();
            this.silver_radiobutton = new System.Windows.Forms.RadioButton();
            this.void_radiobutton = new System.Windows.Forms.RadioButton();
            this.glue_radiobutton = new System.Windows.Forms.RadioButton();
            this.resin_button = new System.Windows.Forms.RadioButton();
            this.top_radiobutton = new System.Windows.Forms.RadioButton();
            this.output_text = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_generate
            // 
            this.button_generate.Location = new System.Drawing.Point(1064, 1357);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(170, 52);
            this.button_generate.TabIndex = 0;
            this.button_generate.Text = "OK";
            this.button_generate.UseVisualStyleBackColor = true;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // base_radiobutton
            // 
            this.base_radiobutton.AutoSize = true;
            this.base_radiobutton.Location = new System.Drawing.Point(46, 124);
            this.base_radiobutton.Name = "base_radiobutton";
            this.base_radiobutton.Size = new System.Drawing.Size(172, 41);
            this.base_radiobutton.TabIndex = 1;
            this.base_radiobutton.TabStop = true;
            this.base_radiobutton.Text = "Base Layer";
            this.base_radiobutton.UseVisualStyleBackColor = true;
            // 
            // silver_radiobutton
            // 
            this.silver_radiobutton.AutoSize = true;
            this.silver_radiobutton.Location = new System.Drawing.Point(46, 189);
            this.silver_radiobutton.Name = "silver_radiobutton";
            this.silver_radiobutton.Size = new System.Drawing.Size(191, 41);
            this.silver_radiobutton.TabIndex = 2;
            this.silver_radiobutton.TabStop = true;
            this.silver_radiobutton.Text = "Silver Traces";
            this.silver_radiobutton.UseVisualStyleBackColor = true;
            // 
            // void_radiobutton
            // 
            this.void_radiobutton.AutoSize = true;
            this.void_radiobutton.Location = new System.Drawing.Point(46, 260);
            this.void_radiobutton.Name = "void_radiobutton";
            this.void_radiobutton.Size = new System.Drawing.Size(113, 41);
            this.void_radiobutton.TabIndex = 3;
            this.void_radiobutton.TabStop = true;
            this.void_radiobutton.Text = "Voids";
            this.void_radiobutton.UseVisualStyleBackColor = true;
            // 
            // glue_radiobutton
            // 
            this.glue_radiobutton.AutoSize = true;
            this.glue_radiobutton.Location = new System.Drawing.Point(440, 124);
            this.glue_radiobutton.Name = "glue_radiobutton";
            this.glue_radiobutton.Size = new System.Drawing.Size(245, 41);
            this.glue_radiobutton.TabIndex = 4;
            this.glue_radiobutton.TabStop = true;
            this.glue_radiobutton.Text = "Anisotropic Glue";
            this.glue_radiobutton.UseVisualStyleBackColor = true;
            // 
            // resin_button
            // 
            this.resin_button.AutoSize = true;
            this.resin_button.Location = new System.Drawing.Point(440, 189);
            this.resin_button.Name = "resin_button";
            this.resin_button.Size = new System.Drawing.Size(110, 41);
            this.resin_button.TabIndex = 5;
            this.resin_button.TabStop = true;
            this.resin_button.Text = "Resin";
            this.resin_button.UseVisualStyleBackColor = true;
            // 
            // top_radiobutton
            // 
            this.top_radiobutton.AutoSize = true;
            this.top_radiobutton.Location = new System.Drawing.Point(440, 260);
            this.top_radiobutton.Name = "top_radiobutton";
            this.top_radiobutton.Size = new System.Drawing.Size(161, 41);
            this.top_radiobutton.TabIndex = 6;
            this.top_radiobutton.TabStop = true;
            this.top_radiobutton.Text = "Top Layer";
            this.top_radiobutton.UseVisualStyleBackColor = true;
            // 
            // output_text
            // 
            this.output_text.Location = new System.Drawing.Point(1942, 16);
            this.output_text.Multiline = true;
            this.output_text.Name = "output_text";
            this.output_text.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.output_text.Size = new System.Drawing.Size(612, 1391);
            this.output_text.TabIndex = 7;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(46, 900);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(173, 41);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // selection_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2572, 1425);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.output_text);
            this.Controls.Add(this.top_radiobutton);
            this.Controls.Add(this.resin_button);
            this.Controls.Add(this.glue_radiobutton);
            this.Controls.Add(this.void_radiobutton);
            this.Controls.Add(this.silver_radiobutton);
            this.Controls.Add(this.base_radiobutton);
            this.Controls.Add(this.button_generate);
            this.Name = "selection_form";
            this.Text = "Initial Selection";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_generate;
        private RadioButton base_radiobutton;
        private RadioButton silver_radiobutton;
        private RadioButton void_radiobutton;
        private RadioButton glue_radiobutton;
        private RadioButton resin_button;
        private RadioButton top_radiobutton;
        private TextBox output_text;
        private CheckBox checkBox1;
    }
}