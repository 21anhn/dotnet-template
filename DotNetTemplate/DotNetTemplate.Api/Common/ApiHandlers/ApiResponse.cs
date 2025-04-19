namespace DotNetTemplate.WebApi.Common.ApiHandlers
{
    public class ApiResponse<T> where T : class
    {
        public bool Success { get; set; }
        public string? MessageId { get; set; }
        public string? Message { get; set; }
        public List<DetailError>? DetailErrorList { get; set; }
        public T? Data { get; set; }
    }
}
