
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataContractCore
{
    public sealed class DataBaseContext
    {
        private DataBaseContext()
        {




        }

        private static Lazy<DataBaseContext> instance = new Lazy<DataBaseContext>(() => new DataBaseContext());

        public MySqlConnection _con { get; set; }

        /// public string ConnectionString { get; set; } = "Server=192.168.0.30;Port=3306;Database=employees_db;Uid=root;Pwd=P@55w0rd;";
        /// 



        //  public string ConnectionString { get; set; } = "Server=dbdata;Port=3306;Database=templatebuild;Uid=root; Pwd=myPass123;";

        public string ConnectionString { get; set; } = "Server=db;Port=3306;Database=templatebuild;Uid=root;Pwd=mypass;";

        public static DataBaseContext GetInstance
        {
            get { return instance.Value; }
        }

        internal bool OpenConnection()
        {
            try
            {
                if (_con != null && _con.State == System.Data.ConnectionState.Open)
                    _con.Close();


                _con = new MySqlConnection(ConnectionString);

                _con.Open();

                return true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }


        }

        internal bool CloseConnection()
        {
            try
            {
                if (_con.State == System.Data.ConnectionState.Open)
                    _con.Close();

                return true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


    }
}
