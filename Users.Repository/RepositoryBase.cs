using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Repository
{
    public class RepositoryBase<ctx> : IDisposable
        where ctx : DbContext, new()
    {
        private ctx _dbContext;

        

        public virtual ctx DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new ctx();
                    this.AllowSerialization = true;
                }
                return _dbContext;
            }
           
        }

        public virtual bool AllowSerialization
        {
            get
            {
                return _dbContext.Configuration.ProxyCreationEnabled;
            }
            private set
            {
                _dbContext.Configuration.ProxyCreationEnabled = !value;
            }
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
