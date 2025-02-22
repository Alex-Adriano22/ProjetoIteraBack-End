using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Projetoalex.Dominio.Entidades
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Column (TypeName ="decimal(18,2)")]
        public decimal Preco { get; set; }
        
        public string Descricao { get; set; }



        public bool Ativo { get; set; }

        #region Relacionamentos


        #endregion

        public Produtos()
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