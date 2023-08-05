// <copyright file="UserTrace.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models.Common
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user tracking data related to all db entities.
    /// </summary>
    public class UserTrace
    {
        /// <summary>
        /// Gets or sets The creation date.
        /// </summary>
        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets The creation user.
        /// </summary>
        [JsonIgnore]
        public string CreationUser { get; set; }

        /// <summary>
        /// Gets or sets The updating date.
        /// </summary>
        [JsonIgnore]
        public DateTime? UpdatingDate { get; set; }

        /// <summary>
        /// Gets or sets The updating user.
        /// </summary>
        [JsonIgnore]
        public string? UpdatingUSer { get; set; }

        /// <summary>
        /// Gets or sets The deletion date.
        /// </summary>
        [JsonIgnore]
        public DateTime? DeletionDate { get; set; }

        /// <summary>
        /// Gets or sets The deletion user.
        /// </summary>
        [JsonIgnore]
        public string? DeletionUser { get; set; }
    }
}