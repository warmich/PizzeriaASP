﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Pizzeria.ASP.Services
{
	public class FileService : IFileService
	{
		private readonly IWebHostEnvironment _env;

		public FileService(IWebHostEnvironment env)
		{
			_env = env;
		}

		public string AddFile(IFormFile file)
		{
			string fileName = Guid.NewGuid() + file.FileName;
			string path = Path.Combine(_env.WebRootPath, "uploads");
			using FileStream stream = new FileStream(
				Path.Combine(path, fileName), FileMode.Create);
			file.CopyTo(stream);
			return fileName;
		}

		public void Delete(string image)
		{
			File.Delete(
					Path.Combine(
						_env.WebRootPath,
						"uploads",
						image
						));
		}
	}
}
