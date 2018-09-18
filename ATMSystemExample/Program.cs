using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystemExample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region GOLBAL VARIABLE DECLARATION

            char restartProgram;
            int[] noteArr = { 500, 100, 50, 10, 5 };

            #endregion

            do
            {
                #region VARIABLE DECLARATION

                long amount = 0;
                bool isValidAmount = false;
                StringBuilder amountFormat = new StringBuilder();
                long amountMod = 0;
                long inputAmountForPrint = 0;

                #endregion

                #region WRITE TEXT ON CONSOLE

                Console.Clear();
                Console.WriteLine(Environment.NewLine + "Welcome to ATM." + Environment.NewLine); 

                #endregion

                #region ASKING AMOUNT FROM USER TO WITHDRAWAL

                Console.Write("Please enter Amount to withdrawal: ");
                try
                {
                    long.TryParse(Convert.ToString(Console.ReadLine()), out amount);
                    inputAmountForPrint = amount;
                }
                catch { amount = 0; }


                #endregion

                #region CORE LOGIC

                isValidAmount = amount > 0 && (Convert.ToInt64(amount % 10) % noteArr.Last()) == 0;

                if (isValidAmount)
                {
                    foreach (var item in noteArr)
                    {
                        amountMod = Convert.ToInt64((amount / item) % item);

                        if (amountMod > 0)
                            amountFormat.AppendLine(item + " * " + amountMod);

                        amount = amount % item;
                    }
                }

                #endregion

                #region OUTPUT PRINTING ONLY

                Console.WriteLine(Environment.NewLine + "-------------------------------------");
                Console.WriteLine("Program Output - Amount: " + inputAmountForPrint);
                Console.WriteLine("-------------------------------------");
                Console.WriteLine(Environment.NewLine);

                if (isValidAmount)
                    Console.WriteLine(amountFormat);
                else
                    Console.WriteLine("Invalid Amount :(");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("-------------------------------------" + Environment.NewLine);
                Console.ReadKey();
                Console.Clear(); 

                #endregion

                #region RESUME PROGRAM

                Console.Write("Do you want to continue banking (Y/N)? ");
                char.TryParse(Convert.ToString(Console.ReadLine()), out restartProgram); 
                
                #endregion

            } while (restartProgram.Equals('y') || restartProgram.Equals('Y'));

        }
    }
}
