using LightScience.Migrations;
using System.ComponentModel.DataAnnotations;

namespace LightScience.Models
{
    public class Cutura
    {
        public int CuturaId { get; set; }

        [Required(ErrorMessage = "O código da cutura deve ser informado")] //Define que o campo  é obrigatório
        [Display(Name = "Código")]//Define o nome do campo quando o usuário for preencher este campo no sistema
        public int CodigoCutura { get; set; }

        [Required(ErrorMessage = "A categoria da cutura deve ser informado")] //Define que o campo  é obrigatório
        [Display(Name = "Categoria")]//Define o nome do campo quando o usuário for preencher este campo no sistema
        [StringLength(20, ErrorMessage = "O tamanho máximo é de 20 caracteres")] //Define a capacidade maxima de caracteres aceita no campo
        public string Categoria { get; set; }

        [Required(ErrorMessage = "A descrição da cutura deve ser informado")] //Define que o campo  é obrigatório
        [Display(Name = "Descrição")]//Define o nome do campo quando o usuário for preencher este campo no sistema
        [StringLength(100, ErrorMessage = "O tamanho máximo é de 20 caracteres")] //Define a capacidade maxima de caracteres aceita no campo
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o m² ideal para essa cutura")] //Define que o campo é obrigatório
        [Display(Name = "Lux m²")]//Define o nome do campo quando o usuário for preencher este campo no sistema
        [StringLength(20, ErrorMessage = "O tamanho máximo é de 20 caracteres")] //Define a capacidade maxima de caracteres aceita no campo CategoriaNome
        public string Nome { get; set; }
    }
}
