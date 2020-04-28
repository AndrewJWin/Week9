using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**********************************\
*                                  *
* Andrew Terwilliger 4/28/2020     *
* Minneapolis College              *
* ITEC 2505-60 C# Programming      *
*                                  *
\**********************************/

namespace QuarterBill
{
    class BillAnaylisis
    {
        // Public methods set readonly for getting the Average and Total values.
        public string Average { get; private set; }
        public string Total { get; private set; }

        // Public method to calculate a bill, taking in the List of quarter and calculating their total and average.
        // Rewritten in a way to accept more than 4 quarters if needed, calculating the average based on how many values are in the list.
        public void calculateBill(List<Decimal> Quarters)
        {
            // Preparing variables;
            decimal total = 0m;
            decimal average = 0m;

            // Looping through and adding their total and average for calculation.
            foreach (decimal quarter in Quarters)
            {
                total += quarter;
                average += quarter;
            }

            // Setting the internal values of Average and Total.
            Average = (average / Quarters.Count).ToString("C");
            Total = total.ToString("C");
        }
        
    }
}
