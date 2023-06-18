using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenAPI.Data
{
	public class Conexion
	{
		/// <summary>
		/// Esta es la clase que contiene la cadena de conexion 
		/// necesaria para realizar las consultas a la base de datos
		/// <list type="bullet">
		/// <item>
		/// <term>conexion</term>
		/// <description>Cadena de texto con los datos requeridos</description>
		/// </item>
		/// </list>
		/// </summary>
		public static string conexion = "Data Source=.;Initial Catalog=prueba;Integrated Security=True";
	}
}