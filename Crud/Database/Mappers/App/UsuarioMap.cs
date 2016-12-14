using Crud.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Crud.Database.Mappers.App
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuarios", "dbo");

            HasKey(b => b.IdUsuario);

            Property(b => b.IdUsuario).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(b => b.Email).HasMaxLength(100).IsRequired();
            Property(b => b.Nome).HasMaxLength(150).IsRequired();
            Property(b => b.Telefone).HasMaxLength(14).IsOptional();
            Property(b => b.Cpf).HasMaxLength(15).IsOptional();

        }
    }
}