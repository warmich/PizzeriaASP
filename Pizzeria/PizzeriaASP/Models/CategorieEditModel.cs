﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.ASP.Models
{
	public class CategorieEditModel
	{
		[Required]
		[MaxLength(50)]
		public string Nom { get; set; }

	}
}
