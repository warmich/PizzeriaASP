using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.DAL.Entities
{
    public class Plat_Commande
    {
        #region Props

        public int Id { get; set; }
        public int PlatId { get; set; }
        public int CommandeId { get; set; }
        public decimal Prix { get; set; }
        public Plat Plat { get; set; }
        public Commande Commande { get; set; }

        #endregion
    }
}
