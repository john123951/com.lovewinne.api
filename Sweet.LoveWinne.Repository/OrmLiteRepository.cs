using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Repository
{
	public class OrmLiteRepository<T> : IBaseRepository<T> 
		where T :   BaseEntity
	{
		private const string Read = "read";
		private const string Write = "write";

		private static readonly IDbConnectionFactory dbFactory;

		public static IDbConnectionFactory DbFactory {
			get { return dbFactory ?? new OrmLiteConnectionFactory (); }
		}

		static OrmLiteRepository ()
		{
			OrmLiteConfig.DialectProvider = MySqlDialect.Provider;

			dbFactory = new OrmLiteConnectionFactory ();
			OrmLiteConnectionFactory.NamedConnections.Add (Read, new OrmLiteConnectionFactory (GlobalConfig.GetInstance ().ConnectionString));
			OrmLiteConnectionFactory.NamedConnections.Add (Write, new OrmLiteConnectionFactory (GlobalConfig.GetInstance ().ConnectionString));
		}

		public long Insert (T entity)
		{
			using (var db = DbFactory.Open (Write)) {
				var result = db.Insert (entity);

				return result;
			}
		}

		public bool Update (T entity)
		{
			using (var db = DbFactory.Open (Write)) {
				var result = db.Update (entity);

				return result > 0;
			}
		}

		public bool SaveOrUpdate (T entity)
		{
			throw new NotImplementedException ();
		}

		public bool Remove (T entity)
		{
			throw new NotImplementedException ();
		}

		public int InsertTransaction (IEnumerable<T> entityList)
		{
			throw new NotImplementedException ();
		}

		public int UpdateTransaction (IEnumerable<T> entityList)
		{
			throw new NotImplementedException ();
		}

		public int SaveOrUpdateTransaction (IEnumerable<T> entityList)
		{
			throw new NotImplementedException ();
		}

		public int RemoveTransaction (IEnumerable<T> entityList)
		{
			throw new NotImplementedException ();
		}

		public List<T> LoadEntities (Func<SqlExpression<T>, SqlExpression<T>> whereLambda)
		{
			using (var db = DbFactory.Open (Write)) {

				var result = db.LoadSelect<T> (whereLambda);

				return result;
			}
		}

		public List<T> LoadPageEntities (int pageIndex, int pageSize, out int totalCount,
		                                 Expression<Func<T, bool>> whereLambda,
		                                 Expression<Func<T, object>> orderLambda, bool isAsc = true)
		{
			totalCount = 0;

			using (var db = DbFactory.Open (Write)) {
				Func<SqlExpression<T>, SqlExpression<T>> expr;

				if (isAsc) {
					expr = s => s.Where (whereLambda).OrderBy (orderLambda).Skip (pageSize * (pageIndex - 1)).Take (pageSize);
				} else {
					expr = s => s.Where (whereLambda).OrderByDescending (orderLambda).Skip (pageSize * (pageIndex - 1)).Take (pageSize);
				}

				var result = db.LoadSelect (expr);

				return result;
			}
		}
	}
}

