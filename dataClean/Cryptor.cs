using System;
namespace dataClean
{
    public class Cryptor
    {
        /// <summary>
        /// convert hash to lower case.
        /// </summary>
        private bool m_Lower;
        /// <summary>
        /// The algorithm name.(eg md5,sha256)
        /// </summary>
        private string m_algorithm;
        /// <summary>
        /// the key or salt to compute hash.
        /// </summary>
        private string m_key;
        /// <summary>
        /// the data(plain/cryped data)
        /// </summary>
        private string m_plainText;
        /// <summary>
        /// 计算出的hash
        /// </summary>
        private string m_hash;

        public Cryptor(CryptBuilder builder)
        {
            m_Lower = builder.m_Lower;
            m_algorithm = builder.m_algorithm;
            m_key = builder.m_key;
            m_plainText = builder.m_plainText;
        }

        public bool Lower
        {
            get => m_Lower;
        }

        public string Algorithm
        {
            get => m_algorithm;
        }

        public string Key
        {
            get => m_key;
        }

        public string PlainText
        {
            get => m_plainText;
        }

        public string Hash
        {
            get
            {
                return m_hash;
            }
        }
        public Cryptor setHash(string val)
        {
            this.m_hash = val;
            return this;
        }

        public class CryptBuilder
        {
            public bool m_Lower;
            public string m_algorithm;
            public string m_key;
            public string m_plainText;
            public string m_hash;

            public CryptBuilder(string m_algorithm, string m_plainText)
            {
                this.m_algorithm = m_algorithm;
                this.m_plainText = m_plainText;
            }

            public CryptBuilder setLower(bool val)
            {
                this.m_Lower = val;
                return this;
            }

            public CryptBuilder setAlgorithm(string m_algorithm)
            {
                this.m_algorithm = m_algorithm;
                return this;
            }

            public CryptBuilder setKey(string m_key)
            {
                this.m_key = m_key;
                return this;
            }

            public CryptBuilder setPlainText(string m_plainText)
            {
                this.m_plainText = m_plainText;
                return this;
            }

            public CryptBuilder setHash(string m_hash)
            {
                this.m_hash = m_hash;
                return this;
            }

            public string Build()
            {
                return CryptFactory.ComputeHash(this);
            }
        }
    }
}
