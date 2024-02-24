using System;

namespace JeuDeMath
{
    internal class Program
    {
            enum EOperateurs
            {
                addition = 1, 
                multiplication = 2, 
                soustraction = 3
            }

        static void Main(string[] args)
        {
            const int NOMBRE_MIN = 1;
            const int NOMBRE_MAX = 20;
            const int NOMBRE_QUESTIONS = 5; 

            int nombreDePoints = 0; 
            int moyenneNombreQuestions = NOMBRE_QUESTIONS / 2; 

            for (int i = 0; i < NOMBRE_QUESTIONS; i++)
            {
                System.Console.WriteLine($"Question n° {i + 1} / {NOMBRE_QUESTIONS}");
                bool bonneReponse = PoserQuestion(NOMBRE_MIN, NOMBRE_MAX);

                if (bonneReponse == true)
                {
                    System.Console.WriteLine("Bravo ! Votre réponse est correcte !");
                    nombreDePoints++; 
                }
                else
                {
                    System.Console.WriteLine("Dommage ! Votre réponse est incorrecte !");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine($"Vous avez un score de {nombreDePoints} / {NOMBRE_QUESTIONS}.");

            if (nombreDePoints == NOMBRE_QUESTIONS)
            {
                System.Console.WriteLine("Excellent");
            }
            else if (nombreDePoints > moyenneNombreQuestions)
            {
                System.Console.WriteLine("Bien");
            }
            else
            {
                System.Console.WriteLine("Reprenez les bases ");
            }
        }

        public static bool PoserQuestion(int min, int max)
        {
            int reponseInt; 
            Random nombreAleatoire = new Random(); 

            int nombre1 = nombreAleatoire.Next(min, max + 1); 
            int nombre2 = nombreAleatoire.Next(min, max + 1); 
            EOperateurs operateurs = (EOperateurs)nombreAleatoire.Next(1, 4);


            while (true)
            {
                if (operateurs == EOperateurs.addition)
                {
                    Console.Write($"{nombre1} + {nombre2} = "); 
                }
                else if (operateurs == EOperateurs.multiplication)
                {
                    Console.Write($"{nombre1} x {nombre2} = ");
                }
                else if (operateurs == EOperateurs.soustraction)
                {
                    Console.Write($"{nombre1} - {nombre2} = "); 
                }
                else
                {
                    System.Console.WriteLine("ERREUR : Opérateur inconnu");
                }

                
                string? reponse = Console.ReadLine();
                try
                {
                    reponseInt = int.Parse(reponse);
                    if ((reponseInt == nombre1 + nombre2) || (reponseInt == nombre1 * nombre2) || (reponseInt == nombre1 - nombre2))
                    {
                        return true;
                    }
                    return false; 

                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Erreur ! Merci de rentrer un nombre !");
                }
            }
        }

    }
}
