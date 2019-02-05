using FileExplorer.Model;
using FileExplorer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.ViewModel
{
    public class FileExplorerViewModel : ViewModelBase
    {
        private ExplorerWindowViewModel explorerWindowVM;
        private DirInfo currentTreeItem;
        private IList<DirInfo> sysDirSource;

        public IList<DirInfo> SystemDirectorySource
        {
            get => sysDirSource;
            set
            {
                sysDirSource = value;
                OnPropertyChanged(nameof(SystemDirectorySource));
            }
        }
        public DirInfo CurrentTreeItem
        {
            get => currentTreeItem;
            set
            {
                currentTreeItem = value;
                explorerWindowVM.CurrentDirectory = currentTreeItem;
            }
        }
        public FileExplorerViewModel(ExplorerWindowViewModel expVM)
        {
            explorerWindowVM = expVM;

            DirInfo rootNode = new DirInfo(Resources.My_computer_string);
            rootNode.Path = Resources.My_computer_string;
            explorerWindowVM.CurrentDirectory = rootNode;

            SystemDirectorySource = new List<DirInfo> { rootNode };
        }

        public void ExpandToCurrentNode (DirInfo currentDir)
        {
            if (CurrentTreeItem != null && (currentDir.Path.Contains(CurrentTreeItem.Path) || CurrentTreeItem.Path == Resources.My_computer_string))
            {
                CurrentTreeItem.IsExpanded = false;
                CurrentTreeItem.IsExpanded = true;
            }
        }
    }
}
