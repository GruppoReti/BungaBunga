using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BungaBunga
{
    class Program
    {
        private static List<Politico> ListaPolitici = new List<Politico>();
        private static List<Escort> ListaEscort = new List<Escort>();
        private static List<Persona> ListaNera = new List<Persona>();
        private static List<List<Persona>> ListaDiGruppi = new List<List<Persona>>();

        private static string nome;
        private static char sesso;
        private static int denaro;
        private static int eta;
        private static int altezza;
        private static int peso;
        private static float capelli;
        private static float costituzione;
        private static string presenze;

        static void Main(string[] args)
        {

            string line;
            string evento;

            string path = @"C:\Users\milinlo1\Desktop\provaBunga.txt";
            // string fileName ="provaBunga.txt";

            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);

                string[] strings = line.Split(' ');
                evento = strings[0];

                if (evento == "in")
                {
                    assegna_caratteristiche(strings);
                    Console.WriteLine("La persona {0} è stata introdotta alla festa", nome);

                    if (VerificaPersona(nome, sesso, denaro, eta, altezza, peso, capelli, costituzione, presenze))
                    {
                        introduci(nome, sesso, denaro, eta, altezza, peso, capelli, costituzione, presenze);
                    }

                   // else Console.WriteLine("Dati della persona non conformi agli standard");
                }

                else if (evento == "out")
                {
                    estrometti(strings[1]);
                    Console.WriteLine("Estromissione della persona: {0}", strings[1]);
                }

                else if (evento == "bungabunga")
                {
                    bungabunga(Convert.ToChar(strings[2]), Convert.ToInt32(strings[3]));
                    Console.WriteLine("Gran festa a casa del presidente il giorno {0}, avverranno {1} donazioni", Convert.ToChar(strings[2]), Convert.ToInt32(strings[3]));
                }


            }

            file.Close();

            Console.ReadKey();

        }

   /*     MAIN DI TEST SEBA
        static void Main(string[] args)
        {   
            //test GeneraOrgie
            Politico P = new Politico("Berlusconi",'M',10000, 17, 170, 60,(float)0.5,(float)0.5, "E");
            Escort E = new Escort("Ruby", 'F', 10000, 17, 170, 60, (float)0.5, (float)0.5, "E");
            Politico P2 = new Politico("Bossi", 'M', 9000, 17, 170, 60, (float)0.5, (float)0.5, "E");
            Escort E2 = new Escort("Cicciolina", 'F', 9000, 17, 170, 60, (float)0.5, (float)0.5, "E");
            Politico P3 = new Politico("Brunetta", 'M', 20000, 17, 170, 60, (float)0.5, (float)0.5, "E");
            Escort E3 = new Escort("Belen", 'F', 9000, 17, 170, 60, (float)0.5, (float)0.5, "E");

            ListaPolitici.Add(P);
            ListaPolitici.Add(P2);
            ListaPolitici.Add(P3);
            
            ListaEscort.Add(E);
            ListaEscort.Add(E2);
            ListaEscort.Add(E3);
            bungabunga('E', 3);
            //fine test GeneraOrgie
            Console.ReadKey();
        }

*/
        public static void assegna_caratteristiche(string[] strings)
        {

            nome = strings[1];
            sesso = Convert.ToChar(strings[2]);
            denaro = Convert.ToInt32(strings[3]);
            eta = Convert.ToInt32(strings[4]);
            altezza = Convert.ToInt32(strings[5]);
            peso = Convert.ToInt32(strings[6]);
            capelli = (float)Convert.ToDouble(strings[7]);
            costituzione = (float)Convert.ToDouble(strings[8]);
            presenze = strings[9];
        }

        public static void introduci(string nome,char sesso,int denaro,int età,int altezza,int peso,float colorecapelli,float costituzione,string presenze)
        {   
            //da aggiungere: eventuale controllo sui dati in ingresso (prima che incongruenze finiscano nella lista)

            if (sesso == 'M')
            {
                Politico P = new Politico(nome, sesso, denaro, età, altezza, peso, colorecapelli, costituzione, presenze);
                if(!(ListaNera.Contains(P) || ListaPolitici.Contains(P))) ListaPolitici.Add(P); 
                //il politico viene aggiunto nella lista degli invitati solo se non è segnato nella lista nera e non è già stato precedentemente aggiunto nella lista 
            }
            else
            {
                Escort E = new Escort(nome, sesso, denaro, età, altezza, peso, colorecapelli, costituzione, presenze);
                if (!(ListaNera.Contains(E) || ListaEscort.Contains(E))) ListaEscort.Add(E);
            }
        }


        public static void estrometti(string nome)
        {
            
            var politico_estromesso = ListaPolitici.SingleOrDefault(x => x.GetNome() == nome); // controlla se il soggetto è già presente nella lista
            if (politico_estromesso != null)
            {
                ListaPolitici.Remove(politico_estromesso);  // elimina il soggetto dalla lista
                ListaNera.Add(politico_estromesso); //aggiungo il soggetto alla black list
            }

            else
            {
                var escort_estromessa = ListaEscort.SingleOrDefault(x => x.GetNome() == nome);
                if (escort_estromessa != null)
                {
                    ListaEscort.Remove(escort_estromessa);
                    ListaNera.Add(escort_estromessa);
                }

            }

        }



        public static void bungabunga(char giorno, int Naccoppiamenti)  
        {

            //verifica dati inseriti

            //(TO BE DONE)

            //creiamo, sulla base del giorno in unput, le sottoliste di Politici ed Escort che possono partecipare

            List<Politico> SottoListaPolitici = new List<Politico>();
            for(int i = 0; i < ListaPolitici.Count; i++)
            {
                if (ListaPolitici[i].GetPresenze().Contains(giorno.ToString()))
                {
                    SottoListaPolitici.Add(ListaPolitici[i]);
                }
            }
            List<Escort> SottoListaEscort = new List<Escort>();
            for (int i = 0; i < ListaEscort.Count; i++)
            {
                if (ListaEscort[i].GetPresenze().Contains(giorno.ToString()))
                {
                    SottoListaEscort.Add(ListaEscort[i]);
                }
            }
            //per ogni possibile coppia Politico-Escort calcoliamo la discrepanza secondo le indicazioni del testo, e generiamo una Tupla <Politico, Escort, float> da inserire nella lista

            List<Tuple<Politico, Escort, float>> ListaDiAffinità = new List<Tuple<Politico, Escort, float>>();

            for (int j = 0; j < SottoListaPolitici.Count; j++)
            {
                for (int i = 0; i < SottoListaEscort.Count; i++)
                {
                    ListaDiAffinità.Add(Tuple.Create(SottoListaPolitici[j], SottoListaEscort[i],CalcolaAffinità(SottoListaPolitici[j], SottoListaEscort[i])));
                }
            }
            //ultimata la generazione della lista, la riordiniamo per discrepanza crescente (così che i primi N elementi siano quelli da considerare)
            List<Tuple<Politico, Escort, float>> ListaDiAffinitàOrdinata =ListaDiAffinità.OrderBy(x => x.Item3).ToList();


            //consideriamo solo gli Naccoppiamenti migliori della lista

            List<Tuple<Politico, Escort>> ListaCoppie = new List<Tuple<Politico, Escort>>();
            for(int i=0; i<Naccoppiamenti; i++)
            {
                ListaCoppie.Add(Tuple.Create(ListaDiAffinitàOrdinata[i].Item1,ListaDiAffinitàOrdinata[i].Item2));
            }
            //chiamiamo la funzione "GeneraOrgie" per calcolare il numero di gruppetti che si vengono a formare

            List<List<Persona>> ListaDiGruppi = GeneraOrgie(ListaCoppie,0);

            //chiamiamo la funzione "TrovaOrgione" per identificare la stanza con più elementi -> ci restituisce una lista/array di 3 interi che rappresentano l'output richiesto
            TrovaOrgione(ListaDiGruppi);
        }



        private static float CalcolaAffinità(Politico P, Escort E)  //restituisce il valore di discrepanza tra le preferenze del politico e le caratteristiche della Escort
        {
            float Discrepanza = 0;
            float[] importanza = {(float)0.0009, (float)1.0, (float)0.1, (float)0.15, (float)0.5, (float)2.0 };
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


        private static List<List<Persona>> GeneraOrgie(List<Tuple<Politico, Escort>> ListaCoppie, int j)  //funzione che prende in ingresso la lista di coppie che parteciperanno al BungaBunga e restituisce una lista di gruppi [quindi una lista di "liste di persone"(i.e. "gruppi")] che rappresentano le stanze di Villa San Martino
        {
            List<Persona> Gruppo = new List<Persona>();
            Gruppo.Add(ListaCoppie[0].Item1);
            Gruppo.Add(ListaCoppie[0].Item2);
            ListaDiGruppi.Add(Gruppo);
            bool CoppiaAggiunta = true;  //flag per segnalare se almeno una coppia ha trovato la stanza a cui partecipare

            while (CoppiaAggiunta) {
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
            /////////////   STAMPA GRUPPI PER DEBUG ////////////////////////
            for (int k = 0; k < ListaDiGruppi.Count; k++)
            {
                for (int x = 0; x < ListaDiGruppi[k].Count; x++)
                {
                    Console.Write(" {0}", ListaDiGruppi[k][x].GetNome());
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
                    return GeneraOrgie(ListaCoppie, j+1);
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
                    NPolitici = ListaDiGruppi[i].Count(x=>x.GetSesso()=='M');
                    NEscort = max - NPolitici;
                }
            }

            Console.WriteLine("{0} {1} {2}",ListaDiGruppi.Count,NPolitici,NEscort);
        }

        private static bool VerificaPersona(string nome, char sesso, int denaro, int età, int altezza, int peso, float colorecapelli, float costituzione, string presenze)
        {
            int check = 0;
            string[] simbolinonpermessi = { ",", ";", "-", "_", "!", "?", "£", "$", "%", "&", "/", "(", ")", "=", "^", "'", "[", "]", "{", "}", "#", "§", "@", ".", ":" };
            string[] sessi = { "M", "F" };
            //string[] giornisettimana = { "L", "M", "E", "G", "V", "S", "D" };
            string giornisettimana = "LMEGVSD";
            int[] range_età = { 17, 18, 19, 20, 21, 22, 23, 24 };
            int counter = 0;

            // check nome

            for (int i = 0; i < simbolinonpermessi.Length; i++)
            {
                if (nome.IndexOf(simbolinonpermessi[i]) == -1)
                {
                    //
                }
                else
                {
                    Console.WriteLine("Il campo \"nome\" contiene il simbolo non permesso {0}", simbolinonpermessi[i]);
                    return false;
                }
            }
            check = check + 1;

            // check sesso

            if (sesso == 'M' || sesso == 'F')
            {
                check = check + 1;
            }
            else
            {
                Console.WriteLine("Il campo \"sesso\" inserito è errato");
                return false;
            }

            // check denaro
            /*   if (denaro- Math.Truncate(denaro))
                 {
                     check = check + 1;
                 }
                 else
                 {
                     Console.WriteLine("Il campo \"denaro\" non è un intero");
                     return false;
                 }*/

            // check età

            counter = 0;
            for (int i = 0; i < range_età.Length; i++)
            {
                if (età == range_età[i])
                {
                    check = check + 1;
                    counter = counter + 1;
                }
            }
            if (counter == range_età.Length)
            {
                Console.WriteLine("Il campo \"età\" inserito {0} non rispetta i limiti imposti (17 - 24 anni)", età);
                return false;
            }

            // check altezza

            if (altezza > 130 && altezza < 220)
            {
                check = check + 1;
            }
            else
            {
                Console.WriteLine("Il campo \"altezza\" inserito {0} non è in cm", altezza);
                return false;
            }


            // check peso

            if (peso > 10 && peso < 500)
            {
                check = check + 1;
            }
            else
            {
                Console.WriteLine("Il campo \"peso\" inserito {0} non è in kg", peso);
                return false;
            }

            // check colore capelli

            if (colorecapelli < 0.0 && colorecapelli > 1.0)
            {
                Console.WriteLine("Il campo \"colorecapelli\" {0} non rispetta i limiti imposti (0.1 - 1.0)", colorecapelli);
                return false;
            }
            else
            {
                check = check + 1;
            }

            //check costituzione

            if (costituzione < 0.0 && costituzione > 1.0)
            {
                Console.WriteLine("Il campo \"costituzione\" {0} non rispetta i limiti imposti (0.1 -1.0)", costituzione);
                return false;
            }
            else
            {
                check = check + 1;
            }

            //check giorni settimana

            counter = 0;
            for (int i = 0; i < presenze.Length; i++)
            {
                // if (presenze.IndexOf(giornisettimana[i]) == -1)
                if (!giornisettimana.Contains(presenze[i]))
                {
                    Console.WriteLine("Il campo \"presenze\" contiene il carattere errato: {0}", presenze[i]);
                    return false;
                }
                else
                {
                    //counter = counter + 1;
                }
            }
            check = check + 1;


            // check finale

            if (check == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
