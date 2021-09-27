using NUnit.Framework;
using System;
using Agenda.Domain;
using System.Linq;
using AutoFixture;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest : BaseTest
    {
        Contatos _contatos;
        Fixture _fixture;


        [SetUp]//Indica que o método será executado antes de cada método de teste
        public void SetUp()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        //IncluirContatoTest
        [Test]//indica o método a ser testado
        public void AdicionarContatoTest()
        {
            //Monta
            var contato = _fixture.Create<Contato>();

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
            var contato = _fixture.Create<Contato>();
            Contato resultado;

            //Executa
            _contatos.Adicionar(contato);
            resultado = _contatos.Obter(contato.Id);

            //Verifica
            Assert.AreEqual(contato.Id, resultado.Id);//Verifica se o nome incluido é igual ao retornado com o ID
            Assert.AreEqual(contato.Nome, resultado.Nome);
        }

       

        [TearDown]// Indica que o método será executado depois de cada método de teste
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
