using FileExplorer.Model;
using FileExplorer.Properties;
using System;
using FileExplorer.Service;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace FileExplorer.ViewModel
{
    public class ExplorerWindowViewModel : ViewModelBase
    {
        private DirInfo currentDirectory;
        private FileExplorerViewModel fileTreeViewVM;
        private DirectoryViewerViewModel dirViewerVM;
        private IList<DirInfo> currentItems;
        private bool showDirectoryTree = true;
        private ICommand showTreeCommand;

        public ExplorerWindowViewModel()
        {

        }

        public DirInfo CurrentDirectory
        {
            get => currentDirectory;
            set
            {
                currentDirectory = value;
                RefreshCurrentItems();
                OnPropertyChanged(nameof(CurrentDirectory));
            }
        }

        public FileExplorerViewModel FileTreeVM
        {
            get => fileTreeViewVM;
            set
            {
                fileTreeViewVM = value;
                OnPropertyChanged(nameof(FileTreeVM));
            }
        }
        public bool ShowDirectoryTree
        {
            get => showDirectoryTree;
            set
            {
                showDirectoryTree = value;
                OnPropertyChanged(nameof(ShowDirectoryTree));
            }
        }

        public ICommand ShowTreeCommand
        {
            get => showTreeCommand;
            set
            {
                showTreeCommand = value;
                OnPropertyChanged(nameof(ShowTreeCommand));
            }
        }

        public DirectoryViewerViewModel DirViewerVM
        {
            get => dirViewerVM;
            set
            {
                dirViewerVM = value;
                OnPropertyChanged(nameof(DirViewerVM));
            }
        }
        public IList<DirInfo> CurrentItems
        {
            get
            {
                if (currentItems == null)
                {
                    currentItems = new List<DirInfo>();
                }
                return currentItems;
            }
            set
            {
                currentItems = value;
                OnPropertyChanged(nameof(CurrentItems));
            }
        }


        private void RefreshCurrentItems()
        {
            IList<DirInfo> childDirList = new List<DirInfo>();
            IList<DirInfo> childFileList = new List<DirInfo>();

            if (CurrentDirectory.Name.Equals(Resources.My_computer_string))
            {
                childDirList = FileSystemService.GetRootDirectories().Select(x => new DirInfo(x)).ToList();
            }
            else
            {
                childDirList = FileSystemService.GetChildFiles(CurrentDirectory.Path).Select(x => new DirInfo(x)).ToList();
                childFileList = FileSystemService.GetChildFiles(CurrentDirectory.Path).Select(x => new DirInfo(x)).ToList();

                childDirList = childDirList.Concat(childFileList).ToList();
            }
            CurrentItems = childDirList;

        }
        private void DirectoryTreeHandler()
        {
            ShowDirectoryTree = false;
        }
    }
}
