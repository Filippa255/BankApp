using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel.Design;

class Program 
{
    static void Main()
    {
        // List<User> users = new List<User>();
        // int nextID = 1;

        bool running = true; //loopar tills användaren avslutar

        while (running)
        {

            Console.WriteLine("Välkommen till MinBank!");
            Console.WriteLine("Välj vad du vill göra:");
            Console.WriteLine("1. Skapa ett nyt konto");
            Console.WriteLine("2. Logga in");
            Console.WriteLine("3. Avsluta");

            Console.WriteLine("Välj ett alternativ: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    Console.WriteLine("Avslutar programmet");
                    running = false;
                    break;
                default:
                Console.WriteLine("Ogiltigt val, försök igen.");
                break;
            }

        }

     }


    static void CreateAccount()
    {

        Console.WriteLine("SKAPA KONTO!!!!");
        Console.WriteLine("Namn: ");
        var namn = Console.ReadLine();

        Console.WriteLine("Tryck enter för att komma tillbaka till startsidan: ");
        Console.ReadLine();
    }

    static void Login()
    {
        Console.WriteLine("LOGGA IN!!!");

    }

    

}