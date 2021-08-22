using apiProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace apiProject2.Services
{
    public class data
    {
       static SqlConnection connection = new SqlConnection("Data Source="+apiProject2.Properties.Settings.Default.serverName+ ";Initial Catalog=" + apiProject2.Properties.Settings.Default.initialCatalog + ";User ID=" + apiProject2.Properties.Settings.Default.user + ";Password=" + apiProject2.Properties.Settings.Default.pass + ";MultipleActiveResultSets=True;Connect Timeout=100;Encrypt=False;Application Name=Deupay;Current Language=spanish");
        public static Deuda getSingleDeudaById(int id)
        {
            Deuda returningResult = new Deuda();
            if (testConnection())
            {
                try
                {
                    abrir();
                    SqlCommand query = new SqlCommand("select * from deudas where id="+id,connection);
                    using (SqlDataReader oReader = query.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            returningResult.id= Convert.ToInt32(oReader["id"].ToString());
                            returningResult.amount= Convert.ToDouble(oReader["amount"].ToString());
                            returningResult.label= oReader["label"].ToString();
                            returningResult.description= oReader["description"].ToString();
                        }
                        cerrar();
                        return returningResult;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return null;
            
        }

        private static bool testConnection()
        {
            try
            {
                abrir();
                cerrar();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static void cerrar()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private static void abrir()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}