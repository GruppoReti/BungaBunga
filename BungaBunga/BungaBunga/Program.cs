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
            //test affinità
            Program pg = new Program();
            Politico P = new Politico("berlusconi",'M',10000, 17, 170, 60,(float)0.5,(float)0.5, "E");
            Escort E = new Escort("Ruby", 'F', 10000, 17, 170, 60, (float)0.5, (float)0.5, "E");
            Console.WriteLine(pg.CalcolaAffinità(P,E));
            //fine test affinità
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


    }
}
