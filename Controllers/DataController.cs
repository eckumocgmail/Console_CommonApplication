using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

[Route("[controller]/[action]")]
public class DataController: Controller
{
    public IEnumerable<string> Entities([FromServices] AuthorizationDataModel dataModel) 
        => dataModel.GetEntityTypeNames();
    public object List([FromServices] AuthorizationDataModel dataModel, string entity)
        => new
        {
            columns = entity.ToType().GetOwnPropertyNames(),
            dataset = dataModel.List(entity)
        };
    public object Form([FromServices] AuthorizationDataModel dataModel, string entity)
        => new
        {
            columns = entity.ToType().GetOwnPropertyNames(),
            form = new Form(entity.ToType().New())
        };
    public object Search([FromServices] AuthorizationDataModel dataModel, string entity, string query)
        => new
        {
            columns = entity.ToType().GetOwnPropertyNames(),
            dataset = dataModel.Search(entity,query,1,10)
        };
}
 