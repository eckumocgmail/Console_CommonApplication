
using Microsoft.EntityFrameworkCore;

public sealed class CustomerDataModel : BaseDbContext, ICustomerDataModel
{
    public CustomerDataModel()
    {
    }
    protected override void InitDbSets()
    {
    }
    public CustomerDataModel(DbContextOptions<CustomerDataModel> options) : base(options)
    {
    }
}
 
