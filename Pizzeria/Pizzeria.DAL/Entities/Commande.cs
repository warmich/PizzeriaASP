using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.DAL.Entities
{
    public class Commande
    {
        #region Props

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Statut { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public IEnumerable<Plat_Commande> Plat_Commandes { get; set; }

        #endregion
    }
}
