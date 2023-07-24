// <copyright file="Airport.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using FancyWebApp.Models.Common;

    /// <summary>
    /// Represents a known airport in a known location.
    /// </summary>
    public class Airport : UserTrace
    {
        /// <summary>
        /// Gets or sets the airport id field.
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the airport IATA code field.
        /// </summary>
        [Required]

        // ReSharper disable once InconsistentNaming
        public string IATACode { get; set; }

        /// <summary>
        /// Gets or sets the airport name field.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the airport city field.
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the airport description field.
        /// </summary>
        public string? Description { get; set; }
    }
}
