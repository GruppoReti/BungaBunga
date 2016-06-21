using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungaBunga
{
    public class Persona : IEquatable<Persona>
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

        public bool Equals(Persona other)
        {
            if (other == null)
                return false;

            if (nome == other.nome && sesso == other.sesso && denaro == other.denaro && età == other.età && altezza == other.altezza && peso == other.peso && colorecapelli == other.colorecapelli && costituzione == other.costituzione && presenze == other.presenze)
                return true;
            else
                return false;
        }


        //PROPRIETA'

        public string Nome
        {
            get { return nome; }
        }

        public char Sesso
        {
            get { return sesso; }
        }

        public int Denaro
        {
            get { return denaro; }
        }

        public int Età
        {
            get { return età; }
        }

        public int Altezza
        {
            get { return altezza; }
        }

        public int Peso
        {
            get { return peso; }
        }

        public float ColoreCapelli
        {
            get { return colorecapelli; }
        }

        public float Costituzione
        {
            get { return costituzione; }
        }

        public string Presenze
        {
            get { return presenze; }
        }

    }
}
