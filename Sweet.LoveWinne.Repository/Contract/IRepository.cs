using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ServiceStack.OrmLite;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Repository
{
	public interface IRepository<TEntity> 
		where TEntity :  BaseEntity, new()
	{
		long Insert (TEntity entity);

		bool Update (TEntity entity);

		bool SaveOrUpdate (TEntity entity);

		bool Remove (TEntity entity);

		int InsertTransaction (IEnumerable<TEntity> entityList);

		int UpdateTransaction (IEnumerable<TEntity> entityList);

		int SaveOrUpdateTransaction (IEnumerable<TEntity> entityList);

		int RemoveTransaction (IEnumerable<TEntity> entityList);

		List<TEntity> LoadEntities (Expression<Func<TEntity, bool>> whereLambda);

		//		List<TEntity> LoadEntities (Func<SqlExpression<TEntity>, SqlExpression<TEntity>> whereLambda);

		List<TEntity> LoadPageEntities (int pageIndex, int pageSize, out int totalCount,
		                                Expression<Func<TEntity, bool>> whereLambda,
		                                Expression<Func<TEntity, object>> orderLambda, bool isAsc = true);
	}
}

