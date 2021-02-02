using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_De_Series { 
    public class Serie : EntityBase
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        private bool Excluded { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênre: " + this.Genre + Environment.NewLine;
            retorno += "Títle: " + this.Title + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Year: " + this.Year + Environment.NewLine;
            retorno += "Excluded: " + this.Excluded;
            return retorno;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnExcluded()
        {
            return this.Excluded;
        }

        public Genre returnGenre()
        {
            return this.Genre;
        }

        public void Exclude()
        {
            this.Excluded = true;
        }

    }
}
