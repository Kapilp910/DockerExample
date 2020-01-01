
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace DataContractCore
{
    public class BaseRepository
    {


        DataBaseContext _uow;


        public BaseRepository()
        {
            _uow = DataBaseContext.GetInstance;
        }


        public List<T> GetData<T>(string query)
        {
            List<T> allData = new List<T>();
            try
            {
                _uow.OpenConnection();


                allData = _uow._con.Query<T>(query).ToList();

                _uow.CloseConnection();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }


            return allData;
        }

        public int ModifiedData<T>(string query)
        {
            IEnumerable<T> allData;
            try
            {
                _uow.OpenConnection();


                allData = _uow._con.Query<T>(query);

                _uow.CloseConnection();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }


            return (allData == null) ? 0 : allData.Count();
        }


    }
}
