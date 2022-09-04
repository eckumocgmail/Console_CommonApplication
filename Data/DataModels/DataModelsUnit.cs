using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DataModelsUnit : TestingUnit
{
    public DataModelsUnit(TestingUnit parent) : base(parent)
    {
        this.Push(new AnaliticsServiceUnit(this));
        this.Push(new AuthorizationServiceUnit(this));
        this.Push(new BusinessServiceUnit(this));
        this.Push(new FilesServiceUnit(this));
        this.Push(new ManagmentServiceUnit(this));
        this.Push(new MarketServiceUnit(this));
        this.Push(new CustomerServiceUnit(this));
        this.Push(new CommunicationServiceUnit(this));
        this.Push(new MedicalServiceUnit(this));
        this.Push(new DnsServiceUnit(this));
        this.Push(new CatalogServiceUnit(this));
        this.Push(new AppServiceUnit(this));
    }
}
 