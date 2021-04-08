using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_konto
{
    class KontoInfo
    {
        public KontoInfo(string cardno,string password,double balance)
        {
            CardNo = cardno;
            Password = password;
            Balance = balance;
             

        }

        public string CardNo { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
    }
}
