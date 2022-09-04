 

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.RepositoryPattern
{

    public interface IEntityRepository<TEntity> where TEntity : class
    {
        public int Post(TEntity data);
        public int Put(TEntity data);
        public int Patch(params TEntity[] dataset);
        public int Delete(int id);
        public IEnumerable<TEntity> Get(int? id);
    }

    public abstract class EntityRepository<TEntity>: IEntityRepository<TEntity> where  TEntity: class
    {
        protected readonly DbContext _context;

        public EntityRepository(DbContext context )
        {
            _context = context;
        }

        public abstract DbSet<TEntity> GetDbSet(DbContext context);

        public int Post(TEntity data)
        {
            var dbset = this.GetDbSet(_context);
            dbset.Add(data);
            int result = _context.SaveChanges();
            return result;
        }

        public int Put(TEntity data)
        {
            var dbset = this.GetDbSet(_context);
            dbset.Update(data);
            int result = _context.SaveChanges();
            return result;
        }

        public int Patch(params TEntity[] dataset)
        {
            int result = 0;
            var dbset = this.GetDbSet(_context);
            foreach( TEntity next in dbset.ToArray())
            {
                result += Delete(int.Parse(next.GetType().GetProperty("ID").GetValue(next).ToString()));
            }
            foreach (TEntity next in dataset)
            {
                result += Put(next);
            }
            return result;
        }

        public int Delete(int id)
        {
            var dbset = this.GetDbSet(_context);
            IEnumerable<TEntity> records = Get(id);
            if (records.Count() == 0)
            {
                return 0;
            }
            else
            {
                dbset.Remove(records.FirstOrDefault());
                int result = _context.SaveChanges();
                return result;
            }
        }

        public IEnumerable<TEntity> Get(int? id)
        {
            if(id == null)
            {
                return this.GetDbSet(_context).ToArray();
            }
            else
            {
                return this.GetDbSet(_context).Where(record=>record.GetProperty("ID").ToString() ==id.ToString()).ToArray();
            }
        }
    }
}
