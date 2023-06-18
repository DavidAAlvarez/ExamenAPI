using ExamenAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamenAPI.Data
{
	public class AlumnosData
	{
		public static bool Agregar(Alumnos alumno)
		{
			using (SqlConnection conection = new SqlConnection(Conexion.conexion))
			{
				SqlCommand command = new SqlCommand("nuevo", conection);
				command.CommandType = CommandType.StoredProcedure;
				//command.Parameters.AddWithValue("@Id", 0);
				command.Parameters.AddWithValue("@Nombre", alumno.Nombre);
				command.Parameters.AddWithValue("@Apellidos", alumno.Apellidos);
				command.Parameters.AddWithValue("@Curp", alumno.Curp);

				try
				{
					conection.Open();
					command.ExecuteNonQuery();
					//conection.Close();
					return true;

				}
				catch (Exception ex)
				{
					//conection.Close();
					return false;
				}
			}
			return true;
		}

		public static bool Eliminar(int id)
		{
			using (SqlConnection conection = new SqlConnection(Conexion.conexion))
			{
				SqlCommand command = new SqlCommand("elimina", conection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@Id", id);
				try
				{
					conection.Open();
					command.ExecuteNonQuery();
					//conection.Close();
					return true;

				}
				catch (Exception e)
				{
					conection.Close();
					return false;
				}
			}

		}

	}
}