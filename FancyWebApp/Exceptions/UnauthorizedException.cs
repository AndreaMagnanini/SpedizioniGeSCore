// <copyright file="UnauthorizedException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Exceptions
{
    using System.Net;

    /// <summary>
    /// The Exception representing an Unauthorized Response Status.
    /// </summary>
    public class UnauthorizedException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
        /// </summary>
        /// <param name="message">The exception message to show.</param>
        /// <param name="e">The inner exception.</param>
        public UnauthorizedException(HttpRequestMessage message, Exception? e = null)
            : base(message, e)
        {
        }

        /// <inheritdoc/>
        public override int StatusCode => (int)HttpStatusCode.Unauthorized;
    }
}