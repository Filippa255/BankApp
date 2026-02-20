using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Text.Json;
using System.IO;

class Program 
{
        static List<User> users = new List<User>();
        static int nextID = 1;
    static void Main()
    {

        LoadUsersFromFile();

        bool running = true; //loopar tills användaren avslutar

        while (running)
        {

            Console.WriteLine("Välkommen till MinBank!");
            Console.WriteLine("Välj vad du vill göra:");
            Console.WriteLine("1. Skapa ett nyt konto");
            Console.WriteLine("2. Logga in");
            Console.WriteLine("3. Avsluta");
            Console.WriteLine("4. Se alla användaren"); //tillfällig

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

                case "4":
                    ShowAllUsers(); 
                    break;

                default:
                Console.WriteLine("Ogiltigt val, försök igen.");
                break;

            }

        }

     }

    static void CreateAccount()
    {
        

        Console.WriteLine("Skapa Konto:");

        Console.WriteLine("Förnamn: ");
        var first = Console.ReadLine();

        Console.WriteLine("Efternamn: ");
        var last = Console.ReadLine();

        Console.WriteLine("Lösenord: ");
        var pass = Console.ReadLine();

        User newUser = new User(nextID, first, last, pass);
        users.Add(newUser);
        nextID++;

        SaveUsersToFile();


        Console.WriteLine("Tryck enter för att komma tillbaka till startsidan: ");
        Console.ReadLine();
    }

    static void Login()
    {
        Console.WriteLine("Logga in: ");

        Console.WriteLine("Förnamn: ");
        var first = Console.ReadLine();

        Console.WriteLine("Lösenord: ");
        var pass = Console.ReadLine();

        User foundUser = users.Find(u => u.Firstname == first &&  u.Password == pass);
        if (foundUser != null)
            Console.WriteLine($"Du är inloggad som {first}");
        else
            Console.WriteLine("Fel namn eller lösenord");



    }
    static void ShowAllUsers()
    {
        if (users.Count == 0)
        {
            Console.WriteLine("Inga användare finns ännu.");
            return;
        }

        Console.WriteLine("Alla användare:");
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.OwnerID}, Namn: {user.Firstname} {user.Lastname}");
        }
        Console.WriteLine("Klicka enter för att komma tillbaka till startsidan: ");
        Console.ReadLine();
    }


    static void SaveUsersToFile()
    {
        string json = JsonSerializer.Serialize(users);
        File.WriteAllText("users.json", json); //sparar i samma mapp som programmet
    }

    static void LoadUsersFromFile()
    {
        if (File.Exists("users.json")) //kollar ifall filen finns
        {
            string json = File.ReadAllText("users.json");
            users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();

            //sätter nextID så att det blir unikt även efter omstartning
            if (users.Count > 0)
                nextID = users[users.Count - 1].OwnerID + 1;
        }
    }
    

}