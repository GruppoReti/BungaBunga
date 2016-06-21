using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungaBunga.BL
{
    public class Escort : Persona
    {
        //COSTRUTTORE
        public Escort(string name, char sex, int money, int age, int height, int weight, float hair, float costitution, string presence)
        {
            nome = name;
            sesso = sex;
            denaro = money;
            età = age;
            altezza = height;
            peso = weight;
            colorecapelli = hair;
            costituzione = costitution;
            presenze = presence;
        }
    }
}
