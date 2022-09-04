
using NetCoreConstructorAngular.ActionEvent.EventsAndMessages;

using System;

public class ExceptionEvent : CommonEventMessage<Exception>
{
    public ExceptionEvent(Exception ex) : base(ex)
    {
    }
}
 