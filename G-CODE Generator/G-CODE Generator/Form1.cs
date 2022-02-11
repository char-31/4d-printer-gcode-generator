namespace G_CODE_Generator
{
    using System;
    using System.Text.RegularExpressions;
    public partial class selection_form : Form
    {
        public selection_form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            string pattern = @"G90";
            string input = "G1 X163 Y90 G90";
            Match m_code = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            if (m_code.Success)
                this.output_text.Text += "Found " + m_code.Value + " at position " + m_code.Index + "\r\n";

        }
        private void base_radiobutton_CheckedChanged(object sender, EventArgs e)
        {
            this.output_text.Text += "Input G-CODE: \r\n";
        }

    }
}