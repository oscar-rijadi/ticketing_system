using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using TicketingSystem.Core.Db.Interfaces;

namespace TicketingSystem.Core.Db
{
    public class DbCommandReader<TContext> : IDbCommandReader
        where TContext : DbContext
    {
        private readonly TContext _context;

        private DbDataReader _reader;

        public object this[int oridnal] => _reader?[oridnal];

        public object this[string name] => _reader?[name];

        public DbCommandReader(TContext context)
        {
            _context = context;
        }

        public void ExecuteReader(string commandText, params object[] parameters)
        {
            var cmd = _context.Database.Connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandTimeout = 30;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);
            cmd.Connection.Open();
            _reader = cmd.ExecuteReader();
        }

        public bool Read()
        {
            if (_reader == null)
            {
                return false;
            }
            return _reader.Read();
        }

        public bool GetNextResult()
        {
            if (_reader == null)
            {
                return false;
            }
            return _reader.NextResult();
        }

        public List<T> Translate<T>()
        {
            var objCtx = ((IObjectContextAdapter)_context).ObjectContext;
            return objCtx.Translate<T>(_reader).ToList();
        }

        public void Dispose()
        {
            if (_reader != null)
            {
                if (_context.Database.Connection.State != ConnectionState.Closed)
                {
                    _context.Database.Connection.Close();
                }
                _reader.Close();
                _reader.Dispose();
            }
        }
    }
}
