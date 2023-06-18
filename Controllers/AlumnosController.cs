using ExamenAPI.Data;
using ExamenAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExamenAPI.Controllers
{
	public class AlumnosController : ApiController
	{

		/// <summary>
		/// Esta es la clase que concede los metodos de consulta
		/// a los alumnos y los cursos.
		/// <list type="bullet">
		/// <item>
		/// <term>GetLista</term>
		/// <description>Listado el curp y nombre de todos los alumnos</description>
		/// </item>
		/// </list>
		/// </summary>
		[HttpGet]
		[Route("GetLista")]
		public List<Alumnos> GetLista()
		{
			List<Alumnos> alumnos = new List<Alumnos>();

			string query = "select  * from Alumnos";

			using (SqlConnection conection = new SqlConnection(Conexion.conexion))
			{
				SqlCommand command = new SqlCommand(query, conection);
				conection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					Alumnos alumno = new Alumnos();
					alumno.Id = reader.GetInt32(0);
					alumno.Nombre = reader.GetString(1);
					alumno.Apellidos = reader.GetString(2);
					alumno.Curp = reader.GetString(3);
					alumnos.Add(alumno);
				}
				conection.Close();
			}

			return alumnos;
		}

		/// <summary>
		/// Este es la clase que concede los metodos de consulta
		/// a los alumnos y los cursos.
		/// <list type="bullet">
		/// <item>
		/// <term>GetLista</term>
		/// <description>Listado el curp y nombre de todos los alumnos</description>
		/// </item>
		/// </list>
		/// </summary>
		[HttpPost]
		[Route("GetAlumno")]
		public Alumnos GetAlumno(int id)
		{
			Alumnos alumno = new Alumnos();

			string query = "select  * from Alumnos where id = " + id;

			using (SqlConnection conection  = new SqlConnection(Conexion.conexion))
			{
				SqlCommand command = new SqlCommand(query, conection);
				conection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					alumno.Id = reader.GetInt32(0);
					alumno.Nombre = reader.GetString(1);
					alumno.Apellidos = reader.GetString(2);
					alumno.Curp = reader.GetString(3);
				}
				conection.Close();
			}
				return alumno;
		}

		/// <summary>
		/// <para>
		/// Es el encargado de agregar un nuevo alumno en la base de datos
		/// </para>
		/// </summary>
		/// <remarks>
		/// Se agrega al recibir todos los datos requeridos del alumno usando el modelo alumno
		/// </remarks>
		/// <param name="slumno">Modelo alumnos el cual contiene los datos del alumno</param>
		/// <returns>Devuelve un valor de tipo boolean true en caso de exito y false si algo inesperado sucedió</returns>
		[HttpPost]
		[Route("Nuevo")]
		public bool Nuevo([FromBody] Alumnos alumno)
		{
			return AlumnosData.Agregar(alumno);
		}

		/// <summary>
		/// <para>
		/// Es el encargado de eliminar el alumno en la base de datos
		/// dependiendo al parametro que necesitamos
		/// </para>
		/// </summary>
		/// <remarks>
		/// Esto lo hace por medio del Id del alumno.
		/// </remarks>
		/// <param name="id">El Id del alumno requerido</param>
		/// <returns>Devuelve un valor de tipo boolean true en caso de exito y false si algo sucedio</returns>
		[HttpPost]
		[Route("Elimina")]
		public bool Elimina(int id)
		{
			return AlumnosData.Eliminar(id);
		}

		/// <summary>
		/// <para>
		/// Es el encargado de buscar la materia indicada
		/// dependiendo al parametro que necesitamos
		/// </para>
		/// </summary>
		/// <remarks>
		/// Esto lo hace por medio del Id del curso.
		/// </remarks>
		/// <param name="id">El Id del curso requerido</param>
		/// <returns>Devuelve un valor de tipo Cursos con los datos de la materia y el maestro</returns>
		[HttpGet]
		[Route("GetCurso")]
		public Cursos GetCurso(int id)
		{
			Cursos curso = new Cursos();

			string query = "select Materias.Id, Materias.Nombre, Materias.Descripcion, Maestros.maestroId, Maestros.nombre from Materias " +
				"join Maestros on Materias.maestroId = Maestros.maestroId where Materias.Id =" + id;

			using (SqlConnection conection = new SqlConnection(Conexion.conexion))
			{
				SqlCommand command = new SqlCommand(query, conection);
				conection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					curso.Id = reader.GetInt32(0);
					curso.Materia = reader.GetString(1);
					curso.Descripcion = reader.GetString(2);
					curso.maestroId = reader.GetInt32(3);
					curso.Maestro = reader.GetString(4);
				}
				conection.Close();
			}

			return curso;
		}
	}
}