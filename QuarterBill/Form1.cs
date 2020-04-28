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

namespace QuarterBill
{
    public partial class Form1 : Form
    {
        // Global list of Quarters.
        readonly List<Decimal> Quarters = new List<Decimal>();
        readonly List<TextBox> QtrBoxes = new List<TextBox>();

        public Form1()
        {
            InitializeComponent();
            QtrBoxes.Add(txbQtrOne);
            QtrBoxes.Add(txbQtrTwo);
            QtrBoxes.Add(txbQtrThree);
            QtrBoxes.Add(txbQtrFour);
        }

        // Calculate button method, runs through each TextBox quarter, validates and adds the value to the global list.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Clearing the Quarters list, and setting the error status as false.
            Quarters.Clear();
            bool errored = false;

            // Bill class to calculate our bill.
            BillAnaylisis Bill = new BillAnaylisis();

            // Validating all the inputs provided by the user before going ahead and adding to list.

            while (errored != true && Quarters.Count < 4)
            {
                foreach (TextBox quarter in QtrBoxes)
                {
                    if (errored == true) continue;
                    if (!ValidatePositiveDecimal(quarter.Text, out decimal Value, out string QtrError))
                    {
                        quarter.Focus();
                        errored = true;
                        MessageBox.Show($"Please verify the text in the highlighted quarter. {QtrError}", "Quarter Error");
                    }
                    else
                    {
                        Quarters.Add(Value);
                    }
                }
            }

            // Validating if the count has all the quarters before continuing.
            if (Quarters.Count == 4)
            {
                // Have the Class calculate the bill.
                Bill.calculateBill(Quarters);

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
