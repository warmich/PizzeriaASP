using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.DAL.Entities
{
    public class Client
    {
        #region Props

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
		public string Role { get; set; }
		public Guid Salt { get; set; }
		public IEnumerable<Commande> Commandes { get; set; }

        #endregion
    }
}
