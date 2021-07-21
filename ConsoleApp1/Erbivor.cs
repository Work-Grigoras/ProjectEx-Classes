using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Erbivor : Animal
    {
        public Erbivor() { }
        public Erbivor(string nume, decimal greutate, Dimensiune dimensiune, decimal viteza) : base(nume, greutate, dimensiune, viteza)
        {

            this.nume = nume;
            this.greutate = greutate;
            this.dimensiune = dimensiune;
            this.viteza = viteza;
            contor++;

        }

        public override void Mancare(Mancare m)
        {

            if (m.greutate <= greutate / 8 && typeof(Plante).IsInstanceOfType(m))
            {

                stomac.Add(new Plante() { greutate = m.greutate, energie = m.energie });

                Console.WriteLine("Mananca plante: " + m.greutate + "g cu valoarea energetica " + m.energie);
            }

            if (!typeof(Plante).IsInstanceOfType(m))
                Console.WriteLine("Meehhhhh.......Nu-mi place!");

        }

        public override decimal Energie()
        {
            decimal eng;
            decimal sumEng = 0;
            decimal sumGre = 0;
            foreach (Mancare m in stomac)
            {
                sumEng = sumEng + m.energie;
                sumGre = sumGre + m.greutate;
            }

            Console.WriteLine("Suma eng = " + sumEng);
            Console.WriteLine("Suma greutate = " + sumGre);

            eng = 0.5m + (1/3m * (sumGre / stomac.Count)) + sumEng;
            Console.WriteLine("Nivelul de energie este de: " + eng * 100m + "%");

            return eng;

        }

    }
}
