using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.ASP.Models
{
	public class RegisterModel
	{
		[Required]
		public string Nom { get; set; }
		[Required]
		public string Tel { get; set; }
		[Required]
		[EmailAddress]
		[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
