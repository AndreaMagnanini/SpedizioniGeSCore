// <copyright file="GenericException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Exceptions
{
    using System.Net;

    /// <summary>
    /// The Exception representing an Internal Server Error Response Status.
    /// </summary>
    public class GenericException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericException"/> class.
        /// </summary>
        /// <param name="message">The exception message to show.</param>
        /// <param name="e">The inner exception.</param>
        public GenericException(HttpRequestMessage message, Exception? e = null)
            : base(message, e)
        {
        }

        /// <inheritdoc/>
        public override int StatusCode => (int)HttpStatusCode.InternalServerError;
    }
}