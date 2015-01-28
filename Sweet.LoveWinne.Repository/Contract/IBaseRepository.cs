using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ServiceStack.OrmLite;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Repository
{
	public interface IBaseRepository<T> 
		where T :  BaseEntity
	{
		long Insert (T entity);

		bool Update (T entity);

		bool SaveOrUpdate (T entity);

		bool Remove (T entity);

		int InsertTransaction (IEnumerable<T> entityList);

		int UpdateTransaction (IEnumerable<T> entityList);

		int SaveOrUpdateTransaction (IEnumerable<T> entityList);

		int RemoveTransaction (IEnumerable<T> entityList);

		List<T> LoadEntities (Func<SqlExpression<T>, SqlExpression<T>> whereLambda);

		List<T> LoadPageEntities (int pageIndex, int pageSize, out int totalCount,
		                          Expression<Func<T, bool>> whereLambda,
		                          Expression<Func<T, object>> orderLambda, bool isAsc = true);
	}
}

