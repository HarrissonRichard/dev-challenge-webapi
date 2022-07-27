using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RestChallenge.Dtos;
using RestChallenge.Models;
using RestChallenge.Repository;
using RestChallenge.Utils;

namespace RestChallenge.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController: ControllerBase
    {
       private readonly IProductRepository repository;
       private readonly IValidator<ProductModel> validator;
        public ProductController(IProductRepository repository, IValidator<ProductModel> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetProductsAsync()
        {
            var products =  (await repository.GetProductsAsync()).Select(prod => prod.getDto());
            
            return Ok(
                new 
                    {
                        total = products.LongCount(),
                        data = products 
                    });
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProductAsync(CreateProductDto productDto)
        {
                  
            try
            {
                ProductModel product = new ProductModel {
     
                Identifier = productDto.Identifier,
                Description = productDto.Description,
                DescriptionEN = productDto.DescriptionEN,
                Price = productDto.Price,
                Unit = productDto.Unit,
                AvailableSTK = productDto.AvailableSTK,
                Vat = productDto.Vat,
                ComponentType = productDto.ComponentType,
                RemoteId = productDto.RemoteId
            };
                
                await validator.ValidateAsync<ProductModel>(product, opt => {
                        opt.ThrowOnFailures();
                        opt.IncludeRuleSets("OnCreate");
                }); 
             
                await repository.CreateProductAsync(product);

                return CreatedAtAction("GetProductById", new { Id = product.Id } , product.getDto());
            }
            catch (SqlException  ex)
               {
                string errorMessage = ExceptionsHandling.getSqlErrorMessages(ex);
             
                return BadRequest(new {
                    status = "Fail",
                    message = errorMessage
                });
            } catch(ValidationException ex) {

              List<string> messages = ExceptionsHandling.getValidationErrorMessages(ex);

                return BadRequest(new {
                    status = "Fail",
                    messages
                });
            }
        }      

        [HttpGet("{id}")]
        [ActionName("GetProductById")]
        public async Task<ActionResult<ProductDto>> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await repository.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (InvalidOperationException ex)
            {
                string message = ExceptionsHandling.getInvalidOperationError(ex);
                return NotFound(new {
                    status = "Fail",
                    message = message
                });   
            }
 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
        {
            try
            {
                ProductModel  existingProduct = await repository.GetProductByIdAsync(id);
                //check if product with that id existis
                if(existingProduct is null)
                {
                    return NotFound( new
                    {
                        status = "Fail",
                        message = "Producto para actualizar nao encontrado"
                    });
                }

                ProductModel product = existingProduct with
                {
                    Identifier = productDto.Identifier,
                    Description = productDto.Description,
                    DescriptionEN = productDto.DescriptionEN,
                    Price = productDto.Price,
                    Unit = productDto.Unit,
                    AvailableSTK = productDto.AvailableSTK,
                    Vat = productDto.Vat,
                    Inactive = productDto.Inactive,
                    ComponentType = productDto.ComponentType
                };

             await validator.ValidateAsync<ProductModel>(product, opt => 
                {
                    opt.ThrowOnFailures();
                    opt.IncludeRuleSets("OnUpdate");
                });


                await repository.UpdateProductAsync(product);
                return Ok(product);
            }
            catch (ValidationException ex)
            {
                  List<string> messages = ExceptionsHandling.getValidationErrorMessages(ex);
                
                return BadRequest(new {
                    status = "Fail",
                    message = messages
                });
                    
            }
            catch(InvalidOperationException ex)
            {
                string message = ExceptionsHandling.getInvalidOperationError(ex);
                return NotFound(new {
                    status = "Fail",
                    message = message
                });  
            }
        }
    }
}