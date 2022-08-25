namespace PageCom.Api.Application.Models;

public class ResponseDTO
{
    public bool IsSuccess { get; set; } = true;
    public object? Result { get; set; }
    public List<string>? Error { get; set; }
    public string Message { get; set; } = "";
}