using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataClean
{
    public class FieldStat
    {
        private string m_name;
        private string m_hex;
        private int m_count;
       

        public FieldStat(string m_name,string m_hex, int m_count)
        {
            this.m_name = m_name;
            this.m_hex = m_hex;
            this.m_count = m_count;
        }

        public string Name { get => m_name; set => m_name = value; }
        public int Count { get => m_count; set => m_count = value; }
        public string Hex { get => m_hex; set => m_hex = value; }

        public override string ToString()
        {
            return "FieldStat [name = "+m_name+", count = "+m_count+"]";
        }
    }
}
