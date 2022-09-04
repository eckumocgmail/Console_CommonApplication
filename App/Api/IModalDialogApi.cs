public interface IModalDialogApi
{
    bool InfoDialog(string Title, string Text, string Button);
    void ShowHelp(string Text);
    bool RemoteDialog(string Title, string Url);
    bool ConfirmDialog(string Title, string Text);
    bool CreateEntityDialog(string Title, string Entity);
    object InputDialog(string Title, object Properties);
}
