using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace OTD.Core.Models
{
    public class ResponseViewModel
    {
        public bool Success { get; set; }
        public string? Message { get; set; } = "";
        public object? Data { get; set; } = "";
    }

    public static class ResponseViewModelExtension
    {
        public static TaskAwaiter<ResponseViewModel> GetAwaiter(this ResponseViewModel response)
            => Task.FromResult(response).GetAwaiter();
    }

    public class ResponseViewModel<T> : ResponseViewModel
    {
        [JsonConstructor]
        public ResponseViewModel()
        {
        }

        public ResponseViewModel(T t)
        {
            Data = t;
        }

        public new T? Data { get; set; }
    }
}