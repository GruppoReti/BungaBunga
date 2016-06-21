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

            if (nome == other.nome && sesso==other.sesso && denaro==other.denaro && età==other.età && altezza==other.altezza && peso==other.peso && colorecapelli==other.colorecapelli && costituzione==other.costituzione && presenze==other.presenze)
                return true;
            else
                return false;
        }

        public string GetNome()
        {
            return nome;
        }

        public char GetSesso()
        {
            return sesso;
        }
        public int GetDenaro()
        {
            return denaro;
        }
        public int GetEtà()
        {
            return età;
        }
        public int GetAltezza()
        {
            return altezza;
        }

        public int GetPeso()
        {
            return peso;
        }

        public float GetColoreCapelli()
        {
            return colorecapelli;
        }

        public float GetCostituzione()
        {
            return costituzione;
        }
        public string GetPresenze()
        {
            return presenze;
        }
    

        //PROPRIETA'
        /*
                public string Nome
                {
                   get;
                   set { Nome = value; }
                }
                */
    }


}
