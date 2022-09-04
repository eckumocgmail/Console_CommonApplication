using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


public interface IServiceModule 
{
    public void ConfigureServices(IConfiguration configuration, IServiceCollection services);


}