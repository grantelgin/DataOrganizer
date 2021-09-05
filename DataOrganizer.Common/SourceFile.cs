using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataOrganizer.Common
{
    public class SourceFile : Entity
    {
        public SourceHost SourceHost { get; private set; }
        public string FileName { get; private set; }
        public string RelativePath { get; private set; }
        public SourceFile(long iD, string sFileName, SourceHost srcHost, string sFullPath) : base(iD)
        {
            FileName = sFileName;
            SourceHost = srcHost;
            RelativePath = Path.GetDirectoryName(sFullPath);

        }
    }
}
