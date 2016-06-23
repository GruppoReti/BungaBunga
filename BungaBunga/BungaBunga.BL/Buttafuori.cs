using System;
using System.Linq;
using System.Globalization;

namespace BungaBunga.BL
{ 
    public class Buttafuori
    {
        public static void verifica_e_introduci(string[] strings)
        {
            string nome = strings[1];
            char sesso = Convert.ToChar(strings[2]);
            int denaro = Convert.ToInt32(strings[3]);
            int eta = Convert.ToInt32(strings[4]);
            int altezza = Convert.ToInt32(strings[5]);
            int peso = Convert.ToInt32(strings[6]);
            float capelli = float.Parse(strings[7], CultureInfo.InvariantCulture.NumberFormat);
            float costituzione = float.Parse(strings[8], CultureInfo.InvariantCulture.NumberFormat);
            string presenze = strings[9];

            if (Persona.VerificaPersona(nome, sesso, denaro, eta, altezza, peso, capelli, costituzione, presenze))
            {
                if (introduci(nome, sesso, denaro, eta, altezza, peso, capelli, costituzione, presenze))
                {
                    Console.WriteLine("{0} è stato introdotto nell'elenco!", nome);
                }
                else
                {
                    Console.WriteLine("{0} è in lista nera!", nome);
                }
            }
        }

        public static bool introduci(string nome, char sesso, int denaro, int età, int altezza, int peso, float colorecapelli, float costituzione, string presenze)
        {
            if (sesso == 'M')
            {

                Politico P = new Politico(nome, sesso, denaro, età, altezza, peso, colorecapelli, costituzione, presenze);
                if (!(BungaBungaManager.ListaNera.Contains(P) || BungaBungaManager.ListaPolitici.Contains(P)))
                {
                    BungaBungaManager.ListaPolitici.Add(P);
                    return true;
                }
                //il politico viene aggiunto nella lista degli invitati solo se non è segnato nella lista nera e non è già stato precedentemente aggiunto nella lista 
            }
            else
            {
                Escort E = new Escort(nome, sesso, denaro, età, altezza, peso, colorecapelli, costituzione, presenze);
                if (!(BungaBungaManager.ListaNera.Contains(E) || BungaBungaManager.ListaEscort.Contains(E)))
                {
                    BungaBungaManager.ListaEscort.Add(E);
                    return true;
                }
            }
            return false; //BUG: non viene mai eseguito il return FALSE! (lista nera)
        }

        public static void estrometti(string nome)
        {
            Persona persona_out = BungaBungaManager.ListaPolitici.SingleOrDefault(x => x.nome == nome);
            if (persona_out == null)
            {
                persona_out = BungaBungaManager.ListaEscort.SingleOrDefault(x => x.nome == nome);
            }

            if (persona_out is Politico)
            {
                BungaBungaManager.ListaPolitici.Remove((Politico)persona_out);
            }
            else
            {
                BungaBungaManager.ListaEscort.Remove((Escort)persona_out);
            }

            BungaBungaManager.ListaNera.Add(persona_out);

            /*
            var politico_estromesso = BungaBungaManager.ListaPolitici.SingleOrDefault(x => x.nome == nome); // controlla se il soggetto è già presente nella lista
            if (politico_estromesso != null)
            {
                BungaBungaManager.ListaPolitici.Remove(politico_estromesso);  // elimina il soggetto dalla lista
                BungaBungaManager.ListaNera.Add(politico_estromesso); //aggiungo il soggetto alla black list

            }

            else
            {
                var escort_estromessa = BungaBungaManager.ListaEscort.SingleOrDefault(x => x.nome == nome);
                if (escort_estromessa != null)
                {
                    BungaBungaManager.ListaEscort.Remove(escort_estromessa);
                    BungaBungaManager.ListaNera.Add(escort_estromessa);
                }

            }
            */

        }
    }
}
