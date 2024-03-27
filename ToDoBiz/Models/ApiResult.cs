namespace TodoApi.Models;

public class APIResult<T>
{
    public APIResult(T data )
    {
        Data = data;
    }

    public T Data { get; set; }
}
