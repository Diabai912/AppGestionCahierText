

using System;
/// <summary>
/// Programme pour afficher les informations d'un utlisateur
/// </summary>
class Program
{
    static void Main(string[] args)
     {
        Console.WriteLine("Prénom : ");
        string prenom = Console.ReadLine();
        Console.WriteLine("Nom : ");
        string nom = Console.ReadLine();
        Console.WriteLine("Email : ");
        string email = Console.ReadLine();
        Console.Write(" Bonjour {0} {1}, votre email est {2}", prenom, nom, email);
    } 
}