using ApiCatalogoJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Domain.Interfaces
{
    public interface IRepository : IDisposable
    {
        Task<List<Jogo>> Get(int pagina, int quantidade);
        Task<Jogo> GetById(Guid id);
        Task<List<Jogo>> Get(string nome, string produtora);
        Task Post(Jogo jogo);
        Task Update(Jogo jogo);
        Task Delete(Guid id);
    }
}
