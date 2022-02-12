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

        //All of your code that involves "checking if buttons are clicked" must be in "private void button_generate_Click" which will be refered to as the main body
        //If you need to make any code that involves calculations, create a function in the proper sections below, then call them in the main body
        //Example: In the main body I will check if the button to print a pad is called and I will use a function called "make_pad"
        //           This function make_pad will be created outside of the main body and will involve all the calculations and outputting of text

        private void button_generate_Click(object sender, EventArgs e)
        {
            string pattern = @"G90";
            string input = "G1 X163 Y90 G90";
            Match m_code = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            if (m_code.Success)
                this.output_text.Text += "Found " + m_code.Value + " at position " + m_code.Index + "\r\n";

        }

        //Enter your code for BASE Radio Button here

        //

        //Enter your code for SILVER LINES Radio Button here

        //
        //Enter your code for VOIDS Radio Button here

        //
        //Enter your code for ANISOTROPIC GLUE Radio Button here

        //
        //Enter your code for RESIN Radio Button here

        //
        //Enter your code for TOP LAYER Radio Button here

        //







    }
}