namespace RestChallenge.Dtos
{
    public record ProductDto
    {
        
        public int Id { get; init; }
        public string Identifier { get; init; }
        public string Description { get; init; }
        public string DescriptionEN { get; init; }
        public decimal Price { get; init; }
        public string Unit { get; init; }
        public decimal AvailableSTK { get; init; }
        public decimal Vat { get; init; }
        public bool Inactive { get; init; }
        public int ComponentType { get; init; }
        public int RemoteId { get; set; }

    }    
}
