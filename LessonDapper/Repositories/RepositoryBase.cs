using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LessonDapper
{
    public abstract class RepositoryBase<TModel>
    {
        public string ConnectionString { get; private set; }

        
        public RepositoryBase()
        {
            ConnectionString = "Data Source=localhost;Initial Catalog=RamziDB;integrated security=true";
        }

        public List<TModel> GetAll()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    return db.Query<TModel>($"SELECT * FROM {typeof(TModel).Name?.ToUpper()}").ToList();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return null;
            }
        }
        public List<TModel> AddOne()
        {

        }
    }
}
