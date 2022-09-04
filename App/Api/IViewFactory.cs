using System.Threading.Tasks;

public interface IViewFactory
{
    public ColumnChartViewModel CreateColumnChartViewModel();

    public class ColumnChartViewModel
    {
    }
    public LineChartViewModel CreateLineChartViewModel();

    public class LineChartViewModel
    {
    }

    public TreeViewModel CreateTreeViewModel<THierDictionary>();
    public TreeViewModel CreateDragAndDropBehaviour<TDraggableElement, TDroppableContainer>();
    public TreeViewModel CreateTreeView<THierDictionary>();
    public class TreeViewModel
    {
    }
}


