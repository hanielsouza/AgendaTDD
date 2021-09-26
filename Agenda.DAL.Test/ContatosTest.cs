using NUnit.Framework;
using System;
using Agenda.Domain;
using System.Linq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest
    {
        Contatos _contatos;

        [SetUp]//Indica que o método será executado antes de cada método de teste
        public void SetUp()
        {
            _contatos = new Contatos();
        }

        //IncluirContatoTest
        [Test]//indica o método a ser testado
        public void AdicionarContatoTest()
        {
            //Monta
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Marcos"
            };

            //Executa
            _contatos.Adicionar(contato);

            //Verifica
            Assert.True(true);
        }

        //ObterContatoTest
        [Test]//indica o método a ser testado
        public void ObterContatoTest()
        {
            //Monta
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Maria"
            };
            Contato resultado;

            //Executa
            _contatos.Adicionar(contato);
            resultado = _contatos.Obter(contato.Id);

            //Verifica
            Assert.AreEqual(contato.Id,resultado.Id);//Verifica se o nome incluido é igual ao retornado com o ID
            Assert.AreEqual(contato.Nome, resultado.Nome);
        }

        [Test]
        public void ObterTodosOsContatosTest()
        {
            //Monta
            var contato1 = new Contato() { Id = Guid.NewGuid(), Nome = "Maria"};
            var contato2 = new Contato() { Id = Guid.NewGuid(), Nome = "João"};
            //Executa
            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);

            var lstContato = _contatos.ObterTodos();
            var contatoResultado = lstContato.Where(o => o.Id == contato1.Id).FirstOrDefault();
            //Verifica
            Assert.IsTrue(lstContato.Count > 1);
            Assert.AreEqual(contato1.Id, contatoResultado.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado.Nome);
        }

        [TearDown]// Indica que o método será executado depois de cada método de teste
        public void TearDown()
        {
            _contatos = null;
        }
    }
}
