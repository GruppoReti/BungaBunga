using System;

namespace BungaBunga
{
    public class Persona : IEquatable<Persona>
    {
    
        //PROPRIETA'

        public string nome
        {
            get; protected set;
        }

        public char sesso
        {
            get; protected set;
        }

        public int denaro
        {
            get; protected set;
        }

        public int età
        {
            get; protected set;
        }

        public int altezza
        {
            get; protected set;
        }

        public int peso
        {
            get; protected set;
        }

        public float colorecapelli
        {
            get; protected set;
        }

        public float costituzione
        {
            get; protected set;
        }

        public string presenze
        {
            get; protected set;
        }

        // METODI

        public bool Equals(Persona other)
        {
            if (other == null)
                return false;

            if (nome == other.nome && sesso == other.sesso && denaro == other.denaro && età == other.età && altezza == other.altezza && peso == other.peso && colorecapelli == other.colorecapelli && costituzione == other.costituzione && presenze == other.presenze)
                return true;
            else
                return false;
        }


    }
}
