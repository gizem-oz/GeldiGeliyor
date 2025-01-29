using AutoMapper;
using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.ResultModels;
using GeldiGeliyor.Business.Validations;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Concrete
{

public class PictureManager(IPictureDal pictureDal, IMapper mapper) : IPictureService

{
        PictureValidator pictureValidator = new PictureValidator();
    public async Task<IResponseResult> PictureAddAsync(PictureAddDto pictureAddDto)
    {
        IResponseResult responseResult = new ResponseResult();
        try
        {
            Picture picture = mapper.Map<Picture>(pictureAddDto);
                var result =pictureValidator.Validate(picture);
                if(result.IsValid)
            await pictureDal.AddAsync(picture);
            return responseResult;
        }
        catch (Exception ex)
        {
            responseResult.Error = ex.Message;
            responseResult.IsSuccessed = false;
            return responseResult;
        }
    }

    public async Task<IResponseResult> PictureRemoveByIdAsync(int id)
    {
        IResponseResult responseResult = new ResponseResult();
        try
        {
            Picture picture = await pictureDal.GetAsync(x => x.Id == id);
            await pictureDal.DeleteAsync(picture);
            return responseResult;
        }
        catch (Exception ex)
        {
            responseResult.IsSuccessed = false;
            responseResult.Error = ex.Message;
            return responseResult;
        }
    }

    public async Task<IResponseResult> PictureUpdateAsync(PictureUpdateDto pictureUpdateDto)
    {
        IResponseResult responseResult = new ResponseResult();
        try
        {
            Picture picture = mapper.Map<Picture>(pictureUpdateDto);
            await pictureDal.UpdateAsync(picture);
            return responseResult;
        }
        catch (Exception ex)
        {
            responseResult.IsSuccessed = false;
            responseResult.Error = ex.Message;
            return responseResult;
        }
    }

    public async Task<List<PictureGetDto>> GetPicturesAsync()
    {
        List<PictureGetDto> pictureGetDtos = new List<PictureGetDto>();
        IEnumerable<Picture> pictures = await pictureDal.GetAllAsync();
        foreach (Picture picture in pictures)
            pictureGetDtos.Add(mapper.Map<PictureGetDto>(picture));
        return pictureGetDtos;
    }



    public async Task<PictureGetDto> GetPictureByIdAsync(int id)
    {
        Picture picture = await pictureDal.GetAsync(x => x.Id == id);
            PictureGetDto pictureGetDto = new PictureGetDto()
            {
                 Id =picture.Id,
                  Image = picture.Image,
                   ProductId = picture.ProductId,
                    Status = picture.Status,
            };
            return pictureGetDto;
    }

    public async Task<List<PictureWithProductDto>> PicturesWithProductsAsync()
    {

        List<PictureWithProductDto> pictureWithProductDtos = new List<PictureWithProductDto>();
        IEnumerable<Picture> pictures = await pictureDal.GetAllAsync();
        foreach (Picture picture in pictures)
            pictureWithProductDtos.Add(mapper.Map<PictureWithProductDto>(picture));
        return pictureWithProductDtos;
    }

    public async Task<PictureWithProductDto> GetPictureWithProductAsync(int productId)
    {
        Picture picture = await pictureDal.PictureWithProductsAsync(x => x.ProductId == productId);
        return mapper.Map<PictureWithProductDto>(picture);
    }
}
}

