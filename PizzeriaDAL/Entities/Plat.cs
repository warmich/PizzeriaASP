using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaDAL.Entities
{
	public class Plat
	{
		public int Id { get; set; }
		public string Nom { get; set; }
		public decimal Prix { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public int CategorieId { get; set; }
		public Categorie Categorie { get; set; }
	}
}
