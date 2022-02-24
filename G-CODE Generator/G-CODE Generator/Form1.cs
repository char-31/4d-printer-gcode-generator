namespace G_CODE_Generator
{
    using System;
    using System.IO;
    using System.Text;
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
            //BASE Radio Button Code
            if (base_radiobutton.Checked == true)
            {
                //The First phrase to find in the text (cutoff point)
                string pattern1 = @"Z:3.2";

                string line;
                int find1 = 0;
                // Make sure any \ become \\`
                string base_gcode = "C:\\Users\\mossc\\Documents\\4D Print RESEARCH\\BusinessBRICK.gcode";
                string copy_gcode = "C:\\Users\\mossc\\Documents\\4D Print RESEARCH\\~Brick1.gcode";

                //FINDS PHRASE AND WRITES NEW TEXT FILE FROM START TO LINE WHERE THE PHRASE IS FOUND
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(base_gcode);
                    StreamWriter sw = new StreamWriter(copy_gcode, true, Encoding.ASCII);
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (find1 == 0 && line != null)
                    {
                        //Search for pattern in current line
                        Match m_code = Regex.Match(line, pattern1, RegexOptions.IgnoreCase);
                        if (m_code.Success)
                        {
                            //this.output_text.Text += "Found " + m_code.Value + "\r\n";
                            //Can add: at m_code.Index
                            find1 = 1;
                            sw.WriteLine(line);
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                        //Display the line to output text box (debugging only)
                        //this.output_text.Text += line + "\r\n";

                        //Read the next line
                        line = sr.ReadLine();
                    }

                    //close the file
                    sr.Close();
                    sw.Close();
                    Console.ReadLine();
                }
                finally
                {
                    this.output_text.Text += "Search and Write Complete. \r\n";
                    if (find1 == 0)
                    {
                        this.output_text.Text += "Phrase not found in text. \r\n";
                    }
                }



                //FIND AND WRITE ENDING PORTION OF THE CODE
                string pattern2 = @"G92 E0";
                int find2 = 0;
                int countLine = 0;
                int lastLine = 0;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(base_gcode);
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        countLine += 1;
                        //Search for pattern in current line
                        Match m_code = Regex.Match(line, pattern2, RegexOptions.IgnoreCase);
                        if (m_code.Success)
                        {
                            //this.output_text.Text += "Found " + m_code.Value + " at line " + countLine + "\r\n";
                            find2 += 1;
                            lastLine = countLine;

                        }
                        //Read the next line
                        line = sr.ReadLine();
                    }
                    //close the file
                    sr.Close();
                    Console.ReadLine();
                }
                finally
                {
                    this.output_text.Text += "Search Complete. \r\n";
                    if (find2 == 0)
                    {
                        this.output_text.Text += "Phrase not found in text. \r\n";
                    }
                }

                if (find2 > 0)
                {

                    int count = 0;
                    try
                    {
                        //Pass the file path and file name to the StreamReader constructor (**Make sure any \ characters become \\**)
                        StreamReader sr = new StreamReader(base_gcode);
                        StreamWriter sw = new StreamWriter(copy_gcode, true, Encoding.ASCII);
                        //Read the first line of text
                        line = sr.ReadLine();
                        while (count < (lastLine - 2))
                        {
                            count += 1;
                            line = sr.ReadLine();
                        }
                        while (line != null)
                        {
                            count += 1;
                            line = sr.ReadLine();
                            sw.WriteLine(line);

                        }
                        //close the file
                        sr.Close();
                        sw.Close();
                        Console.ReadLine();
                    }
                    finally
                    {
                        this.output_text.Text += "Write Complete. \r\n";
                    }
                }
            }



            //SILVER LINES Radio Button Code
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