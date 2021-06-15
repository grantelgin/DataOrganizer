using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataOrganizer.Common
{
    public class SourceHostEntityService
    {
        private static Dictionary<string, long> mdictLocatorToEntityIDLookup = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
        private Dictionary<string, long> mdictFileHashToIDLookup = new Dictionary<string, long>();

        private static long mnLastID = 0;
        public static long GetID(SourceHostConnection sourceConn)
        {
            if (mdictLocatorToEntityIDLookup.TryGetValue(sourceConn.Locator, out long nID) == false)
            {
                nID = ++mnLastID;
                mdictLocatorToEntityIDLookup[sourceConn.Locator] = nID;
            }
            return nID;
        }

        public long FileID_Get(FileInfo fi)
        {
            string sFileHash = FileHash_Get(fi);
            if(mdictFileHashToIDLookup.TryGetValue(sFileHash, out long nID)==false)
            {
                nID = ++mnLastID;
                mdictFileHashToIDLookup[sFileHash] = nID;
            }
            return nID;
        }

        private string FileHash_Get(FileInfo fi)
        {
            //TODO do it based on filename and size for now... implement smarter solution
            long nFileHash = fi.Name.GetHashCode() + fi.Length;
            return nFileHash.ToString();
        }
    }
}
