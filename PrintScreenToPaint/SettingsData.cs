﻿// <copyright file="SettingsData.cs" company="PublicDomain.com">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>
using System.Drawing.Imaging;

namespace PrintScreenToPaint
{
    // Directives
    using System;

    /// <summary>
    /// Settings data.
    /// </summary>
    public class SettingsData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PrintScreenToPaint.SettingsData"/> class.
        /// </summary>
        public SettingsData()
        {
            // Parameterless constructor for serialization to work
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MultilingualWordCounter.SettingsData"/> runs at startup.
        /// </summary>
        /// <value><c>true</c> if run at startup; otherwise, <c>false</c>.</value>
        public bool RunAtStartup { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MultilingualWordCounter.SettingsData"/> hides the close button.
        /// </summary>
        /// <value><c>true</c> if hide close button; otherwise, <c>false</c>.</value>
        public bool HideCloseButton { get; set; } = false;

        /// <summary>
        /// Gets or sets the save image format.
        /// </summary>
        /// <value>The save image format.</value>
        public ImageFormat SaveImageFormat { get; set; } = ImageFormat.Png;
    }
}
