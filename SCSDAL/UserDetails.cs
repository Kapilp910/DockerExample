using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DataContract;

namespace SCSDAL
{
    public class UserDetails
    {

        public string TableName { get { return "user_info"; } }

        public List<user_info> GetAllUserList()
        {
            try
            {
                BaseRepository baseRepository = new BaseRepository();

                List<user_info> objUserList = baseRepository.GetData<user_info>(string.Format("select * from {0}", TableName));

                return objUserList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool UpdateUserDetails(user_info user_Info)
        {
            try
            {
                BaseRepository baseRepository = new BaseRepository();

                #region Check Modified User Name already into our dataabse 
                string query = string.Format("select * from {0} where ID <> {1} and Name = '{2}'", TableName, user_Info.ID, user_Info.Name);

               List<user_info> user_InfosList =  baseRepository.GetData<user_info>(query);

                #endregion


                if (user_InfosList.Count() == 0)
                {
                    query = string.Format("UPDATE {2} SET Name = '{0}' WHERE ID = {1};", user_Info.Name, user_Info.ID, TableName);



                    int modifiedRecords = baseRepository.ModifiedData<user_info>(query);

                    if (modifiedRecords > 0)
                        return true;
                    else
                        return false;
                }
                else
                    throw new Exception("Please provide another name, this name is already exists.");


            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool SaveUserDetails(user_info user_Info)
        {
            try
            {

                if (GetUserDetailByName(user_Info.Name) == null)
                {

                    string query = string.Format("Insert into {1} values(NULL,'{0}')", user_Info.Name, TableName);

                    BaseRepository baseRepository = new BaseRepository();

                    int modifiedRecords = baseRepository.ModifiedData<user_info>(query);

                    return true;

                }
                else
                    throw new Exception("User already register into our system.");

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        public user_info GetUserDetailByName(string UserName)
        {
            try
            {
                string query = string.Format("select * from {1} where Name = '{0}'", UserName, TableName);

                BaseRepository baseRepository = new BaseRepository();

                List<user_info> objUsers = baseRepository.GetData<user_info>(query);

                if (objUsers != null && objUsers.Count() > 0)
                {
                    return objUsers.FirstOrDefault();
                }
                else
                    return null;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        public user_info GetUserDetailByID(int UserId)
        {
            try
            {
                string query = string.Format("select * from {1} where ID = {0}", UserId, TableName);

                BaseRepository baseRepository = new BaseRepository();

                List<user_info> objUsers = baseRepository.GetData<user_info>(query);

                if (objUsers != null && objUsers.Count() > 0)
                {
                    return objUsers.FirstOrDefault();
                }
                else
                    return null;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

    }



}
