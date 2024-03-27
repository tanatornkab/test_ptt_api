
using TodoApi.Models;

namespace TodoApi.Services;

public class MockData
{
    public List<PicturesModel> Pictures = new List<PicturesModel>{
        new PicturesModel{
            PictureUrl="http://localhost:5055/api/picture?path=/Users/tanatornk/Documents/Test/api/TodoApi/PictureMock/1.png",
            Title="Test Title1"
        },
        new PicturesModel{
            PictureUrl="http://localhost:5055/api/picture?path=/Users/tanatornk/Documents/Test/api/TodoApi/PictureMock/2.png",
            Title="Test Title2"
        },
        new PicturesModel{
            PictureUrl="http://localhost:5055/api/picture?path=/Users/tanatornk/Documents/Test/api/TodoApi/PictureMock/3.png",
            Title="Test Title3"
        },
        new PicturesModel{
            PictureUrl="https://images.pexels.com/photos/65894/peacock-pen-alluring-yet-lure-65894.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
            Title="Test Title4"
        },
        new PicturesModel{
            PictureUrl="https://images.pexels.com/photos/60597/dahlia-red-blossom-bloom-60597.jpeg?auto=compress&cs=tinysrgb&w=800",
            Title="Test Title5"
        }
    };
    public PicturesService picturesService;
    public MockData(PicturesService picturesService)
    {
        this.picturesService = picturesService;
    }

    public void AddPicture(PicturesModel model)
    {
        Pictures.Add(model);
    }

}