/*  Password hashing using PBKDF2 (SHA256 hashing Algorithm)
 *  +Setting iteration time
 *  +Hashing process time tracking
 *  https://github.com/idpNET/PBKDF2_hashing
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PBKDF2_hashing
{
    internal class Program : HashGenerator
    {
        static void Main(string[] args)
        {

            // Getting user password input in plain text for hashsing process
            Console.WriteLine("Please enter a password to hash:");
            var inputPassword = Console.ReadLine();
            Console.WriteLine("");

            
            /*
             * Getting iteration time for hashsing process 
             * (How many times do you need HashAlgorith to run over your password hasing it? 
             * "Reportedly, safe values for production environments are in the hundreds of thousands"
            */
            Console.WriteLine("Please enter iteration time:");
            iterations = int.TryParse(Console.ReadLine(), out iterations) ? iterations : 10000;
            Console.WriteLine("");


            // Tracking hashing process elpased time [Lambda expression]
            var time = HashGenerator.RunTimeMeasurement(() =>
            {
                // Calling HashIT to hash the input password
                var hash = HashIt(inputPassword="default", out var salt);
                Console.WriteLine("Entered password is: " + inputPassword);
                Console.WriteLine($"Password hash is : {hash}");
                Console.WriteLine("");
                Console.WriteLine($"Generated salt is : {Convert.ToHexString(salt)}");

            });

            // Results
            Console.WriteLine("");
            Console.WriteLine("** Hashing process took " + time + " with " + iterations + " times of iteration");


        }
    }
}