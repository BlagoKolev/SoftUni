using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data.EntityConfiguration
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {

        }
    }
}
