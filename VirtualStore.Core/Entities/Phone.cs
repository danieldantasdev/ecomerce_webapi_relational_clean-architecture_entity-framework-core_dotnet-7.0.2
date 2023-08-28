using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStore.Core.Entities;

public class Phone
{
    [Column("code_country")] public string CodeCountry { get; private set; }
    [Column("code_area")] public string CodeArea { get; private set; }
    [Column("number")] public string Number { get; private set; }
}