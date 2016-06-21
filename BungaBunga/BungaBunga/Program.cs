using System;
using System.Collections.Generic;
using System.IO;
using BungaBunga.BL;

namespace BungaBunga
{
    class Program
    {
        private static List<Politico> ListaPolitici = new List<Politico>();
        private static List<Escort> ListaEscort = new List<Escort>();
        private static List<Persona> ListaNera = new List<Persona>();
        private static List<List<Persona>> ListaDiGruppi = new List<List<Persona>>();

        static void Main(string[] args)
        {
            string line;
            string evento;

            string path = @"C:\Users\castese1\Desktop\provaBungaReinserimentoDiPersona.txt";
            // string fileName ="provaBunga.txt";

            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);

                string[] strings = line.Split(' ');
                evento = strings[0];

                if (evento == "in")
                {
                    BungaBungaManager.verifica_e_introduci(strings);
                }
             
                else if (evento == "out")
                {
                    BungaBungaManager.estrometti(strings[1]);
                    Console.WriteLine("Estromissione della persona: {0}", strings[1]);
                }

                else if (evento == "bungabunga")
                {
                    int NaccopiamentiAvvenuti = BungaBungaManager.bungabunga(Convert.ToChar(strings[1]), Convert.ToInt32(strings[2]));
                    Console.WriteLine("Gran festa a casa del presidente il giorno {0}, avvenute {1} donazioni", Convert.ToChar(strings[1]), NaccopiamentiAvvenuti);
                }


            }

            file.Close();

            Console.ReadKey();

        }

    }
}