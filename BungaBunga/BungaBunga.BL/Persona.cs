using System;
using System.Linq;
using System.Globalization;

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

        public static bool VerificaPersona(string nome, char sesso, int denaro, int età, int altezza, int peso, float colorecapelli, float costituzione, string presenze)
        {
            string[] simbolinonpermessi = { ",", ";", "-", "_", "!", "?", "£", "$", "%", "&", "/", "(", ")", "=", "^", "[", "]", "{", "}", "#", "§", "@", ".", ":" };
            string[] sessi = { "M", "F" };
            string giornisettimana = "LMEGVSD";

            // check nome

            for (int i = 0; i < simbolinonpermessi.Length; i++)
            {
                if (!(nome.IndexOf(simbolinonpermessi[i]) == -1))
                {
                    Console.WriteLine("Il campo \"nome\" contiene il simbolo non permesso {0}", simbolinonpermessi[i]);
                    return false;
                }
            }

            // check sesso

            if (!(sesso == 'M' || sesso == 'F'))
            {
                Console.WriteLine("Il campo \"sesso\" inserito è errato");
                return false;
            }

            // check età

            if (età < 17 || età > 24)
            {
                Console.WriteLine("Il campo \"età\" inserito {0} non rispetta i limiti imposti (17 - 24 anni)", età);
                return false;
            }

            // check altezza

            if (altezza < 100 || altezza > 220)
            {
                Console.WriteLine("Il campo \"altezza\" inserito {0} non è in cm", altezza);
                return false;
            }


            // check peso

            if (peso < 10 || peso > 500)
            {
                Console.WriteLine("Il campo \"peso\" inserito {0} non è in kg", peso);
                return false;
            }

            // check colore capelli

            if (colorecapelli < 0.0 || colorecapelli > 1.0)
            {
                Console.WriteLine("Il campo \"colorecapelli\" {0} non rispetta i limiti imposti (0.0 - 1.0)", colorecapelli);
                return false;
            }

            //check costituzione

            if (costituzione < 0.0 || costituzione > 1.0)
            {
                Console.WriteLine("Il campo \"costituzione\" {0} non rispetta i limiti imposti (0.0 - 1.0)", costituzione);
                return false;
            }

            //check giorni settimana

            for (int i = 0; i < presenze.Length; i++)
            {
                if (!giornisettimana.Contains(presenze[i]))
                {
                    Console.WriteLine("Il campo \"presenze\" contiene il carattere errato: {0}", presenze[i]);
                    return false;
                }
            }

            return true;

        }


    }
}
