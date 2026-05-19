using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class CD_Departamento
    {
        Conexion conn = new Conexion();

        //Metodo para agregar un Nuevo Municipio (Boton Guardar)
        public void MtdAgregarDepartamento(string  Nombre, int DistanciaCapital, int CantidadMunicipios, bool EsCapital, string DepartamentoVecinoSeleccionado)
        {

            String QueryAgregar = "Insert into Departamento (DepartamentoVecino, Nombre, DistanciaCapital, CantidadMunicipios, EsCapital)values (@DepartamentoVecino, @Nombre, @DistanciaCapital, @CantidadMunicipios, @EsCapital);";

            SqlCommand sqlcm = new SqlCommand(QueryAgregar, conn.MtdAbrirConexion());

            // Si el ComboBox está en "Ninguno", se guarda NULL
            if (DepartamentoVecinoSeleccionado == "Ninguno")
            {
                sqlcm.Parameters.AddWithValue("@DepartamentoVecino", DBNull.Value);
            }
            else
            {
                int idVecino = ObtenerIdDepartamento(DepartamentoVecinoSeleccionado);
                if  (idVecino == -1)
                {
                    throw new Exception("El departamento vecino seleccionado no existe.");
                }
                else
                {
                    sqlcm.Parameters.AddWithValue("@DepartamentoVecino", idVecino);
                }
            }

           
            sqlcm.Parameters.AddWithValue("@Nombre", Nombre);
            sqlcm.Parameters.AddWithValue("@DistanciaCapital", DistanciaCapital);
            sqlcm.Parameters.AddWithValue("@CantidadMunicipios", CantidadMunicipios);
            sqlcm.Parameters.AddWithValue("@EsCapital", EsCapital);
            sqlcm.ExecuteNonQuery();
            conn.MtdCerrarConexion();

        }

        //Metodo para Consultar Departamento (Seleccionar Departamento)
        public DataTable MtdConsultarDepartamento()
        {
    
            string Query = "Select * from Departamento";//Cambiar Query
            SqlDataAdapter Adapter = new SqlDataAdapter(Query, conn.MtdAbrirConexion());
            DataTable dt = new DataTable();
            Adapter.Fill(dt);

            return dt;
        }

        public int ObtenerIdDepartamento(string nombre)
        {
            string Query = "SELECT Id FROM Departamento WHERE Nombre = @Nombre";
            SqlCommand cmd = new SqlCommand(Query, conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@Nombre", nombre);

            object result = cmd.ExecuteScalar();

            return result != null ? Convert.ToInt32(result) : -1;
        }
    }
}
