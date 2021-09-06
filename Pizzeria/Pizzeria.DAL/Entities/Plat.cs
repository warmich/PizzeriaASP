using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.DAL.Entities
{
    public class Plat
    {
        #region Props

        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
        public IEnumerable<Plat_Commande> Plat_Commandes { get; set; }

        #endregion
    }
}
