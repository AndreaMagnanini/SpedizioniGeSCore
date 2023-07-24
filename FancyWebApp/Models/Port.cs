// <copyright file="Port.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using FancyWebApp.Models.Common;

    /// <summary>
    /// The port table entity.
    /// </summary>
    public class Port : UserTrace
    {
        /// <summary>
        /// Gets or sets the port id field.
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the port id field.
        /// </summary>
        [Required]
        public string LoCode { get; set; }

        /// <summary>
        /// Gets or sets the port name field.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the port country field.
        /// </summary>
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the port description field.
        /// </summary>
        public string? Description { get; set; }
    }
}