

using System.Collections;
using Microsoft.Extensions.Configuration;
using TodoApi.Services;
using TodoApi.Models;
using System.Net;

namespace ToDoBiz.Pictures;
public class PicturesBiz
{
    public IConfiguration configuration;
    public PicturesService picturesService;
    public MockData mockData;
    public PicturesBiz(IConfiguration configuration, PicturesService picturesService, MockData mockData)
    {
        this.configuration = configuration;
        this.picturesService = picturesService;
        this.mockData = mockData;
    }
    public bool IsImageUrl(string url)
    {
        try
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";
            using (var response = request.GetResponse())
            {
                return response.ContentType.StartsWith("image/");
            }
        }
        catch
        {
            return false;
        }
    }
    public Hashtable AddPictures(PicturesModel body)
    {
        try
        {
            if (IsImageUrl(body.PictureUrl))
            {
                mockData.AddPicture(body);
            }
            else
            {
                return new Hashtable{
                {Constants.Result ,false},
                {Constants.Message ,"กรุณาตรวจสอบ photo"}
            };
            }
            return new Hashtable{
                {Constants.Message , "Save Successfully"},
                {Constants.Result ,true},
            };
        }
        catch (Exception e)
        {
            return new Hashtable{
                {Constants.Result ,false},
                {Constants.Message ,e.InnerException?.Message ?? e.Message}
            };
        }

    }

    public List<PicturesModel> GetPictures(string keyword)
    {
        var data = mockData.Pictures;
        if (!string.IsNullOrEmpty(keyword))
        {
            data = data.Where(w => w.Title.Contains(keyword)).ToList();
        }
        return data;
    }
}