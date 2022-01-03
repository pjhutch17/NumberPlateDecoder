// Number Plate Decoder
// by PJ Hutchison
// Aug 2019.
// Changes
// 03/01/2022 - Fixed Reg. Year field.

using System;
using System.Text;
using System.Windows.Forms;

namespace Number_Plate_Decoder_2019
{
    public partial class frmNumberPlate : Form
    {
        public frmNumberPlate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Decode given car number.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event</param>
        private void cmdDecode_Click(object sender, EventArgs e)
        {
            Decode_CarNumber();
        }

        /// <summary>
        /// Decode old or new style car number.
        /// </summary>
        void Decode_CarNumber()
        {
            String Office, Local, RegMonth, RegYear, CarNum, Plate;
            String OfficeName, Ids, MonthName, FullYear;
            int MonthNum;

            Ids = "ABCDEFGHJKLMNOPRSTUVWXY"; // q,i,z are not included
            OfficeName = "";
            // Get data from Plate number
            Plate = txtPlate.Text.ToUpper();
            Office = Plate.Substring(0, 1);
            Local = Plate.Substring(1, 1);
            RegMonth = Plate.Substring(2, 1);
            RegYear = Plate.Substring(3, 1);
            CarNum = Plate.Substring(5, 3);
            // Validation
            if (Plate.Length != 8)
            {
                txtOffice.Text = "Old Number Plate";
                txtYear.Text = Get_Old_RegYear(Plate.Substring(0, 1));
                return;
            }
            if (Ids.IndexOf(Office) == 9 & Ids.IndexOf(Local) == 0)
            {
                txtOffice.Text = "Old Number Plate";
                txtYear.Text = Get_Old_RegYear(Plate.Substring(0, 1));
                return;
            }
            if (String.Compare(RegMonth, "0") < 0 | String.Compare(RegMonth, "9") > 0)
            {
                txtOffice.Text = "Old Number Plate";
                txtYear.Text = Get_Old_RegYear(Plate.Substring(0, 1));
                return;
            }
            if (String.Compare(Office, "A") >= 0 && String.Compare(Office, "Z") <= 0 && String.Compare(Local, "0") >= 0 && String.Compare(Local, "9") <= 0)
            {
                txtOffice.Text = "Old Number Plate";
                txtYear.Text = Get_Old_RegYear(Plate.Substring(0, 1));
                return;
            }
            // Decode DVLA Office
            switch (Office)
            {
                case "A":
                    if (Ids.Substring(0, 13).IndexOf(Local) > 0)
                    {
                        OfficeName = "Peterborough";
                    }
                    else if (Ids.Substring(13, 6).IndexOf(Local) > 0)
                    {
                        OfficeName = "Norwich";
                    }
                    else if (Ids.Substring(19, 4).IndexOf(Local) > 0)
                    {
                        OfficeName = "Ipswich";
                    }
                    break;
                case "B":
                    OfficeName = "Birmingham";
                    break;
                case "C":
                    if (Ids.Substring(0, 14).IndexOf(Local) > 0)
                    {
                        OfficeName = "Cardiff";
                    }
                    else if (Ids.Substring(14, 6).IndexOf(Local) > 0)
                    {
                        OfficeName = "Swansea";
                    }
                    else if (Ids.Substring(20, 3).IndexOf(Local) > 0)
                    {
                        OfficeName = "Bangor";
                    }
                    break;
                case "D":
                    if (Ids.Substring(0, 10).IndexOf(Local) > 0)
                    {
                        OfficeName = "Chester";
                    }
                    else if (Ids.Substring(10, 13).IndexOf(Local) > 0)
                    {
                        OfficeName = "Shewsbury";
                    }
                    break;
                case "E":
                    OfficeName = "Chemsford";
                    break;
                case "F":
                    if (Ids.Substring(0, 15).IndexOf(Local) > 0)
                    {
                        OfficeName = "Nottingham";
                    }
                    else if (Ids.Substring(15, 7).IndexOf(Local) > 0)
                    {
                        OfficeName = "Lincoln";
                    }
                    break;
                case "G":
                    if (Ids.Substring(0, 14).IndexOf(Local) > 0)
                    {
                        OfficeName = "Maidstone";
                    }
                    else if (Ids.Substring(14, 7).IndexOf(Local) > 0)
                    {
                        OfficeName = "Brighton";
                    }
                    break;
                case "H":
                    if (Ids.Substring(0, 9).IndexOf(Local) > 0)
                    {
                        OfficeName = "BourneMouth";
                    }
                    else if (Ids.Substring(9, 13).IndexOf(Local) > 0 && Local != "W")
                    {
                        OfficeName = "Portsmouth";
                    }
                    else
                        OfficeName = "Isle of Wight"; // W number
                    break;
                case "K":
                    if (Ids.Substring(0, 11).IndexOf(Local) > 0)
                    {
                        OfficeName = "Bournemouth"; // Formally Luton
                    }
                    else if (Ids.Substring(11, 12).IndexOf(Local) > 0 && Local != "W")
                    {
                        OfficeName = "Northampton";
                    }
                    break;
                case "L":
                    if (Ids.Substring(0, 9).IndexOf(Local) > 0)
                    {
                        OfficeName = "Wimbledon";
                    }
                    else if (Ids.Substring(9, 9).IndexOf(Local) > 0 && Local != "W")
                    {
                        OfficeName = "Borehamwood"; // Formally Stanmore
                    }
                    else if (Ids.Substring(18, 5).IndexOf(Local) > 0)
                    {
                        OfficeName = "Sidcup";
                    }
                    break;
                case "M":
                    OfficeName = "Manchester";
                    break;
                case "N":
                    if (Ids.Substring(0, 13).IndexOf(Local) > 0)
                    {
                        OfficeName = "Newcastle";
                    }
                    else if (Ids.Substring(13, 9).IndexOf(Local) > 0 && Local != "W")
                    {
                        OfficeName = "Stockton";
                    }
                    break;
                case "O":
                    OfficeName = "Oxford";
                    break;
                case "P":
                    if (Ids.Substring(0, 18).IndexOf(Local) > 0)
                    {
                        OfficeName = "Preston";
                    }
                    else if (Ids.Substring(18, 5).IndexOf(Local) > 0 && Local != "W")
                    {
                        OfficeName = "Carlisle";
                    }
                    break;
                case "R":
                    OfficeName = "Theale"; // in Reading
                    break;
                case "S":
                    if (Ids.Substring(0, 9).IndexOf(Local) > 0)
                    {
                        OfficeName = "Glasgow";
                    }
                    else if (Ids.Substring(9, 5).IndexOf(Local) > 0 && Local != "W")
                    {
                        OfficeName = "Edinburgh";
                    }
                    else if (Ids.Substring(14, 3).IndexOf(Local) > 0)
                    {
                        OfficeName = "Dundee";
                    }
                    else if (Ids.Substring(18, 3).IndexOf(Local) > 0 && Local != "W")
                    {
                        OfficeName = "Aberdeen";
                    }
                    else if (Ids.Substring(21, 3).IndexOf(Local) > 0 && Local != "W")
                    {
                        OfficeName = "Inverness";
                    }
                    break;
                case "V":
                    OfficeName = "Worcester";
                    break;
                case "W":
                    if (Ids.Substring(0, 9).IndexOf(Local) > 0)
                    {
                        OfficeName = "Exeter";
                    }
                    else if (Ids.Substring(9, 2).IndexOf(Local) > 0 && Local != "W")
                    {
                        OfficeName = "Truro";
                    }
                    else if (Ids.Substring(11, 12).IndexOf(Local) > 0)
                    {
                        OfficeName = "Bristol";
                    }
                    break;
                case "Y":
                    if (Ids.Substring(0, 11).IndexOf(Local) > 0)
                    {
                        OfficeName = "Leeds";
                    }
                    else if (Ids.Substring(11, 9).IndexOf(Local) > 0 && Local != "W")
                    {
                        OfficeName = "Sheffield";
                    }
                    else if (Ids.Substring(20, 3).IndexOf(Local) > 0)
                    {
                        OfficeName = "Barnsley";
                    }
                    break;
                default:
                    OfficeName = "Invalid Office";
                    break;
            }
            if (String.Compare(Local, "Q") == 0 || String.Compare(Local, "I") == 0 || String.Compare(Local, "Z") == 0)
            {
                OfficeName = "Invalid Office";
            }
            // Work out month of registration
            MonthNum = Int32.Parse(RegMonth); // String to integer
            if (MonthNum < 5)
                MonthName = "March";
            else
                MonthName = "September";
            // Work out year of registration
            if (MonthNum < 5)
            { 
                FullYear = String.Concat("20", RegMonth, RegYear);
            }
            else
            {
                RegMonth = (MonthNum - 5).ToString();
                FullYear = String.Concat("20", RegMonth, RegYear);
            }
            // Display results on form
            txtOffice.Text = OfficeName;
            txtLocal.Text = Local;
            txtMonth.Text = MonthName;
            txtYear.Text = FullYear;
            txtNumber.Text = CarNum;
        }


