using System.Threading.Tasks;

public interface IDialogFactory
{
    public Task ShowLineChartDialog();
    public Task ShowColumnChartDialog();
    public Task ShowAreaChartDialog();
    public Task ShowInformationDialog();
    public Task ShowSubmitDialog();
    public Task ShowConfirmDialog();
    public Task ShowErrotDialog();
    public Task ShowInputDialog();
    public Task ShowProgressDialog();

    public Task ShowSelectListDialog();
    public Task ShowCheckListDialog();
    public Task ShowSearchListDialog();
    public Task ShowSearchListPagedDialog();
    public Task ShowSearchTableDialog();
    public Task ShowSearchTablePagedDialog();
    public Task ShowSearchCardsDialog();
    public Task ShowSearchCardsPagedDialog();
    public Task ShowSearchChartsDialog();

}


