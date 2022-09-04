using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BusinessServiceLocal : Local, IBusinessServiceModel
{
    public BusinessServiceLocal(IServiceProvider provider) : base(provider)
    {
    }
}