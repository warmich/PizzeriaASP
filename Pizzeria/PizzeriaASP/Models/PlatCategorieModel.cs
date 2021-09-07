using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.ASP.Models
{
	public class PlatCategorieModel
	{
		public IEnumerable<PlatModel> Plats { get; set; }
		public IEnumerable<CategorieModel> Categories { get; set; }
		public int? Filtre { get; set; }

	}
}
