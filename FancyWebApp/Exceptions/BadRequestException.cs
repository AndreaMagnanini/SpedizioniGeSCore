// <copyright file="BadRequestException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Exceptions
{
    using System.Net;

    /// <summary>
    /// The Exception representing a Bad Request Response Status.
    /// </summary>
    public class BadRequestException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="message">The exception message to show.</param>
        /// <param name="e">the inner exception.</param>
        public BadRequestException(string message, Exception? e = null)
            : base(message, e)
        {
        }

        /// <inheritdoc/>
        public override int StatusCode => (int)HttpStatusCode.BadRequest;
    }
}