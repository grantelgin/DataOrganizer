using DataOrganizer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrganizer.Sources
{
    public interface ISourceAdapter
    {
        SourceHost SourceHost { get; }
        IEnumerable<SourceFile> All();

    }
}
