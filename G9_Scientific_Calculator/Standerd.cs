using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G9_Scientific_Calculator
{
    public partial class StanderdForm : Form
    {
        float iCelsius, iFahrenheit, iKelvin;
        float milli, centi, meter, kilo, inch, feet, yard, mile;
        float milliL, liter, cubicM;

        bool displayDigits = true;

        private class Operation
        {
            public double number;
            public int operation;



            public Operation(double number, int operation)
            {
                this.number = number;
                this.operation = operation;
            }
        }

        // Indicates that the display content should be cleared
        // Next time user enters a value, the display will reset and print the new value
        bool newLine = true;

        // Indicates what type of input the calculator processed last time
        // 0 - number
        // 1 - operation
        int lastInput = 0;

        // Data structure that stores queued operations
        List<Operation> operations = new List<Operation>();

        // Save cache of last operation. 
        // Repeatedly pressing Enter or Clicking Equal will perform the cached operation
        Operation lastOperation = null;


        public StanderdForm()
        {
            InitializeComponent();

            comboBox1.SelectedItem = "Temperature";
            comboBox2.SelectedItem = "Celsius";
            comboBox3.SelectedItem = "Fahrenheit";
            comboBox4.SelectedItem = "Millimeters";
            comboBox5.SelectedItem = "Centimeters";
            comboBox6.SelectedItem = "Milliliters";
            comboBox7.SelectedItem = "Liters";
            comboBox8.SelectedItem = "Decimal";
            comboBox9.SelectedItem = "Binary";

            labelStandard.ForeColor = Color.Black;
            labelScientific.ForeColor = Color.Gray;
            labelConverter.ForeColor = Color.Gray;

            output.Width = 407;
            previousEntryOutput.Width = 407;

            displayPanel.Visible = true;
            calNumbersPanel.Visible = true;
            arrithmaticPanel.Visible = true;

            panelScieceTrigo.Visible = false;
            panelSciePower.Visible = false;
            scientificPanel.Visible = false;

            conPanel.Visible = false;
            btnConvert.Visible = false;

            calNumbersPanel.Location = new Point(15, 167);
            arrithmaticPanel.Location = new Point(321, 167);

        }

        private void labelStandard_Click(object sender, EventArgs e)
        {
            displayPanel.Visible = true;
            calNumbersPanel.Visible = true;
            arrithmaticPanel.Visible = true;

            panelScieceTrigo.Visible = false;
            panelSciePower.Visible = false;
            scientificPanel.Visible = false;

            conPanel.Visible = false;            
            btnConvert.Visible = false;

            panelHex.Visible = false;
            F.Visible = false;

            calNumbersPanel.Location = new Point(15, 167);
            arrithmaticPanel.Location = new Point(321, 167);
            output.Width = 406;
            previousEntryOutput.Width = 406;
            this.Size = new Size(454, 485);

            labelStandard.ForeColor = Color.Black;
            labelScientific.ForeColor = Color.Gray;
            labelConverter.ForeColor = Color.Gray;

            lastInput = 0;
            previousEntryOutput.Text = "";
            clearDisplay();
            newLine = true;
            lastOperation = null;
            operations.Clear();
            labelAns.Text = "";

            displayDigits = true;
            buttonDot.Visible = true;
        }

        private void labelScientific_Click(object sender, EventArgs e)
        {
            displayPanel.Visible = true;
            calNumbersPanel.Visible = true;
            arrithmaticPanel.Visible = true;

            panelScieceTrigo.Visible = true;
            panelSciePower.Visible = true;
            scientificPanel.Visible = true;

            conPanel.Visible = false;           
            btnConvert.Visible = false;
            btnConvert.BringToFront();

            panelHex.Visible = false;
            F.Visible = false;

            calNumbersPanel.Location = new Point(219, 219);
            arrithmaticPanel.Location = new Point(525, 219);
            panelScieceTrigo.Location = new Point(15, 167);
            panelSciePower.Location = new Point(117, 219);
            scientificPanel.Location = new Point(15, 219);

            output.Width = 610;
            previousEntryOutput.Width = 610;
            this.Size = new Size(658, 537);

            labelStandard.ForeColor = Color.Gray;
            labelScientific.ForeColor = Color.Black;
            labelConverter.ForeColor = Color.Gray;

            lastInput = 0;
            previousEntryOutput.Text = "";
            clearDisplay();
            newLine = true;
            lastOperation = null;
            operations.Clear();
            labelAns.Text = "";

            displayDigits = false;
            buttonDot.Visible = true;
        }

        private void labelConverter_Click(object sender, EventArgs e)
        {
            displayPanel.Visible = false;            
            arrithmaticPanel.Visible = false;
            panelScieceTrigo.Visible = false;
            panelSciePower.Visible = false;
            scientificPanel.Visible = false;

            conPanel.Visible = true;           
            btnConvert.Visible = true;



            conPanel.Visible = true;
            btnConvert.Visible = true;
            btnConvert.BringToFront();

            calNumbersPanel.Location = new Point(15, 100);
            conPanel.Location = new Point(358, 58);                       
            btnConvert.Location = new Point(344, 308);            
            this.Size = new Size(980, 418);

            labelStandard.ForeColor = Color.Gray;
            labelScientific.ForeColor = Color.Gray;
            labelConverter.ForeColor = Color.Black;

            lastInput = 0;
            previousEntryOutput.Text = "";
            clearDisplay();
            newLine = true;
            lastOperation = null;
            operations.Clear();
            labelAns.Text = "";

            displayDigits = false;

            comboBox1.SelectedItem = "Temperature";
            buttonDot.Visible = true;
        }     


        /**
         *  Function that handles event created when user clicks Numpad7
         * */
        private void num7_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("7");
                newLine = false;
            }
            else
            {
                addToDisplay("7");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad8
         * */
        private void num8_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("8");
                newLine = false;
            }
            else
            {
                addToDisplay("8");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad9
         * */
        private void num9_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("9");
                newLine = false;
            }
            else
            {
                addToDisplay("9");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad4
         * */
        private void num4_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("4");
                newLine = false;
            }
            else
            {
                addToDisplay("4");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad5
         * */
        private void num5_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("5");
                newLine = false;
            }
            else
            {
                addToDisplay("5");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad6
         * */
        private void num6_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("6");
                newLine = false;
            }
            else
            {
                addToDisplay("6");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad1
         * */
        private void num1_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("1");
                newLine = false;
            }
            else
            {
                addToDisplay("1");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad2
         * */
        private void num2_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("2");
                newLine = false;
            }
            else
            {
                addToDisplay("2");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad3
         * */
        private void num3_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("3");
                newLine = false;
            }
            else
            {
                addToDisplay("3");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad0
         * */
        private void num0_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            // If user entered 0 while the calculator display is already showing 0,
            //  then do nothing.
            if (newLine && isOutputDisplayEmpty())
            {
                newLine = true;
            }
            // If the display has another value and it is being discarded, then print 0
            else if (newLine)
            {
                display("0");
            }
            // If the existing display has a non-zero value and it is not being discarded,
            //  then add 0 to the existing value  
            else
            {
                addToDisplay("0");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks C button
         * */
        private void buttonC_Click(object sender, EventArgs e)
        {
            lastInput = 0;
            previousEntryOutput.Text = "";
            clearDisplay();
            newLine = true;
            lastOperation = null;
            operations.Clear();
            labelAns.Text = "";
        }

        /**
         *  Function that handles event created when user clicks CE button
         * */
        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            lastInput = 0;
            clearDisplay();
            newLine = true;
        }

        /**
         *  Function that handles event created when user clicks Backspace button
         * */
        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (output.Text.Length == 1)
            {
                newLine = true;
                clearDisplay();
            }
            else
            {
                display(output.Text.Remove(output.Text.Length - 1, 1));
            }
        }

        /**
         *  Function that handles event created when user clicks Sign Change button
         * */
        private void buttonSign_Click(object sender, EventArgs e)
        {          

            lastInput = 0;

            if (isOutputDisplayEmpty())
            {
                ;
            }
            else if (output.Text[0] == '-')
            {
                display(output.Text.Remove(0, 1));
            }
            else
            {
                display("-" + output.Text);
            }            

        }

        /**
         *  Function that handles event created when user clicks Decimal button
         * */
        private void buttonDot_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine == true)
            {
                display("0.");
            }
            else if (!output.Text.Contains("."))
            {
                addToDisplay(".");
            }

            newLine = false;
        }

        /**
         *  Function that handles event created when user clicks Subtract button
         * */
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            // If user pressed any of the operation button more than once in a row
            // Ignore that input
            if (lastInput == 1 && operations[operations.Count - 1].operation == 1)
            {
                return;
            }
            else if (lastInput == 1)
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new Operation(Convert.ToDouble(output.Text), 1));
                displayPreviousEntries();
            }
            else
            {
                operations.Add(new Operation(Convert.ToDouble(output.Text), 1));
                displayPreviousEntries();
                calculate();
            }

            lastInput = 1;
            newLine = true;
        }

        /**
         *  Function that handles event created when user clicks Add button
         * */
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            // If user pressed any of the operation button more than once in a row
            // Ignore that input
            if (lastInput == 1 && operations[operations.Count - 1].operation == 2)
            {
                return;
            }
            else if (lastInput == 1)
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new Operation(Convert.ToDouble(output.Text), 2));
                displayPreviousEntries();
            }
            else
            {
                operations.Add(new Operation(Convert.ToDouble(output.Text), 2));
                displayPreviousEntries();
                calculate();
            }

            lastInput = 1;
            newLine = true;
        }

        /**
         *  Function that handles event created when user clicks Multiply button
         * */
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            // If user pressed any of the operation button more than once in a row
            // Ignore that input
            if (lastInput == 1 && operations[operations.Count - 1].operation == 3)
            {
                return;
            }
            else if (lastInput == 1)
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new Operation(Convert.ToDouble(output.Text), 3));
                displayPreviousEntries();
            }
            else
            {
                operations.Add(new Operation(Convert.ToDouble(output.Text), 3));
                displayPreviousEntries();
                calculate();
            }

            lastInput = 1;
            newLine = true;
        }

        /**
         *  Function that handles event created when user clicks Divide button
         * */
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            // If user pressed any of the operation button more than once in a row
            // Ignore that input
            if (lastInput == 1 && operations[operations.Count - 1].operation == 4)
            {
                return;
            }
            else if (lastInput == 1)
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new Operation(Convert.ToDouble(output.Text), 4));
                displayPreviousEntries();
            }
            else
            {
                operations.Add(new Operation(Convert.ToDouble(output.Text), 4));
                displayPreviousEntries();
                calculate();
            }

            lastInput = 1;
            newLine = true;
        }

        /**
         *  Function that handles event created when user clicks Equals button
         * */
        private void buttonEquals_Click(object sender, EventArgs e)
        {

            // If there are any queued operations, add the last operand and perform calculation. Clear the operations queue.
            if (operations.Count > 0)
            {
                // Cache last operation
                lastOperation = new Operation(Convert.ToDouble(output.Text), operations[operations.Count - 1].operation);
                operations.Add(lastOperation);
                calculate();
                operations.Clear();
                clearPreviousEntryDisplay();
            }
            // If there is no queued operations, but last operation has cache, then perform the last operation.
            else if (lastOperation != null)
            {
                double value = Convert.ToDouble(output.Text);

                switch (lastOperation.operation)
                {
                    case 1:
                        output.Text = Convert.ToString(value - lastOperation.number);
                        break;
                    case 2:
                        output.Text = Convert.ToString(value + lastOperation.number);
                        break;
                    case 3:
                        output.Text = Convert.ToString(value * lastOperation.number);
                        break;
                    case 4:
                        output.Text = Convert.ToString(value / lastOperation.number);
                        break;
                    case 5:
                        output.Text = Convert.ToString(value % lastOperation.number);
                        break;
                }
            }
            // Do nothing if above 2 conditions aren't met.
            else
            {
                ;
            }

            newLine = true;
            lastInput = 0;


        }

        /**
         *  Function that performs calculation based on the value of operation and currentNum
         * */
        private async void calculate()
        {
            // Requires at least 2 operands to perform calculation
            if (operations.Count < 2)
            {
                return;
            }
            else
            {
                double newValue = operations[0].number;

                for (int i = 0; i < operations.Count - 1; i++)
                {
                    switch (operations[i].operation)
                    {
                        case 1:
                            newValue = newValue - operations[i + 1].number;
                            break;
                        case 2:
                            newValue = newValue + operations[i + 1].number;
                            break;
                        case 3:
                            newValue = newValue * operations[i + 1].number;
                            break;
                        case 4:
                            if (operations[i + 1].number == 0)
                            {
                                display("Division By Zero");
                                await Task.Delay(1500);
                                buttonC.PerformClick();
                                return;
                            }

                            newValue = newValue / operations[i + 1].number;
                            break;
                        case 5:
                            newValue = newValue % operations[i + 1].number;
                            break;
                    }
                }

                display(Convert.ToString(newValue));
            }
        }

        /**
         *  Function that clears the contents of the Previous Entry Display Window
         * */
        private void clearPreviousEntryDisplay()
        {
            previousEntryOutput.Text = "";
        }

        /**
         *  Function that set new literal to previous entry Display window.
         *  @param literal string literal to add to the display
         * */
        private void displayPreviousEntries()
        {
            string newLiteral = "";

            for (int i = 0; i < operations.Count; i++)
            {
                newLiteral += operations[i].number;

                switch (operations[i].operation)
                {
                    case 1:
                        newLiteral += " - ";
                        break;
                    case 2:
                        newLiteral += " + ";
                        break;
                    case 3:
                        newLiteral += " * ";
                        break;
                    case 4:
                        newLiteral += " / ";
                        break;
                    case 5:
                        newLiteral += " Mod ";
                        break;
                }
            }

            if (newLiteral.Length > 62)
            {
                previousEntryOutput.Text = newLiteral.Remove(62);
            }
            else
            {
                previousEntryOutput.Text = newLiteral;
            }
        }

        /**
         *  Function that changes the display of calculator to the given string literal.
         *  @param toDisplay String literal to display on the screen
         * */
        private void display(string toDisplay)
        {
            if (displayDigits)
            {
                if (toDisplay.Length > 14)
                {
                    output.Text = toDisplay.Remove(14);
                }
                else
                {
                    output.Text = toDisplay;
                }
            }
            else
            {
                if (toDisplay.Length > 21)
                {
                    output.Text = toDisplay.Remove(21);
                }
                else
                {
                    output.Text = toDisplay;
                }
            }

            if (toDisplay.Length > 21)
            {
                labelIn.Text = toDisplay.Remove(21);
            }
            else
            {
                labelIn.Text = toDisplay;
            }

        }

        /**
         *  Function that displays the given string literal in addition to current displayed content
         *  @param toDisplay String literal to add to the display screen
         * */
        private void addToDisplay(string toAdd)
        {
            if (displayDigits)
            {
                string newString2 = output.Text + toAdd;

                if (newString2.Length > 14)
                {
                    output.Text = newString2.Remove(14);
                }
                else
                {
                    output.Text = newString2;
                }
            }
            else
            {
                string newString = output.Text + toAdd;

                if (newString.Length > 21)
                {
                    output.Text = newString.Remove(21);
                }
                else
                {
                    output.Text = newString;
                }
            }

            string newString1 = labelIn.Text + toAdd;

            if (newString1.Length > 21)
            {
                labelIn.Text = newString1.Remove(21);
            }
            else
            {
                labelIn.Text = newString1;
            }

        }

        /**
         *  Function that clears the display contents
         * */
        private void clearDisplay()
        {
            labelIn.Text = "0";
            output.Text = "0";
        }

        /**
         *  Output display is considered "empty" if it is only diplaying 0
         *  @return isEmpty true if the output display is only showing 0
         * */
        private bool isOutputDisplayEmpty()
        {            
            return output.Text == "0";
        }

        /**
         *  Override ProcessCmdKey so that the form receives keyboard input before any other components
         *  and handle the event. 
         * */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.NumPad9:
                    num9.PerformClick();
                    return true;
                case Keys.D9:
                    num9.PerformClick();
                    return true;
                case Keys.NumPad8:
                    num8.PerformClick();
                    return true;
                case Keys.D8:
                    num8.PerformClick();
                    return true;
                case Keys.NumPad7:
                    num7.PerformClick();
                    return true;
                case Keys.D7:
                    num7.PerformClick();
                    return true;
                case Keys.NumPad6:
                    num6.PerformClick();
                    return true;
                case Keys.D6:
                    num6.PerformClick();
                    return true;
                case Keys.NumPad5:
                    num5.PerformClick();
                    return true;
                case Keys.D5:
                    num5.PerformClick();
                    return true;
                case Keys.NumPad4:
                    num4.PerformClick();
                    return true;
                case Keys.D4:
                    num4.PerformClick();
                    return true;
                case Keys.NumPad3:
                    num3.PerformClick();
                    return true;
                case Keys.D3:
                    num3.PerformClick();
                    return true;
                case Keys.NumPad2:
                    num2.PerformClick();
                    return true;
                case Keys.D2:
                    num2.PerformClick();
                    return true;
                case Keys.NumPad1:
                    num1.PerformClick();
                    return true;
                case Keys.D1:
                    num1.PerformClick();
                    return true;
                case Keys.NumPad0:
                    num0.PerformClick();
                    return true;
                case Keys.D0:
                    num0.PerformClick();
                    return true;
                case Keys.Subtract:
                    buttonMinus.PerformClick();
                    return true;
                case Keys.Add:
                    buttonPlus.PerformClick();
                    return true;
                case Keys.Multiply:
                    buttonMultiply.PerformClick();
                    return true;
                case Keys.Divide:
                    buttonDivide.PerformClick();
                    return true;
                case Keys.Enter:
                    btnConvert.PerformClick();
                    buttonEquals.PerformClick();
                    return true;
                case Keys.Escape:
                    buttonC.PerformClick();
                    return true;
                case Keys.Back:
                    buttonBackspace.PerformClick();
                    return true;
                case Keys.Decimal:
                    buttonDot.PerformClick();
                    return true;
                case Keys.A:
                    A.PerformClick();
                    return true;
                case Keys.B:
                    B.PerformClick();
                    return true;
                case Keys.C:
                    C.PerformClick();
                    return true;
                case Keys.D:
                    D.PerformClick();
                    return true;
                case Keys.E:
                    E.PerformClick();
                    return true;
                case Keys.F:
                    F.PerformClick();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void mod_Click(object sender, EventArgs e)
        {
            if (lastInput == 1 && operations[operations.Count - 1].operation == 5)
            {
                return;
            }
            else if (lastInput == 1)
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new Operation(Convert.ToDouble(output.Text), 5));
                displayPreviousEntries();
            }
            else
            {
                operations.Add(new Operation(Convert.ToDouble(output.Text), 5));
                displayPreviousEntries();
                calculate();
            }

            lastInput = 1;
            newLine = true;
        }

        private void pi_Click(object sender, EventArgs e)
        {
            output.Text = Convert.ToString(Math.PI);
        }

        private void log_Click(object sender, EventArgs e)
        {
            double ilog = Double.Parse(output.Text);
            previousEntryOutput.Text = System.Convert.ToString("log" + "(" + (output.Text) + ")");
            ilog = Math.Log10(ilog);
            output.Text = System.Convert.ToString(ilog);
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            double sq = Double.Parse(output.Text);
            previousEntryOutput.Text = System.Convert.ToString("√" + "(" + (output.Text) + ")");
            sq = Math.Sqrt(sq);
            output.Text = System.Convert.ToString(sq);
        }

        private void sinh_Click(object sender, EventArgs e)
        {
            double qSinh = Double.Parse(output.Text);
            previousEntryOutput.Text = System.Convert.ToString("Sinh" + "(" + (output.Text) + ")");
            qSinh = Math.Sinh(qSinh);
            output.Text = System.Convert.ToString(qSinh);
        }

        private void sin_Click(object sender, EventArgs e)
        {
            double qSin = Double.Parse(output.Text);
            previousEntryOutput.Text = System.Convert.ToString("Sin" + "(" + (output.Text) + ")");
            qSin = Math.Sin(qSin * (Math.PI / 180f));
            output.Text = System.Convert.ToString(qSin);
        }

        private void powerTwo_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(output.Text) * Convert.ToDouble(output.Text);
            previousEntryOutput.Text = System.Convert.ToString((output.Text) + "^2");
            output.Text = System.Convert.ToString(a);
        }

        private void F_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("F");
                newLine = false;
            }
            else
            {
                addToDisplay("F");
                newLine = false;
            }
        }

        private void A_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("A");
                newLine = false;
            }
            else
            {
                addToDisplay("A");
                newLine = false;
            }
        }

        private void B_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("B");
                newLine = false;
            }
            else
            {
                addToDisplay("B");
                newLine = false;
            }
        }

        private void C_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("C");
                newLine = false;
            }
            else
            {
                addToDisplay("C");
                newLine = false;
            }
        }

        private void D_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("D");
                newLine = false;
            }
            else
            {
                addToDisplay("D");
                newLine = false;
            }
        }

        private void E_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("E");
                newLine = false;
            }
            else
            {
                addToDisplay("E");
                newLine = false;
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == 3)
            {
                conPanel.Location = new Point(458, 58);
                btnConvert.Location = new Point(444, 308);
                this.Size = new Size(1080, 418);

                panelHex.Visible = true;
                F.Visible = true;
                panelHex.Location = new Point(321, 100);
                F.Location = new Point(204, 208);
                F.BringToFront();
            }
            else
            {
                conPanel.Location = new Point(358, 58);
                btnConvert.Location = new Point(344, 308);
                this.Size = new Size(980, 418);

                panelHex.Visible = false;
                F.Visible = false;
            }
        }

        private void cosh_Click(object sender, EventArgs e)
        {
            double qCosh = Double.Parse(output.Text);
            previousEntryOutput.Text = System.Convert.ToString("Cosh" + "(" + (output.Text) + ")");
            qCosh = Math.Cosh(qCosh);
            output.Text = System.Convert.ToString(qCosh);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    panelLeng.Visible = false;
                    panelTemp.Visible = true;
                    panelVolume.Visible = false;
                    panelNumber.Visible = false;

                    panelHex.Visible = false;
                    F.Visible = false;
                    buttonDot.Visible = true;

                    conPanel.Location = new Point(358, 58);
                    btnConvert.Location = new Point(344, 308);
                    this.Size = new Size(980, 418);

                    buttonC.PerformClick();
                    break;


                case 1:
                    panelLeng.Visible = true;
                    panelTemp.Visible = false;
                    panelVolume.Visible = false;
                    panelNumber.Visible = false;
                    panelLeng.Location = new Point(110, 153);

                    panelHex.Visible = false;
                    F.Visible = false;
                    buttonDot.Visible = true;

                    conPanel.Location = new Point(358, 58);
                    btnConvert.Location = new Point(344, 308);
                    this.Size = new Size(980, 418);

                    buttonC.PerformClick();
                    break;

                case 2:
                    panelLeng.Visible = false;
                    panelTemp.Visible = false;
                    panelVolume.Visible = true;
                    panelNumber.Visible = false;
                    panelVolume.Location = new Point(110, 153);

                    panelHex.Visible = false;
                    F.Visible = false;
                    buttonDot.Visible = true;

                    conPanel.Location = new Point(358, 58);
                    btnConvert.Location = new Point(344, 308);
                    this.Size = new Size(980, 418);

                    buttonC.PerformClick();
                    break;

                case 3:
                    panelLeng.Visible = false;
                    panelTemp.Visible = false;
                    panelVolume.Visible = false;
                    panelNumber.Visible = true;
                    panelNumber.Location = new Point(110, 153);

                    panelHex.Visible = false;
                    F.Visible = false;
                    buttonDot.Visible = false;

                    conPanel.Location = new Point(358, 58);
                    btnConvert.Location = new Point(344, 308);
                    this.Size = new Size(980, 418);
                    comboBox8.SelectedItem = "Decimal";

                    buttonC.PerformClick();
                    break;
            }
        }

        private void cos_Click(object sender, EventArgs e)
        {
            double qCos = Double.Parse(output.Text);
            previousEntryOutput.Text = System.Convert.ToString("Cos" + "(" + (output.Text) + ")");
            qCos = Math.Cos(qCos * (Math.PI / 180f));
            output.Text = System.Convert.ToString(qCos);
        }

        private void powerThree_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(output.Text) * Convert.ToDouble(output.Text) * Convert.ToDouble(output.Text);
            previousEntryOutput.Text = System.Convert.ToString((output.Text) + "^3");
            output.Text = System.Convert.ToString(a);
        }

        private void tanh_Click(object sender, EventArgs e)
        {
            double qTanh = Double.Parse(output.Text);
            previousEntryOutput.Text = System.Convert.ToString("Tanh" + "(" + (output.Text) + ")");
            qTanh = Math.Tanh(qTanh);
            output.Text = System.Convert.ToString(qTanh);
        }

        private void tan_Click(object sender, EventArgs e)
        {
            double qTan = Double.Parse(output.Text);
            previousEntryOutput.Text = System.Convert.ToString("Tan" + "(" + (output.Text) + ")");
            qTan = Math.Tan(qTan * (Math.PI / 180f));
            output.Text = System.Convert.ToString(qTan);
        }

        private void oneOver_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(1.0 / Convert.ToDouble(output.Text));
            previousEntryOutput.Text = System.Convert.ToString("1/" + "(" + (output.Text) + ")");
            output.Text = System.Convert.ToString(a);
        }

        private void btnPresentage_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(output.Text) / Convert.ToDouble(100);
            previousEntryOutput.Text = System.Convert.ToString((output.Text) + "%");
            output.Text = System.Convert.ToString(a);
        }

        private void ln_Click(object sender, EventArgs e)
        {
            double ilog = Double.Parse(output.Text);
            previousEntryOutput.Text = System.Convert.ToString("ln" + "(" + (output.Text) + ")");
            ilog = Math.Log(ilog);
            output.Text = System.Convert.ToString(ilog);
        }

        private void exp_Click(object sender, EventArgs e)
        {
            double iExp = Double.Parse(output.Text);
            previousEntryOutput.Text = System.Convert.ToString("Exp" + "(" + (output.Text) + ")");
            iExp = Math.Exp(iExp);
            output.Text = System.Convert.ToString(iExp);
        }        

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {

                case 0:
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0://celciuos
                            switch (comboBox3.SelectedIndex)
                            {
                                case 0://celcius to celcius
                                    labelAns.Text = output.Text;
                                    break;

                                case 1://celcius to fahrenheit
                                    iCelsius = float.Parse(labelIn.Text);
                                    labelAns.Text = ((((9 * iCelsius) / 5) + 32).ToString());
                                    break;

                                case 2://celcius to kelvin
                                    iCelsius = float.Parse(labelIn.Text);
                                    labelAns.Text = ((iCelsius + 273.15).ToString());
                                    break;
                            }
                            break;

                        case 1://fahrenheit
                            switch (comboBox3.SelectedIndex)
                            {
                                case 0://fahrenheit to celcius
                                    iFahrenheit = float.Parse(labelIn.Text);
                                    labelAns.Text = ((((iFahrenheit - 32) * 5) / 9).ToString());
                                    break;

                                case 1://fahrenheit to fahrenheit
                                    labelAns.Text = output.Text;
                                    break;

                                case 2://fahrenheit to kelvin
                                    iFahrenheit = float.Parse(labelIn.Text);
                                    labelAns.Text = (((((iFahrenheit - 32) * 5) / 9) + 273.15).ToString());
                                    break;

                            }
                            break;
                        case 2://kelvin
                            switch (comboBox3.SelectedIndex)
                            {
                                case 0://Kelvin to celcius
                                    iKelvin = float.Parse(labelIn.Text);
                                    labelAns.Text = ((iKelvin - 273.15).ToString());
                                    break;

                                case 1://Kelvin to fahrenheit
                                    iKelvin = float.Parse(labelIn.Text);
                                    labelAns.Text = ((((9 * (iKelvin - 273.15)) / 5) + 32).ToString());
                                    break;

                                case 2://Kelvin to kelvin
                                    labelAns.Text = output.Text;
                                    break;

                            }
                            break;
                    }
                    break;

                case 1:
                    switch (comboBox4.SelectedIndex)
                    {
                        case 0://millimeter
                            switch (comboBox5.SelectedIndex)
                            {
                                case 0://millimeter to millimeter
                                    labelAns.Text = labelIn.Text;
                                    break;

                                case 1://millimeter to centimeter
                                    milli = float.Parse(labelIn.Text);
                                    labelAns.Text = ((milli / 10).ToString());
                                    break;

                                case 2://millimeter to meter
                                    milli = float.Parse(labelIn.Text);
                                    labelAns.Text = ((milli / 1000).ToString());
                                    break;

                                case 3://millimeter to kilometer
                                    milli = float.Parse(labelIn.Text);
                                    labelAns.Text = ((milli / 1000000).ToString());
                                    break;

                                case 4://millimeter to inches
                                    milli = float.Parse(labelIn.Text);
                                    labelAns.Text = ((milli / 25.4).ToString());
                                    break;

                                case 5://millimeter to feet
                                    milli = float.Parse(labelIn.Text);
                                    labelAns.Text = ((milli / 305).ToString());
                                    break;

                                case 6://millimeter to yards
                                    milli = float.Parse(labelIn.Text);
                                    labelAns.Text = ((milli / 914).ToString());
                                    break;

                                case 7://millimeter to miles
                                    milli = float.Parse(labelIn.Text);
                                    labelAns.Text = ((milli / 1609000).ToString());
                                    break;
                            }
                            break;

                        case 1://centimiter
                            switch (comboBox5.SelectedIndex)
                            {
                                case 0://centimiter to millimeter
                                    centi = float.Parse(labelIn.Text);
                                    labelAns.Text = ((centi * 10).ToString());
                                    break;

                                case 1://centimiter to centimeter
                                    labelAns.Text = labelIn.Text;
                                    break;

                                case 2://centimiter to meter
                                    centi = float.Parse(labelIn.Text);
                                    labelAns.Text = ((centi / 100).ToString());
                                    break;

                                case 3://centimiter to kilometer
                                    centi = float.Parse(labelIn.Text);
                                    labelAns.Text = ((centi / 100000).ToString());
                                    break;

                                case 4://centimiter to inches
                                    centi = float.Parse(labelIn.Text);
                                    labelAns.Text = ((centi / 2.54).ToString());
                                    break;

                                case 5://centimiter to feet
                                    centi = float.Parse(labelIn.Text);
                                    labelAns.Text = ((centi / 30.48).ToString());
                                    break;

                                case 6://centimiter to yards
                                    centi = float.Parse(labelIn.Text);
                                    labelAns.Text = ((centi / 91.44).ToString());
                                    break;

                                case 7://centimiter to miles
                                    centi = float.Parse(labelIn.Text);
                                    labelAns.Text = ((centi / 160934).ToString());
                                    break;
                            }
                            break;

                        case 2://meter
                            switch (comboBox5.SelectedIndex)
                            {
                                case 0://meter to millimeter
                                    meter = float.Parse(labelIn.Text);
                                    labelAns.Text = ((meter * 1000).ToString());
                                    break;

                                case 1://meter to centimeter
                                    meter = float.Parse(labelIn.Text);
                                    labelAns.Text = ((meter * 100).ToString());
                                    break;

                                case 2://meter to meter
                                    labelAns.Text = labelIn.Text;
                                    break;

                                case 3://meter to kilometer
                                    meter = float.Parse(labelIn.Text);
                                    labelAns.Text = ((meter / 1000).ToString());
                                    break;

                                case 4://meter to inches
                                    meter = float.Parse(labelIn.Text);
                                    labelAns.Text = ((meter * 39.37).ToString());
                                    break;

                                case 5://meter to feet
                                    meter = float.Parse(labelIn.Text);
                                    labelAns.Text = ((meter * 3.281).ToString());
                                    break;

                                case 6://meter to yards
                                    meter = float.Parse(labelIn.Text);
                                    labelAns.Text = ((meter * 1.094).ToString());
                                    break;

                                case 7://meter to miles
                                    meter = float.Parse(labelIn.Text);
                                    labelAns.Text = ((meter / 1609).ToString());
                                    break;
                            }
                            break;

                        case 3://kilometer
                            switch (comboBox5.SelectedIndex)
                            {
                                case 0://centimiter to millimeter
                                    kilo = float.Parse(labelIn.Text);
                                    labelAns.Text = ((kilo * 1000000).ToString());
                                    break;

                                case 1://kilometer to centimeter
                                    kilo = float.Parse(labelIn.Text);
                                    labelAns.Text = ((kilo * 100000).ToString());
                                    break;

                                case 2://kilometer to meter
                                    kilo = float.Parse(labelIn.Text);
                                    labelAns.Text = ((kilo * 1000).ToString());
                                    break;

                                case 3://kilometer to kilometer
                                    labelAns.Text = labelIn.Text;
                                    break;

                                case 4://kilometer to inches
                                    kilo = float.Parse(labelIn.Text);
                                    labelAns.Text = ((kilo * 39370).ToString());
                                    break;

                                case 5://kilometer to feet
                                    kilo = float.Parse(labelIn.Text);
                                    labelAns.Text = ((kilo * 3281).ToString());
                                    break;

                                case 6://kilometer to yards
                                    kilo = float.Parse(labelIn.Text);
                                    labelAns.Text = ((kilo * 1094).ToString());
                                    break;

                                case 7://kilometer to miles
                                    kilo = float.Parse(labelIn.Text);
                                    labelAns.Text = ((kilo / 1.609).ToString());
                                    break;
                            }
                            break;

                        case 4://inches
                            switch (comboBox5.SelectedIndex)
                            {
                                case 0://inches to millimeter
                                    inch = float.Parse(labelIn.Text);
                                    labelAns.Text = ((inch * 25.4).ToString());
                                    break;

                                case 1://inches to centimeter
                                    inch = float.Parse(labelIn.Text);
                                    labelAns.Text = ((inch * 2.54).ToString());
                                    break;

                                case 2://inches to meter
                                    inch = float.Parse(labelIn.Text);
                                    labelAns.Text = ((inch / 39.37).ToString());
                                    break;

                                case 3://inches to kilometer
                                    inch = float.Parse(labelIn.Text);
                                    labelAns.Text = ((inch / 39370).ToString());
                                    break;

                                case 4://inches to inches
                                    labelAns.Text = labelIn.Text;
                                    break;

                                case 5://inches to feet
                                    inch = float.Parse(labelIn.Text);
                                    labelAns.Text = ((inch / 12).ToString());
                                    break;

                                case 6://inches to yards
                                    inch = float.Parse(labelIn.Text);
                                    labelAns.Text = ((inch / 36).ToString());
                                    break;

                                case 7://inches to miles
                                    inch = float.Parse(labelIn.Text);
                                    labelAns.Text = ((inch / 63360).ToString());
                                    break;
                            }
                            break;

                        case 5://feet
                            switch (comboBox5.SelectedIndex)
                            {
                                case 0://feet to millimeter
                                    feet = float.Parse(labelIn.Text);
                                    labelAns.Text = ((feet * 305).ToString());
                                    break;

                                case 1://feet to centimeter
                                    feet = float.Parse(labelIn.Text);
                                    labelAns.Text = ((feet * 30.48).ToString());
                                    break;

                                case 2://feet to meter
                                    feet = float.Parse(labelIn.Text);
                                    labelAns.Text = ((feet / 3.281).ToString());
                                    break;

                                case 3://feet to kilometer
                                    feet = float.Parse(labelIn.Text);
                                    labelAns.Text = ((feet / 3281).ToString());
                                    break;

                                case 4://feet to inches
                                    feet = float.Parse(labelIn.Text);
                                    labelAns.Text = ((feet * 12).ToString());
                                    break;

                                case 5://feet to feet
                                    labelAns.Text = labelIn.Text;
                                    break;

                                case 6://feet to yards
                                    feet = float.Parse(labelIn.Text);
                                    labelAns.Text = ((feet / 3).ToString());
                                    break;

                                case 7://feet to miles
                                    feet = float.Parse(labelIn.Text);
                                    labelAns.Text = ((feet / 5280).ToString());
                                    break;
                            }
                            break;

                        case 6://yards
                            switch (comboBox5.SelectedIndex)
                            {
                                case 0://yards to millimeter
                                    yard = float.Parse(labelIn.Text);
                                    labelAns.Text = ((yard * 914).ToString());
                                    break;

                                case 1://yards to centimeter
                                    yard = float.Parse(labelIn.Text);
                                    labelAns.Text = ((yard * 91.44).ToString());
                                    break;

                                case 2://yards to meter
                                    yard = float.Parse(labelIn.Text);
                                    labelAns.Text = ((yard / 1.094).ToString());
                                    break;

                                case 3://yards to kilometer
                                    yard = float.Parse(labelIn.Text);
                                    labelAns.Text = ((yard / 1094).ToString());
                                    break;

                                case 4://yards to inches
                                    yard = float.Parse(labelIn.Text);
                                    labelAns.Text = ((yard * 36).ToString());
                                    break;

                                case 5://yards to feet
                                    yard = float.Parse(labelIn.Text);
                                    labelAns.Text = ((yard * 3).ToString());
                                    break;

                                case 6://yards to yards
                                    labelAns.Text = labelIn.Text;
                                    break;

                                case 7://yards to miles
                                    yard = float.Parse(labelIn.Text);
                                    labelAns.Text = ((yard / 1760).ToString());
                                    break;
                            }
                            break;

                        case 7://miles
                            switch (comboBox5.SelectedIndex)
                            {
                                case 0://miles to millimeter
                                    mile = float.Parse(labelIn.Text);
                                    labelAns.Text = ((mile * 1609000).ToString());
                                    break;

                                case 1://miles to centimeter
                                    mile = float.Parse(labelIn.Text);
                                    labelAns.Text = ((mile * 160934).ToString());
                                    break;

                                case 2://miles to meter
                                    mile = float.Parse(labelIn.Text);
                                    labelAns.Text = ((mile * 1609).ToString());
                                    break;

                                case 3://miles to kilometer
                                    mile = float.Parse(labelIn.Text);
                                    labelAns.Text = ((mile * 1.609).ToString());
                                    break;

                                case 4://miles to inches
                                    mile = float.Parse(labelIn.Text);
                                    labelAns.Text = ((mile * 63360).ToString());
                                    break;

                                case 5://miles to feet
                                    mile = float.Parse(labelIn.Text);
                                    labelAns.Text = ((mile * 5280).ToString());
                                    break;

                                case 6://miles to yards
                                    mile = float.Parse(labelIn.Text);
                                    labelAns.Text = ((mile * 1760).ToString());
                                    break;

                                case 7://miles to miles
                                    labelAns.Text = labelIn.Text;
                                    break;
                            }
                            break;
                    }
                    break;

                case 2://Volume
                    switch (comboBox6.SelectedIndex)
                    {
                        case 0://Milliliters
                            switch (comboBox7.SelectedIndex)
                            {
                                case 0://Milliliters to Milliliters
                                    labelAns.Text = labelIn.Text;
                                    break;

                                case 1://Milliliters to Liters
                                    milliL = float.Parse(labelIn.Text);
                                    labelAns.Text = ((milliL / 1000).ToString());
                                    break;

                                case 2://Millimeters to Cubic Meters
                                    milliL = float.Parse(labelIn.Text);
                                    labelAns.Text = ((milliL / 1000000).ToString());
                                    break;
                            }
                            break;

                        case 1://Liters
                            switch (comboBox7.SelectedIndex)
                            {
                                case 0://Liters to Milliliters
                                    liter = float.Parse(labelIn.Text);
                                    labelAns.Text = ((liter * 1000).ToString());
                                    break;

                                case 1://Liters to Liters
                                    labelAns.Text = labelIn.Text;
                                    break;

                                case 2://Liters to Cubic Meters
                                    liter = float.Parse(labelIn.Text);
                                    labelAns.Text = ((liter / 1000).ToString());
                                    break;
                            }
                            break;

                        case 2://Cubic Meters
                            switch (comboBox7.SelectedIndex)
                            {
                                case 0://Cubic Meters to Milliliters
                                    cubicM = float.Parse(labelIn.Text);
                                    labelAns.Text = ((cubicM * 1000000).ToString());
                                    break;

                                case 1://Cubic Meters to Liters
                                    cubicM = float.Parse(labelIn.Text);
                                    labelAns.Text = ((cubicM * 1000).ToString());
                                    break;

                                case 2://Cubic Meters to Cubic Meters
                                    labelAns.Text = labelIn.Text;
                                    break;
                            }
                            break;
                    }
                    break;

                case 3://Number System
                    switch (comboBox8.SelectedIndex)
                    {
                        case 0://Decimal
                            switch (comboBox9.SelectedIndex)
                            {
                                case 0://Decimal to Decimal
                                    labelAns.Text = labelIn.Text;
                                    break;

                                case 1://Decimal to Binary
                                    try
                                    {
                                        int number = Convert.ToInt32(output.Text);
                                        labelAns.Text = Convert.ToString(number, 2);
                                    }
                                    catch (Exception ex)
                                    {
                                        labelAns.Text = "Enter Valid number";
                                        await Task.Delay(1500);
                                        buttonC.PerformClick();
                                    }
                                    break;

                                case 2://Decimal to Octal
                                    try
                                    {
                                        int decimalNumber = int.Parse(output.Text);
                                        labelAns.Text = Convert.ToString(decimalNumber, 8);
                                    }
                                    catch (Exception ex)
                                    {
                                        labelAns.Text = "Enter Valid number";
                                        await Task.Delay(1500);
                                        buttonC.PerformClick();
                                    }
                                    break;

                                case 3://Decimal to Hexadecimal
                                    try
                                    {
                                        string input = output.Text;
                                        string outputHex = int.Parse(input).ToString("X");
                                        labelAns.Text = outputHex;
                                    }
                                    catch (Exception ex)
                                    {
                                        labelAns.Text = "Enter Valid number";
                                        await Task.Delay(1500);
                                        buttonC.PerformClick();
                                    }
                                    break;
                            }
                            break;

                        case 1://Binary
                            switch (comboBox9.SelectedIndex)
                            {
                                 
                                case 0://Binary to Decimal
                                    try
                                    {
                                        labelAns.Text = Convert.ToInt32((output.Text), 2).ToString();
                                    }
                                    catch (Exception ex)
                                    {                                        
                                        labelAns.Text = "Enter Valid number";
                                        await Task.Delay(1500);
                                        buttonC.PerformClick();
                                    }
                                    break;

                                case 1://Binary to Binary
                                    labelAns.Text = labelIn.Text;
                                    break;

                                case 2://Binary to Octal
                                    try
                                    {
                                        string val = output.Text;
                                        int convertnumber = Convert.ToInt32(val, 2);
                                        labelAns.Text = Convert.ToString(convertnumber, 8);
                                    }
                                    catch (Exception ex)
                                    {
                                        labelAns.Text = "Enter Valid number";
                                        await Task.Delay(1500);
                                        buttonC.PerformClick();
                                    }
                                    break;

                                case 3://Binary to Hexadecimal
                                    try
                                    {
                                        string valu = output.Text;
                                        labelAns.Text = Convert.ToInt32(valu, 2).ToString("X");
                                    }
                                    catch (Exception ex)
                                    {
                                        labelAns.Text = "Enter Valid number";
                                        await Task.Delay(1500);
                                        buttonC.PerformClick();
                                    }
                                    break;
                                   
                            }
                            break;

                        case 2://Octal
                            switch (comboBox9.SelectedIndex)
                            {
                                case 0://Octal to Decimal
                                    try
                                    {
                                        labelAns.Text = Convert.ToInt32((output.Text), 8).ToString();
                                    }
                                    catch (Exception ex)
                                    {
                                        labelAns.Text = "Enter Valid number";
                                        await Task.Delay(1500);
                                        buttonC.PerformClick();
                                    }
                                    break;

                                case 1://Octal to Binary
                                    try
                                    {
                                        labelAns.Text = Convert.ToString(Convert.ToInt32((output.Text), 8), 2);
                                    }
                                    catch (Exception ex)
                                    {
                                        labelAns.Text = "Enter Valid number";
                                        await Task.Delay(1500);
                                        buttonC.PerformClick();
                                    }
                                    break;

                                case 2://Octal to Octal
                                    labelAns.Text = labelIn.Text;
                                    break;

                                case 3://Octal to Hexadecimal
                                    try
                                    {
                                        string val = output.Text;
                                        labelAns.Text = Convert.ToInt32(val, 8).ToString("X");
                                    }
                                    catch (Exception ex)
                                    {
                                        labelAns.Text = "Enter Valid number";
                                        await Task.Delay(1500);
                                        buttonC.PerformClick();
                                    }
                                    break;
                            }
                            break;

                        case 3://Hexadecimal
                            switch (comboBox9.SelectedIndex)
                            {
                                case 0://Hexadecimal to Decimal
                                    try
                                    {
                                        string s = output.Text;
                                        long n = Int64.Parse(s, System.Globalization.NumberStyles.HexNumber);
                                        labelAns.Text = n.ToString();
                                    }
                                    catch (Exception ex)
                                    {
                                        labelAns.Text = "Enter Valid number";
                                        await Task.Delay(1500);
                                        buttonC.PerformClick();
                                    }
                                    break;

                                case 1://Hexadecimal to Binary
                                    try
                                    {
                                        labelAns.Text = Convert.ToString(Convert.ToInt32((output.Text), 16), 2);
                                    }
                                    catch (Exception ex)
                                    {
                                        labelAns.Text = "Enter Valid number";
                                        await Task.Delay(1500);
                                        buttonC.PerformClick();
                                    }
                                    break;

                                case 2://Hexadecimal to Octal
                                    try
                                    {
                                        labelAns.Text = Convert.ToString(Convert.ToInt32((output.Text), 16), 8);
                                    }
                                    catch (Exception ex)
                                    {
                                        labelAns.Text = "Enter Valid number";
                                        await Task.Delay(1500);
                                        buttonC.PerformClick();
                                    }
                                    break;

                                case 3://Hexadecimal to Hexadecimal
                                    labelAns.Text = labelIn.Text;
                                    break;
                            }
                            break;
                    }
                    break;

            }
        }
    }
}
