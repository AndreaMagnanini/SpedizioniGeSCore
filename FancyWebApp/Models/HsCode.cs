// <copyright file="HsCode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The hs code table entity.
    /// </summary>
    public class HsCode
    {
        /// <summary>
        /// Gets or sets the hs code code field.
        /// </summary>
        [Key]
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the hs code description field.
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}