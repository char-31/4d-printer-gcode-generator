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
                //Patterns to Find in Code
                string pattern1 = @"Z:3.2";     //Will only find the first instance of pattern
                string pattern2 = @"END CODE";  //Will only find last instance of pattern

                // Make sure any "\" become "\\"
                string base_gcode = "C:\\Users\\mossc\\Documents\\4D Print RESEARCH\\BusinessBRICK.gcode";  //Complete GCODE file for the part
                string copy_gcode = "C:\\Users\\mossc\\Documents\\4D Print RESEARCH\\~Brick1.GCODE";        //Creates file or adds on to existing file
                
                string line;        //Variable for current line of text read
                int find1 = 0;      //Varible to note when pattern has been found

                //FINDS 1ST PHRASE AND WRITES NEW TEXT FILE FROM START TO LINE WHERE THE PHRASE IS FOUND
                //          Does both reading and writing at the same time up to pattern 1
                try
                {
                    //Pass the file path and file name to the StreamReader constructor and StreamWriter constructor
                    StreamReader sr = new StreamReader(base_gcode);
                    StreamWriter sw = new StreamWriter(copy_gcode, true, Encoding.ASCII);
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file or when the 1st pattern has been found
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

                    //If not successful, will output this phrase (and the whole text file will be copied to the new one)
                    if (find1 == 0)
                    {
                        this.output_text.Text += "Phrase not found in text. \r\n";
                    }
                }


                //FIND AND WRITE ENDING PORTION OF THE CODE (FINDS 2ND PATTERN)
                //          Reads the whole file to find the last instance of pattern and then writes from line containing pattern to the end of the file
                int find2 = 0;          //Keeps track of if the pattern is found in the text file
                int countLine = 0;      //Counts line numbers to keep track of where the patterns are found
                int lastLine = 0;       //For finding the last instance of the 2nd pattern
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
                            lastLine = countLine;       //Will note the line number of the last instance of the pattern

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

                    //If the phrase is not found, will output this and will not do the next writing section to the text file
                    if (find2 == 0)
                    {
                        this.output_text.Text += "Phrase not found in text. \r\n";
                    }
                }

                //Will complete only if the 2nd phrase was found
                if (find2 > 0)
                {
                    int count = 0;
                    try
                    {
                        //Pass the file path and file name to the StreamReader and StreamWriter constructor
                        StreamReader sr = new StreamReader(base_gcode);
                        StreamWriter sw = new StreamWriter(copy_gcode, true, Encoding.ASCII);
                        //Read the first line of text
                        line = sr.ReadLine();

                        //Reads to the line before the second pattern
                        while (count < (lastLine - 2))
                        {
                            count += 1;
                            line = sr.ReadLine();
                        }

                        //Starts writing from selected line to the end of the text file
                        while (line != null)
                        {
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
            //End of BASE Button Code


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