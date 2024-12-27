using System.Reflection.Metadata;

namespace Projetoalex.Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }



        public bool Ativo { get; set; }

        #region Relacionamentos

        #endregion

        public Usuario()
        {
            Ativo = true;
        }

        public void Deletar()
        {
            Ativo = false;
        }
        public void Restaurar()
        {
            Ativo = true;
        }


    }
}