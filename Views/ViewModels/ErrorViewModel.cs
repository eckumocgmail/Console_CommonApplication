using System;

[Icon("")]
[Label("")]
[Description("���������� ������������ ��� .")]
public class ErrorViewModel
{
    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
 