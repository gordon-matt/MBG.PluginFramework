using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MBG.Extensions.Xml
{
    public static class XElementExtensions
    {
        public static bool Exists(this IEnumerable<XElement> elements, string elementName)
        {
            return elements.Any(x => x.Name == elementName);
        }
    }
}