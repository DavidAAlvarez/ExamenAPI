using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenAPI.Models
{
	public class Cursos
	{
		public int Id { get; set; }
		public string Materia { get; set; }
		public string Descripcion { get; set; }
		public int maestroId { get; set; }
		public string Maestro { get; set; }
	}
}