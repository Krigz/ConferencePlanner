using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Models
{
    public class Activiteit
    {
        public Activiteit(string naam, double duur)
        {
            Naam = naam;
            Duur = duur;
        }

        public Activiteit()
        {

        }

        public string Naam
        {
            get; set;
        }
        public double Duur
        {
            get; set;
        }
    }
}
