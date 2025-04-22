namespace MystiqueMapperTests.Models
{
    internal class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
        public bool Active { get; set; }
    }
}
