// <copyright file="Camion.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    /// <summary>
    /// The camion table entity.
    /// </summary>
    public class Camion
    {
        /// <summary>
        /// Gets or sets the camion id field.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the camion society field.
        /// </summary>
        public string Society { get; set; }

        /// <summary>
        /// Gets or sets the camion model field.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the camion code field.
        /// </summary>
        public string TargaCode { get; set; }

        // public List<Content> Contents { get; set; }
    }
}