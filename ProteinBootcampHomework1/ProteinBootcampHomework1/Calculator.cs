using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProteinBootcampHomework1
{   
     public  class Calculator
     {
        public int id { get; set; }
        public int defferend { get; set; } // vade 
        public int amount { get; set; } // tutar

        public const double interest = 0.3; // faiz sabiti
        public double amountInterest => ((interest * amount *defferend) /100)+amount; // faizi ile birlikte tutar
        public double monthlyPayment =>Math.Round((((interest * amount * defferend) / 100) + amount) / defferend,2);



    }

}
