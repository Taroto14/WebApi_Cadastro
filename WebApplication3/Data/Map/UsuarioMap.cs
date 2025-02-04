﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeiraApi.Models;

namespace PrimeiraApi.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(150);
        }
    }
}
