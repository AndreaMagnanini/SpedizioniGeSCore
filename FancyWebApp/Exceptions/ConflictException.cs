// <copyright file="ConflictException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Exceptions
{
    using System.Net;

    /// <summary>
    /// The Exception representig a Conflict Response Status.
    /// </summary>
    public class ConflictException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictException"/> class.
        /// </summary>
        /// <param name="message">The exception message to show.</param>
        /// <param name="e">The inner exception.</param>
        public ConflictException(HttpRequestMessage message, Exception? e = null)
            : base(message, e)
        {
        }

        /// <inheritdoc/>
        public override int StatusCode => (int)HttpStatusCode.Conflict;
    }
}