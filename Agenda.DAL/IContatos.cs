using Agenda.Domain;
using System;

namespace Agenda.DAL
{
    public interface IContatos
    {
        IContato Obter(Guid id);
    }
}
