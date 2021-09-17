using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Agenda.Domain;
namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;

        SqlConnection _con;

        public Contatos()
        {
            _strCon = @"Data Source = LAPTOP-BRVE8T7A\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True;";

            _con = new SqlConnection(_strCon);
        }


        public void Adicionar(Contato contato)
        {

            _con.Open();
            string sql = String.Format("insert into Contato (Id,Nome) values('{0}','{1}')", contato.Id, contato.Nome);

            SqlCommand cmd = new SqlCommand(sql, _con);

            cmd.ExecuteNonQuery();
            _con.Close();
        }

        public Contato Obter(Guid id)
        {

            string strCon = @"Data Source = LAPTOP-BRVE8T7A\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True;";

            
            _con.Open();

            string sql = string.Format("select Id,Nome from Contato where Id = '{0}'", id);
            SqlCommand cmd = new SqlCommand(sql, _con);

            var sqlDataReader = cmd.ExecuteReader();
            sqlDataReader.Read();

            var contato = new Contato()
            {
                Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                Nome = sqlDataReader["Nome"].ToString()
            };
            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();
            _con.Open();

            string sql = string.Format("select Id,Nome from Contato");
            SqlCommand cmd = new SqlCommand(sql, _con);

            var sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                var contato = new Contato()
                {
                    Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                    Nome = sqlDataReader["Nome"].ToString()
                };
                contatos.Add(contato);
            }

            return contatos;
        }


    }
}

