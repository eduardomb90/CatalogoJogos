using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCatalogoJogos.Domain.Entities;
using ApiCatalogoJogos.Domain.Interfaces;
using System.Data.SqlClient;

namespace ApiCatalogoJogos.Infra.Repository
{
    class JogoRepository : IRepository
    {
        public JogoRepository(IConfiguration configuration)
        {

        }
        
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Jogo>> Get(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<List<Jogo>> Get(string nome, string produtora)
        {
            throw new NotImplementedException();
        }

        public Task<Jogo> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Task Post(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
