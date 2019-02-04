using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileExplorer.Model
{
    public enum ObjectType
    {
        MyComputer = 0,
        Drive,
        Directory,
        File
    }
    public class DirInfo : DependencyObject
    {
        #region PublicProps
        public string Name { get; set; }
        public string Path { get; set; }
        public string Root { get; set; }
        public string Size { get; set; }
        public string Ext { get; set; }
        public int DirType { get; set; }

        #endregion

        #region DependencyProps
        public static readonly DependencyProperty propChilds = DependencyProperty.Register("Childs", typeof(IList<DirInfo>), typeof(DirInfo));
        public IList<DirInfo> SubDirectories
        {
            get => (IList<DirInfo>)GetValue(propChilds);
            set => SetValue(propChilds, value);
        }
        public static readonly DependencyProperty propertyIsExpanded = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(DirInfo));
        public bool IsExpanded
        {
            get => (bool)GetValue(propertyIsExpanded);
            set => SetValue(propertyIsExpanded, value);
        }

        public static readonly DependencyProperty propertyIsSelected = DependencyProperty.Register("IsSelected", typeof(bool), typeof(DirInfo));
        public bool IsSelected
        {
            get => (bool)GetValue(propertyIsSelected);
            set => SetValue(propertyIsSelected, value);
        }
        #endregion

        #region CTOR
        public DirInfo()
        {
            SubDirectories = new List<DirInfo>();
            SubDirectories.Add(new DirInfo("TempDir"));
        }

        public DirInfo(string dirName)
        {
            Name = dirName;
        }

        public DirInfo(DirectoryInfo dir) : this()
        {
            Name = dir.Name;
            Root = dir.Root.Name;
            Path = dir.FullName;
            DirType = (int)ObjectType.Directory;
        }
        public DirInfo(FileInfo fileobj)
        {
            Name = fileobj.Name;
            Path = fileobj.FullName;
            DirType = (int)ObjectType.File;
            Size = (fileobj.Length / 1024).ToString() + " KB";
            Ext = fileobj.Extension + " File";
        }
        public DirInfo(DriveInfo driveobj)
               : this()
        {
            if (driveobj.Name.EndsWith(@"\"))
                Name = driveobj.Name.Substring(0, driveobj.Name.Length - 1);
            else
                Name = driveobj.Name;

            Path = driveobj.Name;
            DirType = (int)ObjectType.Drive;
        }
        #endregion
    }
}
