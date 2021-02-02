using System.Collections.Generic;
using CRUD_De_Series.Interfaces;

namespace CRUD_De_Series
{
    class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();
        public void Update(int id, Serie entity)
        {
            listSerie[id] = entity;
        }

        public void Exclude(int id)
        {
            listSerie[id].Exclude();
        }

        public void Insert(Serie entity)
        {
            listSerie.Add(entity);
        }

        public List<Serie> List()
        {
            return listSerie;
        }

        public int NextId()
        {
            return listSerie.Count;
        }

        public Serie ReturnById(int id)
        {
            return listSerie[id];
        }
    }
}
