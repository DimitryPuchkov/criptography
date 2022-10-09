using System;


namespace lab2
{
   class Program
   {
      
      static void Main(string[] args)
      {
         Int64 p, q;
         var rsa = new Rsa();
         Console.WriteLine("Input p:");
         p = Int64.Parse(Console.ReadLine());
         Console.WriteLine("Input q:");
         q = Int64.Parse(Console.ReadLine());
         try
         {
            var keys = rsa.GenKeys(p, q);
            Int64 M = 123456;
            var C = rsa.Encode(M, keys["public"]);
            var decM = rsa.Decode(C, keys["private"]);
            Console.WriteLine(decM.ToString());
         }
         catch(Exception e)
         {
            Console.WriteLine(e);
         }
         

      }
   }
}
