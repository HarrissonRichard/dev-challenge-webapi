namespace RestChallenge.Models
{
    public record ProductModel
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }
        public string DescriptionEN { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public decimal AvailableSTK { get; set; }
        public decimal Vat { get; set; }
        public bool Inactive { get; set; }
        public int ComponentType { get; set; }
        public int RemoteId { get; set; }
        

    }
}
