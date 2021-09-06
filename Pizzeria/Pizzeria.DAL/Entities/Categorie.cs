using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.DAL.Entities
{
    public class Categorie
    {
        #region Props

        public int Id { get; set; }
        public string Nom { get; set; }
        public IEnumerable<Plat> Plats { get; set; }

        #endregion
    }
}
