using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace dataClean
{
    /// <summary>
    /// 清洗载荷
    /// </summary>
    public class Payload
    {
        private string name;
        private string m_from;
        private string m_to;
        //替换规则
        private string m_rules;

        private static Payload instance = new Payload();
        private string m_category;

        public static Payload Instance
        {
            get {
                return instance;
            }
        }

        public Payload()
        { }

        public Payload(string from, string to) : this(null, from, to)
        {
        }

        public Payload(char from, char to) : this(null, from, to)
        {

        }

        public Payload(string from, char to) : this(from, Convert.ToString(to))
        {
        }

        public Payload(char from, string to) : this(Convert.ToString(from), to)
        { }

        public Payload(string name, char from, char to) : this(name, Convert.ToString(from), Convert.ToString(to))
        {

        }

        public Payload(string name, char from, char to,string rules):this(name,from,to)
        {
            this.m_rules = rules;
        }

        public Payload(string name, string from, string to)
        {
            this.name = name;
            this.m_from = from;
            this.m_to = to;
        }

        public Payload(string name, string from, string to,string rules):this(name,from,to)
        {
            this.m_rules = rules;
        }

        public Payload(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
        public string To { get => m_to; set => m_to = value; }
        public string From { get => m_from; set => m_from = value; }//https://github.com/be5invis/Iosevka/issues/121

        public string Rules { get => m_rules; set => m_rules = value; }

        public string Category { get => m_category; set => m_category = value; }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("PayLoad [");
            if (!string.IsNullOrEmpty(name))
            {
                builder.Append(name);
                builder.Append((char)32);
            }

            builder.Append("from = ");
            builder.Append(m_from);

            builder.Append(" to = ");
            builder.Append(m_to);

            builder.Append("]");

            return builder.ToString();
        }

        public string[] LoadStatFactory(string code,string[] parameters)
        {
            
            var tpls = LoadTemplateFactory(code);

            string[] sqls = new string[tpls.Length];

            for (int i = 0; i < tpls.Length; i++)
            {
                Template template = tpls[i];
                
                template.Parameters = parameters;

                sqls[i] = template.FormatedSql;
            }

            return sqls;
        }

        Template[] LoadTemplateFactory(string code)
        {
            return LoadTemplate(Environment.CurrentDirectory + "\\templates.xml");
        }

        Template[] LoadTemplate(string file)
        {
            List<Template> ltTemplates = new List<Template>();
            if (File.Exists(file))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                XmlElement root = null;
                root = doc.DocumentElement;

                XmlNodeList listNodes = null;
                listNodes = root.SelectNodes("/templates/template");
                foreach (XmlNode node in listNodes)
                {
                    XmlNode nameNode = node.SelectSingleNode("name");
                    XmlNode sqlNode = node.SelectSingleNode("sql");

                    string name = nameNode.InnerText;
                    string sql = sqlNode.InnerText;

                    Template tpl = new Template(name,sql);
                    ltTemplates.Add(tpl);                                                         
                }
            }
            return ltTemplates.ToArray();
        }




        public Payload[] LoadPayLoadFactory(string code)
        {
            List<Payload> ltPayLoads = new List<Payload>();
            var all = LoadProfile(Environment.CurrentDirectory + "\\payloads.xml");

            Payload payload = null;

            switch (code)
            {
                case "phone":
                    ltPayLoads.AddRange(Phone());
                    foreach (Payload thePayload in all)
                    {
                        if ("phone".Equals(thePayload.Category))
                        {
                            ltPayLoads.Add(thePayload);
                        }
                    }
                    break;

                case "halfwidth":
                    ltPayLoads.AddRange(FullWidth2HalfWidth());
                    break;

                case "default":
                    foreach (Payload thePayload in all)
                    {
                        if ("all".Equals(thePayload.Category))
                        {
                            ltPayLoads.Add(thePayload);
                        }
                    }
                    break;

                case "upper":
                    payload = new Payload("upper");
                    payload.Rules = "upper";
                    ltPayLoads.Add(payload);
                    break;


                case "lower":
                    payload = new Payload("lower");
                    payload.Rules = "lower";
                    ltPayLoads.Add(payload);
                    break;

                case "ltrim":
                    payload = new Payload("ltrim");
                    payload.Rules = "ltrim";
                    ltPayLoads.Add(payload);
                    break;

                case "rtrim":
                    payload = new Payload("rtrim");
                    payload.Rules = "rtrim";
                    ltPayLoads.Add(payload);
                    break;

                case "ltrimr":
                    payload = new Payload("ltrimr");
                    payload.Rules = "ltrimr";
                    ltPayLoads.Add(payload);
                    break;
            }

            return ltPayLoads.ToArray();
        }

        Payload[] FullWidth2HalfWidth()
        {
            List<Payload> ltPayLoads = new List<Payload>();

            //Payload[] payloads = new Payload[95];
            
            //ascii中可视字符(不包含空格 32 ) \u3000 半角\u0020
            for (int i = 33; i <= 126; i++)
            {
                char ch = (char)i;
                Payload payload = null;

                if (ch == EscapeCharacter.ch1 || ch == EscapeCharacter.ch2 || ch == EscapeCharacter.ch3 ||
                    ch == EscapeCharacter.ch4 || ch == EscapeCharacter.ch5)
                {
                    //payloads[i - 33] = new Payload(ToSBC(ch), new string(new char [] { '\\',ch}));
                    payload = new Payload(ToSBC(ch), new string(new char[] { '\\', ch }));
                }
                else
                {
                    payload = new Payload(ToSBC(ch), ch);
                }
                payload.Name = "fullWidth to half Width";
                payload.Rules = "replace";
                ltPayLoads.Add(payload);

            }
            var customPayload = new Payload("0xE38080", " ");
            customPayload.Rules = "replace";
            ltPayLoads.Add(customPayload);
            return ltPayLoads.ToArray();
        }



        Payload[] Phone()
        {
            List<Payload> ltPayLoads = new List<Payload>();
            //0-9
            for (int i = 48; i <= 57; i++)
            {
                char ch = (char)i;
                Payload payload = new Payload("replace fullwidth",ToSBC(ch), ch,"replace");
                ltPayLoads.Add(payload);
            }
            //https://www.fileformat.info/info/unicode/char/2014/index.htm
            ltPayLoads.AddRange(new Payload[] {
                new Payload("invalid","—","-","replace")                
            });
            return ltPayLoads.ToArray();
        }

        Payload[] LoadProfile(string file)
        {
            List<Payload> ltPayLoads = new List<Payload>();
            if (File.Exists(file))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                XmlElement root = null;
                root = doc.DocumentElement;

                XmlNodeList listNodes = null;
                listNodes = root.SelectNodes("/payloads/payload");
                foreach (XmlNode node in listNodes)
                {
                    XmlNode nameNode = node.SelectSingleNode("name");
                    XmlNode fromNode = node.SelectSingleNode("from");
                    XmlNode toNode = node.SelectSingleNode("to");
                    XmlNode matchNode = node.SelectSingleNode("match");
                    XmlNode categoryNode = node.SelectSingleNode("category");

                    string name = nameNode.InnerText;
                    string from = fromNode.InnerText;
                    string to = toNode == null ? null : toNode.InnerText;
                    string match = matchNode.InnerText;
                    string category = categoryNode.InnerText;

                    Payload payload = new Payload(name, from, to);
                    payload.Rules = match;
                    payload.Category = category;
                    ltPayLoads.Add(payload);
                }
            }
            return ltPayLoads.ToArray();
        }


        [Obsolete]
        public Payload[] Default
        {
            get {

                List<Payload> ltPayLoads = new List<Payload>();
                Payload[] payloads = new Payload[94];
                //ascii中可视字符(不包含空格 32 ) \u3000 半角\u0020
                for (int i = 33; i <= 126; i++)
                {
                    char ch = (char)i;
                    Payload payload = null;
                    
                    if (ch == EscapeCharacter.ch1 || ch == EscapeCharacter.ch2 || ch == EscapeCharacter.ch3 ||
                        ch == EscapeCharacter.ch4 || ch == EscapeCharacter.ch5)
                    {
                        //payloads[i - 33] = new Payload(ToSBC(ch), new string(new char [] { '\\',ch}));
                        payload = new Payload(ToSBC(ch), new string(new char[] { '\\', ch }));
                    }
                    else {
                        payload = new Payload(ToSBC(ch), ch);
                    }
                    payload.Name = "fullWidth to half Width";
                    ltPayLoads.Add(payload);

                }

                string file = Environment.CurrentDirectory + "\\payloads.xml";
                ltPayLoads.AddRange(LoadProfile(file));
                /*if (File.Exists(file))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(file);

                    XmlElement root = null;
                    root = doc.DocumentElement;

                    XmlNodeList listNodes = null;
                    listNodes = root.SelectNodes("/payloads/payload");
                    foreach (XmlNode node in listNodes)
                    {
                        XmlNode nameNode = node.SelectSingleNode("name");
                        XmlNode fromNode = node.SelectSingleNode("from");
                        XmlNode toNode = node.SelectSingleNode("to");
                        XmlNode matchNode = node.SelectSingleNode("match");

                        string name = nameNode.InnerText;
                        string from = fromNode.InnerText;
                        string to = toNode==null?null:toNode.InnerText;
                        string match = matchNode.InnerText;

                        Payload payload = new Payload(name,from, to);
                        payload.Rules = match;
                        ltPayLoads.Add(payload);
                    }
                }*/

                return ltPayLoads.ToArray();
            }
        }

        //left trim,right trim
        //upper,LOWER

        //public string ToHexString(string str)
        //{
        //    var sb = new StringBuilder();
        //    sb.Append("0x");
        //    var bytes = Encoding.Unicode.GetBytes(str);
        //    foreach (var t in bytes)
        //    {
        //        sb.Append(t.ToString("X2"));
        //    }

        //    return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        //}
        public char ToSBC(char input)
        {
            if (input == 32)
            {
                input = (char)12288;

            }
            if (input < 127)
            {
                input = (char)(input + 65248);
            }
            return input;
        }

        public string BuildSql(string schema, string table, string column)
        {
            return BuildSql(schema, table, column, this);
        }
        public string BuildSql(string schema, string table, string column,Payload payload)
        {
            string from = payload.From;
            string to = payload.To;
            string rules = payload.Rules;

            if ("full".Equals(rules))
            {
                if (string.IsNullOrEmpty(from))
                {
                    if (!string.IsNullOrEmpty(to))
                    {
                        //如果替换成的值是经过hex的
                        if (Regex.IsMatch(to, "0x[a-f0-9]{2,}", RegexOptions.IgnoreCase))
                        {
                            return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = {3} where `{4}` = ''", schema, table, column, to, column);
                        }
                        else
                        {
                            return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = '{3}' where `{4}` = ''", schema, table, column, to, column);
                        }
                    }
                    else {
                        return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = null where `{3}` = ''", schema, table, column,column);
                    }
                }

                if (String.IsNullOrEmpty(to))
                {
                    //根据hex更新,例如 0xab5f
                    if(Regex.IsMatch(from, "0x[a-f0-9]{2,}", RegexOptions.IgnoreCase))
                        return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = null where `{3}` = {4}", schema, table, column, column, from);

                    //普通文本转hex再更新
                    string hex = MySqlHexDecimalEncoding.hex(from);                    
                    return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = null where `{3}` = {4}", schema, table, column, column, hex);
                }
                else
                {
                    //如果被替换的值经过hex的
                    if (Regex.IsMatch(from, "0x[a-f0-9]{2,}", RegexOptions.IgnoreCase))
                    {
                        //如果替换成的值是经过hex的    
                        if (Regex.IsMatch(to, "0x[a-f0-9]{2,}", RegexOptions.IgnoreCase))
                        {
                            return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = {3} where `{4}` = {5}", schema, table, column, to, column, from);
                        }
                        else
                        {
                            return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = '{3}' where `{4}` = {5}", schema, table, column, to, column, from);
                        }
                    }
                    else
                    {
                        //如果替换成的值是经过hex的
                        if (Regex.IsMatch(to, "0x[a-f0-9]{2,}", RegexOptions.IgnoreCase))
                        {
                            return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = {3} where `{4}` = {5}", schema, table, column, to, column, MySqlHexDecimalEncoding.hex(from));
                        }
                        else
                        {
                            return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = '{3}' where `{4}` = {5}", schema, table, column, to, column, MySqlHexDecimalEncoding.hex(from));
                        }
                    }
                }
            }
            if ("replace".Equals(rules))
            {

                //如果替换成为null
                if (string.IsNullOrEmpty(to)) {
                    if (Regex.IsMatch(from, "0x[a-f0-9]{2,}", RegexOptions.IgnoreCase))
                    {
                        return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = replace(`{2}`,{3},{4}) where `{2}` like concat('%',{3},'%')",
                          schema, table, column, from, to);
                    }
                    else
                    {
                        return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = replace(`{2}`,'{3}','{4}') where `{2}` like concat('%{3}%')",
                        schema, table, column, from, to);
                    }
                }

                //if (String.IsNullOrEmpty(to))
                //{
                //如果被替换的值经过hex的
                if (Regex.IsMatch(from, "0x[a-f0-9]{2,}", RegexOptions.IgnoreCase))
                {
                    //如果替换成的值是经过hex的
                    if (Regex.IsMatch(to, "0x[a-f0-9]{2,}", RegexOptions.IgnoreCase))
                    {

                        return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = replace(`{3}`,{4},{5}) where `{6}` like concat('%',{7},'%')",
                            schema, table, column, column, from, to, column, from);
                    }
                    else
                    {
                        return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = replace(`{3}`,{4},'{5}') where `{6}` like concat('%{7}%')",
                        schema, table, column, column, from, to, column, from);
                    }
                }
                else
                {                    
                    //如果替换成的值是经过hex的
                    if (Regex.IsMatch(to, "0x[a-f0-9]{2,}", RegexOptions.IgnoreCase))
                    {

                        return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = replace(`{3}`,'{4}',{5}) where `{6}` like concat('%{7}%')",
                            schema, table, column, column, from, to, column, from);
                    }
                    else
                    {
                        return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = replace(`{3}`,'{4}','{5}') where `{6}` like concat('%{7}%')",
                        schema, table, column, column, from, to, column, from);
                    }
                }
                   
                //return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = replace(`{3}`,'{4}','{5}') where `{6}` like '%{7}%'",
                  //      schema, table, column, column, from, to, column, from);
                //}
                //else
                //{
                //return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = replace(`{2}`,'{3}','{4}')' where `{4}` = '{5}'", schema, table, column, to, column, from);
                //}

            }
            if ("regexp".Equals(rules))
            {
                //REGEXP '\\.[0-9]{3}'
            }
            //toupper or lower

            if ("upper".Equals(rules)||"lower".Equals(rules))
            {
                return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = {3}(`{4}`)", schema, table, column, rules, column);
            }

            //left match
            if("lregex".Equals(rules))
            {
                return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = '{3}' where `{4}` like '{5}%'", schema, table, column,to, column, from);
            }

            //right match
            if ("rregex".Equals(rules))
            {
                return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = '{3}' where `{4}` like '%{5}'", schema, table, column,to, column, from);
            }

            if ("ltrim".Equals(rules) || "rtrim".Equals(rules))
            {
                return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = {3} (`{4}`)", schema, table, column, rules, column);
            }
            if ("ltrimr".Equals(rules))
            {
                return string.Concat(
                    new string[] {
                        string.Format("UPDATE `{0}`.`{1}` SET `{2}` = ltrim(`{3}`)", schema, table, column, column),
                        ";",
                        string.Format("UPDATE `{0}`.`{1}` SET `{2}` = rtrim(`{3}`)", schema, table, column, column)
                    }
                );                
            }

            ///过时代码
            if ("trim".Equals(rules))
            {
                return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = {3} (`{4}`)", schema, table, column, from,column);
            }

            return string.Format("UPDATE `{0}`.`{1}` SET `{2}` = REPLACE (`{3}`, '{4}', '{5}')", schema,table,column,column,from,to);
        }



        public string[] BuildUpdateSqls(string statSql, string[] parameters)
        {
            return null;
        }

        public string[] BuildSqls(string schema, string table, string column, List<Payload> ltPayLoads)
        {
            return BuildSqls(schema, table, column, ltPayLoads.ToArray());
        }

        public string[] BuildSqls(string schema, string table, string column, Payload[] payloads)
        {
            string[] sqls = new string[payloads.Length];
            for (int i = 0; i < sqls.Length; i++)
            {
                sqls[i] = BuildSql(schema, table, column, payloads[i]);
            }

            return sqls;
        }

        public string[] BuildSqls(string schema, string table, string[] columns, Payload payload)
        {
            string[] sqls = new string[columns.Length];
            for (int i = 0; i < sqls.Length; i++)
            {
                sqls[i] = BuildSql(schema, table, columns[i], payload);
            }
            return sqls;
        }

        public string[] BuildSqls(string schema, string table, List<string> columns, Payload payload)
        {
            string[] sqls = new string[columns.Count];
            for (int i = 0; i < sqls.Length; i++)
            {
                sqls[i] = BuildSql(schema, table, columns[i], payload);
            }
            return sqls;
        }


        public string[] BuildSqls(string schema, string table, List<string> columns, Payload[] payloads)
        {
            return BuildSqls(schema, table, columns.ToArray(), payloads);
        }

        public string[] BuildSqls(string schema, string table, string[] columns, Payload[] payloads)
        {           
            List<string> sqls = new List<string>(columns.Length*payloads.Length);
            for (int i = 0; i < payloads.Length; i++)
            {
                sqls.AddRange( BuildSqls(schema, table, columns, payloads[i]) );
            }

            return sqls.ToArray();
        }
       
    }
}
