using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungaBunga
{
    public class Persona
    {
//ATTRIBUTI
        protected string nome;
        protected char sesso;
        protected int denaro;
        protected int età;
        protected int altezza;
        protected int peso;
        protected float colorecapelli;
        protected float costituzione;
        protected string presenze;

//PROPRIETA'
        public string Name
        {
            get { return nome; }
            set { nome = value; }
        }

        public char Sesso
        {
            get { return sesso; }
            set { sesso = value; }
        }

        public int Denaro
        {
            get { return denaro; }
            set { denaro = value; }
        }

        public int Età
        {
            get { return età; }
            set { età = value; }
        }

        public int Altezza
        {
            get { return altezza; }
            set { altezza = value; }
        }

        public int Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public float Colorecapelli
        {
            get { return colorecapelli; }
            set { colorecapelli = value; }
        }

        public float Costituzione
        {
            get { return costituzione; }
            set { costituzione = value; }
        }

        public string Presenze
        {
            get { return presenze; }
            set { presenze = value; }
        }

    }

    
}
