using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrganizer.Common
{
    public class SourceHostEntityService
    {
        private static Dictionary<string, long> mdictLocatorToEntityIDLookup = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
        private static long mnLastID = 0;
        internal static long GetID(SourceHostConnection sourceConn)
        {
            if (mdictLocatorToEntityIDLookup.TryGetValue(sourceConn.Locator, out long nID) == false)
            {
                nID = ++mnLastID;
                mdictLocatorToEntityIDLookup[sourceConn.Locator] = nID;
            }
            return nID;
        }
    }
}
