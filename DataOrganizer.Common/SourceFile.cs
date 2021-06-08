using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrganizer.Common
{
    public class SourceFile : Entity
    {
        public SourceHost SourceHost { get; private set; }
        public string FileName { get; private set; }

        public SourceFile(long iD) : base(iD)
        {
        }
    }
}
