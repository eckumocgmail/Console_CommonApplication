using System.Text;

public class TextDocument
{
    [NotNullNotEmpty]
    private FileEntity<TextDocument> fileEntity;

    public TextDocument(FileEntity<TextDocument> fileEntity)
    {
        this.fileEntity = fileEntity;
    }

    public string GetText() => 
        Encoding.Unicode.GetString(fileEntity.Data);
    public void SetText(string text) => 
        fileEntity.Data = Encoding.Unicode.GetBytes(text);
}