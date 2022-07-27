using RestChallenge.Dtos;
using RestChallenge.Models;

namespace RestChallenge
{
    public static class Extension
    {

        public static ProductDto getDto(this ProductModel product)
        {
            return new ProductDto {
                Id = product.Id,
                Identifier = product.Identifier,
                Description = product.Description,
                DescriptionEN = product.DescriptionEN,
                Price = product.Price,
                Unit = product.Unit,
                AvailableSTK = product.AvailableSTK,
                Vat = product.Vat,
                Inactive = product.Inactive,
                ComponentType = product.ComponentType,
                RemoteId = product.RemoteId
            };
        }
    }
}