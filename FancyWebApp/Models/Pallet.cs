// <copyright file="Pallet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a Cargo Pallet, capable to contain both boxes and floating objects.
    /// </summary>
    public class Pallet : Item
    {
        /// <summary>
        /// Gets or sets the pallet code field.
        /// </summary>
        [Required]
        public string PalletCode { get; set; }
    }
}