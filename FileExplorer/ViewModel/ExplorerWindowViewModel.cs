using FileExplorer.Model;
using System.Collections.Generic;
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


    }
}
