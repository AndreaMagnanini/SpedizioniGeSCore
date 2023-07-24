// <copyright file="Sigil.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using FancyWebApp.Models.Common;

    /// <summary>
    /// Represents the set of sigils used to close an item at the freight security zone
    /// </summary>
    public class Sigil : UserTrace
    {
        /// <summary>
        /// Gets or sets the sigil id field.
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the sigil code field.
        /// </summary>
        [Required]
        public string Code { get; set; }
    }
}
