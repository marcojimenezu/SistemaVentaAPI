using FluentValidation.Results;

namespace SistemaVenta.DTO.Response
{
    public class Response<T>
    {
        // TODO: Remove to use method factories
        public Response()
        {
        }
        
        private Response(bool status, T? value, string? error = null)
        {
            Status = status;
            Value = value;
            Error = error;
        }
        
        public bool Status { get; set; }
        public T? Value { get; set; }
        public string? Error{ get; set; }

        public static Response<T> CreateSuccessResponse(T data)
        {
            return new Response<T>(true, data);
        }
        
        public static Response<T?> CreateErrorResponse(string error)
        {
            return new Response<T?>(false, default, error);
        }
        
        public static Response<T?> CreateErrorResponse(IEnumerable<ValidationFailure> errors)
        {
            return CreateErrorResponse(errors.Select(p => p.ErrorMessage));
        }
        
        public static Response<T?> CreateErrorResponse(IEnumerable<string> errors)
        {
            return new Response<T?>(false, default, string.Join(",", errors));
        }
    }
}
