using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Vagas.Modelos;
using Xamarin.Forms;
using System.Linq;

namespace Vagas.Banco
{
    class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");
            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Vaga>();
        }
        public void Cadastro(Vaga vaga)
        {
            _conexao.Insert(vaga);
        }
        public void Exclusao(Vaga vaga)
        {
            _conexao.Delete(vaga);
        }
        public void Atualizacao(Vaga vaga)
        {
            _conexao.Update(vaga);
        }
        public List<Vaga> Consultar()
        {
            return _conexao.Table<Vaga>().ToList();
            
        }
        public List<Vaga> Pesquisar(string palavra)
        {
            return _conexao.Table<Vaga>().Where(a => a.NomeVaga.Contains(palavra)).ToList();

        }
        public Vaga ObterVagaId(int id)
        {
            return _conexao.Table<Vaga>().Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
