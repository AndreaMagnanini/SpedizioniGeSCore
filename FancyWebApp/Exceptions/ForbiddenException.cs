// <copyright file="ForbiddenException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Exceptions
{
    using System.Net;

    /// <summary>
    /// The Exception representing a Forbidden Response Status.
    /// </summary>
    public class ForbiddenException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="message">The exception message to show.</param>
        /// <param name="e">The inner exception.</param>
        public ForbiddenException(HttpRequestMessage message, Exception? e = null)
            : base(message, e)
        {
        }

        /// <inheritdoc/>
        public override int StatusCode => (int)HttpStatusCode.Forbidden;
    }
}