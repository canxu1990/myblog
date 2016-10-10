using MyBlog.IRepository;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository
{
    public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity:class
    {
        MyBlogDB db = new MyBlogDB();
        DbSet<TEntity> _dbSet;
        public BaseRepository()
        {
            _dbSet = db.Set<TEntity>();
        }

        #region 查询
        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
        /// <summary>
        /// 多表关联查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        public List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, string[] tableNames)
        {
            if (tableNames == null && tableNames.Any() == false)
            {
                throw new Exception("缺少连表名称");
            }
            DbQuery<TEntity> query = _dbSet;
            foreach (var table in tableNames)
            {
                query = query.Include(table);
            }
            return query.Where(predicate).ToList();
        }
        /// <summary>
        /// 升序查询还是降序查询
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <param name="isQueryOrderBy"></param>
        /// <returns></returns>
        public List<TEntity> QueryOrderBy<Tkey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Tkey>> keySelector, bool isQueryOrderBy)
        {
            if (isQueryOrderBy)
            {
                return _dbSet.Where(predicate).OrderBy(keySelector).ToList();
            }
            return _dbSet.Where(predicate).OrderByDescending(keySelector).ToList();
        }
        /// <summary>
        /// 升序分页查询还是降序分页
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowcount"></param>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <param name="isQueryOederBy"></param>
        /// <returns></returns>
        public List<TEntity> QueryByPage<Tkey>(int pageIndex, int pageSize, out int rowcount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Tkey>> keySelector, bool isQueryOederBy)
        {
            rowcount = _dbSet.Count(predicate);
            if (isQueryOederBy)
            {
                return _dbSet.Where(predicate).OrderBy(keySelector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            return _dbSet.Where(predicate).OrderByDescending(keySelector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        #endregion

        #region 编辑
        /// <summary>
        /// 通过传入的model加需要修改的字段来更改数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="propertys"></param>
        public void Edit(TEntity model, string[] propertys)
        {
            if (model == null)
            {
                throw new Exception("实体不能为空");
            }
            if (!propertys.Any())
            {
                throw new Exception("要修改的属性至少要有一个");
            }
            //将model追加到容器
            DbEntityEntry entry = db.Entry(model);
            entry.State = EntityState.Unchanged;
            foreach (var item in propertys)
            {
                entry.Property(item).IsModified = true;
            }
            //关闭EF对于实体的合法性验证参数
            db.Configuration.ValidateOnSaveEnabled = false;
        }
        /// <summary>
        /// 直接查询之后再修改
        /// </summary>
        /// <param name="model"></param>
        public void Edit(TEntity model)
        {
            db.Entry(model).State = EntityState.Modified;
        }
        #endregion

        #region 删除
        public void Delete(TEntity model,bool isadded)
        {
            if (!isadded)
            {
                _dbSet.Attach(model);
            }
            _dbSet.Remove(model);
        }
        #endregion

        #region 新增
        public void Add(TEntity model)
        {
            _dbSet.Add(model);
        }
        #endregion

        #region 统一提交
        public int SaveChanges()
        {
            return db.SaveChanges();
        }
        #endregion

        #region 调用存储过程返回一个指定的TResult
        public List<TResult> RunProc<TResult>(string sql, params object[] pamrs)
        {
            return db.Database.SqlQuery<TResult>(sql, pamrs).ToList();
        }
        #endregion
    }
}
