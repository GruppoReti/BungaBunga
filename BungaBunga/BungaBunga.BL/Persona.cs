using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungaBunga.BL
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
                   get { return Nome; }
                   set { Nome = value; }
                }
                */
    }


}
