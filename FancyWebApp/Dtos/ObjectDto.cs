// <copyright file="ObjectDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Dtos
{
    /// <summary>
    /// The object data transfer object.
    /// </summary>
    public class ObjectDto : ItemDto
    {
        /// <summary>
        /// Gets or sets the object english description.
        /// </summary>
        public string EnglishDescription { get; set; }

        /// <summary>
        /// Gets or sets the object code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the object value.
        /// </summary>
        public int Value { get; set; }
    }
}