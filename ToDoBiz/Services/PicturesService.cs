
using TodoApi.Models;

namespace TodoApi.Services;

public class PicturesService
{
    public List<PicturesModel> Pictures = new List<PicturesModel>();
    public PicturesService()
    {
        Pictures = new List<PicturesModel>(){
            new PicturesModel{
                PictureUrl =  "",
                Title = "1"
            },
            new PicturesModel{ PictureUrl = "2" , Title = "2"}
        };
    }

    public void AddPicture(string path, PicturesModel model)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);  
        }

        string imageName = model.Title + ".jpg";

        //set the image path
        string imgPath = Path.Combine(path, "PictureMock", imageName);

        byte[] imageBytes = Convert.FromBase64String(model.PictureUrl);

        File.WriteAllBytes(imgPath, imageBytes);
    }

}