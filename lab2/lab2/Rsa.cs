using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
   class Rsa
   {
      public Dictionary<string, List<Int64>> GenKeys(Int64 p, Int64 q)
      {
         // step 1
         if (!isPrime(p) || !isPrime(q))
            throw new Exception("Number(s) is not prime");

         var keys = new Dictionary<string, List<Int64>>();

         //step 2
         Int64 n = p * q;

         //step 3
         Int64 lambda = Lcm(p - 1, q - 1);

         //step 4, 5
         Int64 e = 0;
         Int64 d = 0;
         bool flag = true;
         Dictionary<string, Int64> eucklid_ifno;
         for (Int64 i = 3; i<lambda && flag; i+=2)
         {
            eucklid_ifno = GcdEx(i, lambda);
            if (isPrime(i) && eucklid_ifno["gcd"] == 1)
            {
               e = i;
               d = eucklid_ifno["x"];
               flag = false;
            }
         }
         if (flag)
            throw new Exception("Programm can't find e");
         

         keys.Add("publlic", new List<Int64>(){n, e});
         keys.Add("private", new List<Int64>() { n, d });
         return keys;
      }

      public Int64 Lcm(Int64 a, Int64 b)
      {
         var tmp = GcdEx(a, b)["gcd"];
         return (a * b) / GcdEx(a, b)["gcd"];
      }

      public Dictionary<string, Int64> GcdEx(Int64 a, Int64 b)
      {
         var res = new Dictionary<string, Int64>();
         if(a==0)
            return new Dictionary<string, Int64>(){
               { "gcd", b },
               { "x", 0 },
               { "y", 1 }
            };

         var tmpDict = GcdEx(b % a, a);
         res.Add("x", tmpDict["y"] - (b / a) * tmpDict["x"]);
         res.Add("y", tmpDict["x"]);
         res.Add("gcd", tmpDict["gcd"]);
         return res;
      }

      public static bool isPrime(Int64 a)
      {
         Int64 sqrta = (Int64)Math.Ceiling(Math.Sqrt(a));
         for (Int64 i = 2; i <= sqrta; i++)
            if (a % i == 0)
               return false;
         return true;
      }
   }
}
