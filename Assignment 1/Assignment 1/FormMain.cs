using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_1
{
    public partial class FormMain : Form
    {
        ///Initialise list that holds the Fish objects and int that stores the number of fish
        private Fish[] fishType;
        private int fishNum = Fish.GetName.Length;

        ///Initialise list that holds the Boat objects and an object that stores the current boat
        private List<Boat> boatNum = new List<Boat>();
        private Boat currentBoat;

        ///Initialise misc variables
        private int boatCount = 0;
        private int boatIncrement = 1;
        private int fleetLoopCount = Fish.GetName.Length;
        private decimal[] totalQuota = new decimal[Fish.GetName.Length];
        private decimal[] totalFactorQuota = new decimal[Fish.GetName.Length];
        private string weightOutput = "KG";
        private decimal weightModifier = 1;
        private int[] selectedSpecies = { -1, -1, -1, -1 };
        int memChoice = -1;

        public FormMain()
        {
            InitializeComponent();
            FishCreator();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This creates the fish objects
        /// </summary>
        private void FishCreator()
        {
            fishType = new Fish[fishNum];
            for (int i = 0; i < fishNum; i++)
            {
                fishType[i] = new Fish(Fish.GetName[i], Fish.GetFactor[i], Fish.GetQuota[i]);
                speciesComboBox1.Items.Add(Fish.GetName[i]);
                speciesComboBox2.Items.Add(Fish.GetName[i]);
                speciesComboBox3.Items.Add(Fish.GetName[i]);
                speciesComboBox4.Items.Add(Fish.GetName[i]);
            }
            ShowCurrentFish(fishType);
        }

        /// <summary>
        /// This displays the fish objects in the middle right UI
        /// </summary>
        private void ShowCurrentFish(Fish[] fishType)
        {
            fishOutputBox.Text = string.Empty;
            fishOutputBox.AppendText("Name" + "\t\t" + "Factor" + "\t\t" + "Quota" + Environment.NewLine);
            for (int i = 0; i < fishNum; i++)
            {
                switch (Fish.GetName[i].Length)
                {
                    case int n when (n > 7):
                        fishOutputBox.Text += Fish.GetName[i];
                        fishOutputBox.AppendText("\t");
                        fishOutputBox.Text += Fish.GetFactor[i];
                        fishOutputBox.AppendText("\t\t");
                        fishOutputBox.Text += Fish.GetQuota[i] * weightModifier + weightOutput;
                        fishOutputBox.Text += Environment.NewLine;
                        break;
                    default:
                        fishOutputBox.Text += Fish.GetName[i];
                        fishOutputBox.AppendText("\t\t");
                        fishOutputBox.Text += Fish.GetFactor[i];
                        fishOutputBox.AppendText("\t\t");
                        fishOutputBox.Text += Fish.GetQuota[i] * weightModifier + weightOutput;
                        fishOutputBox.Text += Environment.NewLine;
                        break;
                }
            }
        }

        /// <summary>
        /// This calls ShipCreator to create a new boat and if the currently selected boat isn't null, it calls QuotaMemory to store the number of caught fish
        /// </summary>
        private void SubmitShipButton_MouseClick(object sender, MouseEventArgs e)
        {
            ShipCreator();
        }

        /// <summary>
        /// This handles creating new boat objects
        /// </summary>
        private void ShipCreator()
        {
            ///Declare temporary variables
            ///These will take the input from the form
            string tempName = nameTextBox.Text;
            string tempLicense = "";
            decimal tempMaxLoad = 0m;
            string[] tempFishSpecies = new string[fleetLoopCount];
            decimal[] tempQuotaArray = new decimal[fleetLoopCount];
            decimal tempHaul = 0;
            decimal[] tempLiveWeight = new decimal[fleetLoopCount];

            ///Declare verification variables
            ///These will be used to verify max load and quota filled inputs
            decimal maxLoadBox;
            bool maxLoadVarCheck;
            decimal quotaTextBox;
            bool quotaVarCheck;

            memChoice = 0;

            ///Input verification for ship name
            ///Will accept any name so long as it is not empty or whitespace
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("You have not entered a name for the vessel, please verify.");
                return;
            }

            ///Input verification for ship License
            ///Displays specific error messages depending on the length of the License
            switch (licenseTextBox.TextLength)
            {
                case 0:
                    if (string.IsNullOrWhiteSpace(licenseTextBox.Text)) { MessageBox.Show("You have not entered a license for the vessel."); return; }
                    break;
                case int n when (n > 0 && n < 3):
                    MessageBox.Show("Please enter a License of valid length: LXX, LXXX, LLXX, LLXXX.");
                    return;
                case 3:
                    if (char.IsLetter(licenseTextBox.Text.ElementAt(0)) != true || char.IsDigit(licenseTextBox.Text.ElementAt(1)) != true || char.IsDigit(licenseTextBox.Text.ElementAt(2)) != true)
                    { MessageBox.Show("Please enter a License of valid length: LXX, LXXX, LLXX, LLXXX."); ; return; }
                    break;
                case 4:
                    if (char.IsLetter(licenseTextBox.Text.ElementAt(0)) != true || char.IsDigit(licenseTextBox.Text.ElementAt(2)) != true || char.IsDigit(licenseTextBox.Text.ElementAt(3)) != true)
                    { MessageBox.Show("Please enter a License of valid length: LXX, LXXX, LLXX, LLXXX."); return; }
                    break;
                case 5:
                    if (char.IsLetter(licenseTextBox.Text.ElementAt(0)) != true || char.IsLetter(licenseTextBox.Text.ElementAt(1)) != true || char.IsDigit(licenseTextBox.Text.ElementAt(2)) != true
                    || char.IsDigit(licenseTextBox.Text.ElementAt(3)) != true || char.IsDigit(licenseTextBox.Text.ElementAt(4)) != true)
                    { MessageBox.Show("Please enter a License of valid length: LXX, LXXX, LLXX, LLXXX."); return; }
                    break;
                default:
                    MessageBox.Show("Please enter a License of valid length: LXX, LXXX, LLXX, LLXXX.");
                    return;
            }

            ///Secondary verification for ship License
            ///Checks to see if the License is already in use, and if so returns an error
            ///Boats are allowed to share names, but not License numbers
            if (boatCount > 0)
            {
                for (int i = 0; i < boatNum.Count; i++)
                {
                    if (licenseTextBox.Text == (currentBoat = boatNum[i]).GetLicence.ToString())
                    {
                        MessageBox.Show("You have entered the same license as another boat.");
                        return;
                    }
                }
                tempLicense = licenseTextBox.Text;
            }
            else { tempLicense = licenseTextBox.Text; }

            ///Input verifiaction for maximum load
            ///Checks to see if input is empty, is a decimal and is at least 1
            maxLoadVarCheck = decimal.TryParse(maxLoadTextBox.Text, out maxLoadBox);
            if (string.IsNullOrWhiteSpace(maxLoadTextBox.Text) || maxLoadVarCheck != true || maxLoadBox < 1)
            {
                MessageBox.Show("Maximum Load must be a positive number of at least 1.");
                maxLoadTextBox.Text = "";
                return;
            }
            else { tempMaxLoad = maxLoadBox; }

            ///Input verification for fish species
            ///Checks to see if a species has been selected, if not that box is ignored
            if (speciesComboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(speciesComboBox1.Text)) {}
            else { tempFishSpecies[Array.IndexOf(Fish.GetName, speciesComboBox1.Text)] = speciesComboBox1.Text; }
            if (speciesComboBox2.SelectedIndex == -1 || string.IsNullOrWhiteSpace(speciesComboBox2.Text)) {}
            else { tempFishSpecies[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] = speciesComboBox2.Text; }
            if (speciesComboBox3.SelectedIndex == -1 || string.IsNullOrWhiteSpace(speciesComboBox3.Text)) {}
            else { tempFishSpecies[Array.IndexOf(Fish.GetName, speciesComboBox3.Text)] = speciesComboBox3.Text; }
            if (speciesComboBox4.SelectedIndex == -1 || string.IsNullOrWhiteSpace(speciesComboBox4.Text)) {}
            else { tempFishSpecies[Array.IndexOf(Fish.GetName, speciesComboBox4.Text)] = speciesComboBox4.Text; }

            ///Input verification for fish caught
            ///Checks to see if input is empty or if the species selected is empty, if so it is ignored
            quotaVarCheck = decimal.TryParse(quotaFilledTextBox1.Text, out quotaTextBox);
            if (string.IsNullOrWhiteSpace(quotaFilledTextBox1.Text) || speciesComboBox1.SelectedIndex == -1) { }
            else
            {
                if (quotaVarCheck != true || quotaTextBox < 1)
                {
                    MessageBox.Show("Your input must be a positive number of at least 1.");
                    quotaFilledTextBox1.Text = "";
                    return;
                }
                else
                {
                    tempQuotaArray[Array.IndexOf(Fish.GetName, speciesComboBox1.Text)] += quotaTextBox;
                    tempHaul += Decimal.Parse(quotaFilledTextBox1.Text);
                    tempLiveWeight[Array.IndexOf(Fish.GetName, speciesComboBox1.Text)] = Fish.GetFactor[Array.IndexOf(Fish.GetName, speciesComboBox1.Text)] * quotaTextBox;
                }
            }

            ///Input verification for fish caught
            ///Checks to see if input is empty or if the species selected is empty, if so it is ignored
            quotaVarCheck = decimal.TryParse(quotaFilledTextBox2.Text, out quotaTextBox);
            if (string.IsNullOrWhiteSpace(quotaFilledTextBox2.Text) || speciesComboBox2.SelectedIndex == -1) { }
            else
            {
                if (quotaVarCheck != true || quotaTextBox < 1)
                {
                    MessageBox.Show("Your input must be a positive number of at least 1.");
                    quotaFilledTextBox2.Text = "";
                    return;
                }
                else
                {
                    tempQuotaArray[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] += quotaTextBox;
                    tempHaul += Decimal.Parse(quotaFilledTextBox2.Text);
                    tempLiveWeight[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] = Fish.GetFactor[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] * quotaTextBox;
                }
            }

            ///Input verification for fish caught
            ///Checks to see if input is empty or if the species selected is empty, if so it is ignored
            quotaVarCheck = decimal.TryParse(quotaFilledTextBox3.Text, out quotaTextBox);
            if(string.IsNullOrWhiteSpace(quotaFilledTextBox3.Text) || speciesComboBox3.SelectedIndex == -1) { }
            else
            {
                if (quotaVarCheck != true || quotaTextBox < 1)
                {
                    MessageBox.Show("Your input must be a positive number of at least 1.");
                    quotaFilledTextBox3.Text = "";
                    return;
                }
                else
                {
                    tempQuotaArray[Array.IndexOf(Fish.GetName, speciesComboBox3.Text)] += quotaTextBox;
                    tempHaul += Decimal.Parse(quotaFilledTextBox3.Text);
                    tempLiveWeight[Array.IndexOf(Fish.GetName, speciesComboBox3.Text)] = Fish.GetFactor[Array.IndexOf(Fish.GetName, speciesComboBox3.Text)] * quotaTextBox;
                }
            }

            ///Input verification for fish caught
            ///Checks to see if input is empty or if the species selected is empty, if so it is ignored
            quotaVarCheck = decimal.TryParse(quotaFilledTextBox4.Text, out quotaTextBox);
            if (string.IsNullOrWhiteSpace(quotaFilledTextBox4.Text) || speciesComboBox4.SelectedIndex == -1) { }
            else
            {
                if (quotaVarCheck != true || quotaTextBox < 1)
                {
                    MessageBox.Show("Your input must be a positive number of at least 1.");
                    quotaFilledTextBox4.Text = "";
                    return;
                }
                else
                {
                    tempQuotaArray[Array.IndexOf(Fish.GetName, speciesComboBox4.Text)] += quotaTextBox;
                    tempHaul += Decimal.Parse(quotaFilledTextBox4.Text);
                    tempLiveWeight[Array.IndexOf(Fish.GetName, speciesComboBox4.Text)] = Fish.GetFactor[Array.IndexOf(Fish.GetName, speciesComboBox4.Text)] * quotaTextBox;
                }
            }

            ///Checks if total haul is higher than the maximum load and returns an error if so
            if (tempHaul > tempMaxLoad)
            {
                MessageBox.Show("You have a greater load than capacity, please verify.");
                tempHaul = 0;
                tempMaxLoad = 0;
                return;
            }

            ///Creates a new boat object
            boatNum.Add(new Boat(tempName, tempLicense, tempMaxLoad, tempHaul, tempFishSpecies, tempQuotaArray, tempLiveWeight));

            ///Adds the name and License to the boat selection comboBox
            boatSelectionComboBox.Items.Add(boatNum[boatCount].GetName + " - " + boatNum[boatCount].GetLicence);

            ///Sets the current boat to the boat that has just been created, this is used by QuotaMemory to store the caught fish into permanant memory
            currentBoat = boatNum[boatCount];

            ///Increments the total number of boats that have been created by one
            boatCount += boatIncrement;

            if (currentBoat != null)
            {
                QuotaMemory(tempQuotaArray, tempLiveWeight);
            }
        }

        private void updateButton_MouseClick(object sender, MouseEventArgs e)
        {
            ShipUpdater();
            ShowCurrentBoat(currentBoat);
        }

        private void ShipUpdater()
        {
            if (currentBoat == null) { return; }

            string tempName = currentBoat.GetName;
            string tempLicense = currentBoat.GetLicence;
            decimal tempMaxLoad = currentBoat.GetMaximumLoad;
            string[] tempFishSpecies = currentBoat.GetFishSpecies;
            decimal[] tempQuotaArray = currentBoat.GetFilledQuota;
            decimal tempHaul = currentBoat.GetShipHaul;
            decimal[] tempLiveWeight = currentBoat.GetLiveWeight;

            decimal quotaTextBox;
            bool quotaVarCheck;

            ///Memory variables
            decimal[] memQuotaArray = new decimal[fleetLoopCount];
            decimal[] memLiveWeight = new decimal[fleetLoopCount];

            memChoice = 1;


            ///Checks if total haul is higher than the maximum load and returns an error if so
            if (tempHaul >= tempMaxLoad)
            {
                MessageBox.Show("You have a greater load than capacity, please verify.");
                return;
            }

            ///Input verification for updates, makes sure you can't add new types of fish to a boat while updating
            if (tempFishSpecies.Contains(speciesComboBox1.Text) || string.IsNullOrWhiteSpace(speciesComboBox1.Text)) { }
            else { MessageBox.Show("Your cannot add/change fish species to a boat."); speciesComboBox1.Text = ""; return; }
            if (tempFishSpecies.Contains(speciesComboBox2.Text) || string.IsNullOrWhiteSpace(speciesComboBox2.Text)) { }
            else { MessageBox.Show("Your cannot add/change fish species to a boat."); speciesComboBox2.Text = ""; return; }
            if (tempFishSpecies.Contains(speciesComboBox3.Text) || string.IsNullOrWhiteSpace(speciesComboBox3.Text)) { }
            else { MessageBox.Show("Your cannot add/change fish species to a boat."); speciesComboBox3.Text = ""; return; }
            if (tempFishSpecies.Contains(speciesComboBox4.Text) || string.IsNullOrWhiteSpace(speciesComboBox4.Text)) { }
            else { MessageBox.Show("Your cannot add/change fish species to a boat."); speciesComboBox4.Text = ""; return; }

            ///Input verification for fish species
            ///Checks to see if a species has been selected, if not that box is ignored
            if (speciesComboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(speciesComboBox1.Text)) { }
            else { tempFishSpecies[Array.IndexOf(Fish.GetName, speciesComboBox1.Text)] = speciesComboBox1.Text; }
            if (speciesComboBox2.SelectedIndex == -1 || string.IsNullOrWhiteSpace(speciesComboBox2.Text)) { }
            else { tempFishSpecies[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] = speciesComboBox2.Text; }
            if (speciesComboBox3.SelectedIndex == -1 || string.IsNullOrWhiteSpace(speciesComboBox3.Text)) { }
            else { tempFishSpecies[Array.IndexOf(Fish.GetName, speciesComboBox3.Text)] = speciesComboBox3.Text; }
            if (speciesComboBox4.SelectedIndex == -1 || string.IsNullOrWhiteSpace(speciesComboBox4.Text)) { }
            else { tempFishSpecies[Array.IndexOf(Fish.GetName, speciesComboBox4.Text)] = speciesComboBox4.Text; }

            ///Input verification for fish caught
            ///Checks to see if input is empty or if the species selected is empty, if so it is ignored
            quotaVarCheck = decimal.TryParse(quotaFilledTextBox1.Text, out quotaTextBox);
            if (string.IsNullOrWhiteSpace(quotaFilledTextBox1.Text) || speciesComboBox1.SelectedIndex == -1) { }
            else
            {
                if (quotaVarCheck != true || quotaTextBox < 1)
                {
                    MessageBox.Show("Your input must be a positive number of at least 1.");
                    quotaFilledTextBox1.Text = "";
                    return;
                }
                else
                {
                    tempQuotaArray[Array.IndexOf(Fish.GetName, speciesComboBox1.Text)] += quotaTextBox;
                    memQuotaArray[Array.IndexOf(Fish.GetName, speciesComboBox1.Text)] += quotaTextBox;
                    tempHaul += Decimal.Parse(quotaFilledTextBox1.Text);
                    tempLiveWeight[Array.IndexOf(Fish.GetName, speciesComboBox1.Text)] += Fish.GetFactor[Array.IndexOf(Fish.GetName, speciesComboBox1.Text)] * quotaTextBox;
                    memLiveWeight[Array.IndexOf(Fish.GetName, speciesComboBox1.Text)] += Fish.GetFactor[Array.IndexOf(Fish.GetName, speciesComboBox1.Text)] * quotaTextBox;
                }
            }

            ///Input verification for fish caught
            ///Checks to see if input is empty or if the species selected is empty, if so it is ignored
            quotaVarCheck = decimal.TryParse(quotaFilledTextBox2.Text, out quotaTextBox);
            if (string.IsNullOrWhiteSpace(quotaFilledTextBox2.Text) || speciesComboBox2.SelectedIndex == -1) { }
            else
            {
                if (quotaVarCheck != true || quotaTextBox < 1)
                {
                    MessageBox.Show("Your input must be a positive number of at least 1.");
                    quotaFilledTextBox2.Text = "";
                    return;
                }
                else
                {
                    tempQuotaArray[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] += quotaTextBox;
                    memQuotaArray[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] += quotaTextBox;
                    tempHaul += Decimal.Parse(quotaFilledTextBox2.Text);
                    tempLiveWeight[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] += Fish.GetFactor[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] * quotaTextBox;
                    memLiveWeight[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] += Fish.GetFactor[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] * quotaTextBox;
                }
            }

            ///Input verification for fish caught
            ///Checks to see if input is empty or if the species selected is empty, if so it is ignored
            quotaVarCheck = decimal.TryParse(quotaFilledTextBox3.Text, out quotaTextBox);
            if (string.IsNullOrWhiteSpace(quotaFilledTextBox3.Text) || speciesComboBox3.SelectedIndex == -1) { }
            else
            {
                if (quotaVarCheck != true || quotaTextBox < 1)
                {
                    MessageBox.Show("Your input must be a positive number of at least 1.");
                    quotaFilledTextBox3.Text = "";
                    return;
                }
                else
                {
                    tempQuotaArray[Array.IndexOf(Fish.GetName, speciesComboBox3.Text)] += quotaTextBox;
                    memQuotaArray[Array.IndexOf(Fish.GetName, speciesComboBox3.Text)] += quotaTextBox;
                    tempHaul += Decimal.Parse(quotaFilledTextBox3.Text);
                    tempLiveWeight[Array.IndexOf(Fish.GetName, speciesComboBox3.Text)] += Fish.GetFactor[Array.IndexOf(Fish.GetName, speciesComboBox3.Text)] * quotaTextBox;
                    memLiveWeight[Array.IndexOf(Fish.GetName, speciesComboBox3.Text)] += Fish.GetFactor[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] * quotaTextBox;
                }
            }

            ///Input verification for fish caught
            ///Checks to see if input is empty or if the species selected is empty, if so it is ignored
            quotaVarCheck = decimal.TryParse(quotaFilledTextBox4.Text, out quotaTextBox);
            if (string.IsNullOrWhiteSpace(quotaFilledTextBox4.Text) || speciesComboBox4.SelectedIndex == -1) { }
            else
            {
                if (quotaVarCheck != true || quotaTextBox < 1)
                {
                    MessageBox.Show("Your input must be a positive number of at least 1.");
                    quotaFilledTextBox4.Text = "";
                    return;
                }
                else
                {
                    tempQuotaArray[Array.IndexOf(Fish.GetName, speciesComboBox4.Text)] += quotaTextBox;
                    memQuotaArray[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] += quotaTextBox;
                    tempHaul += Decimal.Parse(quotaFilledTextBox4.Text);
                    tempLiveWeight[Array.IndexOf(Fish.GetName, speciesComboBox4.Text)] += Fish.GetFactor[Array.IndexOf(Fish.GetName, speciesComboBox4.Text)] * quotaTextBox;
                    memLiveWeight[Array.IndexOf(Fish.GetName, speciesComboBox4.Text)] += Fish.GetFactor[Array.IndexOf(Fish.GetName, speciesComboBox2.Text)] * quotaTextBox;
                }
            }

            boatNum[boatSelectionComboBox.SelectedIndex] = new Boat(tempName, tempLicense, tempMaxLoad, tempHaul, tempFishSpecies, tempQuotaArray, tempLiveWeight);
            currentBoat = boatNum[boatSelectionComboBox.SelectedIndex];
            QuotaMemory(memQuotaArray, memLiveWeight);
        }

        /// <summary>
        /// This takes caught fish and moves them into permanant storage
        /// </summary>
        private void QuotaMemory(decimal[] memQuotaArray, decimal[] memLiveWeight)
        {
            switch (memChoice)
            {
                case -1:
                    break;
                case 0:
                    for (int i = 0; i < fleetLoopCount; i++)
                    {
                        totalQuota[i] += currentBoat.GetFilledQuota[i];
                        totalFactorQuota[i] += currentBoat.GetLiveWeight[i];
                    }
                    break;
                case 1:
                    for (int i = 0; i < fleetLoopCount; i++)
                    {
                        totalQuota[i] += memQuotaArray[i];
                        totalFactorQuota[i] += memLiveWeight[i];
                    }
                    break;
            }
        }

        /// <summary>
        /// Displays the values of the currently selected boat
        /// </summary>
        private void ShowCurrentBoat(Boat currentBoat)
        {
            shipOutputBox.Text = string.Empty;
            shipOutputBox.Text += "Name: ";
            shipOutputBox.Text += currentBoat.GetName;
            shipOutputBox.Text += Environment.NewLine;
            shipOutputBox.AppendText("License: " + currentBoat.GetLicence + Environment.NewLine);
            shipOutputBox.AppendText("Maximum Capacity: " + currentBoat.GetMaximumLoad * weightModifier + weightOutput + Environment.NewLine);
            for (int i = 0; i < fleetLoopCount; i++)
            {
                if (currentBoat.GetFishSpecies[i] == null) { }
                else
                {
                    shipOutputBox.AppendText(currentBoat.GetFishSpecies[i] + " Fished: " + currentBoat.GetFilledQuota[i] * weightModifier + weightOutput + Environment.NewLine);
                    shipOutputBox.AppendText(currentBoat.GetFishSpecies[i] + " Live Weight: " + currentBoat.GetLiveWeight[i] * weightModifier + weightOutput + Environment.NewLine);
                }
            }
            shipOutputBox.AppendText("Ship Haul: " + currentBoat.GetShipHaul + weightOutput + Environment.NewLine);
            ShowCurrentQuota(currentBoat);

            ///Loads current boat values into UI
            nameTextBox.Text = currentBoat.GetName;
            licenseTextBox.Text = currentBoat.GetLicence;
            maxLoadTextBox.Text = currentBoat.GetMaximumLoad.ToString();
            quotaFilledTextBox1.Text = ""; quotaFilledTextBox2.Text = ""; quotaFilledTextBox3.Text = ""; quotaFilledTextBox4.Text = "";

        }

        /// <summary>
        /// Displays the name, number caught multiplied by species factor and the maximum quota
        /// The switch statement is required for the formatting to work correctly with text boxes, otherwise they would move out of alignment
        /// </summary>
        private void ShowCurrentQuota(Boat currentBoat)
        {
            quotaOutputBox.Text = string.Empty;

            if(weightOutput == "KG")
            {
                quotaOutputBox.AppendText("Name" + "\t\t" + "Fished (" + weightOutput + ")" + "\t" + "Quota" + Environment.NewLine);
            }
            else
            {
                quotaOutputBox.AppendText("Name" + "\t\t" + "Fished (" + weightOutput + ")" + "\t\t" + "Quota" + Environment.NewLine);
            }

            
            for (int i = 0; i < fleetLoopCount; i++)
            {
                if(totalFactorQuota[i] > 1000m / weightModifier)
                {
                    switch (Fish.GetName[i].Length)
                    {
                        case int n when (n > 7):
                            quotaOutputBox.Text += Fish.GetName[i];
                            quotaOutputBox.AppendText("\t");
                            quotaOutputBox.AppendText((totalFactorQuota[i] * weightModifier).ToString());
                            quotaOutputBox.AppendText("\t\t");
                            quotaOutputBox.Text += Fish.GetQuota[i] * weightModifier + Environment.NewLine;
                            break;
                        default:
                            quotaOutputBox.Text += Fish.GetName[i];
                            quotaOutputBox.AppendText("\t\t");
                            quotaOutputBox.AppendText((totalFactorQuota[i] * weightModifier).ToString());
                            quotaOutputBox.AppendText("\t\t");
                            quotaOutputBox.Text += Fish.GetQuota[i] * weightModifier + Environment.NewLine;
                            break;
                    }
                }
                else
                {
                    switch (Fish.GetName[i].Length)
                    {
                        case int n when (n > 7):
                            quotaOutputBox.Text += Fish.GetName[i];
                            quotaOutputBox.AppendText("\t");
                            quotaOutputBox.AppendText((totalFactorQuota[i] * weightModifier).ToString());
                            quotaOutputBox.AppendText("\t\t");
                            quotaOutputBox.Text += Fish.GetQuota[i] * weightModifier + Environment.NewLine;
                            break;
                        default:
                            quotaOutputBox.Text += Fish.GetName[i];
                            quotaOutputBox.AppendText("\t\t");
                            quotaOutputBox.AppendText((totalFactorQuota[i] * weightModifier).ToString());
                            quotaOutputBox.AppendText("\t\t");
                            quotaOutputBox.Text += Fish.GetQuota[i] * weightModifier + Environment.NewLine;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// This converts all displays to show the information in KG
        /// </summary>
        private void kgButton_Click(object sender, EventArgs e)
        {
            if (boatNum.Count == 0) { }
            else
            {
                weightModifier = 1m;
                weightOutput = "KG";
                ShowCurrentFish(fishType);
                ShowCurrentBoat(currentBoat);
            }
        }

        /// <summary>
        /// This converts all displays to show the information in Tonnes
        /// </summary>
        private void tonneButton_Click(object sender, EventArgs e)
        {
            if (boatNum.Count == 0) { }
            else
            {
                weightModifier = 0.001m;
                weightOutput = "T";
                ShowCurrentFish(fishType);
                ShowCurrentBoat(currentBoat);
            }
        }

        /// <summary>
        /// This selects the current boat by what is chosen in the comboBox and then calls ShowCurrentBoat to display this
        /// </summary>
        private void boatSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int speciesSortVar = 0;
            for(int i = 0; i < selectedSpecies.Length; i++)
            {
                selectedSpecies[i] = -1;
            }
            currentBoat = boatNum[boatSelectionComboBox.SelectedIndex];
            ShowCurrentBoat(currentBoat);

            ///Loops through selected fish species and then loads them onto the UI
            for(int i = 0; i < fleetLoopCount; i++)
            {
                if(currentBoat.GetFishSpecies[i] != null)
                {
                    selectedSpecies[speciesSortVar] = i;
                    speciesSortVar++;
                }
            }

            speciesComboBox1.SelectedIndex = -1;
            speciesComboBox2.SelectedIndex = -1;
            speciesComboBox3.SelectedIndex = -1;
            speciesComboBox4.SelectedIndex = -1;

            if (selectedSpecies[0] != -1) { speciesComboBox1.SelectedIndex = selectedSpecies[0]; }
            if (selectedSpecies[1] != -1) { speciesComboBox2.SelectedIndex = selectedSpecies[1]; }
            if (selectedSpecies[2] != -1) { speciesComboBox3.SelectedIndex = selectedSpecies[2]; }
            if (selectedSpecies[3] != -1) { speciesComboBox4.SelectedIndex = selectedSpecies[3]; }
        }

        /// <summary>
        /// This is a verification variable that stops the user from selecting the same species twice
        /// </summary>
        private void speciesComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {          
            if (speciesComboBox1.SelectedItem == speciesComboBox2.SelectedItem || speciesComboBox1.SelectedItem == speciesComboBox3.SelectedItem || speciesComboBox1.SelectedItem == speciesComboBox4.SelectedItem)
            {
                if (speciesComboBox1.SelectedIndex == -1)
                {
                    return;
                }
                MessageBox.Show("You cannot select the same species twice.");
                speciesComboBox1.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// This is a verification variable that stops the user from selecting the same species twice
        /// </summary>
        private void speciesComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speciesComboBox2.SelectedItem == speciesComboBox1.SelectedItem || speciesComboBox2.SelectedItem == speciesComboBox3.SelectedItem || speciesComboBox2.SelectedItem == speciesComboBox4.SelectedItem)
            {
                if (speciesComboBox2.SelectedIndex == -1)
                {
                    return;
                }
                MessageBox.Show("You cannot select the same species twice.");
                speciesComboBox2.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// This is a verification variable that stops the user from selecting the same species twice
        /// </summary>
        private void speciesComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speciesComboBox3.SelectedItem == speciesComboBox1.SelectedItem || speciesComboBox3.SelectedItem == speciesComboBox2.SelectedItem || speciesComboBox3.SelectedItem == speciesComboBox4.SelectedItem)
            {
                if (speciesComboBox3.SelectedIndex == -1)
                {
                    return;
                }
                MessageBox.Show("You cannot select the same species twice.");
                speciesComboBox3.SelectedIndex = -1;
            }

        }

        /// <summary>
        /// This is a verification variable that stops the user from selecting the same species twice
        /// </summary>
        private void speciesComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speciesComboBox4.SelectedItem == speciesComboBox1.SelectedItem || speciesComboBox1.SelectedItem == speciesComboBox2.SelectedItem || speciesComboBox1.SelectedItem == speciesComboBox3.SelectedItem)
            {
                if (speciesComboBox4.SelectedIndex == -1)
                {
                    return;
                }
                MessageBox.Show("You cannot select the same species twice.");
                speciesComboBox4.SelectedIndex = -1;
            }
        }
    }
}
