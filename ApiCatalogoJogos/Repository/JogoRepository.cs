using System;
using System.Collections.Generic;
using System.Linq;
using ApiCatalogoJogos.Domain.Entities;
using ApiCatalogoJogos.Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ApiCatalogoJogos.Repository
{
    class JogoRepository : IRepository
    {
        private readonly SqlConnection _sqlConnection;

        public JogoRepository(IConfiguration configuration)
        {
            _sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }


        public async Task<List<Jogo>> Get(int pagina, int quantidade)
        {
            var jogos = new List<Jogo>();

            var comando = $"SELECT * FROM Jogos ORDER BY ID OFFSET{((pagina - 1) * quantidade)} ROWS FECTH NEXT {quantidade} ROW";

            await _sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, _sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                jogos.Add(new Jogo
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Produtora = (string)sqlDataReader["Produtora"],
                    Preco = (double)sqlDataReader["Preco"]
                });
            }

            await _sqlConnection.CloseAsync();

            return jogos;

        }

        public async Task<List<Jogo>> Get(string nome, string produtora)
        {
            var jogos = new List<Jogo>();

            var comando = $"SELECT * FROM Jogos WHERE Nome = '{nome}' AND Produtora = '{produtora}'";

            await _sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, _sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                jogos.Add(new Jogo
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Produtora = (string)sqlDataReader["Produtora"],
                    Preco = (double)sqlDataReader["Preco"]
                });
            }

            await _sqlConnection.CloseAsync();

            return jogos;
        }

        public async Task<Jogo> GetById(Guid id)
        {
            Jogo jogo = null;

            var comando = $"SELECT * FROM Jogos WHERE Id = '{id}'";

            await _sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, _sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                jogo = new Jogo
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Produtora = (string)sqlDataReader["Produtora"],
                    Preco = (double)sqlDataReader["Preco"]
                };
            }

            await _sqlConnection.CloseAsync();

            return jogo;
        }

        public async Task Post(Jogo jogo)
        {
            var comando = $"INSERT INTO Jogos (Id, Nome, Produtora, Preco) VALUES('{jogo.Id}','{jogo.Nome}','{jogo.Produtora}','{jogo.Preco}')";

            await _sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
            
            await _sqlConnection.CloseAsync();
        }
        
        public async Task Update(Jogo jogo)
        {
            var comando = $"UPDATE Jogos SET Nome = '{jogo.Nome}', Produtora = '{jogo.Produtora}', Preco = '{jogo.Preco.ToString().Replace(",",".")}')" +
                $"WHERE Id = '{jogo.Id}'";

            await _sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, _sqlConnection);
            sqlCommand.ExecuteNonQuery();

            await _sqlConnection.CloseAsync();
        }


        public async Task Delete(Guid id)
        {
            var comando = $"DELETE FROM Jogos WHERE Id = '{id}'";

            await _sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, _sqlConnection);
            sqlCommand.ExecuteNonQuery();

            await _sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            _sqlConnection?.Close();
            _sqlConnection?.Dispose();
        }
    }
}
