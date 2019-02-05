using FileExplorer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.ViewModel
{
    public class DirectoryViewerViewModel
    {
        #region // Private variables
        private ExplorerWindowViewModel _evm;
        private DirInfo currentItem;
        #endregion

        #region // .ctor
        public DirectoryViewerViewModel(ExplorerWindowViewModel evm)
        {
            _evm = evm;
        }
        #endregion

        #region // Public members

        public DirInfo CurrentItem
        {
            get => currentItem;
            set => currentItem = value;
        }
        #endregion

        #region Public Methods

        public void OpenCurrentObject()
        {
            int objType = CurrentItem.DirType;

            if ((ObjectType)CurrentItem.DirType == ObjectType.File)
            {
                System.Diagnostics.Process.Start(CurrentItem.Path);
            }
            else
            {
                _evm.CurrentDirectory = CurrentItem;
                _evm.FileTreeVM.ExpandToCurrentNode(_evm.CurrentDirectory);
            }
        }
        #endregion
    }
}
