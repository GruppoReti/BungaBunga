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
        private List<Politico> ListaNera_Politici = new List<Politico>();
        private List<Escort> ListaNera_Escort = new List<Escort>();

        static void Main(string[] args)
        {   
            //test affinità
            Program pg = new Program();
            Politico P = new Politico("Berlusconi",'M',10000, 17, 170, 60,(float)0.5,(float)0.5, "E");
            Escort E = new Escort("Ruby", 'F', 10000, 17, 170, 60, (float)0.5, (float)0.5, "E");
            Console.WriteLine("La discrepanza tra {0} e {1} è {2}", P.GetNome(), E.GetNome(), pg.CalcolaAffinità(P,E));
            //fine test affinità
            Console.ReadKey();

         

        }
        

        public void introduci(string nome,char sesso,int denaro,int età,int altezza,int peso,float colorecapelli,float costituzione,string presenze)
        {   
            //da aggiungere: eventuale controllo sui dati in ingresso (prima che incongruenze finiscano nella lista)

            if (sesso == 'M')
            {
                Politico P = new Politico(nome, sesso, denaro, età, altezza, peso, colorecapelli, costituzione, presenze);
                if(!(ListaNera_Politici.Contains(P) || ListaPolitici.Contains(P))) ListaPolitici.Add(P); 
                //il politico viene aggiunto nella lista degli invitati solo se non è segnato nella lista nera e non è già stato precedentemente aggiunto nella lista 
            }
            else
            {
                Escort E = new Escort(nome, sesso, denaro, età, altezza, peso, colorecapelli, costituzione, presenze);
                ListaEscort.Add(new Escort(nome, sesso, denaro, età, altezza, peso, colorecapelli, costituzione, presenze));
                if (!(ListaNera_Escort.Contains(E) || ListaEscort.Contains(E))) ListaEscort.Add(E);
            }
        }
        
        
        public void estrometti(string nome)
        {

            var politico_estromesso = ListaPolitici.SingleOrDefault(x => x.GetNome() == nome); // controlla se il soggetto è già presente nella lista
            if (politico_estromesso != null)
            {
                ListaPolitici.Remove(politico_estromesso);  // elimina il soggetto dalla lista
                ListaNera_Politici.Add(politico_estromesso); //aggiungo il soggetto alla black list
            }

            else
            {
                var escort_estromessa = ListaEscort.SingleOrDefault(x => x.GetNome() == nome);
                if (escort_estromessa != null)
                {
                    ListaEscort.Remove(escort_estromessa);
                    ListaNera_Escort.Add(escort_estromessa);
                }

            }

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

        private bool VerificaPersona(string nome, char sesso, int denaro, int età, int altezza, int peso, float colorecapelli, float costituzione, string presenze)
        {
            int check = 0;
            string[] simbolinonpermessi = {",", ";", "-", "_", "!", "?", "£", "$", "%", "&", "/", "(", ")", "=", "^", "'", "[", "]", "{", "}", "#", "§", "@", ".", ":"};
            string[] sessi = { "M", "F" };
            string[] giornisettimana = {"L", "M", "E", "G", "V", "S", "D"};
            int[] range_età = { 17, 18, 19, 20, 21, 22, 23, 24 };
            int counter = 0;

            // check nome

            for (int i = 0; i < simbolinonpermessi.Length; i++)
            {
                if(nome.IndexOf(simbolinonpermessi[i]) == -1)
                {
                    //counter = counter + 1;
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
            if(denaro%2 == 0)
            {
                check = check + 1;
            }
            else
            {
                Console.WriteLine("Il campo \"denaro\" non è un intero");
                return false;
            }

            // check età

            counter = 0;
            for(int i = 0; i < range_età.Length; i++)
            {
                if(età == range_età[i] && età%2 == 0)
                {
                    check = check + 1;
                    counter = counter + 1;
                }
            }
            if(counter == range_età.Length)
            {
                Console.WriteLine("Il campo \"età\" inserito {0} non rispetta i limiti imposti (17 - 24 anni) oppure non è un numero intero", età);
                return false;
            }

            // check altezza

            if(altezza%2 == 0 && altezza > 130 && altezza < 220)
            {
                check = check + 1;
            }
            else
            {
                Console.WriteLine("Il campo \"altezza\" inserito {0} non è un numero intero oppure non è in cm", altezza);
                return false;
            }


            // check peso

            if (peso % 2 == 0 && peso > 10 && peso < 500)
            {
                check = check + 1;
            }
            else
            {
                Console.WriteLine("Il campo \"peso\" inserito {0} non è un numero intero oppure non è in kg", altezza);
                return false;
            }

            // check colore capelli

            if (colorecapelli < 0.0 && colorecapelli > 1.0)
            {
                Console.WriteLine("Il campo \"colorecapelli\" {0} non rispetta i limiti imposti (0.1 -1.0)", colorecapelli);
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
            for (int i = 0; i < giornisettimana.Length; i++)
            {
                if (presenze.IndexOf(giornisettimana[i]) == -1)
                {
                    Console.WriteLine("Il campo \"presenze\" contiene il carattere errato: {0}", giornisettimana[i]);
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
