using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebFornecedor.Model;

namespace WebFornecedor.Service
{
    public interface IApiService
    {
        [Get("/auctions")]
        Task<List<ModelApi>> GetResponseAsync();

        [Get("/auctions/{id}")]
        Task<ModelApi> GetAuction(int id);

        [Post("/auctions/{id}/bids")]
        Task<PostAuction> PostAuction([Body(BodySerializationMethod.Serialized)] PostAuction data, int id);

        [Get("/auctions/{id}/bids/results")]
        Task<PostAuction> GetResultadosBids(int id);

        [Get("/sellers/{id}")]
        Task<ModelSeller> GetSeller(int id);

        [Put("/auctions/{id}")]
        Task<PostAuction> PutAuction([Body(BodySerializationMethod.Serialized)] PostAuctionClose put, int id);
    }
}