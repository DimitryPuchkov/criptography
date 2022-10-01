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
            rsa.GenKeys(p, q);
         }
         catch(Exception e)
         {
            Console.WriteLine(e);
         }
         

      }
   }
}
