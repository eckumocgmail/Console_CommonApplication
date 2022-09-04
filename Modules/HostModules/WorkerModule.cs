using UniversalShare.ShareApp;
 

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
public abstract class WorkerModule: MyValidatableObject, IServiceModule
{
    public abstract void ConfigureServices(IConfiguration configuration, IServiceCollection services);
    public void Configure(IApplicationBuilder app)        
        => throw new NotImplementedException($"{GetType().GetTypeName()}");
        
}
 