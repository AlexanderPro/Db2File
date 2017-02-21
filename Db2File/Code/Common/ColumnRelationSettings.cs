using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;

namespace Db2File.Code.Common
{
    class ColumnRelationSettings
    {
        private static ColumnRelationSettings _instance;

        public IList<ColumnRelation> ColumnRelations { get; private set; }

        public static ColumnRelationSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(ColumnRelationSettings))
                    {
                        if (_instance == null)
                        {
                            _instance = new ColumnRelationSettings();
                        }
                    }
                }
                return _instance;
            }
        }


        private ColumnRelationSettings()
        {
            Initialize();
        }

        private void Initialize()
        {
            var section = ConfigurationManager.GetSection("columnRelations") as XmlNode;
            if (section == null) throw new ArgumentNullException("columnRelations", "Section does not exist!");

            ColumnRelations = new List<ColumnRelation>();
            foreach (XmlNode node in section.SelectNodes("./columnRelation"))
            {
                var columnRelation = new ColumnRelation()
                {
                    DbColumnName = node.Attributes["dbColumnName"] == null ? String.Empty : node.Attributes["dbColumnName"].Value,
                    FileColumnName = node.Attributes["fileColumnName"] == null ? String.Empty : node.Attributes["fileColumnName"].Value,
                    FileColumnFormat = node.Attributes["fileColumnFormat"] == null ? String.Empty : node.Attributes["fileColumnFormat"].Value,
                    FileColumnType = node.Attributes["fileColumnType"] == null ? String.Empty : node.Attributes["fileColumnType"].Value,
                    FileColumnLength =  node.Attributes["fileColumnLength"] == null ? (Int32?)null : (Int32?)Int32.Parse(node.Attributes["fileColumnLength"].Value),
                    FileColumnDecimals = node.Attributes["fileColumnDecimals"] == null ? (Int32?)null : (Int32?)Int32.Parse(node.Attributes["fileColumnDecimals"].Value)
                };
                ColumnRelations.Add(columnRelation);
            }
        }
    }
}
