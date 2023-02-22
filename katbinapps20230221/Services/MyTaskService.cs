using Microsoft.Extensions.Configuration;
using katbinapps20230221.Models;
using System.Data.SqlClient;

namespace katbinapps20230221.Services
{
    public class MyTaskService : IMyTaskService
    {
        private readonly IConfiguration _configuration;

        public MyTaskService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SQLConnectionString"));
        }

        public List<MyTask> GetMyTasks()
        {
            List<MyTask> _task_list = new List<Models.MyTask>();
            string statement = "Select MyTaskId, MyTaskTitle, MyTaskDetail from MyTasks";
            SqlConnection conn = GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    MyTask _task = new MyTask()
                    {
                        MyTaskId = reader.GetInt32(0),
                        MyTaskTitle = reader.GetString(1),
                        MyTaskDetail = reader.GetString(2)
                    };
                    _task_list.Add(_task);
                }
            }
            conn.Close();
            return _task_list;
        }
    }
}
