﻿
using Curso.Mvc.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Curso.Mvc.Infra.Data.Mappings
{
    public class EnderecoMapping : EntityTypeConfiguration<Endereco>
    {

        public EnderecoMapping()
        {
            HasKey(e => e.Id);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(e => e.Complemento)
                .HasMaxLength(100);

            // ONE TO ONE OR ZERO
            // ONE TO ONE
            // ONE TO MANY OR ZERO
            // MANY TO MANY

            //ONE TO MANY
            HasRequired(c => c.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);

            ToTable("Enderecos");

        }
    }
}
