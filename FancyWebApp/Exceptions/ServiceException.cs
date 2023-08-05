// <copyright file="ServiceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Exceptions
{
    /// <summary>
    /// The main service exception representing the response status of an error.
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class.
        /// </summary>
        /// <param name="message">The exception message to show.</param>
        /// <param name="e">The inner exception.</param>
        private protected ServiceException(string message, Exception? e = null)
            : base(message, e)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class.
        /// </summary>
        /// <param name="message">The exception message to show.</param>
        /// <param name="e">The inner exception.</param>
        private protected ServiceException(HttpRequestMessage message, Exception? e = null)
            : base(message.ToString(), e)
        {
        }


        /// <summary>
        /// Gets the response status code.
        /// </summary>
        public virtual int StatusCode => throw new NotImplementedException();

        /// <inheritdoc/>
        public override string ToString() => this.Message;
    }
}