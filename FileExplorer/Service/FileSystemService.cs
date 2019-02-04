using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FileExplorer.Service
{
    public class FileSystemService
    {
        public static IList<FileInfo> GetChildFiles(string path)
        {
            IList<FileInfo> fileList = new List<FileInfo>();
            try
            {
                //fileList = (from x in Directory.GetFiles(path) select new FileInfo(x)).ToList();
                fileList = Directory.GetFiles(path).Select(x => new FileInfo(x)).ToList();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return fileList;
        }
        public static IList<DirectoryInfo> GetChildDirectories(string path)
        {
            IList<DirectoryInfo> dirList = new List<DirectoryInfo>();
            try
            {
                dirList = Directory.GetDirectories(path).Select(x => new DirectoryInfo(x)).ToList();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return dirList;
        }
        public static IList<DriveInfo> GetRootDirectories()
        {
            IList<DriveInfo> rootList = new List<DriveInfo>();
            rootList = DriveInfo.GetDrives().ToList();
            return rootList;
        }
    }
}