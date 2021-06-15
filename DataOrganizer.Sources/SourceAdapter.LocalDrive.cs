using DataOrganizer.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataOrganizer.Sources
{
    public class SourceAdapter_LocalDrive : ISourceAdapter
    {
        public SourceHost SourceHost { get; private set; }
        private List<SourceFile> msourceFiles;
        private SourceHostEntityService mEntityService;

        public SourceAdapter_LocalDrive(string sLocator)
        {
            SourceHost = SourceHost.LocalDrive(sLocator);
            msourceFiles = new List<SourceFile>();
            mEntityService = new SourceHostEntityService();
        }
        public IEnumerable<SourceFile> All()
        {
            if (msourceFiles.Count == 0)
            {
                CrawlSource();

            }

            return msourceFiles;
        }

        private void CrawlSource()
        {
            DirectoryInfo di = new DirectoryInfo(SourceHost.SourceHostConnection.Locator);
            DirectoryInfo[] dis = di.GetDirectories();
            for (int i = 0; i < dis.Length; i++)
            {
                //make async...
                IEnumerable<FileInfo> files = dis[i].EnumerateFiles();
                foreach (FileInfo fi in files)
                {
                    long nID = mEntityService.FileID_Get(fi);
                    msourceFiles.Add(new SourceFile(nID));
                }

            }
        }


    }
}
