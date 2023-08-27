namespace VirtualStore.Core.Entities;

public class Address : BaseEntity
{
    public string PublicSpace { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string Neighborhood { get; private set; }
    public string Cep { get; private set; }
    public Client Client { get; private set; }
    public int ClientId { get; private set; }
    public City City { get; private set; }
    public int CityId { get; private set; }
}