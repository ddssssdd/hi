using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Base
{
    public class BaseService<TEntity>:IDisposable where TEntity:class
    {
        protected ShiftContext db;
        public BaseService()
        {
            db = new ShiftContext();
        }

        public virtual void Dispose()
        {
            db.Dispose();
        }

      
        public virtual List<TEntity> List()
        {
            return db.Set<TEntity>().ToList();
        }

        public virtual TEntity Find(int? primaryKey)
        {
            return db.Set<TEntity>().Find(primaryKey);
        }

        public virtual TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public virtual bool Insert(TEntity entity)
        {
            
            db.Set<TEntity>().Add(entity);
            BeforeInsert(entity);
            int count= db.SaveChanges() ;
            AfterInsert(entity);
            return count > 0;
        }

        public virtual bool Update(TEntity entity)
        {
            db.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
            BeforeUpdate(entity);
            int count  = db.SaveChanges();
            AfterUpdate(entity);
            return count>0;
        }

        public virtual bool Delete(int primaryKey)
        {
            TEntity entity = db.Set<TEntity>().Find(primaryKey);
            BeforeDelete(entity);
            db.Set<TEntity>().Remove(entity);
            int count = db.SaveChanges();
            AfterDelete(entity);
            return count > 0;
        }
        public virtual void BeforeInsert(TEntity entity)
        { 
        }
        public virtual void BeforeUpdate(TEntity entity)
        {
        }

        public virtual void BeforeDelete(TEntity entity)
        {
        }
        public virtual void AfterInsert(TEntity entity)
        {
        }
        public virtual void AfterUpdate(TEntity entity)
        {
        }

        public virtual void AfterDelete(TEntity entity)
        {
        }
    }
}
