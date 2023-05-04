/*  Password hashing using PBKDF2 (SHA256 hashing Algorithm)

    .PBKDF2 Hashing + SHA256 Hashing Algorithm
    .Strong Salting (an array of bytes with a cryptographically strong sequence of random nonzero values)
    .Customizable Hashing and salting Keys' size + hashing iteration times.
    .Hashing process time tracking.

 *  https://github.com/idpNET/PBKDF2_hashing
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace PBKDF2_hashing
{

    internal class Program : HashGenerator
    {
        #region Class Methods
        static void Main(string[] args)
        {

            // Gets user password input in plain text for hashing process
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter a password to hash:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            var inputPassword = Console.ReadLine();
            Console.WriteLine("");


            /*
             * Gets iteration time for hashing process 
             * (How many times do you need HashAlgorith to run over your password hashing it? 
             * "Reportedly, safe values for production environments are in the hundreds of thousands"
            */
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter iteration time:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Iterations = int.TryParse(Console.ReadLine(), out Iterations) ? Iterations : 10000;
            Console.WriteLine("");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            // Tracks hashing process elapsed time [Lambda expression]
            var Time = HashGenerator.RunTimeMeasurement(() =>
            {
                // Calls HashIT to hash the input password
                var Hash = ComputeBytesHash(inputPassword = "default", out var salt);
                string HashToString = MergeBytesIntoString(Hash);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entered password is: " + inputPassword);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Password hash is : {HashToString}");
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Generated salt is : {Convert.ToHexString(salt)}");

            });

            // Results
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine("[Hashing process took " + Time + " with " + Iterations + " times of iteration]");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }
        #endregion
    }
}