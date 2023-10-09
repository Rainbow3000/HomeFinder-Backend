using HomeFinder.Core.DataResponse;
using HomeFinder.Core.Dto.Image;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Core.Service;
using HomeFinder.Filter.Jwt;
using HomeFinder.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinder.Controllers
{
    [ApiController]
    public class ImagesController : BasesController<ImageDto, ImageCreateDto, ImageUpdateDto>
    {
        private readonly IImageService _imageService;
        private readonly DatabaseContext _databaseContext;
        public ImagesController(IImageService imageService, DatabaseContext databaseContext) : base(imageService)
        {
            _imageService = imageService;
            _databaseContext = databaseContext;
        }
        [ServiceFilter(typeof(UserTokenFilter))]
        public override Task<DataResponse> InsertAsync([FromBody] ImageCreateDto entityCreateDto)
        {
            return base.InsertAsync(entityCreateDto);
        }
    }
}
