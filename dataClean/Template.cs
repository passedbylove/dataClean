using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataClean
{
    public class Template
    {
        private string name;
        private string sql;
        private string[] parameters;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="sql">sql语句</param>
        public Template(string name, string sql)
        {
            this.name = name;
            this.sql = sql;
        }

        public string[] Parameters { get => parameters; set => parameters = value; }
        public string Sql { get => sql; set => sql = value; }
        public string Name { get => name; set => name = value; }

        public string FormatedSql
        {
            get {
                try
                {
                    return string.Format(@sql, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine("格式化出错:{0}",e.Message);
                }
                return string.Empty;
            }
        }
    }
}
