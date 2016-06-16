using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BungaBunga
{
    class Program 
    {
        private static List<Politico> ListaPolitici = new List<Politico>();
        private static List<Escort> ListaEscort = new List<Escort>();
        private static List<Politico> ListaNera_Politici = new List<Politico>();
        private static List<Escort> ListaNera_Escort = new List<Escort>();

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
            //test affinità
            Program pg = new Program();
            Politico P = new Politico("berlusconi",'M',10000, 17, 170, 60,(float)0.5,(float)0.5, "E");
            Escort E = new Escort("Ruby", 'F', 10000, 17, 170, 60, (float)0.5, (float)0.5, "E");
            Console.WriteLine(pg.CalcolaAffinità(P,E));
            //fine test affinità


            //test lettura da file

            int counter = 0;
            string line;
            string evento;
            

            string path = @"C:\Users\rebolan1\Desktop\provaBunga.txt";
           // string fileName ="provaBunga.txt";
           
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);

                string[] strings = line.Split(' ');
                evento = strings[0];

                if (evento == "in")
                {

                    nome = strings[1];
                    sesso = System.Convert.ToChar(strings[2]);
                    denaro = System.Convert.ToInt32(strings[3]);
                    eta = System.Convert.ToInt32(strings[4]);
                    altezza = System.Convert.ToInt32(strings[5]);
                    peso = System.Convert.ToInt32(strings[6]);
                    capelli = (float)System.Convert.ToDouble(strings[7]);
                    costituzione = (float)System.Convert.ToDouble(strings[8]);
                    presenze = strings[9];

                    Console.WriteLine("Introdotta alla festa {0}", nome);

                    /* if (verifica_Persona(nome, sesso, denaro, eta, altezza, peso, capelli, costituzione, presenze))
                     {
                         introduci(nome, sesso, denaro, eta, altezza, peso, capelli, costituzione, presenze);
                     }
    
                    else Console.WriteLine("Dati della persona non conformi agli standard");*/

                }

                if (evento == "out") {
                    estrometti(strings[1]);
                    Console.WriteLine("Estromissione della persona: {0}",strings[1]);
                }

                if (evento == "bungabunga") {
                    bungabunga(Convert.ToChar(strings[2]),Convert.ToInt32(strings[3]));
                    Console.WriteLine("Gran festa a casa del presidente il giorno {0}, avverranno {1} donazioni", Convert.ToChar(strings[2]), Convert.ToInt32(strings[3]));
                }
                

                counter++;
            }

            file.Close();

            Console.ReadKey();
            

        }


        public static void introduci(string nome,char sesso,int denaro,int età,int altezza,int peso,float colorecapelli,float costituzione,string presenze)
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
                if (!(ListaNera_Escort.Contains(E) || ListaEscort.Contains(E))) ListaEscort.Add(E);
            }


        }
        
        
        public static void estrometti(string nome)
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



        public static void bungabunga(char giorno, int Naccoppiamenti)
        {
            

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


    }
}
