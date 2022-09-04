using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Api.Utils;

public class CollectionBuilder<T>
{
    private List<T> SelectedItems { get; }
    private Func<IEnumerable<T>> SelectData { get; }
    private Func<T, string> ToText { get; }
    public CollectionBuilder(IList<T> SelectedItems, Func<IEnumerable<T>> SelectData, Func<T,string> ToText)
    {
        this.SelectedItems = new List<T>(SelectedItems);
        this.SelectData = SelectData;
        this.ToText = ToText;
    }

    public CollectionBuilder( Func<IEnumerable<T>> SelectData, Func<T, string> ToText)
    {
        this.SelectedItems = new List<T>( );
        this.SelectData = SelectData;
        this.ToText = ToText;
    }



    public void Run()
    {
        this.SelectedItems.Clear();
        this.SelectedItems.AddRange(CheckListTitle("Выберите", this.SelectData(), this.ToText));
    }
}