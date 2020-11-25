using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace Clave3_Grupo04
{
    class ClaseUsuario
    {
        
        public void selectUser(String dataGridViewName) {
            Form1 formMain = new Form1();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM problema3pr115.user", formMain.conectar);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "user");
            //if (dataGridViewName=="dataGridView1") {
                formMain.dataGridView1.DataSource = ds.Tables["user"];
            //}
            formMain.conectar.Close();
        }
    }
}
