using System;
using System.Collections.Generic;
using Primeiro_Projeto.Interfaces;

namespace Primeiro_Projeto
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> listaFilme = new List<Filme>();
        public List<Filme> Lista()
        {
            return listaFilme;
        }
        public Filme RetornaPorId(int id)
        {
            return listaFilme[id];
        }
        public void Insere(Filme objeto)
        {
            listaFilme.Add(objeto);
        }
        public void Exclui(int id)
        {
            listaFilme[id].Excluir();
        }
        public void Atualiza(int id, Filme objeto)
        {
            listaFilme[id] = objeto;
        }
        public int ProximoId()
        {
            return listaFilme.Count;
        }
    }
}