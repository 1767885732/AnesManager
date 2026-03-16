using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace Wis.Anes.Data
{
   public class DbWrapTransaction:IDisposable
    {
       private DbTransaction _dbTransaction;
       private DbConnection _dbConnection;

       public DbTransaction InnerDbTransaction
       {
           get
           {
               return _dbTransaction;
           }
           
       }
       public DbConnection InnerDbConnection
       {
           get
           {
               return _dbConnection;
           }
       }
       public DbWrapTransaction(DbConnection connection)
       {
           _dbConnection = connection;
           _dbConnection.Open();
           _dbTransaction= _dbConnection.BeginTransaction();
       }
       public void Rollback()
       {
           if (_dbTransaction != null)
              _dbTransaction.Rollback();
       }

       public void Commit()
       {
           if(_dbTransaction!=null)
              _dbTransaction.Commit();
           
       }
       public void Dispose()
       {
           if (_dbConnection != null)
           {
               _dbConnection.Dispose();
           }
           if(_dbTransaction!=null)
               _dbTransaction.Dispose();
       }

      
    }
}
