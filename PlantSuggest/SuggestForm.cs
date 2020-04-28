using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace PlantSuggest
{
    public partial class SuggestForm : Form
    {
        // Values for detecting if the home will be too cold or too hot.
        readonly int MinTemp = 50;
        readonly int MaxTemp = 90;

        // Values for verifying if the user has been shown the appropriate warning for their house temperature.
        bool shownMinWarning = false;
        bool shownMaxWarning = false;

        // Initializing the PlantInfo class, allowing us to suggest appropriate houseplants to the user.
        PlantInfo plantInfo = new PlantInfo();

        public SuggestForm()
        {
            InitializeComponent();
            // Adding a new handler to the trackbar Scroll event, this simply re-runs the "Suggest" Method when the user changes the temp.
            this.trkTemp.Scroll += new System.EventHandler(this.btnSuggest_Click);
        }

        // Suggest button Method, gathers the values of each adjustable set and uses the SuggestHouseplant Method to get an answer.
        private void btnSuggest_Click(object sender, EventArgs e)
        {
            int homeTemp = trkTemp.Value;
            bool southLight = chkSouthFacing.Checked;
            if (homeTemp == MinTemp && shownMinWarning == false)
            {
                shownMinWarning = true;
                MessageBox.Show("Your home may be too cold for most houseplants.", "Information");
            }

            if (homeTemp == MaxTemp && shownMaxWarning == false)
            {
                shownMinWarning = true;
                MessageBox.Show("Your home may be too hot for most houseplants.", "Information");
            }
            string SuggestedPlant = plantInfo.SuggestHouseplant(homeTemp, southLight);

            // Using the SuggestedPlant return as the value for what plant would do well.
            lblSuggestion.Text = SuggestedPlant;
        }

        

        // Numeric response to the value of the Trackbar, updates the temperature label with the temperature.
        private void trkTemp_Scroll(object sender, EventArgs e)
        {
            lblTemp.Text = trkTemp.Value.ToString("# °F");
        }

        // Plant Info link Click Method, takes the User to a specific webpage about the suggested houseplant.
        private void lnkPlantInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Default Case in the event that the user has not recieved a suggestion, or clicks before interacting with the model.
            if (lblSuggestion.Text == "Plant suggestion here")
            {
                // Show the default webpage.
                plantInfo.ShowWebPage();
            }
            else
            {
                // Elsewise show the webpage for the suggested houseplant.
                plantInfo.ShowWebPage(lblSuggestion.Text);
            }
        }

    }
}
