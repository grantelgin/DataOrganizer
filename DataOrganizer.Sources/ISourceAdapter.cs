using DataOrganizer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrganizer.Sources
{
    public interface ISourceAdapter
    {
        SourceHost SourceHost { get; }
        int FileCount { get; }
        int FolderCount { get; }

        IEnumerable<SourceFile> All();

    }
}
