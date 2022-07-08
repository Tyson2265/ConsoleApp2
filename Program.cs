using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = "Data source = (localdb)\\MSSQLLocalDB; Initial Catalog = ADO_CRUD; integrated security = SSPI";

            SqlConnection  con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GetAllProducts";
            
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dtProducts = new DataTable();
            // SqlCommand cmd = new SqlCommand("SELECT * FROM ProductTable;", con);
             SqlDataReader dr = cmd.ExecuteReader();
            // foreach(DataRow dr in dtProducts.Rows)
         
           while (dr.Read())
            {
                int ProductID = Convert.ToInt32(dr["ProductID"]);
                string ProductName = dr["ProductName"].ToString();
                decimal Price = Convert.ToDecimal(dr["Price"]);
                int Qty = Convert.ToInt32(dr["qty"]);
                string Remarks = dr["Remarks"].ToString();
                Console.WriteLine($"My Id is : {ProductID} and Product Name is : {ProductName}");
            }
      
            con.Close();
            Console.ReadLine();
            
        }
    }
}
