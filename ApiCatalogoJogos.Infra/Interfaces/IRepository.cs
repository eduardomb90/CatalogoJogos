using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCatalogoJogos.Domain.Entities;

namespace ApiCatalogoJogos.Infra.Interfaces
{
    public interface IRepository
    {
        Task<List<Jogo>> Get(int pagina, int quantidade);
        Task<Jogo> GetById(Guid id);
        Task<List<Jogo>> Get(string nome, string produtora);
        Task Post(Jogo jogo);
        Task Patch(Jogo jogo);
        Task Delete(Guid id);
    }
}
