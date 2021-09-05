using DataOrganizer.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataOrganizer.Sources
{
    public class SourceService
    {
        private Dictionary<long, ISourceAdapter> mdictSourceAdapters = new Dictionary<long, ISourceAdapter>();
        public int ServiceCount { get { return mdictSourceAdapters.Keys.Count; } }
        public int FolderCount { get; private set; }
        public int FileCount { get; private set; }

        

        public SourceService()
        {
            LoadLocalDrives();
            LoadFiles();
        }

        private void LoadFiles()
        {
             foreach (var item in mdictSourceAdapters)
            {
                item.Value.All();
                FileCount += item.Value.FileCount;
                FolderCount += item.Value.FolderCount;
            }
        }

        private void LoadLocalDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                SourceHostConnection shc = SourceHostConnection.ForLocalDrive(drive.Name);
                long nID = SourceHostEntityService.GetID(shc);
                ISourceAdapter sa = new SourceAdapter_LocalDrive(drive.Name);
                mdictSourceAdapters.Add(nID, sa);
            }
        }
    }
}
