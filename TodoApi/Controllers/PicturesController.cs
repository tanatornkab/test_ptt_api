using System.Collections;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using ToDoBiz;
using ToDoBiz.Pictures;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/pictures")]
public class PicturesController : ControllerBase
{
    public readonly PicturesBiz picturesBiz;
    public PicturesController(PicturesBiz picturesBiz)
    {
        this.picturesBiz = picturesBiz;
    }

    [HttpGet("answer1")]
    public List<int> GetNo1()
    {
        var a = new List<int> { 1, 2, 3, 4, 5 };
        var b = new List<int> { 3, 4, 5, 6, 7 };
        return a.Intersect(b).ToList();
    }

    [HttpGet]
    public ActionResult<APIResult<List<PicturesModel>>> GetPictures(string keyword = "")
    {
        var data = picturesBiz.GetPictures(keyword);
        return Ok(new APIResult<List<PicturesModel>>(data));
    }

    [HttpPost]
    public ActionResult<APIResult<Hashtable>> AddPictures([FromBody] PicturesModel body)
    {
        var data = picturesBiz.AddPictures(body);
        return Created(string.Empty, new APIResult<Hashtable>(data));
    }
}
