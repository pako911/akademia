using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik_ocen
{
    class Wykladowca : Student
    {

        public string Przedmiot;
        public Wykladowca(string firstName, string secondName, string przedmiot) : base(firstName, secondName)
        {
            Przedmiot = przedmiot;
        }
        public Wykladowca() { }

        public void dodajOcene(Student s, int ocena)
        {
            s.Ocena = ocena;
        }
    }
}
