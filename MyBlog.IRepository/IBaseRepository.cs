using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity:class
    {
        #region 查询
        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 多表关联查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, string[] tableNames);
        /// <summary>
        /// 升序查询还是降序查询
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <param name="isQueryOrderBy">true为升序 false为降序</param>
        /// <returns></returns>
        List<TEntity> QueryOrderBy<Tkey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Tkey>> keySelector, bool isQueryOrderBy);
        /// <summary>
        /// 升序分页查询还是降序分页
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">一页多少条</param>
        /// <param name="rowcount">返回共多少条</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelector">排序字段</param>
        /// <param name="isQueryOederBy">true为升序 false为降序</param>
        /// <returns></returns>
        List<TEntity> QueryByPage<Tkey>(int pageIndex, int pageSize, out int rowcount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Tkey>> keySelector, bool isQueryOederBy);

        #endregion

        #region 编辑
        /// <summary>
        /// 通过传入的model加需要修改的字段来更改数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="propertys"></param>
        void Edit(TEntity model,string[] propertys);
        /// <summary>
        /// 直接先查询再修改
        /// </summary>
        /// <param name="model"></param>
        void Edit(TEntity model);
        #endregion

        #region 删除
        void Delete(TEntity model, bool isadded);
        #endregion

        #region 新增
        void Add(TEntity model);
        #endregion

        #region 统一提交
        int SaveChanges();
        #endregion

        #region 调用存储过程返回一个指定的TResult
        List<TResult> RunProc<TResult>(string sql, params object[] pamrs);
        #endregion
    }
}
