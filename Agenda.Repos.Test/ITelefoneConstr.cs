using Agenda.Domain;
using System;
using AutoFixture;

namespace Agenda.Repos.Test
{
    public class ITelefoneConstr:BaseConstr<ITelefone>
    {
        protected ITelefoneConstr(): base() { }

        public static ITelefoneConstr Um()
        {
            return new ITelefoneConstr();
        }

        public ITelefoneConstr Padrao()
        {
            _mock.SetupGet(o => o.Id).Returns(_fixture.Create<Guid>());
            _mock.SetupGet(o => o.Numero).Returns(_fixture.Create<string>());
            _mock.SetupGet(o => o.ContatoId).Returns(_fixture.Create<Guid>());
            return this;
        }

        public ITelefoneConstr ComId(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id);
            return this;
        }

        public ITelefoneConstr ComNumero(string numero)
        {
            _mock.SetupGet(o => o.Numero).Returns(numero);
            return this;
        }

        public ITelefoneConstr ComContatoId(Guid contatoId)
        {
            _mock.SetupGet(o => o.ContatoId).Returns(contatoId);
            return this;
        }
    }
}
