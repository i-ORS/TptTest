using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace TptInheritanceTest;

[Table("BASE")]
public class Base
{
    [DataMember, Column("ID"), Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [DataMember, Column("NAME"), Required]
    public string Name { get; set; }

}

[Table("DERIVED")]
public class Derived : Base
{
    [DataMember, Column("ANOTHERNAME"), Required]
    public string AnotherName { get; set; }
}

public class BaseConfiguration : IEntityTypeConfiguration<Base>
{
    public void Configure(EntityTypeBuilder<Base> builder)
    {
        builder.Property(p => p.Id).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
    }
}