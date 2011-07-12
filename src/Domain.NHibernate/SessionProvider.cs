﻿namespace BeerConf.Domain.NHibernate
{
    using System;
    using global::NHibernate;

    public class SessionProvider : ISessionProvider
    {
        private readonly ISessionFactory sessionFactory;
        private bool disposed;
        private bool preventCommit;
        private ISession session;
        private ITransaction transaction;

        public SessionProvider(ISessionFactory sessionFactory)
        {
            if (sessionFactory == null)
                throw new ArgumentNullException("sessionFactory");

            this.sessionFactory = sessionFactory;
        }

        #region ISessionProvider Members

        public ISession CurrentSession
        {
            get
            {
                if (disposed)
                    throw new InvalidOperationException("Object already disposed. Probably container has wrong lifestyle type");

                if (session != null)
                    return session;

                session = sessionFactory.OpenSession();
                transaction = session.BeginTransaction();

                return session;
            }
        }

        public void PreventCommit()
        {
            preventCommit = true;
        }

        public void Dispose()
        {
            if (disposed)
                return;

            if (session == null)
                return;

            try
            {
                if (preventCommit)
                    transaction.Rollback();
                else
                    transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }

            session.Dispose();
            session = null;
            transaction = null;
            disposed = true;
        }

        #endregion
    }
}
