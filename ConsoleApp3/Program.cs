// Partie 1 : Initialisation et saisie
int nbre;
bool rep = false;

Console.WriteLine("Ce programme nous permet de faire la table de multiplication");

do
{
    Console.WriteLine("Donner un nombre");
    nbre = int.Parse(Console.ReadLine());
    // Partie 2 : Affichage de la table
    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine($"{nbre} * {i} = {nbre * i}");
    }
