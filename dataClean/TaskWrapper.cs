using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataClean
{
    public class TaskWrapper
    {
        private string schema;
        private string table;
        private string sql;

        public TaskWrapper(string schema, string table, string sql)
        {
            this.schema = schema;
            this.table = table;
            this.sql = sql;
        }
        public string Schema { get => schema; set => schema = value; }
        public string Table { get => table; set => table = value; }
        public string Sql { get => sql; set => sql = value; }
    }
}
