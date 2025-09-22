using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Clientes.Web.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O campo Situação é obrigatório.")]
        [Display(Name = "Situação")]
        public int IdSituacao { get; set; }

        public string NomeSituacao { get; set; }

        public string CpfFormatado
        {
            get
            {
                if (string.IsNullOrEmpty(Cpf)) return string.Empty;

                var cpfNumeros = new string(Cpf.Where(char.IsDigit).ToArray());

                if (cpfNumeros.Length != 11) return Cpf; // retorna como está se não tiver 11 dígitos

                return Convert.ToUInt64(cpfNumeros).ToString(@"000\.000\.000\-00");
            }
        }

    }
}
