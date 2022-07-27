using FluentValidation;
using RestChallenge.Dtos;
using RestChallenge.Models;

namespace RestChallenge.Utils
{
    public class ProductModelValidator: AbstractValidator<ProductModel>
    {

        public ProductModelValidator()
        {
            RuleSet("OnCreate", () => 
            {
            RuleFor(product => product.Identifier).NotEmpty().WithMessage("O identificador nao pode ser vazio").NotNull().WithMessage("Por favor insira um identificador");
            RuleFor(product => product.Description).NotEmpty().WithMessage("Insira uma breve descricao do produto").NotNull().WithMessage("o produto precisa de uma descricao").MinimumLength(10).WithMessage("A desscricao precida de pelo menos 10 caracteres");
            RuleFor(product => product.Price).NotEmpty().WithMessage("produto precisa de um preço");
            RuleFor(product => product.Unit).NotEmpty().WithMessage("Digite a unidade de medida");
            RuleFor(product => product.Vat).NotEmpty().WithMessage("Produto precisa de um VAT");
            RuleFor(product => product.DescriptionEN).MinimumLength(10).WithMessage("a desc precisa de pelo menos 10 caracteres");
            });

            RuleSet("OnUpdate", () => 
            {
                RuleFor(product => product.Price).NotEmpty().WithMessage("o preco a actualizar, nao pode ser vázio");    
                RuleFor(product => product.Unit).NotEmpty().WithMessage("A unidade a alterar nao pode ser vazia");
                RuleFor(product => product.Identifier).NotEmpty().WithMessage("O identificador a alterar nao pode ser vazio");
                RuleFor(product => product.Description).NotEmpty().WithMessage("A descricao a alterar nao pode ser vazia");
                RuleFor(product => product.DescriptionEN).NotEmpty().WithMessage("A descricao a alterar nao pode ser vazia");
            });
      
        
        }
    }
}