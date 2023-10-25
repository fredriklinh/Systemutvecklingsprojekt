﻿using Datalager.Context;
using Datalager.Repository;
using Entiteter.Personer;
using Entiteter.Prislistor;
using Entiteter.Tjänster;


namespace Datalager
{
    public class UnitOfWork
    {

        protected dbContext _dbContext { get; }
        public Repository<Användare> AnvändareRepository { get; private set; }
        public Repository<Privatkund> PrivatkundRepository { get; private set; }

        public Repository<PrislistaLogi> PrisLogiRepository { get; private set; }

        public Repository<Logi> LogiRepository { get; private set; }

        public Repository<MasterBokning> MasterBokningRepository { get; private set; }
        public UnitOfWork()
        {
            _dbContext = new dbContext();
            AnvändareRepository = new Repository<Användare>(_dbContext);
            PrivatkundRepository = new Repository<Privatkund>(_dbContext);
            PrisLogiRepository = new Repository<PrislistaLogi>(_dbContext);
            LogiRepository = new Repository<Logi>(_dbContext);
            MasterBokningRepository = new Repository<MasterBokning>(_dbContext);

        }


        private bool isDisposed = false;
        private readonly bool disposeContext = false;

        //public UnitOfWork() : this(new dbContext())
        //{
        //    disposeContext = true;
        //}
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
