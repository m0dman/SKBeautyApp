using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using WebAPI.Application.Common.Interfaces;
using WebAPI.Infrastructure.Data.Contexts;

namespace WebAPI.Infrastructure.Contexts
{
    /// <summary>
    /// Factory class to support DBContext provisioning in the future to services and repository layers!
    /// </summary>
    public class DBContextFactory : IDbContextFactory
    {
        private readonly ILogger<DBContextFactory> _logger;
        private readonly IEnumerable<IApplicationDbContext> _contexts;


        public DBContextFactory(ILogger<DBContextFactory> logger
            , IEnumerable<IApplicationDbContext> contexts)
        {
            _logger = logger;
            _contexts = contexts;
        }

        #region Public Accessors

        /// <summary>
        /// Provide the Base DBContext
        /// </summary>
        /// <returns></returns>
        public IApplicationDbContext GetGenericContext()
        {
            //return _defaultContext;
            return GetContextByType(typeof(SKBeautyContext));
        }

        /// <summary>
        /// Base operation to attempt to query for a DBContext by a provided type
        /// </summary>
        /// <param name="type">Object Type</param>
        /// <returns>IApplicationDbContext</returns>
        public IApplicationDbContext TryFindContextByType(Type type)
        {
            IApplicationDbContext res = GetContextByType(type);
            return res;
        }

        #endregion

        /// <summary>
        /// Query records based on an object type
        /// </summary>
        /// <param name="type">Type paramter of expected class!</param>
        /// <returns>IApplicationDbContext or null</returns>
        IApplicationDbContext GetContextByType(Type type)
        {
            try{
                List<IApplicationDbContext> records = _contexts.ToList();
                return records.FirstOrDefault(i => i.GetType() == type);
            }
            catch{
                return null;
            }
        }
    }
}
