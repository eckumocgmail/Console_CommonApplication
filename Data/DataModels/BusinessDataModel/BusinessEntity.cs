
 
using System.Collections.Generic;

public abstract class BusinessEntity<T>: HierDictionary<T> where T: class
{
    [ManyToMany("Datasets")]
    public virtual List<BusinessDataset> BusinessDataset { get; set; }



}
 