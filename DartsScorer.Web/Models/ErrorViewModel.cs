namespace DartsScorer.Web.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    
    // New properties for enhanced error handling
    public int StatusCode { get; set; } = 500;
    public string Title { get; set; } = "Error";
    public string Message { get; set; } = "An error occurred while processing your request.";
    public bool ShowDetails { get; set; } = false;
    public string? Details { get; set; }
}
