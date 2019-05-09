using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataClean
{
    public class Table
    {
        private string m_Name;

        public string Name { get => m_Name; set => m_Name = value; }

        public Table(String m_Name)
        {
            this.m_Name = m_Name;
        }

        public override string ToString()
        {
            return m_Name;
        }
    }
}
