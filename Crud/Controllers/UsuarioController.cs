using Crud.Database;
using Crud.Models;
using Crud.ViewModel.App.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Consultar()
        {
            using (DbCrud contextObj = new DbCrud())
            {
                var usuarios = contextObj.Usuarios.ToList();

                List<dynamic> usuariosJson = new List<dynamic>();

                foreach (Usuario usuario in usuarios)
                {
                    usuariosJson.Add(new
                    {
                        idUsuario = usuario.IdUsuario,
                        nome = usuario.Nome,
                        email = usuario.Email,
                        telefone = String.IsNullOrEmpty(usuario.Telefone) ? "Não Informado" : usuario.Telefone,
                        cpf = String.IsNullOrEmpty(usuario.Cpf) ? "Não Informado" : usuario.Cpf,
                    }
                    );
                }
                return Json(usuariosJson, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult PorId(string id)
        {
            using (DbCrud contextObj = new DbCrud())
            {
                var idUsuario = Convert.ToInt32(id);
                var usuario = contextObj.Usuarios.Where(u => u.IdUsuario == idUsuario);
                return Json(usuario, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public string Salvar(CadastrarUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
            }
            if (viewModel != null)
            {
                using (DbCrud contextObj = new DbCrud())
                {
                    Usuario usuario = new Usuario();
                    usuario.Nome = viewModel.Nome;
                    usuario.Telefone = viewModel.Telefone;
                    usuario.Email = viewModel.Email;
                    usuario.Cpf = viewModel.Cpf;

                    contextObj.Usuarios.Add(usuario);
                    contextObj.SaveChanges();
                    return "Usuário cadastado com sucesso.";
                }
            }
            else
            {
                return "Usuário não Cadastrado";
            }
        }

        [HttpPost]
        public string Atualizar(AtualizarUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
            }
            if (viewModel.idUsuario != 0)
            {
                using (DbCrud contextObj = new DbCrud())
                {
                    Usuario usuario = contextObj.
                                        Usuarios
                                        .Where(u => u.IdUsuario == viewModel.idUsuario).FirstOrDefault();

                    if (usuario != null)
                    {
                        usuario.Nome = viewModel.Nome;
                        usuario.Telefone = viewModel.Telefone;
                        usuario.Email = viewModel.Email;
                        usuario.Cpf = viewModel.Cpf;

                        contextObj.SaveChanges();
                        return "Usuário atualizado com sucesso!";
                    }
                    else
                    {
                        return "Usuário não atualizado";
                    }
                }
            }
            else
            {
                return "Usuário não atualizado";
            }
        }

        [HttpPost]
        public string Deletar(string idUsuario)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
            }
            if (!String.IsNullOrEmpty(idUsuario))
            {
                try
                {
                    int _idUsuario = Int32.Parse(idUsuario);
                    using (DbCrud contextObj = new DbCrud())
                    {
                        Usuario _usuario = contextObj.Usuarios.Where(u => u.IdUsuario == _idUsuario).FirstOrDefault();
                        contextObj.Usuarios.Remove(_usuario);
                        contextObj.SaveChanges();
                        return "Usuário deletado com sucesso;";
                    }
                }
                catch (Exception)
                {
                    return "Usuário não encontrado";
                }
            }
            else
            {
                return "Erro Interno";
            }
        }
    }
}