#pragma checksum "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\Pages\Counter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2dc7e8b7a9e0c6b87319825cdc59a37fd711a216"
// <auto-generated/>
#pragma warning disable 1591
namespace ChequeWriterApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\_Imports.razor"
using ChequeWriterApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\_Imports.razor"
using ChequeWriterApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\_Imports.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/counter")]
    public partial class Counter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Counter</h1>\r\n\r\n");
            __builder.OpenElement(1, "p");
            __builder.AddContent(2, "Number: ");
            __builder.AddContent(3, 
#nullable restore
#line 5 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\Pages\Counter.razor"
            chequeNumber

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n");
            __builder.OpenElement(5, "p");
            __builder.AddContent(6, "Words: ");
            __builder.AddContent(7, 
#nullable restore
#line 6 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\Pages\Counter.razor"
           ChequeNumberWords

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n\r\n");
            __builder.OpenElement(9, "button");
            __builder.AddAttribute(10, "class", "btn btn-primary");
            __builder.AddAttribute(11, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\Pages\Counter.razor"
                                          ChequeNumberToWords

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(12, "Click me");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 10 "C:\Users\ockenden\ChequeWriterApplication\ChequeWriterApp\ChequeWriterApp\Pages\Counter.razor"
       
    private double chequeNumber = 9960000.52;
    // Holds the pre decimal number part of the cheque number.
    private int chequeNumberIntPart;
    // Holds the post decimal number part of the cheque number.
    private int chequeNumberFracPart;
    private int ChequeNumberLength { get; set; }
    private string ChequeNumberWords;
    private int RemainingNumber { get; set; }

    public void ChequeNumberToWords()
    {
        // Set chequeNumberIntPart and chequeNumberFracPart by splitting the cheque number variable at the decimal point.
        string s = chequeNumber.ToString("0.00", CultureInfo.InvariantCulture);
        string[] parts = s.Split('.');
        chequeNumberIntPart = int.Parse(parts[0]);
        chequeNumberFracPart = int.Parse(parts[1]);

        if (chequeNumberIntPart != 0)
        {
            if (chequeNumberIntPart < 0)
            {
                ChequeNumberWords += " Negative";
                chequeNumberIntPart = Math.Abs(chequeNumberIntPart);
            }

            ChequeNumberWords += WordReturn(chequeNumberIntPart, "");

            // Add dollars suffix and deal with the plural wording.
            if (ChequeNumberWords == "One")
            {
                ChequeNumberWords += " Dollar";
            }
            else
            {
                ChequeNumberWords += " Dollars";
            }
        }

        if (chequeNumberFracPart != 0 && chequeNumberIntPart != 0)
        {
            ChequeNumberWords += " And ";
            ChequeNumberWords += WordReturn(chequeNumberFracPart, "");
            ChequeNumberWords += " Cents";
        }

        if (chequeNumberFracPart != 0 && chequeNumberIntPart == 0)
        {
            ChequeNumberWords += WordReturn(chequeNumberFracPart, "");
            ChequeNumberWords += " Cents";
        }

    }

    //private string NumberToWordsconvert(int number)
    //{
    //    var NumberWords = "";
    //    RemainingNumber = number;
    //    ChequeNumberLength = RemainingNumber.ToString().Length;

    //    while (ChequeNumberLength > 0 && RemainingNumber > 0)
    //    {
    //        NumberWords += WordReturn(RemainingNumber);
    //        ChequeNumberLength = RemainingNumber.ToString().Length;
    //    };

    //    return NumberWords;
    //}

    public string WordReturn(int number, string word) {



        var numberWords = word;
        // the base signficant figure amount.

        // the base signficant figure amount.
        int numberColumn;
        // Intermediate number that stores the signficant number on the left of the decimal, and the remaining on the right of decimal side.
        double theNumber;
        // Stores the significant number.
        int numberInt;

        ChequeNumberLength = number.ToString().Length;

        switch (ChequeNumberLength)
        {

            case 1: //ones' range    

                numberWords = Ones(number);
                RemainingNumber = 0;
                return numberWords;

            case 2: //tens' range    
                numberWords = Tens(number);
                RemainingNumber = 0;
                return numberWords;

            case 3: //hundreds' range                               
                // the base signficant figure amount.
                numberColumn = 100;
                // Intermediate number that stores the signficant number on the left of the decimal, and the remaining on the right of decimal side.
                theNumber = (double)number / (double)numberColumn;
                // Stores the significant number.
                numberInt = (int)Math.Floor(theNumber);
                // convert the significant number to words.
                numberWords = WordReturn(numberInt, numberWords) + " " + "Hundred ";
                // Take away the numbers that have been converted to words and store the remaining number.
                RemainingNumber = number - (numberInt * numberColumn);
                while (RemainingNumber > 0)
                {
                    numberWords = WordReturn(RemainingNumber, numberWords);
                }
                return numberWords;


            case 4: //thousands' range (1000)
                    // the base signficant figure amount.
                numberColumn = 1000;
                // Intermediate number that stores the signficant number on the left of the decimal, and the remaining on the right of decimal side.
                theNumber = (double)number / (double)numberColumn;
                // Stores the significant number.
                numberInt = (int)Math.Floor(theNumber);
                // convert the significant number to words.
                numberWords = WordReturn(numberInt, numberWords) + " " + "Thousand ";
                // Take away the numbers that have been converted to words and store the remaining number.
                RemainingNumber = number - (numberInt * numberColumn);
                while (RemainingNumber > 0)
                {
                    numberWords = WordReturn(RemainingNumber, numberWords);
                }
                return numberWords;

            case 5: //thousands' range (10000)
                    // the base signficant figure amount.
                numberColumn = 1000;
                // Intermediate number that stores the signficant number on the left of the decimal, and the remaining on the right of decimal side.
                theNumber = (double)number / (double)numberColumn;
                // Stores the significant number.
                numberInt = (int)Math.Floor(theNumber);
                // convert the significant number to words.
                numberWords = WordReturn(numberInt, numberWords) + " " + "Thousand ";
                // Take away the numbers that have been converted to words and store the remaining number.
                RemainingNumber = number - (numberInt * numberColumn);
                while (RemainingNumber > 0)
                {
                    numberWords = WordReturn(RemainingNumber, numberWords);
                }
                return numberWords;

            case 6: //thousands' range (100000)
                    // the base signficant figure amount.
                numberColumn = 1000;
                // Intermediate number that stores the signficant number on the left of the decimal, and the remaining on the right of decimal side.
                theNumber = (double)number / (double)numberColumn;
                // Stores the significant number.
                numberInt = (int)Math.Floor(theNumber);
                // convert the significant number to words.
                numberWords = WordReturn(numberInt, numberWords) + " " + "Thousand ";
                // Take away the numbers that have been converted to words and store the remaining number.
                RemainingNumber = number - (numberInt * numberColumn);
                while (RemainingNumber > 0)
                {
                    numberWords = WordReturn(RemainingNumber, numberWords);
                }
                return numberWords;

            case 7: //millions' range (1000000)
                    // the base signficant figure amount.
                numberColumn = 1000000;
                // Intermediate number that stores the signficant number on the left of the decimal, and the remaining on the right of decimal side.
                theNumber = (double)number / (double)numberColumn;
                // Stores the significant number.
                numberInt = (int)Math.Floor(theNumber);
                // convert the significant number to words.
                numberWords = WordReturn(numberInt, numberWords) + " " + "Million ";
                // Take away the numbers that have been converted to words and store the remaining number.
                RemainingNumber = number - (numberInt * numberColumn);
                while (RemainingNumber > 0)
                {
                    numberWords = WordReturn(RemainingNumber, numberWords);
                }
                return numberWords;

            default:
                return numberWords;
        }
    }

    /// <summary>
    /// Converts the cheque number to words.
    /// Used for example when the user inputs a number, the output is written in words.
    /// </summary>
    private string Tens(int number)
    {

        RemainingNumber = number;
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

        if (RemainingNumber > 19)
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

    private string Ones(int number)
    {
        if (number.ToString().Length != 1) return "";

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

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
