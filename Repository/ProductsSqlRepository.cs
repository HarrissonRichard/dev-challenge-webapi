using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RestChallenge.Context;
using RestChallenge.Dtos;
using RestChallenge.Models;

namespace RestChallenge.Repository
{
    public class ProductsSqlRepository : IProductRepository
    { 
        private readonly DapperContext dapperContext;
   
        public ProductsSqlRepository(DapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
        }


        public async Task CreateProductAsync(ProductModel product)
        {
            //validate input first
            //creare a con
            //insert it
            using(IDbConnection connection = new SqlConnection(dapperContext.GetConnString()))
            {
            
                var p = new DynamicParameters();

                p.Add("@Identifier", product.Identifier);
                p.Add("@Description", product.Description);
                p.Add("@DescriptionEN",product.DescriptionEN);
                p.Add("@Price", product.Price);
                p.Add("@Unit", product.Unit);
                p.Add("@AvailableSTK", product.AvailableSTK);
                p.Add("@Vat" , product.Vat);
                p.Add("@RemoteId", product.RemoteId);
                //need output ID to return in response thats why dynamic params
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                //stored procedure manages to returnn the id
                string sql = @"spProduct_Insert";

                await connection.ExecuteAsync(sql, p, commandType: CommandType.StoredProcedure);
               
                product.Id = p.Get<int>("@Id");
            }

        }

        public async Task<ProductModel> GetProductByIdAsync(int Id)
        {

            using(IDbConnection connection = new SqlConnection(dapperContext.GetConnString()))
            {

                string sql = "SELECT * FROM [Products] WHERE id=@Id";

                var product = await connection.QuerySingleAsync<ProductModel>(sql, new { id = Id });
                return product;
            }
          
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            //getconnection and query in database
            using(IDbConnection connection = new SqlConnection(dapperContext.GetConnString()))
            {     
                string sql = "SELECT * FROM [Products];";
                IEnumerable<ProductModel> products =  await connection.QueryAsync<ProductModel>(sql);
                return products;
            }
            
        }

        public async Task UpdateProductAsync(ProductModel product)
        {
            using(IDbConnection connection = new SqlConnection(dapperContext.GetConnString()))
            
            {
              
                string sql = "spProduct_Update";

                var p = new DynamicParameters();
                p.Add("@Identifier", product.Identifier);
                p.Add("@Id", product.Id);
                p.Add("@Description", product.Description);
                p.Add("@DescriptionEN", product.DescriptionEN);
                p.Add("@Price", product.Price);
                p.Add("@Unit", product.Unit);
                p.Add("@AvailableSTK", product.AvailableSTK);
                p.Add("@Vat", product.Vat);
                p.Add("@ComponentType", product.ComponentType);
                p.Add("@Inactive", product.Inactive, dbType:DbType.Boolean);
                p.Add("@RemoteId", product.RemoteId);
  
                await connection.ExecuteAsync(sql, p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}