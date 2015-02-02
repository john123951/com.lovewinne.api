using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Repository
{
	public class OrmLiteRepository<TEntity> : IRepository<TEntity> 
		where TEntity :   BaseEntity, new()
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

		public long Insert (TEntity entity)
		{
			using (var db = DbFactory.Open (Write)) {
				var result = db.Insert (entity);

				return result;
			}
		}

		public bool Update (TEntity entity)
		{
			using (var db = DbFactory.Open (Write)) {
				var result = db.Update (entity);

				return result > 0;
			}
		}

		public bool SaveOrUpdate (TEntity entity)
		{
			throw new NotImplementedException ();
		}

		public bool Remove (TEntity entity)
		{
			throw new NotImplementedException ();
		}

		public int InsertTransaction (IEnumerable<TEntity> entityList)
		{
			throw new NotImplementedException ();
		}

		public int UpdateTransaction (IEnumerable<TEntity> entityList)
		{
			throw new NotImplementedException ();
		}

		public int SaveOrUpdateTransaction (IEnumerable<TEntity> entityList)
		{
			throw new NotImplementedException ();
		}

		public int RemoveTransaction (IEnumerable<TEntity> entityList)
		{
			throw new NotImplementedException ();
		}

		public List<TEntity> LoadEntities (Func<SqlExpression<TEntity>, SqlExpression<TEntity>> whereLambda)
		{
			using (var db = DbFactory.Open (Write)) {

				var result = db.LoadSelect<TEntity> (whereLambda);

				return result;
			}
		}

		public List<TEntity> LoadEntities (Expression<Func<TEntity, bool>> whereLambda)
		{
			using (var db = DbFactory.Open (Write)) {

				var result = db.LoadSelect<TEntity> (whereLambda);

				return result;
			}
		}

		public List<TEntity> LoadPageEntities (int pageIndex, int pageSize, out int totalCount,
		                                       Expression<Func<TEntity, bool>> whereLambda,
		                                       Expression<Func<TEntity, object>> orderLambda, bool isAsc = true)
		{
			totalCount = 0;

			using (var db = DbFactory.Open (Write)) {
				Func<SqlExpression<TEntity>, SqlExpression<TEntity>> expr;

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

