// <copyright file="Object.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a single concrete collectible such as piece of Chassis, a Gear or more complex structures treated as single entity.
    /// It may either be stored in a box with other objects, be placed inside a Pallet or stay floating.
    /// </summary>
    public class Object : Item
    {
        /// <summary>
        /// Gets or sets the object code field.
        /// </summary>
        [Required]
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the object hs code field.
        /// </summary>
        [ForeignKey("Code")]
        public HsCode HsCode { get; set; }

        /// <summary>
        /// Gets or sets the object value field.
        /// </summary>
        [Required]
        public int Value { get; set; }
    }
}