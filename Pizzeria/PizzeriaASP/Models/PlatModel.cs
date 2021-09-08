using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Pizzeria.DAL.Entities;

namespace Pizzeria.ASP.Models
{
	public class PlatModel
	{
		public int Id { get; set; }
		public string Nom { get; set; }
		[DataType(DataType.Currency)]
		public decimal Prix { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public int CategorieId { get; set; }
		public Categorie Categorie { get; set; }
	}
}
