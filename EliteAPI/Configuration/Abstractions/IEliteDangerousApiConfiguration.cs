﻿using System;

namespace EliteAPI.Configuration.Abstractions
{
    /// <summary>
    /// Interface for the <see cref="IEliteDangerousApiConfiguration" /> configuration class
    /// </summary>
    public interface IEliteDangerousApiConfiguration
    {
        /// <summary>
        /// The active journal directory path
        /// </summary>
        public string JournalPath { get; }
        
        /// <summary>
        /// The options directory path
        /// </summary>
        public string OptionsPath { get; }

        /// <summary>
        /// The targeted journal file
        /// </summary>
        public string JournalFile { get; }

        /// <summary>
        /// At which frequency EliteAPI checks for journal and status files updates
        /// </summary>
        public TimeSpan TickFrequency { get; }
    }
}