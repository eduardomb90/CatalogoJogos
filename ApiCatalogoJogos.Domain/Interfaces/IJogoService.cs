using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCatalogoJogos.Domain.ViewModel;
using ApiCatalogoJogos.Domain.InputModel;

namespace ApiCatalogoJogos.Domain.Interfaces
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> Get(int pagina, int quantidade);
        Task<JogoViewModel> GetById(Guid id);
        Task<JogoViewModel> Post(JogoInputModel jogo);
        Task Update(Guid id, JogoInputModel jogo);
        Task Update(Guid id, double preco);
        Task Delete(Guid id);
    }
}
