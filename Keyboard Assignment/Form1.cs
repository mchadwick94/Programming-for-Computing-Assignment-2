﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Keyboard_Assignment
{
    public partial class Form_MainWindow : Form
    {
        // Flags changes made and thus file needs saving 
        bool booleanRequiresSaving = false;

        // The Path to the 'Dictionary'
        string strPresentFilePathName = "";

        // Timing Functionality
        bool boolFirstVisit = true;
        int intIntervalRequired = 500;

        // Global ListBox can be place on the Form instead of here. 
        ListBox lstGlobalListbox = new ListBox();
        int intMyListIndex = 0;

        //Character Buttons Array
        string[] button1Array = { "p", "q", "r", "s", "1", "P", "Q", "R", "S" };
        string[] button2Array = { "t", "u", "v", "2", "T", "U", "V" };
        string[] button3Array = { "w", "x", "y", "z", "3", "W", "X", "Y", "Z" };
        string[] button4Array = { "g", "h", "i", "4", "G", "H", "I" };
        string[] button5Array = { "j", "k", "l", "5", "J", "K", "L" };
        string[] button6Array = { "m", "n", "o", "6", "M", "N", "O" };
        string[] button7Array = { ".", ",", "\"", "7", "'", ":", ";" };
        string[] button8Array = { "a", "b", "c", "8", "A", "B", "C" };
        string[] button9Array = { "d", "e", "f", "9", "D", "E", "F" };
        string[] buttonHashArray = { "#", "-", "_" };
        string[] buttonAsterixArray = { "#", "-", "_" };


        // Buttons. Identifies which button is being selected be the user. 
        bool[] boolButtonPresssed = new bool[18];

        // Prediction.
        string Str_KeyStrokes;

        // Is the line from the list that has the highest useage
        int intPredictedIndex;
        int intNumberOfCharacters;
        int intPredictedLength;
        int intTimesClicked = -1;

        //
        string strCharChosen;

        string Mode;
        string MultiPress = "Multi-Press";
        string Prediction = "Prediction";


        public Form_MainWindow()
        {
            InitializeComponent();
        }

        private void ModeMultiPress()
        {
            txtStatus.Clear();
            Mode = MultiPress;
            txtStatus.Text = "Multi-Press";
        }

        private void ModePrediction()
        {
            txtStatus.Clear();
            Mode = Prediction;
            txtStatus.Text = "Prediction";
        }

        /*private void ButtonClicked()
        {
            timer1.Enabled = false;
            timer1.Enabled = true;
            intTimesClicked = intTimesClicked + 1;
            Index = -1 + intTimesClicked;
        }*/

       /* private void CycleThrough()
        {
            if (Index < 6)
            {
                ButtonClicked();
            }
            else
            {
                Reset();
                ButtonClicked();
            }
        }*/


        private void btnMode_Click(object sender, EventArgs e)
        {
            if (Mode == Prediction)
            {
                ModeMultiPress(); //Calls Multi-Press Class
            }
            else
            {
                ModePrediction(); //Calls Prediction Class
            }
        }

        private void Form_MainWindow_Load(object sender, EventArgs e)
        {
            ModeMultiPress();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //On tick (timer elapsed), enter the letter selected in the array
            timer1.Enabled = false;
            boolFirstVisit = true;
            intTimesClicked = -1;

            boolButtonPresssed[1] = false;


        }

      
        private void txtNotepad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            txtNotepad.AppendText(Environment.NewLine);
        }

        private void btn000_Click(object sender, EventArgs e)
        {
            txtNotepad.AppendText(rtxtBuilder.Text + " ");
            Str_KeyStrokes = string.Empty;
            rtxtBuilder.Clear();
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            // restart the timer
            timer1.Enabled = false;
            timer1.Enabled = true;
            boolButtonPresssed[1] = true;
            
                if (timer1.Enabled == true) //start timer cycle
                {
                    if (intTimesClicked < button1Array.Length)
                    {
                        intTimesClicked = (intTimesClicked + 1) % button1Array.Length; //increase the value of intTimesClicked by for the length of the buttons associated array.
                        strCharChosen = (button1Array[intTimesClicked]); //set variable as the character selected at the current element.
                    }
                    else
                    {
                        intTimesClicked = -1;
                    }
                    //if its the first time the button has been pressed during this timer, add the chosen character.
                    if (boolFirstVisit == true)
                    {
                        rtxtBuilder.AppendText(strCharChosen);
                        boolFirstVisit = false;
                    }
                    else//if the button is pressed again, remove the previous character, and add the new character.
                    {
                        rtxtBuilder.Text = rtxtBuilder.Text.Remove(rtxtBuilder.TextLength - 1, 1);
                        rtxtBuilder.AppendText(strCharChosen);
                    }
                }     
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            // restart the timer
            timer1.Enabled = false;
            timer1.Enabled = true;

            if (boolButtonPresssed[2] == true)
            {
                if (timer1.Enabled == true) //start timer cycle
                {
                    if (intTimesClicked < button2Array.Length)
                    {
                        intTimesClicked = (intTimesClicked + 1) % button2Array.Length; //increase the value of intTimesClicked by for the length of the buttons associated array.
                        strCharChosen = (button2Array[intTimesClicked]); //set variable as the character selected at the current element.
                    }
                    else
                    {
                        intTimesClicked = -1;
                    }
                    //if its the first time the button has been pressed during this timer, add the chosen character.
                    if (boolFirstVisit == true)
                    {
                        rtxtBuilder.AppendText(strCharChosen);
                        boolFirstVisit = false;
                    }
                    else//if the button is pressed again, remove the previous character, and add the new character.
                    {
                        rtxtBuilder.Text = rtxtBuilder.Text.Remove(rtxtBuilder.TextLength - 1, 1);
                        rtxtBuilder.AppendText(strCharChosen);
                    }
                }
            }
            else
            {
                //tick the timer
                boolButtonPresssed[2] = true;

            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Enabled = true;
            if (boolFirstVisit == true)
            {

            }

            if (timer1.Enabled == true)
            {
                if (intTimesClicked < button3Array.Length)
                {
                    intTimesClicked = (intTimesClicked + 1) % button3Array.Length;
                    strCharChosen = button3Array[intTimesClicked];
                }
                else
                {
                    intTimesClicked = -1;
                }
            }
            else
            {

                intTimesClicked = -1;
                strCharChosen = button3Array[intTimesClicked];
            }

        }
        private void btn4_Click(object sender, EventArgs e)
        {
            
                // restart the timer
                timer1.Enabled = false;
                timer1.Enabled = true;
                boolButtonPresssed[4] = true;

                if (timer1.Enabled == true) //start timer cycle
                {
                    if (intTimesClicked < button4Array.Length)
                    {
                        intTimesClicked = (intTimesClicked + 1) % button4Array.Length; //increase the value of intTimesClicked by for the length of the buttons associated array.
                        strCharChosen = (button4Array[intTimesClicked]); //set variable as the character selected at the current element.
                    }
                    else
                    {
                        intTimesClicked = -1;
                    }
                    //if its the first time the button has been pressed during this timer, add the chosen character.
                    if (boolFirstVisit == true)
                    {
                        rtxtBuilder.AppendText(strCharChosen);
                        boolFirstVisit = false;
                    }
                    else//if the button is pressed again, remove the previous character, and add the new character.
                    {
                        rtxtBuilder.Text = rtxtBuilder.Text.Remove(rtxtBuilder.TextLength - 1, 1);
                        rtxtBuilder.AppendText(strCharChosen);
                    }
                }
           
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            
                // restart the timer
                timer1.Enabled = false;
                timer1.Enabled = true;
                boolButtonPresssed[5] = true;

                if (timer1.Enabled == true) //start timer cycle
                {
                    if (intTimesClicked < button5Array.Length)
                    {
                        intTimesClicked = (intTimesClicked + 1) % button5Array.Length; //increase the value of intTimesClicked by for the length of the buttons associated array.
                        strCharChosen = (button5Array[intTimesClicked]); //set variable as the character selected at the current element.
                    }
                    else
                    {
                        intTimesClicked = -1;
                    }
                    //if its the first time the button has been pressed during this timer, add the chosen character.
                    if (boolFirstVisit == true)
                    {
                        rtxtBuilder.AppendText(strCharChosen);
                        boolFirstVisit = false;
                    }
                    else//if the button is pressed again, remove the previous character, and add the new character.
                    {
                        rtxtBuilder.Text = rtxtBuilder.Text.Remove(rtxtBuilder.TextLength - 1, 1);
                        rtxtBuilder.AppendText(strCharChosen);
                    }
                }
            }
        

        private void btn6_Click(object sender, EventArgs e)
        
          {
                // restart the timer
                timer1.Enabled = false;
                timer1.Enabled = true;
                boolButtonPresssed[6] = true;

                if (timer1.Enabled == true) //start timer cycle
                {
                    if (intTimesClicked < button6Array.Length)
                    {
                        intTimesClicked = (intTimesClicked + 1) % button6Array.Length; //increase the value of intTimesClicked by for the length of the buttons associated array.
                        strCharChosen = (button6Array[intTimesClicked]); //set variable as the character selected at the current element.
                    }
                    else
                    {
                        intTimesClicked = -1;
                    }
                    //if its the first time the button has been pressed during this timer, add the chosen character.
                    if (boolFirstVisit == true)
                    {
                        rtxtBuilder.AppendText(strCharChosen);
                        boolFirstVisit = false;
                    }
                    else//if the button is pressed again, remove the previous character, and add the new character.
                    {
                        rtxtBuilder.Text = rtxtBuilder.Text.Remove(rtxtBuilder.TextLength - 1, 1);
                        rtxtBuilder.AppendText(strCharChosen);
                    }
                }
            }
        

        private void btn7_Click(object sender, EventArgs e)
        
            {
                // restart the timer
                timer1.Enabled = false;
                timer1.Enabled = true;
                boolButtonPresssed[7] = true;

                if (timer1.Enabled == true) //start timer cycle
                {
                    if (intTimesClicked < button7Array.Length)
                    {
                        intTimesClicked = (intTimesClicked + 1) % button7Array.Length; //increase the value of intTimesClicked by for the length of the buttons associated array.
                        strCharChosen = (button7Array[intTimesClicked]); //set variable as the character selected at the current element.
                    }
                    else
                    {
                        intTimesClicked = -1;
                    }
                    //if its the first time the button has been pressed during this timer, add the chosen character.
                    if (boolFirstVisit == true)
                    {
                        rtxtBuilder.AppendText(strCharChosen);
                        boolFirstVisit = false;
                    }
                    else//if the button is pressed again, remove the previous character, and add the new character.
                    {
                        rtxtBuilder.Text = rtxtBuilder.Text.Remove(rtxtBuilder.TextLength - 1, 1);
                        rtxtBuilder.AppendText(strCharChosen);
                    }
                }
            }
        
        

        private void btn8_Click(object sender, EventArgs e)

            {
                // restart the timer
                timer1.Enabled = false;
                timer1.Enabled = true;
                boolButtonPresssed[8] = true;

                if (timer1.Enabled == true) //start timer cycle
                {
                    if (intTimesClicked < button8Array.Length)
                    {
                        intTimesClicked = (intTimesClicked + 1) % button8Array.Length; //increase the value of intTimesClicked by for the length of the buttons associated array.
                        strCharChosen = (button8Array[intTimesClicked]); //set variable as the character selected at the current element.
                    }
                    else
                    {
                        intTimesClicked = -1;
                    }
                    //if its the first time the button has been pressed during this timer, add the chosen character.
                    if (boolFirstVisit == true)
                    {
                        rtxtBuilder.AppendText(strCharChosen);
                        boolFirstVisit = false;
                    }
                    else//if the button is pressed again, remove the previous character, and add the new character.
                    {
                        rtxtBuilder.Text = rtxtBuilder.Text.Remove(rtxtBuilder.TextLength - 1, 1);
                        rtxtBuilder.AppendText(strCharChosen);
                    }
                }
            }


        private void btn9_Click(object sender, EventArgs e)

            {
                // restart the timer
                timer1.Enabled = false;
                timer1.Enabled = true;
                boolButtonPresssed[9] = true;

                if (timer1.Enabled == true) //start timer cycle
                {
                    if (intTimesClicked < button9Array.Length)
                    {
                        intTimesClicked = (intTimesClicked + 1) % button9Array.Length; //increase the value of intTimesClicked by for the length of the buttons associated array.
                        strCharChosen = (button9Array[intTimesClicked]); //set variable as the character selected at the current element.
                    }
                    else
                    {
                        intTimesClicked = -1;
                    }
                    //if its the first time the button has been pressed during this timer, add the chosen character.
                    if (boolFirstVisit == true)
                    {
                        rtxtBuilder.AppendText(strCharChosen);
                        boolFirstVisit = false;
                    }
                    else//if the button is pressed again, remove the previous character, and add the new character.
                    {
                        rtxtBuilder.Text = rtxtBuilder.Text.Remove(rtxtBuilder.TextLength - 1, 1);
                        rtxtBuilder.AppendText(strCharChosen);
                    }
                }
            }


        private void btnAsterix_Click(object sender, EventArgs e)

                {
                    // restart the timer
                    timer1.Enabled = false;
                    timer1.Enabled = true;
                    boolButtonPresssed[11] = true;

                    if (timer1.Enabled == true) //start timer cycle
                    {
                        if (intTimesClicked < buttonAsterixArray.Length)
                        {
                            intTimesClicked = (intTimesClicked + 1) % buttonAsterixArray.Length; //increase the value of intTimesClicked by for the length of the buttons associated array.
                            strCharChosen = (buttonAsterixArray[intTimesClicked]); //set variable as the character selected at the current element.
                        }
                        else
                        {
                            intTimesClicked = -1;
                        }
                        //if its the first time the button has been pressed during this timer, add the chosen character.
                        if (boolFirstVisit == true)
                        {
                            rtxtBuilder.AppendText(strCharChosen);
                            boolFirstVisit = false;
                        }
                        else//if the button is pressed again, remove the previous character, and add the new character.
                        {
                            rtxtBuilder.Text = rtxtBuilder.Text.Remove(rtxtBuilder.TextLength - 1, 1);
                            rtxtBuilder.AppendText(strCharChosen);
                        }
                    }
                }


        private void btnHash_Click(object sender, EventArgs e)

                    {
                        // restart the timer
                        timer1.Enabled = false;
                        timer1.Enabled = true;
                        boolButtonPresssed[12] = true;

                        if (timer1.Enabled == true) //start timer cycle
                        {
                            if (intTimesClicked < buttonAsterixArray.Length)
                            {
                                intTimesClicked = (intTimesClicked + 1) % buttonAsterixArray.Length; //increase the value of intTimesClicked by for the length of the buttons associated array.
                                strCharChosen = (buttonAsterixArray[intTimesClicked]); //set variable as the character selected at the current element.
                            }
                            else
                            {
                                intTimesClicked = -1;
                            }
                            //if its the first time the button has been pressed during this timer, add the chosen character.
                            if (boolFirstVisit == true)
                            {
                                rtxtBuilder.AppendText(strCharChosen);
                                boolFirstVisit = false;
                            }
                            else//if the button is pressed again, remove the previous character, and add the new character.
                            {
                                rtxtBuilder.Text = rtxtBuilder.Text.Remove(rtxtBuilder.TextLength - 1, 1);
                                rtxtBuilder.AppendText(strCharChosen);
                            }
                        }
                    }
                }
            }

