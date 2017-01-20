using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dziennik_ocen
{
   
    class Program
    {
        private static void wyswietlWgIndeksu(Dictionary<string, Student> lista)
        {
            Console.Write("Podaj nr indeksu studenta ktorego chcesz wyswietlic: ");
            string input = Console.ReadLine();
            if (lista.Keys.Contains<string>(input))
            {
                Console.WriteLine(lista[input]);
            }
            else
                Console.WriteLine("Nie ma studenta o podanym indeksie");
        }
        private static void wyswietl(Dictionary<string, Student> lista)
        {
            foreach (KeyValuePair<string, Student> pair in lista)
            {
                Console.WriteLine("Indeks: {0} \n {1}", pair.Key, pair.Value);
            }
        }
        private static void grupujWgOcen(Dictionary<string, Student> lista)
        {
            Console.Write("Podaj ocene wg ktorej chcesz pogrupowac studentow: ");
            int intTemp = Convert.ToInt32(Console.ReadLine());
            var oceny = (from temp in lista
                         where temp.Value.Ocena == intTemp
                         select temp);
            foreach (var person in oceny)
            {
                Console.WriteLine(person.Value);
                Console.Read();
            }
            Console.Read();
        }

        static void Main(string[] args)
        {
            Dictionary<string, Student> listaStudentow = new Dictionary<string, Student>();

           
            string wybor;
            do
            {
             
                Console.WriteLine("\n\t\t Menu");
             
                Console.WriteLine("[1] Dodawanie studentów.");
                Console.WriteLine("[2] Dodawanie ocen studentom.");
                Console.WriteLine("[3] Wyświetlanie listy studentów.");
                Console.WriteLine("[4] Wyświetlanie studenta wg indeksu.");
                Console.WriteLine("[5] Grupowanie studentów wg oceny.");
                Console.WriteLine("[6] Zapisywanie listy studentów.");
                Console.WriteLine("[0] Wyjście.");

                wybor = Console.ReadLine();
                switch (wybor)
                {
       
                    case "1":
                        Console.Write("Ilu studentów chcesz dodać?: ");
                        int ilosc2 = Convert.ToInt32(Console.ReadLine());
                        Student s = new Student();
                        for (int i = 0; i < ilosc2; i++)
                        {
                            Console.Write("Podaj imie: ");
                            string imie_2 = Console.ReadLine();
                            s.FirstName = imie_2;
                            Console.Write("Podaj nazwisko: ");
                            string nazwisko_2 = Console.ReadLine();
                            s.SecondName = nazwisko_2;
                            Console.Write("Podaj nr indeksu: ");
                            string id = Console.ReadLine();
                            s.ID = id;
                            listaStudentow.Add(s.ID, s);
                        }
                        break;
                    case "2":
                        Wykladowca w = new Wykladowca();
                        Console.Write("Podaj imie: ");
                        string imie = Console.ReadLine();
                        w.FirstName = imie;
                        Console.Write("Podaj nazwisko: ");
                        string nazwisko = Console.ReadLine();
                        w.FirstName = nazwisko;
                        Console.Write("Podaj przedmiot: ");
                        string przedmiot = Console.ReadLine();
                        w.Przedmiot = przedmiot;
                        Console.Write("Podaj nr indeksu studenta: ");
                        string id_2 = Console.ReadLine();
                        if (listaStudentow.Keys.Contains<string>(id_2))
                        {
                            Console.Write("Podaj ocene: ");
                            int ocena = Convert.ToInt32(Console.ReadLine());
                            w.dodajOcene(listaStudentow[id_2], ocena);
                        }
                        else
                            Console.WriteLine("Nie ma studenta o podanym indeksie");
                        break;
                    case "3":
                        wyswietl(listaStudentow);
                        break;
                    case "4":
                        wyswietlWgIndeksu(listaStudentow);
                        break;
                    case "5":
                        grupujWgOcen(listaStudentow);
                        break;
                    case "6":
                        string json = JsonConvert.SerializeObject(listaStudentow.ToArray());
                        Console.WriteLine("Serializacja do JSONa");
                        System.IO.File.WriteAllText(@"D:\json.txt", json);
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;

                }

            } while (wybor != "0");






           
        }

        
    }
}
