// See https://aka.ms/new-console-template for more information

int age = 0;
bool rep = false;
Console.WriteLine("Ce programme permet de definir votre tranche d'age");
do
{
    //recuperation de l'age
    Console.WriteLine("Donner votre age: ");
    age = int.Parse(Console.ReadLine());
    //recuperation de la tranche d'age
    if (age < 15)
    {
        Console.WriteLine("Vous etes mineur");
    }
    if(age < 35) 
    {
        Console.WriteLine("Vous etes adolescent ");
    }
    else
    {
        Console.WriteLine("Vous etes majeur");
    }
    // Demander si on continue
    Console.WriteLine("Voulez-vous recommencer o/n");
    String reponse = Console.ReadLine();
    rep = (reponse.ToLower() == "o");
}while (rep);