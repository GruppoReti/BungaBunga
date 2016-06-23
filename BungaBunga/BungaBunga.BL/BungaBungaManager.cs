using System;
using System.Collections.Generic;
using System.Linq;

namespace BungaBunga.BL
{
    public class BungaBungaManager
    {

        // DICHIARAZIONE LISTE

        public static List<Politico> ListaPolitici { get; protected set; } = new List<Politico>();
        public static List<Escort> ListaEscort { get; protected set; } = new List<Escort>();
        public static List<Persona> ListaNera { get; protected set; } = new List<Persona>();
        public static List<List<Persona>> ListaDiGruppi { get; protected set; } = new List<List<Persona>>();

        // PROPRIETA'
        /*
        public List<Politico> ListaPolitici2
        {
            get { return ListaPolitici; }
            protected set { ListaPolitici; }
        }*/

        public static int bungabunga(char giorno, int Naccoppiamenti)
        {

            //creiamo, sulla base del giorno in input, le sottoliste di Politici ed Escort che possono partecipare

            List<Politico> SottoListaPolitici = new List<Politico>();
            for (int i = 0; i < ListaPolitici.Count; i++)
            {
                if (ListaPolitici[i].presenze.Contains(giorno.ToString()))
                {
                    SottoListaPolitici.Add(ListaPolitici[i]);
                }
            }
            List<Escort> SottoListaEscort = new List<Escort>();
            for (int i = 0; i < ListaEscort.Count; i++)
            {
                if (ListaEscort[i].presenze.Contains(giorno.ToString()))
                {
                    SottoListaEscort.Add(ListaEscort[i]);
                }
            }


            //verifica dati inseriti

            if (SottoListaPolitici.Count * SottoListaEscort.Count < Naccoppiamenti)
            {
                Naccoppiamenti = SottoListaPolitici.Count * SottoListaEscort.Count;
                if (Naccoppiamenti == 0)
                {
                    return Naccoppiamenti;
                }
            }

            //per ogni possibile coppia Politico-Escort calcoliamo la discrepanza secondo le indicazioni del testo, e generiamo una Tupla <Politico, Escort, float> da inserire nella lista

            List<Tuple<Politico, Escort, float>> ListaDiAffinità = new List<Tuple<Politico, Escort, float>>();

            for (int j = 0; j < SottoListaPolitici.Count; j++)
            {
                for (int i = 0; i < SottoListaEscort.Count; i++)
                {
                    ListaDiAffinità.Add(Tuple.Create(SottoListaPolitici[j], SottoListaEscort[i], CalcolaAffinità(SottoListaPolitici[j], SottoListaEscort[i])));
                }
            }
            //ultimata la generazione della lista, la riordiniamo per discrepanza crescente (così che i primi N elementi siano quelli da considerare)
            List<Tuple<Politico, Escort, float>> ListaDiAffinitàOrdinata = ListaDiAffinità.OrderBy(x => x.Item3).ToList();


            //consideriamo solo gli Naccoppiamenti migliori della lista

            List<Tuple<Politico, Escort>> ListaCoppie = new List<Tuple<Politico, Escort>>();
            for (int i = 0; i < Naccoppiamenti; i++)
            {
                ListaCoppie.Add(Tuple.Create(ListaDiAffinitàOrdinata[i].Item1, ListaDiAffinitàOrdinata[i].Item2));
            }
            //chiamiamo la funzione "GeneraOrgie" per calcolare il numero di gruppetti che si vengono a formare

            List<List<Persona>> ListaDiGruppi = GeneraOrge(ListaCoppie, 0);

            //chiamiamo la funzione "TrovaOrgione" per identificare la stanza con più elementi -> ci restituisce una lista/array di 3 interi che rappresentano l'output richiesto
            TrovaOrgione(ListaDiGruppi);
            return Naccoppiamenti;
        }

        private static float CalcolaAffinità(Politico P, Escort E)  //restituisce il valore di discrepanza tra le preferenze del politico e le caratteristiche della Escort
        {
            float Discrepanza = 0;
            float[] importanza = { (float)0.0009, (float)1.0, (float)0.1, (float)0.15, (float)0.5, (float)2.0 };
            Discrepanza = Math.Abs(P.denaro - E.denaro) * importanza[0] + Math.Abs(P.età - E.età) * importanza[1] + Math.Abs(P.altezza - E.altezza) * importanza[2] + Math.Abs(P.peso - E.peso) * importanza[3] + Math.Abs(P.colorecapelli - E.colorecapelli) * importanza[4] + Math.Abs(P.costituzione - E.costituzione) * importanza[5];
            return Discrepanza;
        }

