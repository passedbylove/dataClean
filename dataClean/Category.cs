using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataClean
{
    /// <summary>
    /// 数据库清洗类型
    /// </summary>
    public class Category
    {
        private string m_name;
        private string m_code;


        public Category(string m_name, String m_code)
        {
            this.m_name = m_name;
            this.m_code = m_code;
        }
        public string Name { get => m_name; set => m_name = value; }
        public string Code { get => m_code; set => m_code = value; }

        public override string ToString()
        {
            return m_name;
        }
    }
}
