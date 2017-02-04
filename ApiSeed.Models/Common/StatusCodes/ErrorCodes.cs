namespace ApiSeed.Models.Common.StatusCodes
{
    public static partial class ErrorCodes
    {
        /// <summary>
        /// Error codes not related to any specific operation.
        /// Code range 100xxx
        /// </summary>
        public enum Common
        {
            /// <summary>
            /// Not found
            /// </summary>
            NotFound = 100001,

            /// <summary>
            /// Invalid format or value of input arguments
            /// </summary>
            InvalidInputArguments
        }
    }
}