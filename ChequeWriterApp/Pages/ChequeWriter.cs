using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ChequeWriterApp.Pages
{
    public partial class ChequeWriter
    {
        // Minimum amount that can be input for the Cheque Number
        private double MinChequeNumber { get; set; } = 00.01;
        // Maximum amount that can be input for the Cheque Number
        private double MaxChequeNumber { get; set; } = 1000000;

        // The Number to convert, this is what the user would alter.
        public double ChequeNumber { get; set; } = 0.00;

        // Holds the pre decimal number part of the cheque number.
        private int ChequeNumberIntPart { get; set; }
        // Holds the post decimal number part of the cheque number.
        private int ChequeNumberFracPart { get; set; }
        private int ChequeNumberLength { get; set; }
        private string ChequeNumberWords { get; set; }
        private string ChequeNumberWords2 { get; set; }
        private int RemainingNumber { get; set; }

        public void ChequeNumberToWords()
        {
            // Initialise variables for button press.
            ChequeNumberWords = "";
            ChequeNumberWords2 = "";

            try
            {
                // Set chequeNumberIntPart and chequeNumberFracPart by splitting the cheque number variable at the decimal point.
                string s = ChequeNumber.ToString("0.00", CultureInfo.InvariantCulture);
                string[] parts = s.Split('.');
                ChequeNumberIntPart = int.Parse(parts[0]);
                ChequeNumberFracPart = int.Parse(parts[1]);

            }
            catch (Exception)
            {
                // Error splitting the cheque Number into parts.
                throw new Exception("Error please reload the application");
            }

            try
            {
                if (ChequeNumberIntPart != 0)
                {
                    if (ChequeNumberIntPart < 0)
                    {
                        ChequeNumberWords += " Negative";
                        ChequeNumberIntPart = Math.Abs(ChequeNumberIntPart);
                    }

                    ChequeNumberWords += WordReturn(ChequeNumberIntPart);

                    // Add dollars suffix and deal with the plural wording.
                    if (ChequeNumberIntPart == 1)
                    {
                        ChequeNumberWords += " Dollar";
                    }
                    else
                    {
                        ChequeNumberWords += " Dollars";
                    }
                }

                if (ChequeNumberFracPart != 0 && ChequeNumberIntPart != 0)
                {
                    // Reset the words
                    ChequeNumberWords2 = "";

                    ChequeNumberWords += " And ";
                    ChequeNumberWords += WordReturn(ChequeNumberFracPart);

                    // Add dollars suffix and deal with the plural wording.
                    if (ChequeNumberFracPart == 1)
                    {
                        ChequeNumberWords += " Cent";
                    }
                    else
                    {
                        ChequeNumberWords += " Cents";
                    }
                }

                if (ChequeNumberFracPart != 0 && ChequeNumberIntPart == 0)
                {
                    ChequeNumberWords += WordReturn(ChequeNumberFracPart);

                    // Add dollars suffix and deal with the plural wording.
                    if (ChequeNumberFracPart == 1)
                    {
                        ChequeNumberWords += " Cent";
                    }
                    else
                    {
                        ChequeNumberWords += " Cents";
                    }
                }
            }
            catch (Exception)
            {

                // Error concatenating the Cheque Number too words.
                throw new Exception("Error please reload the application");
            }

           

        }

        public string WordReturn(int theNumber)
        {          

            try
            {
                int numberToConvert = theNumber;

                //ones' range
                if (numberToConvert < 10)
                {
                    ChequeNumberWords2 += Ones(theNumber);
                    RemainingNumber = 0;
                }

                //tens' range
                else if (10 <= numberToConvert && numberToConvert < 100)
                {
                    ChequeNumberWords2 += Tens(theNumber);
                    RemainingNumber = 0;
                }

                //hundreds' range
                else if (100 <= numberToConvert && numberToConvert < 1000)
                {
                    ChequeNumberWords2 += Hundreds(theNumber);
                    RemainingNumber = 0;
                }

                //thousands' range
                else if (1000 <= numberToConvert && numberToConvert < 1000000)
                {
                    ChequeNumberWords2 += Thousands(theNumber);
                }

                else // If for some reason the front end validation does not work.
                {
                    ChequeNumberWords2 = "Sorry, please try again with a number in range";
                }
                return ChequeNumberWords2;
            }

            catch (Exception)
            {
                return "Sorry, please try again with a number in range, or reload the page";
            }
           
        }

        public string NumbersCase(int leadingNumberInt)

        {
            string word = "";
            int lengthOfNumber = leadingNumberInt.ToString().Length;

            switch (lengthOfNumber)
            {
                case 1:
                    word = Ones(leadingNumberInt);
                    return word;
                case 2:
                    word = Tens(leadingNumberInt);
                    return word;
                case 3:
                    word = Hundreds(leadingNumberInt);
                    return word;

                default:
                    return word;
            }

        }

        /// <summary>
        /// Converts the cheque number to words.
        /// Used for example when the user inputs a number, the output is written in words.
        /// </summary>
        private string Hundreds(int number)
        {

            try
            {
                int RemainingNum = number;
                int theNumber = number;
                // the base signficant figure amount.
                int groupNumbersize = 100;
                double leadingNumberDec;
                string numberWords = "";


                // Intermediate number that stores the signficant number on the left of the decimal, and the remaining on the right of decimal side.

                leadingNumberDec = (double)theNumber / (double)groupNumbersize;
                // Stores the significant number.
                int leadingNumberInt = (int)Math.Floor(leadingNumberDec);

                RemainingNum = theNumber - (leadingNumberInt * groupNumbersize);

                string andSuffix1;

                if (RemainingNum != 0)
                {
                    andSuffix1 = "And";
                }
                else
                {
                    andSuffix1 = "";
                }

                // convert the significant number to words.
                numberWords = Ones(leadingNumberInt) + " Hundred " + andSuffix1 + " " + Tens(RemainingNum);

                return numberWords;
            }
            catch (Exception)
            {           
                throw new Exception("Error please reload the application");
            }
           
        }

        private string Thousands(int number)
        {
            try
            {
                int RemainingNum = number;
                int theNumber = number;
                // the base signficant figure amount.
                int groupNumbersize = 1000;
                double leadingNumberDec;
                string numberWords = "";


                // Intermediate number that stores the signficant number on the left of the decimal, and the remaining on the right of decimal side.

                leadingNumberDec = (double)theNumber / (double)groupNumbersize;
                // Stores the significant number.
                int leadingNumberInt = (int)Math.Floor(leadingNumberDec);

                RemainingNum = theNumber - (leadingNumberInt * groupNumbersize);


                // convert the significant number to words.
                numberWords = NumbersCase(leadingNumberInt) + " Thousand " + NumbersCase(RemainingNum);

                return numberWords;
            }
            catch (Exception)
            {

                throw new Exception("Error please reload the application");
            }
           
        }

        /// <summary>
        /// Converts the cheque number to words.
        /// Used for example when the user inputs a number, the output is written in words.
        /// </summary>
        private string Tens(int number)
        {
            try
            {
                if (number == 0 || number.ToString().Length != 2) return "";
                int RemainingNum = number;
                string numberWords = "";


                Dictionary<int, string> tensDictionary = new Dictionary<int, string>()
             {
                {10, "Ten" },
                {11, "Eleven" },
                {12, "Twelve" },
                {13, "Thirteen" },
                {14, "Fourteen" },
                {15, "Fifteen" },
                {16, "Sixteen" },
                {17, "Seventeen" },
                {18, "Eighteen" },
                {19, "Nineteen" },
                {20, "Twenty" },
                {30, "Thirty" },
                {40, "Fourty" },
                {50, "Fifty" },
                {60, "Sixty" },
                {70, "Seventy" },
                {80, "Eighty" },
                {90, "Ninety" },
             };

                if (RemainingNum > 19)
                {

                    // the base signficant figure amount.
                    int numberColumn = 10;
                    // Intermediate number that stores the signficant number on the left of the decimal, and the remaining on the right of decimal side.
                    double theNumber = (double)number / (double)numberColumn;
                    // Stores the significant number.
                    int numberInt = (int)Math.Floor(theNumber);
                    // Get the 10's number amount.
                    int upperNumber = numberInt * numberColumn;
                    // Get the single digit amount.
                    int lowerNumber = number - upperNumber;
                    // convert the significant number to words.
                    numberWords = tensDictionary[upperNumber] + " " + Ones(lowerNumber);

                }
                else // Number is <= 19
                {
                    numberWords = tensDictionary[number];
                }

                return numberWords;
            }
            catch (Exception)
            {

                throw new Exception("Error please reload the application");
            }
            
        }

        private string Ones(int number)
        {
            try
            {
                if (number == 0 || number.ToString().Length != 1) return "";

                string numberWord = "";

                Dictionary<int, string> onesDictionary = new Dictionary<int, string>()
            {
                {1, "One" },
                {2, "Two" },
                {3, "Three" },
                {4, "Four" },
                {5, "Five" },
                {6, "Six" },
                {7, "Seven" },
                {8, "Eight" },
                {9, "Nine" },
             };

                numberWord = onesDictionary[number];
                return numberWord;
            }
            catch (Exception)
            {


                throw new Exception("Error please reload the application");
            }
        }
    }

}
