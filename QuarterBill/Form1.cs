using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**********************************\
*                                  *
* Andrew Terwilliger 4/28/2020     *
* Minneapolis College              *
* ITEC 2505-60 C# Programming      *
*                                  *
\**********************************/

namespace QuarterBill
{
    public partial class Form1 : Form
    {
        // Global list of Quarters and their TextBoxes.
        readonly List<Decimal> QuarterBills = new List<Decimal>();
        readonly List<TextBox> QtrBoxes = new List<TextBox>();

        public Form1()
        {
            InitializeComponent();
            
            // Adding all quarters to a list for easy looping.
            QtrBoxes.Add(txbQtrOne);
            QtrBoxes.Add(txbQtrTwo);
            QtrBoxes.Add(txbQtrThree);
            QtrBoxes.Add(txbQtrFour);
        }

        // Calculate button method, runs through each TextBox quarter, validates and adds the value to the global list.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Clearing the Quarters list, and setting the error status as false.
            QuarterBills.Clear();
            bool errored = false;

            // Bill class to calculate our bill.
            BillAnaylisis Bill = new BillAnaylisis();

            // Looping while the loop has not errored, and while the count is less than 4.
            while (errored != true && QuarterBills.Count < 4)
            {
                // Looping for every TextBox in the List of TextBoxes.
                foreach (TextBox quarter in QtrBoxes)
                {
                    // If it has errored due to a previous loop, we continue the loop out.
                    if (errored == true) continue;

                    // Validating if the TextBox has the correct data we need.
                    if (!ValidatePositiveDecimal(quarter.Text, out decimal Value, out string QtrError))
                    {
                        // If not, we focus - error and notify the User.
                        quarter.Focus();
                        errored = true;
                        MessageBox.Show($"Please verify the text in the highlighted quarter. {QtrError}", "Quarter Error");
                    }
                    else
                    {
                        // Elsewise we add the value to the QuarterBill list.
                        QuarterBills.Add(Value);
                    }
                }
            }

            // Validating if the count has all the quarters before continuing.
            if (QuarterBills.Count == 4)
            {
                // Have the Class calculate the bill.
                Bill.calculateBill(QuarterBills);

                // Post the total and average in currency.
                txbTotal.Text = Bill.Total;
                txbAverage.Text = Bill.Average;
            }
        }

        // ValidatePositiveDecimal bool method, returns a true or false if the provided string is valid bool - also outputs a decimal number and errorMsg.
        private bool ValidatePositiveDecimal(string text, out decimal number, out string errorMsg)
        {
            errorMsg = null;
            number = 0m;
            try
            {
                number = Decimal.Parse(text);
                if (number >= 0m)
                {
                    return true;
                }
                else
                {
                    errorMsg = "Enter a positive Number";
                    return false;
                }
            }
            catch (FormatException)
            {
                errorMsg = "Enter numbers only.";
                return false;
            }
            catch (OverflowException)
            {
                errorMsg = "Enter a smaller number.";
                return false;
            }
        }
    }
}
