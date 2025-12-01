using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    class Program
    {
        static void Main(string[] args)
        {
            byte choix;
            do
            {
                //Different option de calcule
                Console.WriteLine("\nChoisis une opération:");
                Console.WriteLine("1) Addition (+)");
                Console.WriteLine("2) Soustraction (-)");
                Console.WriteLine("3) Multiplication (*)");
                Console.WriteLine("4) Division (/)");
                Console.WriteLine("5) Quitter");
                //Recupere le choix de l'utilisateur
                Console.Write("Votre choix: ");
                choix = byte.Parse(Console.ReadLine());


                switch (choix)
                {
                    case 1:
                        {
                            Console.WriteLine("Choisissez un nombre : ");
                            int x = int.Parse(Console.ReadLine());
                            Console.WriteLine("Choisissez un deuxieme nombre : ");
                            int y = int.Parse(Console.ReadLine());
                            Console.WriteLine("{0} + {1} = {2}", x, y, x + y);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Choisissez un nombre : ");
                            int x = int.Parse(Console.ReadLine());
                            Console.WriteLine("Choisissez un deuxieme nombre : ");
                            int y = int.Parse(Console.ReadLine());
                            Console.WriteLine("{0} - {1} = {2}", x, y, x - y);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Choisissez un nombre : ");
                            int x = int.Parse(Console.ReadLine());
                            Console.WriteLine("Choisissez un deuxieme nombre : ");
                            int y = int.Parse(Console.ReadLine());
                            Console.WriteLine("{0} * {1} = {2}", x, y, x * y);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Choisissez un nombre : ");
                            int x = int.Parse(Console.ReadLine());
                            Console.WriteLine("Choisissez un deuxieme nombre : ");
                            int y = int.Parse(Console.ReadLine());
                            if (y != 0)
                            {
                                Console.WriteLine("{0} / {1} = {2}", x, y, x / y);
                            }
                            else
                            {
                                Console.WriteLine("Erreur: Division par zéro n'est pas permise.");
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Au revoir.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Choix inconnu.");
                            break;
                        }
                }
            } while (choix != 5);
        }
    }
}
