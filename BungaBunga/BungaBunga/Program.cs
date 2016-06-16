using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungaBunga
{
    class Program : Iestrometti, Ibungabunga, Iintroduci
    {
        private List<Politico> ListaPolitici = new List<Politico>();
        private List<Escort> ListaEscort = new List<Escort>();

        static void Main(string[] args)
        {   
            //test GeneraOrgie
            Program pg = new Program();
            Politico P = new Politico("berlusconi",'M',10000, 17, 170, 60,(float)0.5,(float)0.5, "E");
            Escort E = new Escort("Ruby", 'F', 10000, 17, 170, 60, (float)0.5, (float)0.5, "E");
            Politico P2 = new Politico("Bossi", 'M', 9000, 17, 170, 60, (float)0.5, (float)0.5, "E");
            Escort E2 = new Escort("Cicciolina", 'F', 9000, 17, 170, 60, (float)0.5, (float)0.5, "E");
            Politico P3 = new Politico("Brunetta", 'M', 9000, 17, 170, 60, (float)0.5, (float)0.5, "E");
            Escort E3 = new Escort("Belen", 'F', 9000, 17, 170, 60, (float)0.5, (float)0.5, "E");

            List<Tuple<Politico, Escort>> listaprova = new List<Tuple<Politico, Escort>>();
            listaprova.Add(Tuple.Create(P3, E));
            listaprova.Add(Tuple.Create(P3, E2));
            listaprova.Add(Tuple.Create(P3, E3));
            for (int j = 0; j < pg.GeneraOrgie(listaprova).Count; j++)
            {
                for (int i = 0; i < pg.GeneraOrgie(listaprova)[j].Count; i++)
                {
                    Console.Write("{0} ",pg.GeneraOrgie(listaprova)[j][i].GetNome());
                }
                Console.WriteLine();
            }
            //fine test GeneraOrgie
            Console.ReadKey();
        }



        public void introduci(string nome,char sesso,int denaro,int età,int altezza,int peso,float colorecapelli,float costituzione,string presenze)
        {   
            //da aggiungere: eventuale controllo sui dati in ingresso (prima che incongruenze finiscano nella lista)
            if (sesso == 'M')
            {
                ListaPolitici.Add(new Politico(nome, sesso, denaro, età, altezza, peso, colorecapelli, costituzione, presenze));
            }
            else
            {
                ListaEscort.Add(new Escort(nome, sesso, denaro, età, altezza, peso, colorecapelli, costituzione, presenze));
            }


        }




        public void estrometti(string nome)
        {

        }



        public void bungabunga(char giorno, int Naccoppiamenti)
        {
            List<Tuple<Politico, Escort, float>> ListaDiAffinità = new List<Tuple<Politico, Escort, float>>();
            //per ogni possibile coppia Politico-Escort calcoliamo la discrepanza secondo le indicazioni del testo, e generiamo una Tupla <Politico, Escort, float> da inserire nella lista

            //ultimata la generazione della lista, la riordiniamo per discrepanza

            //consideriamo solo gli Naccoppiamenti migliori della lista

            //chiamiamo la funzione "GeneraOrgie" per calcolare il numero di gruppetti che si vengono a formare

            //chiamiamo la funzione "TrovaOrgione" per identificare la stanza con più elementi -> ci restituisce una lista/array di 3 interi che rappresentano l'output richiesto
        }



        private double CalcolaAffinità(Politico P, Escort E)  //restituisce il valore di discrepanza tra le preferenze del politico e le caratteristiche della Escort
        {
            double Discrepanza = 0;
            double[] importanza = {0.0009, 1.0, 0.1, 0.15, 0.5, 2.0};
            Discrepanza = Math.Abs(P.GetDenaro() - E.GetDenaro()) * importanza[0] + Math.Abs(P.GetEtà() - E.GetEtà()) * importanza[1] + Math.Abs(P.GetAltezza() - E.GetAltezza()) * importanza[2] + Math.Abs(P.GetPeso() - E.GetPeso()) * importanza[3] + Math.Abs(P.GetColoreCapelli() - E.GetColoreCapelli()) * importanza[4] + Math.Abs(P.GetCostituzione() - E.GetCostituzione()) * importanza[5];
            return Discrepanza;
        }



        private Tuple<string,string> LeggiIstruzione(int n)  //legge l'istruzione alla riga n-esima nel file di input e la restituisce interpretata nella forma di Tupla <(IDevento), (parametri)>
        {
            string istruzione = null;
            string parametri = null;
            //gestione lettura da file

            //interpretazione della riga letta (istruzione=.... ; parametri = ..... ; NB: i parametri saranno nello stesso ordine del testo, e separati da " ")

            Tuple<string, string> tupla = new Tuple<string, string>(istruzione, parametri);
            return tupla;
        }

        private List<List<Persona>> GeneraOrgie(List<Tuple<Politico,Escort>> ListaCoppie)  //funzione che prende in ingresso la lista di coppie che parteciperanno al BungaBunga e restituisce una lista di gruppi [quindi una lista di "liste di persone"(i.e. "gruppi")] che rappresentano le stanze di Villa San Martino
        {
            List<List<Persona>> ListaDiGruppi = new List<List<Persona>>();
            for(int i=0; i < ListaCoppie.Count(); i++)  //ciclo su ogni elemento della lista di coppie
            {
                bool CoppiaAggiunta = false;  //flag per segnalare se la coppia ha trovato la stanza a cui partecipare
                for (int j = 0; j < ListaDiGruppi.Count(); j++) {   //ciclo su ogni elemento dell'attuale lista di stanze
                    if (ListaDiGruppi[j].Contains(ListaCoppie[i].Item1) && !ListaDiGruppi[j].Contains(ListaCoppie[i].Item2))  //se nel gruppo j-esimo è già presente il politico(della coppia i-esima), ma non la escort (della coppia i-esima) allora la aggiungo al gruppo j-esimo
                    {
                        ListaDiGruppi[j].Add(ListaCoppie[i].Item2); //Escort
                        CoppiaAggiunta = true;
                        break;
                    }
                    if (!ListaDiGruppi[j].Contains(ListaCoppie[i].Item1) && ListaDiGruppi[j].Contains(ListaCoppie[i].Item2))  //se nel gruppo j-esimo è già presente l'escort(della coppia i-esima), ma non il politico (della coppia i-esima) allora lo aggiungo al gruppo j-esimo
                    {
                        ListaDiGruppi[j].Add(ListaCoppie[i].Item1); //Politico
                        CoppiaAggiunta = true;
                        break;
                    }
                } // fine ciclo sulle stanze già esistenti
                if (!CoppiaAggiunta) //se la coppia non può partecipare ad una stanza già esistente, creo una nuova stanza con i due elementi della coppia
                {
                    List < Persona >  Gruppo = new List<Persona>();
                    Gruppo.Add(ListaCoppie[i].Item1);
                    Gruppo.Add(ListaCoppie[i].Item2);
                    ListaDiGruppi.Add(Gruppo);
                }

            }
            return ListaDiGruppi;
        }

        private void TrovaOrgione()
        {

        }

    }
}
