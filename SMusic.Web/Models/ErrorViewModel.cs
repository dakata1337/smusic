namespace SMusic.Web.Models;

public class ErrorViewModel
{
    #nullable enable
    public string? RequestId { get; set; }
    #nullable restore

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
