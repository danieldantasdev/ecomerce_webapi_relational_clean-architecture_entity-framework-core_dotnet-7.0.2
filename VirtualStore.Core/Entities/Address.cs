using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStore.Core.Entities;

public class Address : BaseEntity
{
    [Column("public_place")] public string PublicPlace { get; private set; }
    [Column("number")] public string Number { get; private set; }
    [Column("complement")] public string Complement { get; private set; }
    [Column("neighborhood")] public string Neighborhood { get; private set; }
    [Column("cep")] public string Cep { get; private set; }
    [Column("client_id")] public int ClientId { get; private set; }
    public Client Client { get; private set; }
    [Column("city_id")] public int CityId { get; private set; }
    public City City { get; private set; }
}