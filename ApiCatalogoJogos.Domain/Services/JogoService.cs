using ApiCatalogoJogos.Domain.Entities;
using ApiCatalogoJogos.Domain.InputModel;
using ApiCatalogoJogos.Domain.Interfaces;
using ApiCatalogoJogos.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Domain.Services
{
    public class JogoService : IJogoService
    {
        //Properties
        private readonly IRepository _repositorio;

        //Constructor
        public JogoService(IRepository repositorio)
        {
            _repositorio = repositorio;
        }
        

        //Methods
        public async Task<List<JogoViewModel>> Get(int pagina, int quantidade)
        {
            var jogos = await _repositorio.Get(pagina, quantidade);

            return jogos.Select(jogo => new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            }).ToList();

        }

        public async Task<JogoViewModel> GetById(Guid id)
        {
            var jogo = await _repositorio.GetById(id);

            if (jogo == null)
                return null;

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task<JogoViewModel> Post(JogoInputModel jogo)
        {
            var entidadeJogo = await _repositorio.Get(jogo.Nome, jogo.Produtora);

            if (entidadeJogo.Count > 0)
                throw new Exception();

            var jogoInsert = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };

            await _repositorio.Post(jogoInsert);

            return new JogoViewModel
            {
                Id = jogoInsert.Id,
                Nome = jogoInsert.Nome,
                Produtora = jogoInsert.Produtora,
                Preco = jogoInsert.Preco
            };
        }

        public async Task Update(Guid id, JogoInputModel jogo)
        {
            var entidadeJogo = await _repositorio.GetById(id);

            if (entidadeJogo == null)
                throw new Exception();

            entidadeJogo.Nome = jogo.Nome;
            entidadeJogo.Produtora = jogo.Produtora;
            entidadeJogo.Preco = jogo.Preco;

            await _repositorio.Update(entidadeJogo);
        }
        
        public async Task Update(Guid id, double preco)
        {
            var entidadeJogo = await _repositorio.GetById(id);

            if (entidadeJogo == null)
                throw new Exception();

            entidadeJogo.Preco = preco;

            await _repositorio.Update(entidadeJogo);
        }

        public async Task Delete(Guid id)
        {
            var jogo = await _repositorio.GetById(id);

            if (jogo == null)
                throw new Exception();

            await _repositorio.Delete(id);
        }

        public void Dispose()
        {
            _repositorio?.Dispose();
        }
    }
}
