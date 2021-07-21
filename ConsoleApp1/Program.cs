using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    enum TipAnimal { Lup, Urs, Oaie, Veverita, Pisica, Vaca };

    class Program
    {
        static Animal Creeaza (TipAnimal tip, string nume, decimal greutate, Dimensiune dimensiune, decimal viteza)
        {
            Animal animal;
            switch (tip)
            {
                case TipAnimal.Lup:
                case TipAnimal.Pisica:
                    animal = new Carnivor(nume, greutate, dimensiune, viteza);
                    break;
                case TipAnimal.Urs:
                case TipAnimal.Veverita:
                    animal = new Omnivor(nume, greutate, dimensiune, viteza);
                    break;
                case TipAnimal.Vaca:
                case TipAnimal.Oaie:
                    animal = new Erbivor(nume, greutate, dimensiune, viteza);
                    break;
                default:
                    animal = new Omnivor(nume, greutate, dimensiune, viteza);
                    break;
            }

            return animal;

        }
        
        static void xAnimale()
        {

            //setam proprietatile animalelor;

            Dimensiune dimensiune = new Dimensiune { inaltime = 2, latime = 1, lungime = 2 };
            Animal lup = new Carnivor("Bob", 56.33m, dimensiune, 2.4m);

            dimensiune = new Dimensiune { inaltime = 1.22m, latime = 0.34m, lungime = 1.33m };
            Animal oaie = new Erbivor("Mehhh", 31.23m, dimensiune, 2.01m);

            dimensiune = new Dimensiune { inaltime = 2.22m, latime = 1.2m, lungime = 3.04m };
            Animal urs = new Omnivor("Maximus", 323m, dimensiune, 1.55m);

            //setam proprietatile alimentelor

            Mancare salata = new Plante();
            salata.greutate = 0.03m;
            salata.energie = 0.03m;

            Mancare sunca = new Carne();
            sunca.greutate = 0.02m;
            sunca.energie = 0.022m;

            //Hranim animalele
            Console.WriteLine("Lupul: ");
            lup.Mancare(sunca);
            lup.Mancare(sunca);

            Console.WriteLine("Oaia: ");
            oaie.Mancare(salata);
            oaie.Mancare(salata);
            oaie.Mancare(salata);

            Console.WriteLine("Ursul: ");
            urs.Mancare(sunca);
            urs.Mancare(salata);
            urs.Mancare(salata);
            urs.Mancare(salata);

            //Alergam animalele

            lup.Alerga(200);
            oaie.Alerga(200);
            urs.Alerga(200);

            Console.WriteLine(lup);

        }



    static void Main(string[] args)
        {
             //xAnimale(); //Prima functie


            Dimensiune dimensiune;
            decimal greutate, viteza;

            //Initializam salata
            Mancare salata = new Plante();
            salata.energie = 0.01m;
            salata.greutate = 0.5m;
            int nrSalate=0;

             //Initializam Peste;e
            Mancare peste = new Carne();
            peste.energie = 0.05m;
            peste.greutate = 0.9m;
            int nrPesti=0;

            //Cream lista
            Animal animal;
            List<Animal> ferma = new List<Animal>();


            for (int i=0;i<10;i++)
            {
                //Generam valori random ale animalului
                TipAnimal tip = (TipAnimal)(new Random()).Next(0, 6);
                var rand = new Random();
                greutate = Convert.ToDecimal(rand.NextDouble() * 200);
                dimensiune.latime = Convert.ToDecimal(rand.NextDouble());
                dimensiune.lungime = Convert.ToDecimal(rand.NextDouble() * 3);
                dimensiune.inaltime = Convert.ToDecimal(rand.NextDouble());
                viteza = Convert.ToDecimal(rand.NextDouble() * 16);

                //Creeaza animal
                animal = Creeaza(tip, "Animal", greutate, dimensiune, viteza);

                Console.WriteLine("\n" + Convert.ToString(tip) + "\n" + animal);

                //Hranim animalul si tinem evidenta la ce mananca
                if (typeof(Carnivor).IsInstanceOfType(animal))
                {
                    animal.Mancare(peste);
                    nrPesti++;
                }
                else if (typeof(Erbivor).IsInstanceOfType(animal))
                {
                    animal.Mancare(salata);
                    nrSalate++;
                }
                else
                {
                    animal.Mancare(peste);
                    animal.Mancare(salata);
                    nrSalate++;
                    nrPesti++;

                } 

                Console.WriteLine( "\n" + Convert.ToString(tip) + "\n" + animal );
            }

            Console.WriteLine("\nI.   10 animale mananca mancare\nII.  " + nrPesti + " animale mananca carne\nIII. " + nrSalate + " animale mananca plante");

            Console.ReadLine();
        }

        

    }

}
