using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class UserInterface : VendingMachine
    {
        public static Products ProductsInfo = new Products();
        public static IVending Vending = new VendingMachine();
        public static bool dinsert { get; private set; }

        public static void Menu()
        {
            Console.Clear();

            dinsert = true;

            do
            {
                Console.Clear();
                Console.WriteLine("MENU\n\n");
                ProductsInfo.Examine();
                Console.WriteLine("Money in the money pool: {0}", MoneyPool);
                Console.Write("\n(i): Insert Money - (s): Show all purchases - (e): End Transaction/Exit\n");
                Console.Write("\nChoose: ");

                string inputText = Console.ReadLine();
                int action;
                if (inputText == "i")
                { action = 10; }
                else if (inputText == "s")
                { action = 20; }
                else if (inputText == "e")
                { action = 30; }
                else
                {
                    dinsert = int.TryParse(inputText, out action);
                }
                    switch (action)
                    {
                        case 10:
                            VendingMachine.MoneyPool = Vending.InsertMoney(); // Insert money
                            break;
                        case 20:
                            Vending.ShowAll(); // Show all procucts in cart
                            break;
                        case 30:
                            Vending.EndTransaction(); // Recieve change and exit
                            dinsert = false;
                            break;
                        case 1:
                            Choice = Inventory.Trocadero;
                            Vending.Purchase(Choice);
                            break;
                        case 2:
                            Choice = Inventory.AppleMust;
                            Vending.Purchase(Choice);
                            break;
                        case 3:
                            Choice = Inventory.RoastedNuts;
                            Vending.Purchase(Choice);
                            break;
                        case 4:
                            Choice = Inventory.Chips;
                            Vending.Purchase(Choice);
                            break;
                        case 5:
                            Choice = Inventory.Snickers;
                            Vending.Purchase(Choice);
                            break;
                        case 6:
                            Choice = Inventory.HealthyBar;
                            Vending.Purchase(Choice);
                            break;

                    default:
                            dinsert = true;
                            break;
                    }
                
            } while (dinsert);

        }

    }

}