        /// <summary>
        /// Works out Reg Year for previous number plates. e.g. L25 LUM = 1983 + 1993
        /// </summary>
        /// <param name="YearLetter">Year letter. NB: I, O, Q and Z are not included (similar to 1, 0 and 2)</param>
        /// <returns>Old Year</returns>
        String Get_Old_RegYear(String YearLetter)
        {
            Int32 RegYear = 0;
            byte yr;

            if (String.Compare(YearLetter, "A") > 0 && String.Compare(YearLetter, "S") < 0)
            {
                yr = Encoding.ASCII.GetBytes(YearLetter)[0];
                RegYear = 1983 + yr - 65;
                if (String.Compare(YearLetter, "I") > 0)
                    RegYear = RegYear - 1;
                if (String.Compare(YearLetter, "O") > 0)
                    RegYear = RegYear - 1;
                if (String.Compare(YearLetter, "Q") > 0)
                    RegYear = RegYear - 1;
            }
            else if (String.Compare(YearLetter, "T") == 0 || String.Compare(YearLetter, "V") == 0)
                RegYear = 1999;
            else if (String.Compare(YearLetter, "W") == 0 || String.Compare(YearLetter, "X") == 0)
                RegYear = 2000;
            else if (String.Compare(YearLetter, "Y") == 0)
                RegYear = 2001;

            return (RegYear.ToString());
        }
    
    }
}
