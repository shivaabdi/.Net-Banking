using System;
using System.Collections.Generic;
using System.Text;


namespace Bank_konto
{
    class UserIdentification
    {
        private List<KontoInfo> kontos;
       public UserIdentification(ref List<KontoInfo> accounts)
        {
            this.kontos = accounts;
        }

        public KontoInfo UserLigitation()
        {
            string cardNumber;
            string password;
            Console.WriteLine("----------------------------");
            Console.WriteLine("Enter your Card Numebr:");
            cardNumber=Console.ReadLine();
            Console.WriteLine("Enter your Password:");
            password=Console.ReadLine();
            return Login(cardNumber,password);
        }



        private KontoInfo Login(string cardNo,string password)
        {
            


                foreach (KontoInfo konto in kontos)
                {
               
                    if (konto.CardNo == cardNo && konto.Password == password)
                    {
                        return konto;
                        //ChooseTask choice = new ChooseTask();
                        //choice.ChooseAnOption(konto,kontos);
                        //break;
                    }
                    else if (konto.CardNo == cardNo && konto.Password != password)
                    {
                        Console.WriteLine("wrong password");
                         //UserLigitation();
                        break;
                    }

                }


            return null;
        }
        private void CreateAcount(string cardNo,string password)
        {
            
            int balance = 0;
            KontoInfo konto = new KontoInfo(cardNo, password, balance);
            kontos.Add(konto);
            foreach(KontoInfo k in kontos)
            {
                Console.WriteLine(k.CardNo+"******"+ k.Balance);
            }
        }
        public void CreateAcountList()
        {
            int stop = 0;
            string cardNo = "";
            string password = "";
            int balance = 0;
            Console.WriteLine("Enter -1 to go back to LogIn and 0 to continues");
            stop=Convert.ToInt32(Console.ReadLine());
            while(stop!=-1)
            {
                Console.WriteLine("cardNo:");
                cardNo=Console.ReadLine();
                Console.WriteLine("password:");
                password=Console.ReadLine();
                Console.WriteLine("Balance:");
                balance=Convert.ToInt32(Console.ReadLine());
                KontoInfo konto = new KontoInfo(cardNo, password, balance);
                kontos.Add(konto);
                Console.WriteLine("Enter -1 to go back to LogIn and 0 to continues");
                stop = Convert.ToInt32(Console.ReadLine());
            }
           
        }

    }
}
