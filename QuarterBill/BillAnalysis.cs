using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarterBill
{
    class BillAnaylisis
    {
        public string Average { get; private set; }
        public string Total { get; private set; }

        public void calculateBill(List<Decimal> Quarters)
        {
            // Preparing variables;
            decimal total = 0m;
            decimal average = 0m;

            // Once all the inputs have been validated and stored - we go through, add them together and figure out the average.
            foreach (decimal quarter in Quarters)
            {
                total += quarter;
                average += quarter;
            }
            Average = (average / 4).ToString("C");
            Total = total.ToString("C");
        }
        
    }
}
