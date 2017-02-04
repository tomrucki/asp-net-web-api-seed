namespace ApiSeed.Models.Common.StatusCodes
{
    public static partial class ErrorCodes
    {
        /// <summary>
        /// Error codes related to authentication and authorization.
        /// Error range 101xxx
        /// </summary>
        public enum Auth
        {
            /// <summary>
            /// Invalid authenticaton data format
            /// </summary>
            InvalidFormat = 101001,

            /// <summary>
            /// Invalid credentials
            /// </summary>
            InvalidCredentials,

            /// <summary>
            /// Expired authentication token
            /// </summary>
            Expired
        }
    }
}