
using DataEntities;

using System; 

namespace Mvc_Apteka.Controllers
{

    /// <summary>
    /// Управление структурой БД
    /// </summary>
    public class ProductsDatabaseController
    {


        public bool Config(string ConnectionString)
        {
            using (var appDb = new CatalogDataModel() {
                //ConnectionString = ConnectionString 
            }) {

                
                return appDb.Database.CanConnect();
                 
            }
        
            
        }


        /// <summary>
        /// Обновление структуры данных
        /// </summary>
        public MethodResult<object> CreateDatabase(CatalogDataModel context)
        {
            object result = false;
            try
            {
                result = context.Database.EnsureCreated();
                return MethodResult.OnResult(  result);
            }
            catch (Exception ex)
            {
                return MethodResult.OnError(ex);
            }
        }

        /// <summary>
        /// Уничтожение структуры данных
        /// </summary>
        public MethodResult<object> DeleteDatabase(CatalogDataModel context)
        {
            bool result = false;
            try
            {
                return MethodResult.OnResult(result = context.Database.EnsureDeleted());
            }
            catch (Exception ex)
            {
                return MethodResult.OnError(ex);
            }
        }
    }
}
