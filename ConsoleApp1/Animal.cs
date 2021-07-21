using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    struct Dimensiune
    {

        public decimal lungime;
        public decimal latime;
        public decimal inaltime;

    }

    abstract class Animal
    {

        public string nume;
        protected decimal greutate;
        protected Dimensiune dimensiune;
        protected decimal viteza;

        protected List<Mancare> stomac = new List<Mancare>();

        protected static int contor=0;

        public Animal() { }

        public Animal(string Nume, decimal Greutate, Dimensiune Dim, decimal Viteza)
        {

            nume = Nume;
            greutate = Greutate;
            dimensiune = Dim;
            viteza = Viteza;
            contor++;
        }

        public decimal Greutate
        {
            get
            {
                return greutate;
            }
        }
        public Dimensiune Dim
        {
            get
            {
                return dimensiune;
            }
        }
        public decimal Viteza
        {
            get
            {
                return viteza;
            }
        }


        public abstract void Mancare(Mancare m);

        public abstract decimal Energie();

        public override string ToString()
        {
            return "I.    Tip animal: " + this.GetType().Name +
                "\nII.   Nume: " + nume +
                "\nIII.  Greutate: " + greutate + "kg" +
                "\nIV.   Dimensiuni: " + dimensiune.lungime + "x" + dimensiune.latime + "x" + dimensiune.inaltime + "m" +
                "\nV.    Viteza: " + viteza + "m/s";
        }

        public void Alerga(decimal distanta)
        {

            decimal timp;
            timp = distanta / (viteza / Energie());
            Console.WriteLine("distanta " + distanta + "m a fost parcursa in " + timp + " secunde");

        }

    }
}
