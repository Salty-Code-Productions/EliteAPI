﻿using System;

using EliteAPI.Exceptions.Abstractions;

namespace EliteAPI.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an event is not implemented
    /// </summary>
    public class EventHasMissingDataException : EliteDangerousApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventHasMissingDataException" /> class
        /// </summary>
        public EventHasMissingDataException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHasMissingDataException" /> class with a specified error message
        /// </summary>
        /// <param name="message"> The message that describes the error </param>
        public EventHasMissingDataException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHasMissingDataException" /> class with a specified error message and
        /// a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message"> The message that describes the error </param>
        /// <param name="innerException"> The inner exception that caused this exception </param>
        public EventHasMissingDataException(string message, Exception innerException) : base(message, innerException) { }
    }
}