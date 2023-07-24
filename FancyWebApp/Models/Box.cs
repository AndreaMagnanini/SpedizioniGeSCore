// <copyright file="Box.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a Box as a container of multiple objects belonging to the same category.
    /// It may either be stored in a Pallet ora be floating.
    /// </summary>
    public class Box : Item
    {
        /// <summary>
        /// Gets or sets the box number field.
        /// </summary>
        [Required]
        public string BoxNumber { get; set; }
    }
}