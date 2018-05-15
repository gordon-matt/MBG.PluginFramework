using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MBG.Extensions.Core
{
    public static class GuidExtensions
    {
        public static bool IsNullOrEmpty(this Guid guid)
        {
            return guid == null || guid == Guid.Empty;
        }
    }
}