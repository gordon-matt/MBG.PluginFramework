using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MBG.Extensions.Xml
{
    public static class XmlNodeExtensions
    {
        public static XElement ToXElement(this XmlNode node)
        {
            return XElement.Parse(node.ToString());
        }
    }
}