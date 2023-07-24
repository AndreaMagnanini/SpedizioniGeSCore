// <copyright file="Scuderia.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using FancyWebApp.Models.Common;

    /// <summary>
    /// The scuderia table entity.
    /// </summary>
    public class Scuderia : UserTrace
    {
        /// <summary>
        /// Gets or sets the scuderia id field.
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the scuderia name field.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}