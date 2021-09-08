using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Pizzeria.ASP.Validations;

namespace Pizzeria.ASP.Models
{
	public class PlatAddModel
	{
		[Required(ErrorMessage = "Ce champ est requis")]
		[MaxLength(50, ErrorMessage = "Le champ est trop long")]
		public string Nom { get; set; }
		[Required(ErrorMessage = "Ce champ est requis")]
		[RegularExpression(@"[0-9]{1,6}([.,][0-9]{0,2})?")]
		public string Prix { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		[Required(ErrorMessage = "Ce champ est requis")]
		public int CategorieId { get; set; }

		[FileMimeType("image/jpg", "image/png", "image/x-icon")]
		public IFormFile File { get; set; }
		public IEnumerable<CategorieModel> Categories { get; set; }

	}
}
