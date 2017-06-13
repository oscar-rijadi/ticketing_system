using System;
using System.Collections.Generic;
namespace TicketingSystem.Core.Db.Interfaces
{
    public interface IDbCommandReader : IDisposable
    {
        void ExecuteReader(string commandText, params object[] parameters);

        bool Read();

        bool GetNextResult();

        List<T> Translate<T>();

        object this[int oridnal] { get; }

        object this[string name] { get; }
    }
}
