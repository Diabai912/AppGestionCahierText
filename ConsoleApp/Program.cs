using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string choix;
            do
            {
                Console.WriteLine("Prenom : ");
                string prenom = Console.ReadLine();
                Console.WriteLine("Nom : ");
                string nom = Console.ReadLine();
                Console.WriteLine("Email : ");
                string email = Console.ReadLine();

                Console.WriteLine("Bonjour {0} {1}, votre email est {2}", prenom, nom, email);

                Console.WriteLine("voulez-vous recommencer? (o/n) : ");
                choix = Console.ReadLine();
            } while (choix == "o");
        }
    }
}

