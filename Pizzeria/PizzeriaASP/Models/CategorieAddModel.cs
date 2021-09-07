using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.ASP.Models
{
	public class CategorieAddModel
	{
		[Required(ErrorMessage = "Ce champ est requis")]
		[MaxLength(50, ErrorMessage ="Le champ est trop long")]

		public string Nom { get; set; }
	}
}
