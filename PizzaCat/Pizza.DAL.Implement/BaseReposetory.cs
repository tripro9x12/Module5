using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Pizza.DAL.Implement
{
    public class BaseReposetory
    {
        protected IDbConnection connection;
        public BaseReposetory()
        {
            connection = new SqlConnection(@"Data Source=tri\sqlexpress;Initial Catalog=PizzaDb;Integrated Security=True");
        }
    }
}
