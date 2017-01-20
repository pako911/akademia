using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik_ocen
{
    class Student
    {
        public int Ocena;
        public string ID;
        public string FirstName;
        public string SecondName;
        public Dictionary<string, Student> Lista;

        public Student(string firstName, string secondName, string id)
        {
            ID = id;
        }
        public Student(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }
        public Student() {  }

        public override string ToString()
        {
            return string.Copy("Imie: " + FirstName + " \nNazwisko: " + SecondName + " \nOcena: " + Ocena);
        }

        public void dodaj(Student s)
        {
            Lista.Add(ID, s);
        }

       
    }
}
