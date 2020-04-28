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

namespace PlantSuggest
{
    class PlantInfo
    {
        // SuggestHouseplant Method, takes in the temperature and if the room has a south facing window.
        public string SuggestHouseplant(int temp, bool southFacing)
        {
            // If the room has a south facing window the suggested plants are different, so this is required.
            if (southFacing)
            {
                if (temp > 65)
                {
                    return "Peace Lilly";
                }
                else
                {
                    return "Spider Plant";
                }
            }
            else
            {
                if (temp > 65)
                {
                    return "Dragon Tree";
                }
                else
                {
                    return "Ivy";
                }
            }

        }

        // ShowWebPage Method, takes in a plantName for a requested plant information - Otherwise show the default homepage.
        public void ShowWebPage(string plantName = null)
        {
            string url = "https://www.houseplant411.com/";

            if (plantName != null)
            {
                url = url + "houseplant?hpq=" + plantName;
            }
            // Uses the system Processes to start the default browser with the requested Webpage.
            System.Diagnostics.Process.Start(url);
        }
    }
}
