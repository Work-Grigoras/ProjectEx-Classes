using Baseline.ImTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Carnivor : Animal
    {
        public Carnivor() { }
        public Carnivor(string nume, decimal greutate, Dimensiune dimensiune, decimal viteza) : base(nume, greutate, dimensiune, viteza)
        {

            this.nume = nume;
            this.greutate = greutate;
            this.dimensiune = dimensiune;
            this.viteza = viteza;
            contor++;

        }

        public override decimal Energie() 
        {
            decimal eng;
            decimal sumEng = 0;
            decimal sumGre = 0;
            foreach(Mancare m in stomac)
            {
                sumEng = sumEng + m.energie;
                sumGre = sumGre + m.greutate;
            }

            Console.WriteLine("Suma eng = " + sumEng);
            Console.WriteLine("Suma greutate = " + sumGre);

            eng = 0.2m - (0.2m * (sumGre / stomac.Count)) + sumEng;
            Console.WriteLine("Nivelul de energie este de: " + eng*100m + "%");

            return eng;

        }

        public override void Mancare(Mancare m)
        {

            if (m.greutate <= greutate / 8 && typeof(Carne).IsInstanceOfType(m)) 
            {

                stomac.Add(new Carne() { greutate = m.greutate, energie = m.energie });

                Console.WriteLine("Mananca carne: " + m.greutate + "g cu valoarea energetica " + m.energie);
            }

            if (!typeof(Carne).IsInstanceOfType(m))
                Console.WriteLine("Meehhhhh.......Nu-mi place!");

        }

    }
}
