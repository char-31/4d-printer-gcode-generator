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
            this.GCodeOutputText = new System.Windows.Forms.TextBox();
            this.VoidSuggestion = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ID_GUI_Value = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.XOrigin_GUI_Value = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.YOrigin_GUI_Value = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.PC_PartIncluded = new System.Windows.Forms.CheckBox();
            this.BC_PartIncluded = new System.Windows.Forms.CheckBox();
            this.WiFi_PartIncluded = new System.Windows.Forms.CheckBox();
            this.Pad_PartIncluded = new System.Windows.Forms.CheckBox();
            this.PadSize_Side = new System.Windows.Forms.NumericUpDown();
            this.SG_PartIncluded = new System.Windows.Forms.CheckBox();
            this.StrainGaugeLength_X = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StrainGaugeWidth_Y = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VoidSuggestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_GUI_Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XOrigin_GUI_Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YOrigin_GUI_Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PadSize_Side)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrainGaugeLength_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrainGaugeWidth_Y)).BeginInit();
            this.SuspendLayout();
            // 
            // button_generate
            // 
            this.button_generate.Location = new System.Drawing.Point(1063, 1358);
            this.button_generate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(171, 52);
            this.button_generate.TabIndex = 0;
            this.button_generate.Text = "OK";
            this.button_generate.UseVisualStyleBackColor = true;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // base_radiobutton
            // 
            this.base_radiobutton.AutoSize = true;
            this.base_radiobutton.Location = new System.Drawing.Point(21, 20);
            this.base_radiobutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.silver_radiobutton.Location = new System.Drawing.Point(21, 135);
            this.silver_radiobutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.void_radiobutton.Location = new System.Drawing.Point(21, 267);
            this.void_radiobutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.glue_radiobutton.Location = new System.Drawing.Point(21, 1177);
            this.glue_radiobutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glue_radiobutton.Name = "glue_radiobutton";
            this.glue_radiobutton.Size = new System.Drawing.Size(218, 41);
            this.glue_radiobutton.TabIndex = 4;
            this.glue_radiobutton.TabStop = true;
            this.glue_radiobutton.Text = "Placing of Part";
            this.glue_radiobutton.UseVisualStyleBackColor = true;
            // 
            // resin_button
            // 
            this.resin_button.AutoSize = true;
            this.resin_button.Location = new System.Drawing.Point(21, 1228);
            this.resin_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resin_button.Name = "resin_button";
            this.resin_button.Size = new System.Drawing.Size(219, 41);
            this.resin_button.TabIndex = 5;
            this.resin_button.TabStop = true;
            this.resin_button.Text = "Sealing of Part";
            this.resin_button.UseVisualStyleBackColor = true;
            // 
            // top_radiobutton
            // 
            this.top_radiobutton.AutoSize = true;
            this.top_radiobutton.Location = new System.Drawing.Point(21, 1280);
            this.top_radiobutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.top_radiobutton.Name = "top_radiobutton";
            this.top_radiobutton.Size = new System.Drawing.Size(161, 41);
            this.top_radiobutton.TabIndex = 6;
            this.top_radiobutton.TabStop = true;
            this.top_radiobutton.Text = "Top Layer";
            this.top_radiobutton.UseVisualStyleBackColor = true;
            // 
            // GCodeOutputText
            // 
            this.GCodeOutputText.Location = new System.Drawing.Point(1942, 17);
            this.GCodeOutputText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GCodeOutputText.Multiline = true;
            this.GCodeOutputText.Name = "GCodeOutputText";
            this.GCodeOutputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.GCodeOutputText.Size = new System.Drawing.Size(746, 1392);
            this.GCodeOutputText.TabIndex = 7;
            // 
            // VoidSuggestion
            // 
            this.VoidSuggestion.Location = new System.Drawing.Point(22, 444);
            this.VoidSuggestion.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.VoidSuggestion.Name = "VoidSuggestion";
            this.VoidSuggestion.Size = new System.Drawing.Size(647, 653);
            this.VoidSuggestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VoidSuggestion.TabIndex = 8;
            this.VoidSuggestion.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1328, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Liquid Extruder Inner Diameter";
            // 
            // ID_GUI_Value
            // 
            this.ID_GUI_Value.DecimalPlaces = 2;
            this.ID_GUI_Value.Location = new System.Drawing.Point(1328, 59);
            this.ID_GUI_Value.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ID_GUI_Value.Name = "ID_GUI_Value";
            this.ID_GUI_Value.Size = new System.Drawing.Size(281, 43);
            this.ID_GUI_Value.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1328, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 37);
            this.label2.TabIndex = 11;
            this.label2.Text = "X Origin";
            // 
            // XOrigin_GUI_Value
            // 
            this.XOrigin_GUI_Value.Location = new System.Drawing.Point(1328, 157);
            this.XOrigin_GUI_Value.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.XOrigin_GUI_Value.Name = "XOrigin_GUI_Value";
            this.XOrigin_GUI_Value.Size = new System.Drawing.Size(281, 43);
            this.XOrigin_GUI_Value.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1328, 213);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 37);
            this.label3.TabIndex = 13;
            this.label3.Text = "Y Origin";
            // 
            // YOrigin_GUI_Value
            // 
            this.YOrigin_GUI_Value.Location = new System.Drawing.Point(1328, 255);
            this.YOrigin_GUI_Value.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.YOrigin_GUI_Value.Name = "YOrigin_GUI_Value";
            this.YOrigin_GUI_Value.Size = new System.Drawing.Size(281, 43);
            this.YOrigin_GUI_Value.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1328, 311);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(577, 37);
            this.label4.TabIndex = 15;
            this.label4.Text = "Which parts are being used? (For now pick one)";
            // 
            // PC_PartIncluded
            // 
            this.PC_PartIncluded.AutoSize = true;
            this.PC_PartIncluded.Location = new System.Drawing.Point(1382, 353);
            this.PC_PartIncluded.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.PC_PartIncluded.Name = "PC_PartIncluded";
            this.PC_PartIncluded.Size = new System.Drawing.Size(295, 41);
            this.PC_PartIncluded.TabIndex = 16;
            this.PC_PartIncluded.Text = "DC Power Connector";
            this.PC_PartIncluded.UseVisualStyleBackColor = true;
            // 
            // BC_PartIncluded
            // 
            this.BC_PartIncluded.AutoSize = true;
            this.BC_PartIncluded.Location = new System.Drawing.Point(1382, 409);
            this.BC_PartIncluded.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BC_PartIncluded.Name = "BC_PartIncluded";
            this.BC_PartIncluded.Size = new System.Drawing.Size(180, 41);
            this.BC_PartIncluded.TabIndex = 17;
            this.BC_PartIncluded.Text = "Button Cell";
            this.BC_PartIncluded.UseVisualStyleBackColor = true;
            // 
            // WiFi_PartIncluded
            // 
            this.WiFi_PartIncluded.AutoSize = true;
            this.WiFi_PartIncluded.Location = new System.Drawing.Point(1382, 464);
            this.WiFi_PartIncluded.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.WiFi_PartIncluded.Name = "WiFi_PartIncluded";
            this.WiFi_PartIncluded.Size = new System.Drawing.Size(317, 41);
            this.WiFi_PartIncluded.TabIndex = 18;
            this.WiFi_PartIncluded.Text = "ESP 8285 WiFi Module";
            this.WiFi_PartIncluded.UseVisualStyleBackColor = true;
            // 
            // Pad_PartIncluded
            // 
            this.Pad_PartIncluded.AutoSize = true;
            this.Pad_PartIncluded.Location = new System.Drawing.Point(1382, 520);
            this.Pad_PartIncluded.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Pad_PartIncluded.Name = "Pad_PartIncluded";
            this.Pad_PartIncluded.Size = new System.Drawing.Size(182, 41);
            this.Pad_PartIncluded.TabIndex = 19;
            this.Pad_PartIncluded.Text = "Square Pad";
            this.Pad_PartIncluded.UseVisualStyleBackColor = true;
            // 
            // PadSize_Side
            // 
            this.PadSize_Side.DecimalPlaces = 1;
            this.PadSize_Side.Location = new System.Drawing.Point(1414, 575);
            this.PadSize_Side.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.PadSize_Side.Name = "PadSize_Side";
            this.PadSize_Side.Size = new System.Drawing.Size(281, 43);
            this.PadSize_Side.TabIndex = 20;
            // 
            // SG_PartIncluded
            // 
            this.SG_PartIncluded.AutoSize = true;
            this.SG_PartIncluded.Location = new System.Drawing.Point(1382, 636);
            this.SG_PartIncluded.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SG_PartIncluded.Name = "SG_PartIncluded";
            this.SG_PartIncluded.Size = new System.Drawing.Size(201, 41);
            this.SG_PartIncluded.TabIndex = 21;
            this.SG_PartIncluded.Text = "Strain Gauge";
            this.SG_PartIncluded.UseVisualStyleBackColor = true;
            // 
            // StrainGaugeLength_X
            // 
            this.StrainGaugeLength_X.Location = new System.Drawing.Point(1414, 729);
            this.StrainGaugeLength_X.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.StrainGaugeLength_X.Name = "StrainGaugeLength_X";
            this.StrainGaugeLength_X.Size = new System.Drawing.Size(281, 43);
            this.StrainGaugeLength_X.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1414, 686);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 37);
            this.label5.TabIndex = 23;
            this.label5.Text = "Length (X)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1414, 784);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 37);
            this.label6.TabIndex = 24;
            this.label6.Text = "Width (Y)";
            // 
            // StrainGaugeWidth_Y
            // 
            this.StrainGaugeWidth_Y.Location = new System.Drawing.Point(1414, 827);
            this.StrainGaugeWidth_Y.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.StrainGaugeWidth_Y.Name = "StrainGaugeWidth_Y";
            this.StrainGaugeWidth_Y.Size = new System.Drawing.Size(281, 43);
            this.StrainGaugeWidth_Y.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(874, 1034);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 37);
            this.label7.TabIndex = 26;
            this.label7.Text = "Feb 25, 2022";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(874, 1095);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(591, 37);
            this.label8.TabIndex = 27;
            this.label8.Text = "ONLY Base Layer and Silver Traces currently work";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(874, 1132);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(875, 37);
            this.label9.TabIndex = 28;
            this.label9.Text = "Make sure all file paths are corrected in Form1.cs before running this GUI";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(874, 1169);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(989, 37);
            this.label10.TabIndex = 29;
            this.label10.Text = "Base Layer will give the GCode of the bottom layer given the GCode of a CAD part";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(874, 1280);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(870, 37);
            this.label11.TabIndex = 30;
            this.label11.Text = "Silver Traces will print footprints of parts, square pads, and strain gauges";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(938, 1206);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(673, 37);
            this.label12.TabIndex = 31;
            this.label12.Text = "Enter your GCode of your CAD part in the GCode folder";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(938, 1243);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(357, 37);
            this.label13.TabIndex = 32;
            this.label13.Text = "Enter its file path in Form1.cs";
            // 
            // selection_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2713, 1436);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.StrainGaugeWidth_Y);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StrainGaugeLength_X);
            this.Controls.Add(this.SG_PartIncluded);
            this.Controls.Add(this.PadSize_Side);
            this.Controls.Add(this.Pad_PartIncluded);
            this.Controls.Add(this.WiFi_PartIncluded);
            this.Controls.Add(this.BC_PartIncluded);
            this.Controls.Add(this.PC_PartIncluded);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.YOrigin_GUI_Value);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.XOrigin_GUI_Value);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ID_GUI_Value);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VoidSuggestion);
            this.Controls.Add(this.GCodeOutputText);
            this.Controls.Add(this.top_radiobutton);
            this.Controls.Add(this.resin_button);
            this.Controls.Add(this.glue_radiobutton);
            this.Controls.Add(this.void_radiobutton);
            this.Controls.Add(this.silver_radiobutton);
            this.Controls.Add(this.base_radiobutton);
            this.Controls.Add(this.button_generate);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "selection_form";
            this.Text = "GCodeGenerator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VoidSuggestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_GUI_Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XOrigin_GUI_Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YOrigin_GUI_Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PadSize_Side)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrainGaugeLength_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrainGaugeWidth_Y)).EndInit();
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
        private TextBox GCodeOutputText;
        private PictureBox VoidSuggestion;
        private Label label1;
        private NumericUpDown ID_GUI_Value;
        private Label label2;
        private NumericUpDown XOrigin_GUI_Value;
        private Label label3;
        private NumericUpDown YOrigin_GUI_Value;
        private Label label4;
        private CheckBox PC_PartIncluded;
        private CheckBox BC_PartIncluded;
        private CheckBox WiFi_PartIncluded;
        private CheckBox Pad_PartIncluded;
        private NumericUpDown PadSize_Side;
        private CheckBox SG_PartIncluded;
        private NumericUpDown StrainGaugeLength_X;
        private Label label5;
        private Label label6;
        private NumericUpDown StrainGaugeWidth_Y;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
    }
}