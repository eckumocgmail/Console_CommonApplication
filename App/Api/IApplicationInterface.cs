using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IApplicationInterface : IDialogFactory, IViewFactory
{
    public Task InputForm<T>(Func<T, bool, Task> OnComplete) where T : BaseEntity;
    public Task EditForm<T>(T item, Func<T, bool, Task> OnComplete) where T : BaseEntity;
    public Task SelectList<T>(IEnumerable<T> options, T selected, Func<T, Task> OnSelect) where T : BaseEntity;
    public Task SelectCards<T>(IEnumerable<IServlet<T>> items) where T : BaseEntity;
    public class IServlet<T> where T : class
    {
        private T _item;
        public IServlet(T item) {
            this._item = item;
        }
    }
    public Task SelectTableRows<T>(Func<int, Task> OnSelect) where T : BaseEntity;
    public Task SelectTreeView<T>(object target) where T : HierDictionary;
    public Task SelectTableColumns<T>(Func<int, Task> OnSelect) where T : BaseEntity;
    public Task BarChartView<T>() where T : StatsTable;
    public Task SearchView<T>(Func<IEnumerable<T>, Task> next) where T : BaseEntity;
}