        private static List<List<Persona>> GeneraOrge(List<Tuple<Politico, Escort>> ListaCoppie, int j)  //funzione che prende in ingresso la lista di coppie che parteciperanno al BungaBunga e restituisce una lista di gruppi [quindi una lista di "liste di persone"(i.e. "gruppi")] che rappresentano le stanze di Villa San Martino
        {
            List<Persona> Gruppo = new List<Persona>();
            Gruppo.Add(ListaCoppie[0].Item1);
            Gruppo.Add(ListaCoppie[0].Item2);
            ListaDiGruppi.Add(Gruppo);
            bool CoppiaAggiunta = true;  //flag per segnalare se almeno una coppia ha trovato la stanza a cui partecipare

            while (CoppiaAggiunta)
            {
                CoppiaAggiunta = false;
                for (int i = 0; i < ListaCoppie.Count(); i++)  //ciclo su ogni elemento della lista di coppie
                {
                    if (ListaDiGruppi[j].Contains(ListaCoppie[i].Item1) && !ListaDiGruppi[j].Contains(ListaCoppie[i].Item2))  //se nel gruppo j-esimo è già presente il politico(della coppia i-esima), ma non la escort (della coppia i-esima) allora la aggiungo al gruppo j-esimo
                    {
                        ListaDiGruppi[j].Add(ListaCoppie[i].Item2); //Escort
                        ListaCoppie.RemoveAt(i);
                        CoppiaAggiunta = true;
                        break;
                    }
                    if (!ListaDiGruppi[j].Contains(ListaCoppie[i].Item1) && ListaDiGruppi[j].Contains(ListaCoppie[i].Item2))  //se nel gruppo j-esimo è già presente l'escort(della coppia i-esima), ma non il politico (della coppia i-esima) allora lo aggiungo al gruppo j-esimo
                    {
                        ListaDiGruppi[j].Add(ListaCoppie[i].Item1); //Politico
                        ListaCoppie.RemoveAt(i);
                        CoppiaAggiunta = true;
                        break;
                    }
                    if (ListaDiGruppi[j].Contains(ListaCoppie[i].Item1) && ListaDiGruppi[j].Contains(ListaCoppie[i].Item2))  //se nel gruppo j-esimo è già presente l'escort(della coppia i-esima), ma non il politico (della coppia i-esima) allora lo aggiungo al gruppo j-esimo
                    {
                        ListaCoppie.RemoveAt(i);
                        CoppiaAggiunta = true;
                        break;
                    }
                }
            }

            /////////////STAMPA GRUPPI PER DEBUG ////////////////////////
            for (int k = 0; k < ListaDiGruppi.Count; k++)
            {
                for (int x = 0; x < ListaDiGruppi[k].Count; x++)
                {
                    Console.Write(" {0}", ListaDiGruppi[k][x].nome);
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------");
            /////////////FINE STAMPA GRUPPI PER DEBUG////////////////////

            if (ListaCoppie.Count == 0) //se la coppia non può partecipare ad una stanza già esistente, creo una nuova stanza con i due elementi della coppia
            {
                return ListaDiGruppi;
            }
            else
            {
                return GeneraOrge(ListaCoppie, j + 1); //genero la nuova stanza
            }

        }

        private static void TrovaOrgione(List<List<Persona>> ListaDiGruppi)
        {
            int NPolitici = 0;
            int NEscort = 0;
            int max = 0;
            int indicemax = 0;
            for (int i = 0; i < ListaDiGruppi.Count; i++)
            {
                if (ListaDiGruppi[i].Count > max)
                {
                    max = ListaDiGruppi[i].Count;
                    indicemax = i;
                    NPolitici = ListaDiGruppi[i].Count(x => x.sesso == 'M');
                    NEscort = max - NPolitici;
                }
            }

            Console.WriteLine("{0} {1} {2}", ListaDiGruppi.Count, NPolitici, NEscort);
        }

    }
}
