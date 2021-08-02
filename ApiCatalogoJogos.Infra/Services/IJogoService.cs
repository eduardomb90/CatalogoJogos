using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCatalogoJogos.ViewModel;
using ApiCatalogoJogos.InputModel;

namespace ApiCatalogoJogos.Infra.Services
{
    interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> Get(int pagina, int quantidade);
        Task<JogoViewModel> GetById(Guid id);
        Task<JogoViewModel> Post(JogoInputModel jogo);
        Task Update(Guid id, JogoInputModel jogo);
        Task Update(Guid id, double preco);
        Task Remover(Guid id);
    }
}
