// <copyright file="NotFoundException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Exceptions
{
    using System.Net;

    /// <summary>
    /// The Exception representing a Not Found Response Status.
    /// </summary>
    public class NotFoundException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="message">The exception message to show.</param>
        /// <param name="e">The inner exception.</param>
        public NotFoundException(string message, Exception? e = null)
            : base(message, e)
        {
        }

        /// <inheritdoc/>
        public override int StatusCode => (int)HttpStatusCode.NotFound;
    }
}