using Mirabeau.MySql.Library;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataClean
{
    public class TaskScheduler
    {
        public string host;
        public string port;
        public string user;
        public string passwd;
        //https://stackoverflow.com/questions/34912698/what-determines-the-number-of-threads-for-a-taskfactory-spawned-jobs
        //
        private Hashtable hashTable = new Hashtable();


        public TaskScheduler(string host, string port, string user, string passwd)
        {
            this.host = host;
            this.port = port;
            this.user = user;
            this.passwd = passwd;
        }

        /// <summary>
        /// 任务列表
        /// </summary>
        ConcurrentBag<Task> taskQueue = new ConcurrentBag<Task>();


        public void RunWithParallel(string schema, string table, string[] sqls)
        {
            var tasks = new List<TaskWrapper>();

            foreach (string sql in sqls)
            {
                tasks.Add(new TaskWrapper(schema, table, sql));
                //taskQueue.Add(Task.Run(() => CallLaterAsync(schema, table, sql)));
            }

            Parallel.ForEach(tasks, new ParallelOptions { MaxDegreeOfParallelism = 50 },
            task =>
            {
                // logic
                CallLaterAsync(task.Schema, task.Table, task.Sql);
            });
        }

        public void RunWithMaxLimit(string schema, string table, string[] sqls)
        {
            var options = new ParallelOptions { MaxDegreeOfParallelism = 50 };
            var listOfActions = new List<Action>();
            foreach (string sql in sqls)
            {            
                // Note that we create the Action here, but do not start it.
                listOfActions.Add(() => CallLaterAsync(schema, table, sql));
            }
            Parallel.Invoke(options, listOfActions.ToArray());
        }
        public void Run(string schema, string table, List<string> sqls)
        {
            Run(schema, table, sqls.ToArray());
        }

        public void Run(string schema, string table, string[] sqls)
        {
            Run(schema, table, null, sqls);
        }

        public void RunWithResultExtractor(string schema, string table, string []extractSqls)
        {
            foreach (string extractSql in extractSqls)
            {
                taskQueue.Add(
                    Task.Run( 
                        () => ExtractSqlAsync(schema, table, extractSql)
                    )
                );                
            }
        }

        private async Task ExtractSqlAsync(string schema, string table, string extractSql)
        {
            var task = ExecuteStatSql(schema, table, extractSql);
            if (await Task.WhenAny(task, Task.Delay(Int32.MaxValue)) == task)
            {
                if (task.IsFaulted)
                {

                }

                if (task.IsCanceled)
                {

                }

                // 任务未超时
                if (task.IsCompleted)
                {
                    List<string> updateSqls = task.Result;
                    if (updateSqls.Count > 0)
                    {
                        Console.WriteLine("{0}条数据待更新!", updateSqls.Count);
                        Run(schema, table, updateSqls);
                    }
                    else {
                        Console.WriteLine("没有数据需要更新!");
                    }

                    /* if (task.Status == TaskStatus.RanToCompletion || task.Status == TaskStatus.Faulted || task.Status == TaskStatus.Canceled)
                        {
                            task.Dispose();
                        }*/
                }
            }
        }

        async Task<List<string>> ExecuteStatSql(string schema, string table, string extractSql)
        {
            Console.WriteLine("正在统计待更新的数据{0}.{1} 语句:{2}", schema, table, extractSql);
            List<string> list = new List<string>();

            await Task.Run(() =>
            {              
                list.AddRange(Select(host, user, passwd, schema, table, extractSql));
            });

            return list;
        }

        private List<string> Select(string host, string user, string passwd, string schema, string table, string sql)
        {
            List<string> list = new List<string>();
            String connectionString = String.Format("Data Source = {0}; User ID = {1}; Password = {2}; DataBase = {3}; charset='utf8'", host, user, passwd, schema);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn)
                {
                    CommandTimeout = 0
                };

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(Convert.ToString(reader[0]));
                }
            }
            return list;
        }


        [Obsolete]
        private List<string> Select2(string host, string user, string passwd, string schema, string table, string sql)
        {
            List<string> list = new List<string>();
            MySqlConnection conn = (MySqlConnection)hashTable[host];
            if (conn == null)
            {
                String connectionString = String.Format("Data Source = {0}; User ID = {1}; Password = {2}; DataBase = {3}; charset='utf8'", host, user, passwd, schema);
                conn = new MySqlConnection(connectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();

                }
                hashTable[host] = conn;
            }

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.CommandTimeout = 0;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(Convert.ToString(reader[0]));
                }
            }
            return list;
        }

        public void Run(string schema, string table, string where,string[] sqls)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string sql in sqls)
            {
                builder.Append(sql);
                builder.Append(";");
            }

            Console.WriteLine(builder);
            using (StreamWriter stream = new StreamWriter("sql.txt",true))
            {
                stream.WriteLine(builder.ToString());
            }

            taskQueue.Add(
                Task.Run(
                    () => CallLaterAsync(schema, table, builder.ToString())
                )
            );
        }

        public void Run(string schema, string table, string sql)
        {
            taskQueue.Add(
                Task.Run(
                    () => CallLaterAsync(schema,table,sql)
                )
            );
        }

        /// <summary>
        /// 将推送任务添加到队列中稍后执行
        /// </summary>
        /// <param name="sql">格式化以后的json</param>
        /// <returns></returns>
        public async Task CallLaterAsync(string schema,string table, string sql)
        {
        
            var task = BatchUpdate(schema, table,sql);
            if (await Task.WhenAny(task, Task.Delay(Int32.MaxValue)) == task)
            {
                if (task.IsFaulted)
                {
                       
                }

                if (task.IsCanceled)
                {
                        
                }

                // 任务未超时
                if (task.IsCompleted)
                {
                    //执行不成功
                    if (!task.Result)
                    {
                           
                      
                        HandleError();
                    }
                    //执行成功
                    else
                    {
                           
                    }

                    /* if (task.Status == TaskStatus.RanToCompletion || task.Status == TaskStatus.Faulted || task.Status == TaskStatus.Canceled)
                        {
                            task.Dispose();
                        }*/
                }
            }
              
           
        }

        private void HandleError()
        {
            
        }

        /// <summary>
        /// 发送消息给服务器
        /// </summary>
        /// <param name="sql">json数据</param>
        async Task<bool> BatchUpdate(string schema,string table,string sql)
        {

            Console.WriteLine("正在执行字段更新{0}.{1} sql:{2}",schema,table,sql);
            bool isSuccess = false;

            await Task.Run(() =>
            {               
                Update(host, user, passwd, schema, table, sql);
                return true;
            });

            return isSuccess;

        }

        int Update(String host, String user, String passwd, String schema, string table, String sql)
        {
            String connectionString = String.Format("Data Source = {0}; User ID = {1}; Password = {2}; DataBase = {3}; charset='utf8'", host, user, passwd, schema);
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con) { CommandTimeout = 0 };
                    var task = cmd.ExecuteNonQueryAsync();
                    int effected = task.Result;
                    Console.WriteLine("更新{0}.{1} {2} sql:{3}条记录", schema, table, sql, effected);
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("更新失败:{0}",e.Message);
                return 0;
            }
        }

        [Obsolete]
        int Update2(String host, String user, String passwd, String schema, string table,String sql)
        {
            MySqlConnection conn  = (MySqlConnection)hashTable[host];
            if (conn == null)
            {
                String connectionString = String.Format("Data Source = {0}; User ID = {1}; Password = {2}; DataBase = {3}; charset='utf8'", host, user, passwd, schema);
                conn = new MySqlConnection(connectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();

                }
                hashTable[host] = conn;
            }

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandTimeout = 0;
            var task = cmd.ExecuteNonQueryAsync();
            int effected = task.Result;
            Console.WriteLine("更新{0}.{1} {2} sql:{3}条记录", schema, table, sql,effected);
            return 0;
        }       
    }
}
