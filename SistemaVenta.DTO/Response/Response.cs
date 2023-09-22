using FluentValidation.Results;

namespace SistemaVenta.DTO.Response
{
    public class Response<T>
    {
        private Response(bool status, T? value, IEnumerable<string>? error = null)
        {
            Status = status;
            Value = value;
            Error = error;
        }
        
        public bool Status { get; set; }
        public T? Value { get; set; }
        public IEnumerable<string>? Error{ get; set; }

        public static Response<T> CreateSuccessResponse(T data)
        {
            return new Response<T>(true, data);
        }
        
        public static Response<T?> CreateErrorResponse(IEnumerable<ValidationFailure> errors)
        {
            return CreateErrorResponse(errors.Select(p => p.ErrorMessage));
        }
        
        public static Response<T?> CreateErrorResponse(IEnumerable<string> errors)
        {
            return new Response<T?>(false, default, errors);
        }
    }
}
