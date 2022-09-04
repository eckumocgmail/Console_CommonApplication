


using DataEntities;

public interface ICatalogServiceModel
{
    IEntityFasade<ProductItem> Products { get; }
 
    IEntityFasade<SaleItem> OrderItems { get; }
    IEntityFasade<ProductImage> ProductImages { get; }
}


public class CatalogServiceModel:  ICatalogServiceModel
{



    public CatalogServiceModel( )
    {
       
    }

    public class BaseEntity
    {
        public virtual int ID { get; set; }
    }
    public class NamedObject
    {
        public int ID { get; }
        public string Name { get; }
        public string Topic
        {
            get => GetType().Name;

        }
    }

    public IEntityFasade<ProductItem> Products{get;}

 

    public IEntityFasade<SaleItem> OrderItems{get;}

    public IEntityFasade<ProductImage> ProductImages{get;}
}