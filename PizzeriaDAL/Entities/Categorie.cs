﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaDAL.Entities
{
	public class Categorie
	{
		public int Id { get; set; }
		public string Nom { get; set; }
		public IEnumerable<Plat> Plats { get; set; }
	}
}
