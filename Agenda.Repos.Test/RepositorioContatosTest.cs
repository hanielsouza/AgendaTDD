using Agenda.DAL;
using Agenda.Domain;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Agenda.Repos.Test
{
    [TestFixture]
    public class RepositorioContatosTest
    {
        Mock<IContatos> _contatos;
        Mock<ITelefones> _telefones;
        RepositorioContatos _repositorioContatos;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Mock<IContatos>();
            _telefones = new Mock<ITelefones>();
            _repositorioContatos = new RepositorioContatos(_contatos.Object, _telefones.Object);
        }

        [Test]
        public void DeveSerPossivilObterContatoComListTelefone()
        {
            var telefoneId = Guid.NewGuid();
            var contatoId = Guid.NewGuid();
            var lstTelefone = new List<ITelefone>();
            //Monta
            //Criar Moq de Icontato
            var mContato = IContatoConstr.Um().ComId(contatoId).ComNome("João").Obter();
            mContato.SetupSet(o => o.Telefones = It.IsAny<List<ITelefone>>()).Callback<List<ITelefone>>(p=> lstTelefone = p);
            //moq da função ObterId de Icontatos
            _contatos.Setup(o => o.Obter(contatoId)).Returns(mContato.Object);
            //Cria moq de Itelefones 
            var mockTelefone = ITelefoneConstr.Um().Padrao().ComId(telefoneId).ComContatoId(contatoId).Construir();
            //moq da função ObterTodosDoCOntato de ITelefones
            _telefones.Setup(o => o.ObterTodosDoContato(contatoId)).Returns(new List<ITelefone> { mockTelefone });
            //Executa
            //Chamar o método ObterPorId de RepositorioContatos
            IContato contatoResultado = _repositorioContatos.ObterPorId(contatoId);
            mContato.SetupGet(o => o.Telefones).Returns(lstTelefone);
            //Verifica
            //Verificar se o contato retornado contem os mesmo dados do moq IContato com a lista de telefones do Moq ITelefone
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mContato.Object.Nome, contatoResultado.Nome);
            Assert.AreEqual(1, contatoResultado.Telefones.Count);
            Assert.AreEqual(mockTelefone.Numero, contatoResultado.Telefones[0].Numero);
            Assert.AreEqual(mockTelefone.Id, contatoResultado.Telefones[0].Id);
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Telefones[0].ContatoId);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _telefones = null;
            _repositorioContatos = null;
        }
    }
}
