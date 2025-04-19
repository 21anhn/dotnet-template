namespace DotNetTemplate.WebApi.Common.ApiHandlers
{
    public static partial class Message
    {
        /// <summary>
        /// Get Message
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetContent(string code) => code switch
        {
            // Success
            I0000 => "The operation completed successfully!",

            // Errors
            E0000 => "The operation was unsuccessful!",
            E0001 => "Invalid input data provided.",

            // Warnings
            W0000 => "Warning: please check your request.",

            // Default
            _ => $"Unknown message code: {code}"
        };
    }
}
