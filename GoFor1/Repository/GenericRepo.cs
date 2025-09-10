using GoFor1.Models;

namespace GoFor1.Repository
{
    public class GenericRepo<T> where T : class
    {
        DbCon dbCon;
        public GenericRepo(DbCon _dbCon)
        {
            dbCon = _dbCon;
        }
        public List<T> GetAll()
        {
            return dbCon.Set<T>().ToList();
        }
        public T? GetById(int id)
        {
            return dbCon.Set<T>().Find(id);
        }
        public T? GetByName(string name) 
            {
            return dbCon.Set<T>().Find(name);
        }
        public T Add(T entity)
        {
            dbCon.Set<T>().Add(entity);
            return entity;
        }
        public bool Edit(T entity, int id)
        {
            if (entity == null) return false;
            dbCon.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return true;
        }
        public bool Delete(int id)
        {
            var entity = dbCon.Set<T>().Find(id);
            if (entity == null) return false;
            dbCon.Set<T>().Remove(entity);
            return true;
        }
        public void Save()
        {
            dbCon.SaveChanges();
        }
    }
}
