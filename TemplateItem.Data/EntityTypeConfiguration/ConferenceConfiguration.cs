using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateItem.Models;

namespace TemplateItem.Data.EntityTypeConfiguration
{
    class ConferenceConfiguration : IEntityTypeConfiguration<Conference>
    {
        public void Configure(EntityTypeBuilder<Conference> builder)
        {
            builder.ToTable("Conference").HasKey(x => new { x.Id });
        }
    }
}
