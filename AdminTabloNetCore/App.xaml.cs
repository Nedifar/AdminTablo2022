using GongSolutions.Wpf.DragDrop;
using GongSolutions.Wpf.DragDrop.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdminTabloNetCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

    }

    public class DragDropListView : IDropTarget
    {
        public static string text { get; set; }
        private static IDropTarget _instance;

        public static IDropTarget Instance => _instance ?? (_instance = new DragDropListView());

        public void DragOver(IDropInfo dropInfo)
        {
                if (dropInfo.Data is Models.Para typeInterval)
                {
                    dropInfo.Effects = System.Windows.DragDropEffects.Copy;
                    dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
                }
        }

        public void Drop(IDropInfo dropInfo)
        {
            var sourceCollection = dropInfo.DragInfo.SourceCollection;

            var targetCollection = dropInfo.TargetCollection;
            
            var ObsCollection = targetCollection as ObservableCollection<Models.Para>;

            var insertingData = new Models.Para(dropInfo.Data as Models.Para);

            if (sourceCollection != targetCollection)
            {
                ObsCollection?.Insert(dropInfo.InsertIndex, insertingData);
            }
            else
            {
                if (dropInfo.InsertIndex == dropInfo.TargetCollection.TryGetList().Count)
                {
                    ObsCollection?.Move(dropInfo.DragInfo.SourceIndex, dropInfo.InsertIndex - 1);
                }
                else
                {
                    ObsCollection?.Move(dropInfo.DragInfo.SourceIndex, dropInfo.InsertIndex);
                }
            }
        }
    }

}
