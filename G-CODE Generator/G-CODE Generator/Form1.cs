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
            //File Paths for Copy Code
            // Make sure any "\" become "\\"
            string base_gcode = "C:\\Users\\mossc\\Documents\\4D Print RESEARCH\\visual_studio_test2.GCODE";    //Complete GCODE file for the part
            string copy_gcode = "C:\\Users\\mossc\\Documents\\4D Print RESEARCH\\~Base1.GCODE";     //Creates file or adds on to existing file

            //BASE Radio Button Code
            //Cuts the GCODE file to have the initialization, base layer, and the end portion
            //Will immediately start once the okay button is clicked
            if (base_radiobutton.Checked == true)
            {
                //Patterns to Find in Code
                string pattern1 = @"Z:3.2";     //Will only find the first instance of pattern
                string pattern2 = @"END CODE";  //Will only find last instance of pattern
                //Make sure that in the GCode file for the CAD part, ender ";END CODE" before the last G92 E0

                //FINDS 1ST PHRASE AND WRITES NEW TEXT FILE FROM START TO LINE WHERE THE PHRASE IS FOUND
                //          Does both reading and writing at the same time up to pattern 1
                //          Calls function to copy the first part of code
                Copy_Initialization(pattern1, base_gcode, copy_gcode);


                //FIND AND WRITE ENDING PORTION OF THE CODE (FINDS 2ND PATTERN)
                //          Reads the whole file to find the last instance of pattern and then writes from line containing pattern to the end of the file
                //          Calls function to copy last part of code
                Copy_End(pattern2, base_gcode, copy_gcode);

            }
            //End of BASE Button Code


            //SILVER LINES Radio Button Code
            if (silver_radiobutton.Checked == true)
            {
                Initialization_Silver(); //Output the GCODE that sets the printer and printer head for silver extrusion 
                Print_Element();
                End();
            }
            //End of SILVER LINES Button Code


            //VOIDS Button Code
            if (void_radiobutton.Checked == true)
            {
                //Patterns to Find in Code
                string void_pattern1 = @"END INITIALIZATION";       //First pattern (end of initialization)
                string void_pattern2 = @"Z:3.2";                    //Second pattern (begining of void section)
                string void_pattern3 = @"Z:5";                      //Third pattern (end of void section)
                string void_pattern4 = @"END CODE";                 //Last pattern (start of final section of the code)
                //Make sure that in the GCode file for the CAD part, ender ";END CODE" before the last G92 E0

                Copy_Initialization(void_pattern1, base_gcode, copy_gcode);

                //CODE TO FIND THE MIDDLE SECTION OF CODE ONLY
                string line;
                int find2 = 0;          //Keeps track of if the second pattern is found in the text (finding the BEGINING of the void section)
                int find3 = 0;          //Keeps track of if the third pattern is found in the text (finding the END of the void section)
                int countLine = 0;      //Counts line numbers to keep track of where the patterns are found
                int pattern2_Line = 0;       //For finding the last instance of the 2nd pattern
                int pattern3_Line = 0;       //For finding the instance of the 3rd pattern
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
                        //Search for 2nd pattern in current line
                        Match m_code = Regex.Match(line, void_pattern2, RegexOptions.IgnoreCase);
                        if (m_code.Success)
                        {
                            //this.output_text.Text += "Found " + m_code.Value + " at line " + countLine + "\r\n";
                            find2 += 1;
                            pattern2_Line = countLine;       //Will note the line number of the last instance of the pattern

                        }

                        //Search for 3rd pattern in current line
                        Match p_code = Regex.Match(line, void_pattern3, RegexOptions.IgnoreCase);
                        if (p_code.Success)
                        {
                            //this.output_text.Text += "Found " + m_code.Value + " at line " + countLine + "\r\n";
                            find3 += 1;
                            pattern3_Line = countLine;       //Will note the line number of the last instance of the pattern

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
                    if (find2 > 0 || find3 > 0)
                    {
                        this.GCodeOutputText.Text += "Void Section: Search Complete. \r\n";
                    }
                    else
                    {
                        //If either phrase is not found, will output this and will not do the next writing section to the text file
                        if (find2 == 0)
                        {
                            this.GCodeOutputText.Text += "1st Phrase not found in text. \r\n";
                        }
                        if (find3 == 0)
                        {
                            this.GCodeOutputText.Text += "2st Phrase not found in text. \r\n";
                        }
                    }
                }

                //Will complete only if the 2nd and 3rd phrases was found
                if (find2 > 0 && find3 > 0)
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
                        while (count < (pattern2_Line - 2))
                        {
                            count += 1;
                            line = sr.ReadLine();
                        }

                        //Starts writing from the 2nd pattern to 3rd pattern
                        while (line != null && count < (pattern3_Line - 1))
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
                        this.GCodeOutputText.Text += "Void Section: Write Complete. \r\n";
                    }

                    Copy_End(void_pattern4, base_gcode, copy_gcode);
                }
            }

            //TOP Layer Button Code
            if (top_radiobutton.Checked == true)
            {
                //Patterns to Find in Code
                string top_pattern1 = @"END INITIALIZATION";       //First pattern (end of initialization)
                string top_pattern2 = @"Z:5";                    //Second pattern (begining of final section- top and end sections)

                //Calls function to copy initialization section of gcode (up to pattern 1)
                Copy_Initialization(top_pattern1, base_gcode, copy_gcode);

                //Calls function to copy final section that includes the top section and the end section (from pattern 2 to end)
                Copy_End(top_pattern2, base_gcode, copy_gcode);

            }


        }

        //FUNCTIONS

        //Enter your functions for BASE Radio Button here
        void Copy_Initialization(string pattern, string base_gcode, string copy_gcode)
        {
            //This function reads and copies from the begining of a gcode file to a specified text pattern found within the file
            //Used for both BASE and VOID radio button

            string line;        //Variable for current line of text read
            int find1 = 0;      //Varible to note when pattern has been found
            int countLine = 0;
            int count = 0;

            try
            {
                //Pass the file path and file name to the StreamReader constructor and StreamWriter constructor
                StreamReader sr = new StreamReader(base_gcode);
                //Read the first line of text
                line = sr.ReadLine();
                countLine += 1;
                //Continue to read until you reach end of file or when the 1st pattern has been found
                while (find1 == 0 && line != null)
                {
                    //Search for pattern in current line
                    Match m_code = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
                    if (m_code.Success)
                    {
                        //this.output_text.Text += "Found " + m_code.Value + "\r\n";
                        //Can add: at m_code.Index

                        find1 = 1;
                    }
                    //Display the line to output text box (debugging only)
                    //this.output_text.Text += line + "\r\n";

                    //Read the next line
                    line = sr.ReadLine();
                    countLine += 1;
                }

                //close the file
                sr.Close();
                Console.ReadLine();
            }
            finally
            {
                if (find1 > 0)
                {
                    this.GCodeOutputText.Text += "First Section: Search Complete. \r\n";
                }
                else
                {
                    //If not successful, will output this phrase (and the whole text file will be copied to the new one)
                    this.GCodeOutputText.Text += "Phrase not found in text. \r\n";
                }
                
            }

            if (find1 > 0)
            {
                try
                {
                    //Pass the file path and file name to the StreamReader constructor and StreamWriter constructor
                    StreamReader sr = new StreamReader(base_gcode);
                    StreamWriter sw = new StreamWriter(copy_gcode, true, Encoding.ASCII);
                    //Read the first line of text
                    line = sr.ReadLine();
                    count += 1;
                    //Continue to read until you reach end of file or when the 1st pattern has been found
                    while (count <= (countLine - 1) && line != null)
                    {
                        sw.WriteLineAsync(line);

                        //Read the next line
                        line = sr.ReadLine();
                        count += 1;
                    }

                    //close the file
                    sr.Close();
                    sw.Close();
                    Console.ReadLine();
                }
                finally
                {
                    this.GCodeOutputText.Text += "First Section: Write Complete. \r\n";

                }
            }

        }

        void Copy_End(string pattern, string base_gcode, string copy_gcode)
        {
            //This function reads and copies code from a specified pattern (last instance) to the end of the gcode text file
            //Used for BASE and VOIDS

            string line;
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
                    Match m_code = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
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
                //If the phrase is not found, will output this and will not do the next writing section to the text file
                if (find2 == 0)
                {
                    this.GCodeOutputText.Text += "Phrase not found in text. \r\n";
                }
                else
                {
                    this.GCodeOutputText.Text += "End Section: Search Complete. \r\n";
                }
            }

            //Will complete only if the phrase was found
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

                    //Reads to the line before the pattern
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
                    this.GCodeOutputText.Text += "End Section: Write Complete. \r\n";
                }
            }
        }



        //Enter your functions for SILVER LINES Radio Button here
        void Initialization_Silver()
        {
            //This function adds the printer settings for silver printing
            //Uses the 1cc liquid extruder at T15
            //Syringe needle inner diameter will be pulled from the GUI
            //This function will give the initial settings, raise the head to a height of 30 mm, go to the starting coordinate (from the GUI), and lower the head to a height of 0.2 mm for printing

            this.GCodeOutputText.Text = ";The following section will start up the printer heads, beds, and apply the desired settings for the intended print job\r\n";
            this.GCodeOutputText.Text += ";Printed heads used: 1cc Liquid Extruder Head placed on T15\r\n";
            this.GCodeOutputText.Text += ";\r\n";
            this.GCodeOutputText.Text += "G53  ;Clear offsets\r\n";
            this.GCodeOutputText.Text += "G21  ;Set units to mm\r\n";
            this.GCodeOutputText.Text += "G90  ;Change to absolute coordinates\r\n";
            this.GCodeOutputText.Text += "T15  ;The following settings will apply to the head on T15\r\n"; //The printer uses the 1cc liquid extruder head on T15
            this.GCodeOutputText.Text += "M756 S0.1  ;Used un further calculations (0.1mm layer height)\r\n";
            this.GCodeOutputText.Text += "M6 T15 O1 X0 Y0 Z0  ;Declare head offsets\r\n";
            this.GCodeOutputText.Text += "M721 S10000 E6000 P-100 T15  ;Set unprime values\r\n";
            this.GCodeOutputText.Text += "M722 S10000 E6000 P-100 T15  ;Set prime values\r\n";
            decimal InnerDiameter = ID_GUI_Value.Value;
            //The inner diameter of the syringe needle tip used will be taken from the GUI and entered here
            this.GCodeOutputText.Text += "M221 S1 T15 P270 W" + InnerDiameter.ToString() + " Z0.4  ;Inner diameter of syringe needle tip to be used for T15: " + InnerDiameter.ToString() + "mm\r\n";
            this.GCodeOutputText.Text += "M82  ;Absolute E values\r\n";
            this.GCodeOutputText.Text += "M229 E0 D0  ;Doesn't use custom E values\r\n";
            this.GCodeOutputText.Text += "G28 X0 Y0  ;Send the printer head to the physical home\r\n";
            this.GCodeOutputText.Text += "G92 X0 Y0  ;Reset coordinates\r\n";
            this.GCodeOutputText.Text += "G0 Z30  ;Go to height of 30 mm\r\n";
            decimal XOrigin = XOrigin_GUI_Value.Value;
            decimal YOrigin = YOrigin_GUI_Value.Value;
            this.GCodeOutputText.Text += "G1 X" + XOrigin.ToString() + " Y" + YOrigin.ToString() + " F2400  ;Go to these coordinates at speed 2400 mm/min\r\n"; //Goes to the starting coordinate for printing
            this.GCodeOutputText.Text += "G0 Z0.2  ;Go to height of 0.2 mm\r\n";
            this.GCodeOutputText.Text += "G91  ;Change to relative coordinates\r\n\r\n";
        }

        void End()
        {
            //This function raises the head to a height of 30 mm, returns the head to the starting position, and turns off all printer heads and the printer bed
            //This function can be used regardless of what printer heads or print job is carried out

            this.GCodeOutputText.Text += "\r\n;This section of the code turns off the printer heads, printer bed, returns everything to the home, and shuts down everything\r\n";
            this.GCodeOutputText.Text += ";\r\n";
            this.GCodeOutputText.Text += "G90  ;Change to absolute coordinates\r\n";
            this.GCodeOutputText.Text += "G0 Z30  ;Go to height of 30 mm\r\n";
            this.GCodeOutputText.Text += "G92 E0  ;Reset E value to 0\r\n";
            this.GCodeOutputText.Text += "G28 X0 Y0 ;Send to physical home\r\n";
            this.GCodeOutputText.Text += "M106 T10 S0  ;Turns off cooling fan\r\n";
            this.GCodeOutputText.Text += "M104 T10 S0  ;Turns off printer head temperature\r\n";
            this.GCodeOutputText.Text += "M140 S0  ;Turns off bed heater\r\n";
            this.GCodeOutputText.Text += "G91  ;Change to relative coordinates\r\n";
            this.GCodeOutputText.Text += "G90  ;Change to absolute coordinates\r\n";
            this.GCodeOutputText.Text += "M84  ;Disable motors\r\n";
            this.GCodeOutputText.Text += "M30  ;End the program\r\n";
        }

        void Print_SquarePad(decimal side)
        {
            //This function uses a unique path to print square pads of any size using a liquid extruder head
            //The path is: 
            //   One spiral with the extrusion rate at half of the normal extrusion rate
            //   A second spiral on top of the previous one at the normal extrusion rate
            //   Printing "sevens" from the center to fill the sides and corners of the pad
            //   And a final spiral with no extrusion, where the syringe needle tip will spread the extruded liquid around to fill any gaps 
            //This function can be used to print silver contact pads for parts, or testing pads for alligator clips

            decimal InnerDiameter = ID_GUI_Value.Value; //Syringe inner diameter is pulled from the GUI
            decimal Side_Half = side / 2; //Half of the pad's side length will be used in further calculations
            decimal Spiral_Pitch = InnerDiameter / 2; //The pitch is how far apart the traces in the spiral is
            decimal Spiral_Laps = (side / 2) / Spiral_Pitch; //To calculate the number of laps to make the spiral, multiply the pitch with the radius of the intended circle, or half the pad's side length
            decimal Spiral_Displacement = Spiral_Pitch * Spiral_Laps; //How far apart along the X axis the syringe needle displaced to return back to the origin of the spiral

            //Sets the extrusion rate to half and prints the first spiral
            this.GCodeOutputText.Text += ";This section of the code will print a square pad of " + side.ToString() + " mm in length\r\n";
            this.GCodeOutputText.Text += ";The pad is printed by a spiral at half extrusion rate, another at normal extrusion rate, filling the corners and sides, and a third spiral with no extrusion rate\r\n";
            this.GCodeOutputText.Text += ";This pad will yield a smooth and planar top\r\n\r\n";
            this.GCodeOutputText.Text += "M221 S0.5 T15 P270 W" + InnerDiameter.ToString() + " Z0.4  ;Sets extrusion rate to half\r\n";
            this.GCodeOutputText.Text += "G2.1 I0.1 J0 P" + Spiral_Pitch.ToString() + " L" + Spiral_Laps.ToString() + " E1 R2 F400  ;Prints first spiral\r\n";

            //Returns to the origin of the spiral
            this.GCodeOutputText.Text += "G1 X" + Spiral_Displacement.ToString() + " E0 F400  ;Move back to the center\r\n";

            //Sets the extrusion rate to normal capacity and prints the second spiral
            this.GCodeOutputText.Text += "M221 S1 T15 P270 W" + InnerDiameter.ToString() + " Z0.4  ;Set extrusion rate to normal\r\n";
            this.GCodeOutputText.Text += "G2.1 I0.1 J0 P" + Spiral_Pitch.ToString() + " L" + Spiral_Laps.ToString() + " E1 R2 F400  ;Prints second spiral\r\n";

            //Returns to the origin of the spiral
            this.GCodeOutputText.Text += "G1 X" + Spiral_Displacement.ToString() + " E0 F400  ;Moves back to the center\r\n";

            //Print "sevens"
            this.GCodeOutputText.Text += ";Prints sevens to fill in the corners and the sides of the square pad\r\n";
            this.GCodeOutputText.Text += "G1 X-" + Side_Half.ToString() + " Y-" + Side_Half.ToString() + " E1 F400\r\n";
            this.GCodeOutputText.Text += "G1 X" + side.ToString() + " E1 F400\r\n";
            this.GCodeOutputText.Text += "G1 X-" + Side_Half.ToString() + " Y" + Side_Half.ToString() + " E1 F400\r\n";
            this.GCodeOutputText.Text += "G1 X" + Side_Half.ToString() + " Y-" + Side_Half.ToString() + " E1 F400\r\n";
            this.GCodeOutputText.Text += "G1 Y" + side.ToString() + " E1 F400\r\n";
            this.GCodeOutputText.Text += "G1 X-" + Side_Half.ToString() + " Y-" + Side_Half.ToString() + " E1 F400\r\n";
            this.GCodeOutputText.Text += "G1 X" + Side_Half.ToString() + " Y" + Side_Half.ToString() + " E1 F400\r\n";
            this.GCodeOutputText.Text += "G1 X-" + side.ToString() + " E1 F400\r\n";
            this.GCodeOutputText.Text += "G1 X" + Side_Half.ToString() + " Y-" + Side_Half.ToString() + " E1 F400\r\n";
            this.GCodeOutputText.Text += "G1 X-" + Side_Half.ToString() + " Y" + Side_Half.ToString() + " E1 F400\r\n";
            this.GCodeOutputText.Text += "G1 Y-" + side.ToString() + " E1 F400\r\n";

            //Returns to the origin of the spiral
            this.GCodeOutputText.Text += "G1 X" + Side_Half.ToString() + " Y" + Side_Half.ToString() + " E1 F400  ;Move back to the center\r\n";

            //Moves the syringe needle tip in a third spiral without extruding
            this.GCodeOutputText.Text += "G2.1 I0.1 J0 P" + Spiral_Pitch.ToString() + " L" + Spiral_Laps.ToString() + " E0 R2 F400  ;Move the printer head along the third spiral\r\n";

            //Returns to the origin of the spiral
            this.GCodeOutputText.Text += "G1 X" + Side_Half.ToString() + " Y" + Side_Half.ToString() + " E1 F400  ;Move back to the center\r\n";
        }

        void Print_Pad_KnownShape(decimal length_pad, decimal width_pad)
        {
            //This function will generate the GCode for printing a simple pad from the given length and width using a liquid extruder head
            //The pad is printed using a Snake Pattern (down, left, up, left...) and will always end in the bottom left corner
            //The function will always produce a pad smaller than or equal to the intended size. It will NEVER overshoot the given parameters
            //This function can be used for generating squares or rectangles without any regard to its planarity or density (usually used in strain gauge printing to connect the traces together)

            this.GCodeOutputText.Text += ";Print a pad of size " + length_pad.ToString() + "x" + width_pad.ToString() + " mm size\r\n";
            decimal Width = width_pad; //Width of the pad
            decimal Length = length_pad; //Length of the pad
            decimal Overlap = 50; //Used to calculate how far the syringe needle tip will overlap its current trace when filling in a known shape
            decimal offset = ID_GUI_Value.Value * (Overlap / 100); //The overlap percentage with the inner diameter will give the distance (in mm) to jump over to print the next adjacent trace when filling in a known shape
            decimal limit = Width / offset; //Used in the for loop 

            //If Directioncheck equals to 0, a trace was printed towards the bottom left corner
            //If Directioncheck equals to 1, a trace was printed towards the top left corner
            decimal Directioncheck = 0; 

            decimal LimitCheck = 0; //To keep trace how much distance was covered by going left
            for (int x = 0; x <= (limit / 2); x++) //This for loop will print the pad and make sure it stays under the desired length
            {
                this.GCodeOutputText.Text += "G1 Y" + Width.ToString() + " E1 F400\r\n";
                if (LimitCheck + offset > Length) break; //If printing left would overexceed the desired length, break from the for loop (stop printing the pad)
                this.GCodeOutputText.Text += "G1 X" + offset.ToString() + " E1 F400\r\n";
                LimitCheck += offset; //Since it went left, LimitCheck will be added to keep track
                if (LimitCheck >= Length) //A seperate check similar to above, but for changing the Directioncheck flag
                {
                    this.GCodeOutputText.Text += "G1 Y-" + Width.ToString() + " E1 F400\r\n";
                    Directioncheck = 1; //Raises the Directioncheck flag for moving towards the bottom left corner
                    break;
                }
                this.GCodeOutputText.Text += "G1 Y-" + Width.ToString() + " E1 F400\r\n";
                if (LimitCheck + offset > Length) break; //If printing left would overexceed the desired length, break from the for loop (stop printing the pad)
                this.GCodeOutputText.Text += "G1 X" + offset.ToString() + " E1 F400\r\n";
                LimitCheck += offset; //Since it went left, LimitCheck will be added to keep track
                if (LimitCheck >= Length) //A seperate check similar to above, but for moving towards the bottom left corner
                {
                    this.GCodeOutputText.Text += "G1 Y" + Width.ToString() + " E1 F400\r\n";
                    break;
                }
            }

            if (Directioncheck == 1) //If the Directioncheck flag is raised, the syringe needle tip will move to the bottom left corner of the pad
            {
                this.GCodeOutputText.Text += "G1 Y" + Width.ToString() + " F2400\r\n";
            }
        }

        void Print_StrainGauge(decimal SGLength, decimal SGWidth, decimal SGRotation)
        {
            //This function will print a strain gauge of any known length and width, connected to 10 mm leads and 5x5 mm contact pads, and will rotate the entire structure given the desired degrees
            //This function will begin at the top right corner of a 5x5 mm pad, print it, 10 mm lead from its center, the first trace of the SG, a 2x3 mm pad, then another trace moving downwards
            //From this point, the function will repeat a pattern (pad, up, pad, down) and will make sure that it stays under the desired length
            //Before printing this pattern, it will check whether printing it will overshoot the length
            //If overshooting will occur, the function will print a 10 mm trace and a 5x5 mm contact pad and end in the bottom left corner of that pad

            this.GCodeOutputText.Text += ";This section of the code will print a strain gauge of size " + SGLength.ToString() + "x" + SGWidth.ToString() + " mm\r\n";
            this.GCodeOutputText.Text += ";The strain gauge will be connected to 10 mm traces, which will be connected to the center of 5x5 mm pads\r\n";
            this.GCodeOutputText.Text += ";The strain gauge will start at the top right of the right contact pad and end at the bottom left of the left contact pad\r\n\r\n";

            switch (SGRotation)
            {
                case 0:
                    Print_Pad_KnownShape(5, 5); //Prints the first contact pad
                    this.GCodeOutputText.Text += "G1 X-2.5 Y-2.5 E1 F400\r\n"; //Moves to the center of the pad
                    this.GCodeOutputText.Text += ";\r\n";

                    //Drawing the 10 mm trace to connect the first contact pad to the strain gauge
                    decimal Contact_Distance = 10;
                    this.GCodeOutputText.Text += ";Print a 10 mm trace to connect with the strain gauge\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    decimal SGPadLength = 2;
                    decimal SGPadWidth = 3;

                    this.GCodeOutputText.Text += ";Print the strain gauge\r\n";
                    //Drawing the first trace of the strain gauge
                    this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    Print_Pad_KnownShape(SGPadLength, SGPadWidth); //Prints the first 2x3 mm pad in the strain gauge
                    this.GCodeOutputText.Text += "G1 Y-" + SGPadWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    decimal DistanceToCover = SGLength - SGPadLength; //Used in the for loop to check how much distance is left to cover for printing the strain gauge's length
                    decimal DistanceCovered = SGPadLength; //Used to cover how much distance in the X direction is covered

                    for (int x = 0; x < DistanceToCover; x = x + (int)(SGPadLength * 2))
                    {
                        if ((DistanceCovered + (SGPadLength * 2)) > SGLength)
                            break; //Before printing, if it prints the pattern and overshoots, it will break from the for loop before printing the pattern


                        //This section will print the pattern: pad, up, pad, down

                        this.GCodeOutputText.Text += "G1 Y-" + SGPadWidth.ToString() + "E1 F400\r\n";
                        Print_Pad_KnownShape(SGPadLength, SGPadWidth); //Pad
                        this.GCodeOutputText.Text += ";\r\n"; //Up
                        this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n";
                        Print_Pad_KnownShape(SGPadLength, SGPadWidth); //Pad
                        this.GCodeOutputText.Text += "G1 Y-" + SGPadWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n"; //Down
                        this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n";

                        DistanceCovered += (int)(SGPadLength * 2); //Makes sure to record how much distance was covered to check in the beginning of the for loop
                    }

                    this.GCodeOutputText.Text += ";End the printing of the strain gauge\r\n;\r\n";

                    //Prints the second 10 mm trace
                    this.GCodeOutputText.Text += ";Print a 10 mm trace to connect with the left contact pad\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + Contact_Distance.ToString() + "E1 F400\r\n";
                    decimal RemainingDistance = SGLength - DistanceCovered; //If any length is left but not covered because this function stopped early, then it will print a trace along the X axis to cover for that distance
                    this.GCodeOutputText.Text += "G1 X" + RemainingDistance.ToString() + " E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-2.5 Y-2.5 E1 F400\r\n"; //Moves to print the final contact pad
                    this.GCodeOutputText.Text += ";\r\n";

                    Print_Pad_KnownShape(5, 5); //Prints the final 5x5 mm contact pad
                    break;

                case 45:

                    break;

                case 90:
                    Print_Pad_KnownShape(5, 5); //Prints the first contact pad
                    this.GCodeOutputText.Text += "G1 X-2.5 Y-2.5 E1 F400\r\n"; //Moves to the center of the pad
                    this.GCodeOutputText.Text += ";\r\n";

                    //Drawing the 10 mm trace to connect the first contact pad to the strain gauge
                    Contact_Distance = 10;
                    this.GCodeOutputText.Text += ";Print a 10 mm trace to connect with the strain gauge\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    SGPadLength = 3;
                    SGPadWidth = 2;

                    this.GCodeOutputText.Text += ";Print the strain gauge\r\n";
                    //Drawing the first trace of the strain gauge
                    this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    this.GCodeOutputText.Text += "G1 Y-" + SGPadWidth.ToString() + "E1 F400\r\n";
                    Print_Pad_KnownShape(SGPadLength, SGPadWidth); //Prints the first 2x3 mm pad in the strain gauge
                    this.GCodeOutputText.Text += "G1 X-" + SGPadLength.ToString() + " Y-" + SGPadWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";
                    this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    DistanceToCover = SGLength - SGPadLength; //Used in the for loop to check how much distance is left to cover for printing the strain gauge's length
                    DistanceCovered = SGPadLength; //Used to cover how much distance in the X direction is covered

                    for (int x = 0; x < DistanceToCover; x = x + (int)(SGPadLength * 2))
                    {
                        if ((DistanceCovered + (SGPadLength * 2)) > SGLength)
                            break; //Before printing, if it prints the pattern and overshoots, it will break from the for loop before printing the pattern


                        //This section will print the pattern: pad, up, pad, down
                        this.GCodeOutputText.Text += "G1 X-" + SGPadLength.ToString() + " Y-" + SGPadWidth.ToString() + "E1 F400\r\n";
                        Print_Pad_KnownShape(SGPadLength, SGPadWidth); //Pad
                        this.GCodeOutputText.Text += "G1 Y-" + SGPadWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n"; //Up
                        this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n";
                        this.GCodeOutputText.Text += "G1 Y-" + SGPadWidth.ToString() + "E1 F400\r\n";
                        Print_Pad_KnownShape(SGPadLength, SGPadWidth); //Prints the first 2x3 mm pad in the strain gauge
                        this.GCodeOutputText.Text += "G1 X-" + SGPadLength.ToString() + " Y-" + SGPadWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n"; //Down
                        this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n";

                        DistanceCovered += (int)(SGPadLength * 2); //Makes sure to record how much distance was covered to check in the beginning of the for loop
                    }

                    this.GCodeOutputText.Text += ";End the printing of the strain gauge\r\n;\r\n";

                    //Prints the second 10 mm trace
                    this.GCodeOutputText.Text += ";Print a 10 mm trace to connect with the left contact pad\r\n";
                    this.GCodeOutputText.Text += "G1 X" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + Contact_Distance.ToString() + "E1 F400\r\n";
                    RemainingDistance = SGLength - DistanceCovered; //If any length is left but not covered because this function stopped early, then it will print a trace along the X axis to cover for that distance
                    this.GCodeOutputText.Text += "G1 Y-" + RemainingDistance.ToString() + " E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-2.5 Y-2.5 E1 F400\r\n"; //Moves to print the final contact pad
                    this.GCodeOutputText.Text += ";\r\n";

                    Print_Pad_KnownShape(5, 5); //Prints the final 5x5 mm contact pad
                    break;

                case 135:

                    break;

                case 180:
                    Print_Pad_KnownShape(5, 5); //Prints the first contact pad
                    this.GCodeOutputText.Text += "G1 X-2.5 Y-2.5 E1 F400\r\n"; //Moves to the center of the pad
                    this.GCodeOutputText.Text += ";\r\n";

                    //Drawing the 10 mm trace to connect the first contact pad to the strain gauge
                    Contact_Distance = 10;
                    this.GCodeOutputText.Text += ";Print a 10 mm trace to connect with the strain gauge\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    SGPadLength = 2;
                    SGPadWidth = 3;

                    this.GCodeOutputText.Text += ";Print the strain gauge\r\n";
                    //Drawing the first trace of the strain gauge
                    this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    this.GCodeOutputText.Text += "G1 X-" + SGPadLength.ToString() + " Y-" + SGPadWidth.ToString() + "E1 F400\r\n";
                    Print_Pad_KnownShape(SGPadLength, SGPadWidth); //Prints the first 2x3 mm pad in the strain gauge
                    this.GCodeOutputText.Text += "G1 X-" + SGPadLength.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    DistanceToCover = SGLength - SGPadLength; //Used in the for loop to check how much distance is left to cover for printing the strain gauge's length
                    DistanceCovered = SGPadLength; //Used to cover how much distance in the X direction is covered

                    for (int x = 0; x < DistanceToCover; x = x + (int)(SGPadLength * 2))
                    {
                        if ((DistanceCovered + (SGPadLength * 2)) > SGLength)
                            break; //Before printing, if it prints the pattern and overshoots, it will break from the for loop before printing the pattern


                        //This section will print the pattern: pad, up, pad, down

                        this.GCodeOutputText.Text += "G1 X-" + SGPadLength.ToString() + "E1 F400\r\n";
                        Print_Pad_KnownShape(SGPadLength, SGPadWidth); //Pad
                        this.GCodeOutputText.Text += "G1 X-" + SGPadLength.ToString() + " Y-" + SGPadWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n"; //Up
                        this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n";
                        this.GCodeOutputText.Text += "G1 X-" + SGPadLength.ToString() + " Y-" + SGPadWidth.ToString() + "E1 F400\r\n";
                        Print_Pad_KnownShape(SGPadLength, SGPadWidth); //Pad
                        this.GCodeOutputText.Text += "G1 X-" + SGPadWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n"; //Down
                        this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 Y-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n";

                        DistanceCovered += (int)(SGPadLength * 2); //Makes sure to record how much distance was covered to check in the beginning of the for loop
                    }

                    this.GCodeOutputText.Text += ";End the printing of the strain gauge\r\n;\r\n";

                    //Prints the second 10 mm trace
                    this.GCodeOutputText.Text += ";Print a 10 mm trace to connect with the left contact pad\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 Y-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    RemainingDistance = SGLength - DistanceCovered; //If any length is left but not covered because this function stopped early, then it will print a trace along the X axis to cover for that distance
                    this.GCodeOutputText.Text += "G1 X-" + RemainingDistance.ToString() + " E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-2.5 Y-2.5 E1 F400\r\n"; //Moves to print the final contact pad
                    this.GCodeOutputText.Text += ";\r\n";

                    Print_Pad_KnownShape(5, 5); //Prints the final 5x5 mm contact pad
                    break;
                    
                case 225:

                    break;

                case 270:
                    Print_Pad_KnownShape(5, 5); //Prints the first contact pad
                    this.GCodeOutputText.Text += "G1 X-2.5 Y-2.5 E1 F400\r\n"; //Moves to the center of the pad
                    this.GCodeOutputText.Text += ";\r\n";

                    //Drawing the 10 mm trace to connect the first contact pad to the strain gauge
                    Contact_Distance = 10;
                    this.GCodeOutputText.Text += ";Print a 10 mm trace to connect with the strain gauge\r\n";
                    this.GCodeOutputText.Text += "G1 X" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    SGPadLength = 3;
                    SGPadWidth = 2;

                    this.GCodeOutputText.Text += ";Print the strain gauge\r\n";
                    //Drawing the first trace of the strain gauge
                    this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    this.GCodeOutputText.Text += "G1 X-" + SGPadLength.ToString() + "E1 F400\r\n";
                    Print_Pad_KnownShape(SGPadLength, SGPadWidth); //Prints the first 2x3 mm pad in the strain gauge
                    this.GCodeOutputText.Text += ";\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    DistanceToCover = SGLength - SGPadLength; //Used in the for loop to check how much distance is left to cover for printing the strain gauge's length
                    DistanceCovered = SGPadLength; //Used to cover how much distance in the X direction is covered

                    for (int x = 0; x < DistanceToCover; x = x + (int)(SGPadLength * 2))
                    {
                        if ((DistanceCovered + (SGPadLength * 2)) > SGLength)
                            break; //Before printing, if it prints the pattern and overshoots, it will break from the for loop before printing the pattern


                        //This section will print the pattern: pad, up, pad, down
                        Print_Pad_KnownShape(SGPadLength, SGPadWidth); //Pad
                        this.GCodeOutputText.Text += "G1 X-" + SGPadLength.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n"; //Up
                        this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n";
                        this.GCodeOutputText.Text += "G1 X-" + SGPadLength.ToString() + "E1 F400\r\n";
                        Print_Pad_KnownShape(SGPadLength, SGPadWidth); //Prints the first 2x3 mm pad in the strain gauge
                        this.GCodeOutputText.Text += ";\r\n"; //Down
                        this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += "G1 X-" + SGWidth.ToString() + "E1 F400\r\n";
                        this.GCodeOutputText.Text += ";\r\n";

                        DistanceCovered += (int)(SGPadLength * 2); //Makes sure to record how much distance was covered to check in the beginning of the for loop
                    }

                    this.GCodeOutputText.Text += ";End the printing of the strain gauge\r\n;\r\n";

                    //Prints the second 10 mm trace
                    this.GCodeOutputText.Text += ";Print a 10 mm trace to connect with the left contact pad\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X" + Contact_Distance.ToString() + "E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-" + Contact_Distance.ToString() + "E1 F400\r\n";
                    RemainingDistance = SGLength - DistanceCovered; //If any length is left but not covered because this function stopped early, then it will print a trace along the X axis to cover for that distance
                    this.GCodeOutputText.Text += "G1 Y" + RemainingDistance.ToString() + " E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-2.5 Y-2.5 E1 F400\r\n"; //Moves to print the final contact pad
                    this.GCodeOutputText.Text += ";\r\n";

                    Print_Pad_KnownShape(5, 5); //Prints the final 5x5 mm contact pad
                    break;

                case 315:

                    break;

                case 360:

                    break;
            }

           

            if (StrainGaugeLength_X.Value <= 5)
                this.GCodeOutputText.Text = "STRAIN GAUGE LENGTH MUST BE OVER 5 MM\r\n";

        }

        void Print_Element()
        {
            //This part of the code sets flags if each button is clicked
            //The flags will be used in switch cases further in the program
            decimal PartIncluded_Flag = 0;
            if (PC_PartIncluded.Checked) PartIncluded_Flag = 1;
            if (BC_PartIncluded.Checked) PartIncluded_Flag = 2;
            if (WiFi_PartIncluded.Checked) PartIncluded_Flag = 3;
            if (Pad_PartIncluded.Checked) PartIncluded_Flag = 4;
            if (SG_PartIncluded.Checked) PartIncluded_Flag = 5;

            switch (PartIncluded_Flag) //Checks which artifact is to be used so that it can print the footprint of said artifact
            {
                case 1:
                    //Case 1 ==> For printing the footprint of the DC power connector

                    //Opens a picture of a suggested artifact's void dimensions
                    //MAKE SURE THE FILE PATH OF THE IMAGE IS ENTERED HERE WHEN TRANSFERING THIS PROJECT'S FOLDER ACROSS COMPUTERS
                    //Image to summon: PC_Void.png (GCodeGeneratorV8\Pictures)
                    VoidSuggestion.ImageLocation = @"C:\Users\Datta\OneDrive\Documents\GitHub\4d-printer-gcode-generator\G-CODE Generator\Pictures\PC_Void.png";

                    this.GCodeOutputText.Text += ";The following section will print the footprint for a DC power connector using a liquid extruder\r\n";
                    this.GCodeOutputText.Text += ";The printer will begin at the center of the GND pin and end at the center of the live pad\r\n";
                    this.GCodeOutputText.Text += ";Each pad is of the size 5x5 mm and are intended to fit inside the suggested void dimensions (TAKEN FROM GCODEGENERATOR)\r\n\r\n";

                    Print_SquarePad(5); //Prints the ground pad

                    //Moves to the next pad
                    this.GCodeOutputText.Text += ";\r\n";
                    this.GCodeOutputText.Text += "G0 Z4 F400\r\n";
                    this.GCodeOutputText.Text += "G0 Y15 F400\r\n";
                    this.GCodeOutputText.Text += "G0 Z-4 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    Print_SquarePad(5); //Prints the shunt pad

                    //Moves to the final third pad
                    this.GCodeOutputText.Text += ";\r\n";
                    this.GCodeOutputText.Text += "G0 Z4 F400\r\n";
                    this.GCodeOutputText.Text += "G0 X-9 Y-10 F400\r\n";
                    this.GCodeOutputText.Text += "G0 Z-4 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    Print_SquarePad(5); //Prints the live pad

                    break;
                case 2:
                    //Case 2 ==> For printing the footprint of the button cell

                    this.GCodeOutputText.Text += "TO BE ADDED\r\n";
                    break;
                case 3:
                    //Case 3 ==> For printing the footprint of the ESP8285 Wifi Module
                    //This section will print 4 pins: VCC, GND, IO2 for remotely controlling one pin, and ADC for reading voltage

                    //Opens a picture of a suggested artifact's void dimensions
                    //MAKE SURE THE FILE PATH OF THE IMAGE IS ENTERED HERE WHEN TRANSFERING THIS PROJECT'S FOLDER ACROSS COMPUTERS
                    //Image to summon: WiFi_Void.png (GCodeGeneratorV8\Pictures)
                    VoidSuggestion.ImageLocation = @"C:\Users\Datta\OneDrive\Documents\GitHub\4d-printer-gcode-generator\G-CODE Generator\Pictures\WiFi_Void.png";

                    this.GCodeOutputText.Text += ";The following section will print the footprint for an ESP 8285 WiFi Module using a liquid extruder\r\n";
                    this.GCodeOutputText.Text += ";The printer will print traces connecting to the VCC, GND, ADC, and IO2 pins\r\n";
                    this.GCodeOutputText.Text += ";The printer will begin at the beginning of the ADC pin facing the module, print the VCC pin, GND pin, and finally the IO2 pin, ending under the WiFi module\r\n";
                    this.GCodeOutputText.Text += ";These traces are intended to fit inside the suggested void dimensions (TAKEN FROM GCODEGENERATOR)\r\n";

                    //Prints the trace that connects to the ADC pin
                    this.GCodeOutputText.Text += ";Printing the ADC pin\r\n";
                    this.GCodeOutputText.Text += "G1 X8 E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-8 E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X8 E1 F400\r\n";

                    //Moves to the next pin
                    this.GCodeOutputText.Text += ";\r\n";
                    this.GCodeOutputText.Text += "G0 Z4 F400\r\n";
                    this.GCodeOutputText.Text += "G0 Y9 F400\r\n";
                    this.GCodeOutputText.Text += "G0 Z-4 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    //Prints the trace that connects to the VCC pin
                    this.GCodeOutputText.Text += ";Printing the VCC pin\r\n";
                    this.GCodeOutputText.Text += "G1 X-8 E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X8 E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-8 E1 F400\r\n";

                    //Moves to the next pin
                    this.GCodeOutputText.Text += ";\r\n";
                    this.GCodeOutputText.Text += "G0 Z4 F400\r\n";
                    this.GCodeOutputText.Text += "G0 X-4.5 F400\r\n";
                    this.GCodeOutputText.Text += "G0 Z-4 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    //Prints the trace that connects to the GND pin
                    this.GCodeOutputText.Text += ";Printing the GND Pin\r\n";
                    this.GCodeOutputText.Text += "G1 X-6 E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X6 E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-6 E1 F400\r\n";

                    //Moves to the next pin
                    this.GCodeOutputText.Text += ";\r\n";
                    this.GCodeOutputText.Text += "G0 Z4 F400\r\n";
                    this.GCodeOutputText.Text += "G0 Y-1.5 F400\r\n";
                    this.GCodeOutputText.Text += "G0 Z-4 F400\r\n";
                    this.GCodeOutputText.Text += ";\r\n";

                    //Prints the trace that connects to the IO2 pin
                    this.GCodeOutputText.Text += ";Printing the IO2 Pin\r\n";
                    this.GCodeOutputText.Text += "G1 X6 E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X-6 E1 F400\r\n";
                    this.GCodeOutputText.Text += "G1 X6 E1 F400\r\n";

                    break;
                case 4:
                    //Case 4 ==> For printing a pad of any known side length

                    Print_SquarePad(PadSize_Side.Value);
                    break;
                case 5:
                    //Case 5 ==> For printing a strain gauge of any known length and width

                    Print_StrainGauge(StrainGaugeLength_X.Value, StrainGaugeWidth_Y.Value, RotationOfPart.Value);
                    break;
            }
        }

        //Enter your code for VOIDS Radio Button here



        //Enter your code for ANISOTROPIC GLUE Radio Button here



        //Enter your code for RESIN Radio Button here



        //Enter your code for TOP LAYER Radio Button here


    }
}