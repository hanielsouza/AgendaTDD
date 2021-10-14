using Agenda.Domain;
using AutoFixture;
using Moq;
using System;

namespace Agenda.Repos.Test
{
    public class IContatoConstr
    {
        private readonly Mock<IContato> _mockIcontato;
        private readonly Fixture _fixture;

        protected IContatoConstr(Mock<IContato> mockIcontato,Fixture fixture)
        {
            _mockIcontato = mockIcontato;
            _fixture = fixture;
        }

        public static IContatoConstr Um()
        {
            return new IContatoConstr(new Mock<IContato>(), new Fixture());
        }

        public Mock<IContato> Obter()
        {
            return _mockIcontato;
        }

        public IContato Construir()
        {
            return _mockIcontato.Object;
        }

        public IContatoConstr ComNome(string nome)
        {
            _mockIcontato.SetupGet(o => o.Nome).Returns(nome);
            return this;
        }

        public IContatoConstr ComId(Guid id)
        {
            _mockIcontato.SetupGet(o => o.Id).Returns(id);
            return this;
        }
    }
}
