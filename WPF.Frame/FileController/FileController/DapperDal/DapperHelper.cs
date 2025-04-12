using CommonModels.BllModel;
using CommonModels.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileController.DapperDal
{
    public class DapperHelper : IDapper
    {
        public string ConnectionString;
        public SimpleCRUD.Dialect SQLDialect { get; set; }
        public DapperHelper(string str,int i = 0) 
        {
            ConnectionString = str;
            SQLDialect = (SimpleCRUD.Dialect)i;
            Dapper.SimpleCRUD.SetDialect(SQLDialect);
            if (SQLDialect == SimpleCRUD.Dialect.SQLite)
                SQLiteInit();
        }
        private BllResult<string> SQLiteInit()
        {          
            string strPath = AppDomain.CurrentDomain.BaseDirectory + $"WinCC.db";
            this.ConnectionString = strPath;
            if (!System.IO.File.Exists(strPath))
            {
                var result = CreateDB(strPath);
                if (!result.Success)
                    return result;
                return CreateUserAndRole();
            }
            return BllResultFactory<string>.Sucess("Sucess");
        }

        private BllResult<string> CreateDB(string str)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=" + str))
            {
                try
                {
                    connection.Open();
                    IDbCommand dbCommand = connection.CreateCommand();
                    dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS Role(Id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE ,Name TEXT,Remark TEXT, Created datetime, CreatedBy TEXT , Updated datetime, UpdatedBy TEXT)";
                    dbCommand.ExecuteNonQuery();

                    dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS User(Id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE ,CropId TEXT ,UserName TEXT ,Password TEXT ,RoleId int ,Remark TEXT, Created datetime, CreatedBy TEXT , Updated datetime, UpdatedBy TEXT)";
                    dbCommand.ExecuteNonQuery();                   
                    return BllResultFactory<string>.Sucess("Success");
                }
                catch (Exception ex)
                {
                    return BllResultFactory<string>.Error($"发生异常:{ex.Message}");
                }
            }
        }

        private BllResult<string> CreateUserAndRole()
        {
            try
            {
                List<Role> roles = new List<Role>();
                for (int i = 0; i < 4; i++)
                {
                    Role role = new Role();
                    if (i == 0)
                        role.RoleName = "操作员";
                    if (i == 1)
                        role.RoleName = "技术员";
                    if (i == 2)
                        role.RoleName = "部门主管";
                    if (i == 3)
                        role.RoleName = "超级用户";
                    var result = SaveCommonModel(role);
                }
                User user = new User();
                user.UserName = "admin";
                user.Password = "123";
                user.RoleId = 4;
               var resultUser = SaveCommonModel(user);
                return BllResultFactory<string>.Sucess("Success");
            }
            catch (Exception ex)
            {
                return BllResultFactory<string>.Error($"发生异常:{ex.Message}");
            }
        }

        private IDbConnection GetConnection()
        {
            if (SQLDialect == SimpleCRUD.Dialect.SQLite)
                return new SQLiteConnection("Data Source=" + ConnectionString);
            else
                return new SqlConnection(ConnectionString);
        }
        public  BllResult<List<T>> GetCommonModelByCondition<T>(string v)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    List<T> temp = connection.GetList<T>(v).ToList();
                    if (temp != null && temp.Count > 0)
                    {
                        return BllResultFactory<List<T>>.Sucess(temp, "成功");
                    }
                    else
                    {
                        return BllResultFactory<List<T>>.Error("未查询到数据");
                    }
                }
                catch (Exception ex)
                {
                    return BllResultFactory<List<T>>.Error($"发生异常:{ex.Message}");
                }
            }
        }
        public  async Task<BllResult<List<T>>> GetCommonModelByConditionAsync<T>(string v)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    var temp = await connection.GetListAsync<T>(v);
                    if (temp != null && temp.ToList().Count > 0)
                    {
                        return BllResultFactory<List<T>>.Sucess(temp.ToList(), "成功");
                    }
                    else
                    {
                        return BllResultFactory<List<T>>.Error("未查询到数据");
                    }
                }
                catch (Exception ex)
                {
                    return BllResultFactory<List<T>>.Error("发生异常");
                }
            }
        }
        public  BllResult<List<T>> GetCommonModelByCondition<T>(string v, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                List<T> temp = connection.GetList<T>(v, transaction: tran).ToList();
                if (temp != null && temp.Count > 0)
                {
                    return BllResultFactory<List<T>>.Sucess(temp, "成功");
                }
                else
                {
                    return BllResultFactory<List<T>>.Error("未查询到数据");
                }
            }
            catch (Exception ex)
            {
                return BllResultFactory<List<T>>.Error("发生异常");
            }
        }
        public  async Task<BllResult<List<T>>> GetCommonModelByConditionAsync<T>(string v, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                var temp = await connection.GetListAsync<T>(v, transaction: tran);
                if (temp != null && temp.ToList().Count > 0)
                {
                    return BllResultFactory<List<T>>.Sucess(temp.ToList(), "成功");
                }
                else
                {
                    return BllResultFactory<List<T>>.Error("未查询到数据");
                }
            }
            catch (Exception ex)
            {
                return BllResultFactory<List<T>>.Error("发生异常");
            }
        }
        public  BllResult<List<T>> GetCommonModelByConditionWithZero<T>(string v)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    List<T> temp = connection.GetList<T>(v).ToList();
                    if (temp != null)
                    {
                        return BllResultFactory<List<T>>.Sucess(temp, "成功");
                    }
                    else
                    {
                        return BllResultFactory<List<T>>.Error("未查询到数据");
                    }
                }
                catch (Exception ex)
                {
                    return BllResultFactory<List<T>>.Error("发生异常");
                }
            }
        }
        public  BllResult<int?> SaveCommonModel<T>(T model)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    return BllResultFactory<int?>.Sucess(connection.Insert<T>(model), "成功");
                }
                catch (Exception ex)
                {
                    return BllResultFactory<int?>.Error($"发生异常:{ex.Message}");
                }
            }
        }
        public  BllResult<int?> SaveCommonModel<T>(T model, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                return BllResultFactory<int?>.Sucess(connection.Insert<T>(model, transaction: tran), "成功");
            }
            catch (Exception ex)
            {
                return BllResultFactory<int?>.Error($"发生异常:{ex.Message}");
            }
        }
        public  BllResult UpdateCommonModel<T>(T model)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    connection.Update<T>(model);
                    return BllResultFactory.Sucess("成功");
                }
                catch (Exception ex)
                {
                    return BllResultFactory.Error(ex.Message);
                }
            }
        }
        public  BllResult DeleteCommonModelByIds<T>(List<int> list)
        {
            using (IDbConnection connection = GetConnection())
            {
                IDbTransaction tran = null;
                try
                {
                    connection.Open();
                    tran = connection.BeginTransaction();
                    connection.DeleteList<T>("where id in @ids", new { ids = list }, tran);
                    tran.Commit();
                    return BllResultFactory.Sucess("成功");
                }
                catch (Exception ex)
                {
                    tran?.Rollback();
                    return BllResultFactory.Error($"删除失败：{ex.Message}");
                }
            }
        }
        public BllResult DeleteCommonModelById<T>(int id)
        {
            using (IDbConnection connection = GetConnection())
            {
                IDbTransaction tran = null;
                try
                {
                    connection.Open();
                    tran = connection.BeginTransaction();
                    connection.Delete<T>(id, tran);
                    tran.Commit();
                    return BllResultFactory.Sucess("成功");
                }
                catch (Exception ex)
                {
                    tran?.Rollback();
                    return BllResultFactory.Error($"删除失败：{ex.Message}");
                }
            }
        }
        public  BllResult<List<T>> GetCommonModeByPageCondition<T>(int pageNumber, int pageSize, string condition, string orderBy)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    var a = connection.GetListPaged<T>(pageNumber, pageSize, condition, orderBy).ToList();
                    return BllResultFactory<List<T>>.Sucess(a, "成功");
                }
                catch (Exception ex)
                {
                    return BllResultFactory<List<T>>.Error($"未查询到数据:{ex.Message}");
                }
            }
        }
        public  BllResult<int> GetCommonModelCount<T>(string sql)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    int a = connection.RecordCount<T>(sql);
                    return BllResultFactory<int>.Sucess(a, "");
                }
                catch (Exception ex)
                {
                    return BllResultFactory<int>.Error($"未查询到数据:{ex.Message}");
                }
            }
        }
        public  BllResult<int> GetCommonModelCount<T>(string sql, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                int a = connection.RecordCount<T>(sql, transaction: tran);
                return BllResultFactory<int>.Sucess(a, "");
            }
            catch (Exception ex)
            {
                return BllResultFactory<int>.Error($"未查询到数据:{ex.Message}");
            }
        }
        public  BllResult<int> ExcuteCommonSqlForInsertOrUpdate(string sql)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    return BllResultFactory<int>.Sucess(connection.Execute(sql), "成功)");
                }
                catch (Exception ex)
                {
                    return BllResultFactory<int>.Error("出现异常：" + ex.Message);
                }
            }
        }
        public  BllResult<int> ExcuteCommonSqlForInsertOrUpdate(string sql, object param)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    return BllResultFactory<int>.Sucess(connection.Execute(sql, param), "成功)");
                }
                catch (Exception ex)
                {
                    return BllResultFactory<int>.Error("出现异常：" + ex.Message);
                }
            }
        }
        public  async Task<BllResult<int?>> SaveCommonModelAsync<T>(T model)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    var a = await connection.InsertAsync<T>(model);
                    return BllResultFactory<int?>.Sucess(a, "成功");
                }
                catch (Exception ex)
                {
                    return BllResultFactory<int?>.Error("发生异常");
                }
            }
        }
        public  async Task<BllResult<int?>> SaveCommonModelAsync<T>(T model, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                var a = await connection.InsertAsync<T>(model, transaction: tran);
                return BllResultFactory<int?>.Sucess(a, "成功");
            }
            catch (Exception ex)
            {
                return BllResultFactory<int?>.Error("发生异常");
            }
        }
        public  async Task<BllResult> UpdateCommonModelAsync<T>(T model)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    await connection.UpdateAsync<T>(model);
                    return BllResultFactory.Sucess("成功");
                }
                catch (Exception ex)
                {
                    return BllResultFactory.Error(ex.Message);
                }
            }
        }
        public  BllResult UpdateCommonModel<T>(T model, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                connection.Update<T>(model, transaction: tran);
                return BllResultFactory.Sucess("成功");
            }
            catch (Exception ex)
            {
                return BllResultFactory.Error(ex.Message);
            }
        }
        public  async Task<BllResult> UpdateCommonModelAsync<T>(T model, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                await connection.UpdateAsync<T>(model, tran);
                return BllResultFactory.Sucess("成功");
            }
            catch (Exception ex)
            {
                return BllResultFactory.Error(ex.Message);
            }
        }
        public  async Task<BllResult> DeleteCommonModelByIdsAsync<T>(List<int> list)
        {
            using (IDbConnection connection = GetConnection())
            {
                IDbTransaction tran = null;
                try
                {
                    connection.Open();
                    tran = connection.BeginTransaction();
                    await connection.DeleteListAsync<T>("where id in @ids", new { ids = list }, tran);
                    tran.Commit();
                    return BllResultFactory.Sucess("成功");
                }
                catch (Exception ex)
                {
                    tran?.Rollback();
                    return BllResultFactory.Error($"删除失败：{ex.Message}");
                }
            }
        }
        public  BllResult DeleteCommonModelByIds<T>(List<int> list, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                connection.Open();
                tran = connection.BeginTransaction();
                connection.DeleteList<T>("where id in @ids", new { ids = list }, tran);
                tran.Commit();
                return BllResultFactory.Sucess("成功");
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BllResultFactory.Error($"删除失败：{ex.Message}");
            }
        }
        public  async Task<BllResult> DeleteCommonModelByIdsAsync<T>(List<int> list, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                connection.Open();
                tran = connection.BeginTransaction();
                await connection.DeleteListAsync<T>("where id in @ids", new { ids = list }, tran);
                tran.Commit();
                return BllResultFactory.Sucess("成功");
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BllResultFactory.Error($"删除失败：{ex.Message}");
            }
        }
        public  async Task<BllResult<List<T>>> GetCommonModeByPageConditionAsync<T>(int pageNumber, int pageSize, string condition, string orderBy)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    var a = await connection.GetListPagedAsync<T>(pageNumber, pageSize, condition, orderBy);
                    return BllResultFactory<List<T>>.Sucess(a.ToList(), "成功");
                }
                catch (Exception ex)
                {
                    return BllResultFactory<List<T>>.Error($"未查询到数据:{ex.Message}");
                }
            }
        }
        public  BllResult<List<T>> GetCommonModeByPageCondition<T>(IDbConnection connection, IDbTransaction tran, int pageNumber, int pageSize, string condition, string orderBy)
        {
            try
            {
                var a = connection.GetListPaged<T>(pageNumber, pageSize, condition, orderBy);
                return BllResultFactory<List<T>>.Sucess(a.ToList(), "成功");
            }
            catch (Exception ex)
            {
                return BllResultFactory<List<T>>.Error($"未查询到数据:{ex.Message}");
            }
        }
        public  async Task<BllResult<List<T>>> GetCommonModeByPageConditionAsync<T>(IDbConnection connection, IDbTransaction tran, int pageNumber, int pageSize, string condition, string orderBy)
        {
            try
            {
                var a = await connection.GetListPagedAsync<T>(pageNumber, pageSize, condition, orderBy);
                return BllResultFactory<List<T>>.Sucess(a.ToList(), "成功");
            }
            catch (Exception ex)
            {
                return BllResultFactory<List<T>>.Error($"未查询到数据:{ex.Message}");
            }
        }
        public  async Task<BllResult<int>> ExcuteCommonSqlForInsertOrUpdateAsync(string sql)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    return BllResultFactory<int>.Sucess(await connection.ExecuteAsync(sql), "成功)");
                }
                catch (Exception ex)
                {
                    return BllResultFactory<int>.Error("出现异常：" + ex.Message);
                }
            }
        }
        public  BllResult<int> ExcuteCommonSqlForInsertOrUpdate(string sql, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                return BllResultFactory<int>.Sucess(connection.Execute(sql, transaction: tran), "成功)");
            }
            catch (Exception ex)
            {
                return BllResultFactory<int>.Error("出现异常：" + ex.Message);
            }
        }
        public  async Task<BllResult<int>> ExcuteCommonSqlForInsertOrUpdateAsync(string sql, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                return BllResultFactory<int>.Sucess(await connection.ExecuteAsync(sql, transaction: tran), "成功)");
            }
            catch (Exception ex)
            {
                return BllResultFactory<int>.Error("出现异常：" + ex.Message);
            }
        }
        public  async Task<BllResult<int>> ExcuteCommonSqlForInsertOrUpdateAsync(string sql, object param)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    return BllResultFactory<int>.Sucess(await connection.ExecuteAsync(sql, param), "成功)");
                }
                catch (Exception ex)
                {
                    return BllResultFactory<int>.Error("出现异常：" + ex.Message);
                }
            }
        }
        public  BllResult<int> ExcuteCommonSqlForInsertOrUpdate(string sql, object param, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                return BllResultFactory<int>.Sucess(connection.Execute(sql, param, tran), "成功)");
            }
            catch (Exception ex)
            {
                return BllResultFactory<int>.Error("出现异常：" + ex.Message);
            }
        }
        public  async Task<BllResult<int>> ExcuteCommonSqlForInsertOrUpdateAsync(string sql, object param, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                return BllResultFactory<int>.Sucess(await connection.ExecuteAsync(sql, param, tran), "成功)");
            }
            catch (Exception ex)
            {
                return BllResultFactory<int>.Error("出现异常：" + ex.Message);
            }
        }
        public  async Task<BllResult<List<T>>> GetCommonModelByConditionWithZeroAsync<T>(string v)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    List<T> temp = (await connection.GetListAsync<T>(v)).ToList();
                    if (temp != null)
                    {
                        return BllResultFactory<List<T>>.Sucess(temp, "成功");
                    }
                    else
                    {
                        return BllResultFactory<List<T>>.Error("未查询到数据");
                    }
                }
                catch (Exception ex)
                {
                    return BllResultFactory<List<T>>.Error("发生异常");
                }
            }
        }
        public  BllResult<List<T>> GetCommonModelByConditionWithZero<T>(string v, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                List<T> temp = connection.GetList<T>(v).ToList();
                if (temp != null)
                {
                    return BllResultFactory<List<T>>.Sucess(temp, "成功");
                }
                else
                {
                    return BllResultFactory<List<T>>.Error("未查询到数据");
                }
            }
            catch (Exception ex)
            {
                return BllResultFactory<List<T>>.Error("发生异常");
            }
        }
        public  async Task<BllResult<List<T>>> GetCommonModelByConditionWithZeroAsync<T>(string v, IDbConnection connection, IDbTransaction tran)
        {
            try
            {
                List<T> temp = (await connection.GetListAsync<T>(v)).ToList();
                if (temp != null)
                {
                    return BllResultFactory<List<T>>.Sucess(temp, "成功");
                }
                else
                {
                    return BllResultFactory<List<T>>.Error("未查询到数据");
                }
            }
            catch (Exception ex)
            {
                return BllResultFactory<List<T>>.Error("发生异常");
            }
        }

        #region User

        #endregion
    }
}
