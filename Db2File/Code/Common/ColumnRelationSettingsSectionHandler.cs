using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;

namespace Db2File.Code.Common
{
    class ColumnRelationSettingsSectionHandler : IConfigurationSectionHandler
    {
        public Object Create(Object parent, Object configContext, XmlNode section)
        {
            return section;
        }
    }
}
