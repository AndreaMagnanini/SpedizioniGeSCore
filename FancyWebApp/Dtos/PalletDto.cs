// <copyright file="PalletDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Dtos
{
    /// <summary>
    /// The pallet data transfer object.
    /// </summary>
    public class PalletDto : ItemDto
    {
        /// <summary>
        /// Gets or sets the pallet code.
        /// </summary>
        public string PalletCode { get; set; }
    }
}