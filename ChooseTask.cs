using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_konto
{
    class ChooseTask
    {
        public int ChooseAnOption(KontoInfo konto)
        {
            Console.WriteLine("##################################");
            Console.WriteLine("1.Balance \n2.Money Transfer \n3.Deposit Money \n 4.Exit");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {

                case 1:
                    Console.WriteLine(konto.Balance);
                    Console.ReadLine();
                    ChooseAnOption(konto);
                    break;
                case 2:
             
                    MoneyTransfer(konto);
                    break;
                case 3:
                    DepositeMoney(konto);
                    break;
                case 4:
                    return 0;
                default:
                    Console.WriteLine("Please select an option");
                    break;
            }
            return 1;
        }

        private void DepositeMoney(KontoInfo konto)
        {
            Console.WriteLine("how much you want to deposite?");
            int amount = Convert.ToInt32(Console.ReadLine());
            konto.Balance = konto.Balance + amount;
            ChooseAnOption(konto);
        }

        private void MoneyTransfer(KontoInfo sender_konto)
        {
            int amount;

        string reciever_cardNumber;
            Console.WriteLine("Amount:");
            amount = Convert.ToInt32(Console.ReadLine());
            
            
            if (amount <= sender_konto.Balance)
            {
                Console.WriteLine("Enter the card number that you want to transfer money :");
                reciever_cardNumber = Console.ReadLine();
                if (sender_konto.CardNo != reciever_cardNumber)
                {

                    foreach (KontoInfo i in Program.kontos)
                    {
                        if (i.CardNo == reciever_cardNumber)
                        {
                            sender_konto.Balance = sender_konto.Balance - amount;
                            i.Balance = i.Balance + amount;
                            
                        }
                    }
                }
                else
                    Console.WriteLine("you enter the wrong card number");
            }
            else
            {
                Console.WriteLine("you dont have enough amount in your account");
                ChooseAnOption(sender_konto);
            }
        }
    }
}
