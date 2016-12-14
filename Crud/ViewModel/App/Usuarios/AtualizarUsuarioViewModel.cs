using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud.ViewModel.App.Usuarios
{
    public class AtualizarUsuarioViewModel
    {
        [Required(ErrorMessage = "Campo '{0}' é obrigatório.")]
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Campo '{0}' é obrigatório.")]
        [MaxLength(150, ErrorMessage = "Campo '{0}' deve conter no máximo '{1}' caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo '{0}' é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Campo '{0}' deve conter no máximo '{1}' caracteres.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }

        [MaxLength(14, ErrorMessage = "Campo '{0}' deve conter no máximo '{1}' caracteres.")]
        public string Telefone { get; set; }

        public string Cpf { get; set; }
    }
}