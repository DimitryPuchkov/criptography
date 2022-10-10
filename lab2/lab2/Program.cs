using System;
using System.Collections.Generic;

namespace lab2
{
   class Program
   {
      static void Help()
      {
         Console.WriteLine("Simple RSA usage:");
         Console.WriteLine("gen - generate key pair");
         Console.WriteLine("enc - encode number");
         Console.WriteLine("dec - decode number");
         Console.WriteLine("quit - exit from programm\n");
      }
      
      static void GenKeys(Rsa rsa)
      {
         Int64 p, q;
         Console.WriteLine("Input p:");
         p = Int64.Parse(Console.ReadLine());
         Console.WriteLine("Input q:");
         q = Int64.Parse(Console.ReadLine());
         try
         {
            var keys = rsa.GenKeys(p, q);
            Console.WriteLine("Public Key:");
            Console.WriteLine($"n: {keys["public"][0]}");
            Console.WriteLine($"e: {keys["public"][1]}");
            Console.WriteLine("\nPrivate Key:");
            Console.WriteLine($"n: {keys["private"][0]}");
            Console.WriteLine($"d: {keys["private"][1]}");
         }
         catch (Exception err)
         {
            Console.WriteLine(err);
         }
      }

      static void Encode(Rsa rsa)
      {
         Int64 n, e, M;
         Console.WriteLine("Input Public key");
         Console.WriteLine("Input n:");
         n = Int64.Parse(Console.ReadLine());
         Console.WriteLine("Input e:");
         e = Int64.Parse(Console.ReadLine());
         Console.WriteLine("Input number for encode:");
         M = Int64.Parse(Console.ReadLine());
         try
         {
            var C = rsa.Encode(M, new List<Int64>() { n, e });
            Console.WriteLine("Encoded number:");
            Console.WriteLine(C.ToString());
         }
         catch (Exception err)
         {
            Console.WriteLine(err);
         }
      }

      static void Decode(Rsa rsa)
      {
         Int64 d, n, C;
         Console.WriteLine("Input Private key");
         Console.WriteLine("Input n:");
         n = Int64.Parse(Console.ReadLine());
         Console.WriteLine("Input d:");
         d = Int64.Parse(Console.ReadLine());
         Console.WriteLine("Input number for decode:");
         C = Int64.Parse(Console.ReadLine());
         try
         {
            var M = rsa.Decode(C, new List<Int64>() { n, d });
            Console.WriteLine("Decoded number:");
            Console.WriteLine(M.ToString());
         }
         catch (Exception err)
         {
            Console.WriteLine(err);
         }
      }

      static void Main(string[] args)
      {
         Help();
         string command = "";
         var rsa = new Rsa();
         while(command != "quit")
         {
            Console.Write(">");
            command = Console.ReadLine();
            switch(command)
            {
               case "gen": GenKeys(rsa);  break;
               case "enc": Encode(rsa); break;
               case "dec": Decode(rsa); break;
               case "help": Help(); break;
               case "quit": break;
               default: Console.WriteLine("Uncorrect command"); break;
            }
         }
         

      }
   }
}
