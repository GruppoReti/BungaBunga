using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungaBunga
{
    interface Iintroduci
    {
        //void introduci(string nome, char sesso, int denaro, int età, int altezza, int peso, float colorecapelli, float costituzione, string presenze);
        void introduci_politico(string nome, char sesso, int denaro, int età, int altezza, int peso, float colorecapelli, float costituzione, string presenze, Politico P);
        void introduci_escort(string nome, char sesso, int denaro, int età, int altezza, int peso, float colorecapelli, float costituzione, string presenze, Escort E);
    }
}
