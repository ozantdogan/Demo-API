using System.Runtime.CompilerServices;

namespace OTD.Core.Models
{
    public class ResponseViewModel
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public object? Data { get; set; }
    }

    public static class ResponseViewModelExtension
    {
        public static TaskAwaiter<ResponseViewModel> GetAwaiter(this ResponseViewModel response)
            => Task.FromResult(response).GetAwaiter();
    }
}