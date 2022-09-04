using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;


using System.Threading.Tasks;

[Icon("")]
[Description("Контроллер предназначен для .")]
public interface DoCheck
{
    public Task DoCheck(long timeout);
}

public interface APIActiveObject: APIActiveObject<ResponseMessage, RequestMessage, Exception>
{

}
public interface APIActiveObject<TypeInput, TypeOutput, TypeError>
    where TypeOutput    : class
    where TypeInput     : class
    where TypeError     : Exception

{
    public TypeOutput ActionEvent(TypeInput message);
    public Task<TypeOutput> ActionEventAsync(TypeInput message);
}



public interface IAsyncResult<TResult>: IAsyncResult
    where TResult : IActionResult
{

}


 