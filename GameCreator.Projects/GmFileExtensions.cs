using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Projects
{
    static class GmFileExtensions
    {
        static readonly DateTime ReferenceDate = new DateTime(1899, 12, 30);

        public static DateTime ToDateTime(this double fileValue)
        {
            return ReferenceDate.AddDays(fileValue);
        }
    }
}
