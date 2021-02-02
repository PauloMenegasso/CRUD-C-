using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_De_Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSerie();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        ExcludeSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }
            
        }


        private static void ListSerie()
        {
            Console.WriteLine("List series");

            var list = repository.List();

            if(list.Count == 0)
            {
                Console.WriteLine("No series registered");
                return;
            }

            foreach(var serie in list)
            {
                var excluded = serie.returnExcluded();
                if (!excluded)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.returnId(), serie.returnTitle());
                }
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Insert a new series");

            renderENUM();

            int genreEntry = InsertNumber();

            Console.WriteLine("Type the serie's title: ");
            string titleEntry = InsertString();

            Console.WriteLine("Type the year of the series: ");
            int yearEntry = InsertNumber();

            Console.WriteLine("Type the serie's description: ");
            string descriptionEntry = InsertString();

            Serie newSerie = new Serie(id: repository.NextId(),
                                        genre: (Genre)genreEntry,
                                        title: titleEntry,
                                        year: yearEntry,
                                        description: descriptionEntry);

            repository.Insert(newSerie);
        }


        private static void UpdateSerie()
        {
            Console.WriteLine("Insert series' ID: ");
            int indexSerie = InsertNumber();
            
            renderENUM();
            int genreEntry = InsertNumber();

            Console.WriteLine("Type the serie's title: ");
            string titleEntry = InsertString();

            Console.WriteLine("Type the year of the series: ");
            int yearEntry = InsertNumber();

            Console.WriteLine("Type the serie's description: ");
            string descriptionEntry = InsertString();

            Serie updatedSerie = new Serie(id: repository.NextId(),
                                        genre: (Genre)genreEntry,
                                        title: titleEntry,
                                        year: yearEntry,
                                        description: descriptionEntry);

            repository.Update(indexSerie, updatedSerie);
        }

        private static void ExcludeSerie()
        {
            Console.WriteLine("Insert serie's id for exclude: ");
            int indexSerie = InsertNumber();

            Console.WriteLine("Are you sure you want to exclude this serie?");

            var serie = repository.ReturnById(indexSerie);
            Console.WriteLine(serie);

            Console.WriteLine("1- Yes");
            Console.WriteLine("2- No");
            int exclude = InsertNumber();

            if(exclude == 1)
            {
                repository.Exclude(indexSerie);
                Console.WriteLine("Exluded!");
            }
            else
            {
                Console.WriteLine("Serie not excluded!");
            }


        }

        private static void ViewSerie()
        {
            Console.WriteLine("Insert serie's id for exclude: ");
            int indexSerie = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(indexSerie);

            Console.WriteLine(serie);
        }


        private static int InsertNumber()
        {
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        private static string InsertString()
        {
            string text = Console.ReadLine();
            return text;
        }

        private static void renderENUM()
        {
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.WriteLine("Choose the genre from above options");
        }



        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to serie selector!");
            Console.WriteLine("Inform your desired option:");

            Console.WriteLine("1- List series");
            Console.WriteLine("2- Insert new serie");
            Console.WriteLine("3- Update serie");
            Console.WriteLine("4- Exclude serie");
            Console.WriteLine("5- View serie");
            Console.WriteLine("6- List serie by category");
            Console.WriteLine("C- Clean Screen");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }


    }
}
