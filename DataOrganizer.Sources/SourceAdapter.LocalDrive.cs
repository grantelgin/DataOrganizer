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

        public int FileCount { get { return msourceFiles.Count; } }

        public int FolderCount { get; private set; }

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
            EnumerationOptions eo = new EnumerationOptions() { IgnoreInaccessible = true, RecurseSubdirectories = true };
            DirectoryInfo di = new DirectoryInfo(SourceHost.SourceHostConnection.Locator);
            DirectoryInfo[] dis = di.GetDirectories();
            string sCurrentFolder = "";
            for (int i = 0; i < dis.Length; i++)
            {
                //make async... also handle inaccesible files (hidden)
                IEnumerable<FileInfo> files = dis[i].EnumerateFiles("*.*", eo);
                
                foreach (FileInfo fi in files)
                {

                    long nID = mEntityService.FileID_Get(fi);
                    msourceFiles.Add(new SourceFile(nID, fi.Name, SourceHost, fi.DirectoryName));
                    if(fi.DirectoryName != sCurrentFolder)
                    {
                        FolderCount++;
                        sCurrentFolder = fi.DirectoryName;
                    }
                }

            }
        }


    }
}
