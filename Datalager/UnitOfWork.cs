using Datalager.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datalager
{
    public class UnitOfWork
    {

            protected dbContext _dbContext { get; }



            private bool isDisposed = false;
            private readonly bool disposeContext = false;
           
            public UnitOfWork() : this(new dbContext())
            {
                disposeContext = true;
            }
            public UnitOfWork(dbContext bokningDbContext)
            {
                _dbContext = bokningDbContext;
            }
            public int Complete()
            {
                return _dbContext.SaveChanges();
            }
            public void Dispose()
            {
                Dispose(true);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (isDisposed)
                {
                    return;
                }
                if (disposing)
                {
                    if (disposeContext)
                    {
                        _dbContext.Dispose();
                    }
                }
                isDisposed = true;
            }
            ~UnitOfWork()
            {
                Dispose(false);
            }
        
    }
}
