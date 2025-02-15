﻿using System;
using System.Collections.Generic;

using EliteAPI.Configuration.Abstractions;
using EliteAPI.Event.Module;
using EliteAPI.Event.Processor;
using EliteAPI.Event.Processor.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace EliteAPI.Configuration
{
    /// <summary>
    /// Creates a <see cref="IEliteDangerousApiConfiguration" /> configuration class through a builder
    /// </summary>
    public class EliteDangerousApiConfigurationBuilder
    {
        private readonly IList<Type> _eventModuleImplementations;
        private IList<Type> _eventProcessors;
        private string _journal;
        private string _journalDirectory;
        private string _options;
        private TimeSpan _tickFrequency;

        internal EliteDangerousApiConfigurationBuilder()
        {
            _eventModuleImplementations = new List<Type>();
            _eventProcessors = new List<Type> {typeof(EventsEventProcessor), typeof(AttributeEventProcessor), typeof(AllEventProcessor)};
            _journalDirectory = "";
            _journal = "";
            _options = "";
            _tickFrequency = TimeSpan.Zero;
        }

        /// <summary>
        /// Add an event module to EliteAPI
        /// </summary>
        /// <typeparam name="T"> The event module to be added </typeparam>
        public void AddEventModule<T>() where T : EliteDangerousEventModule
        {
            _eventModuleImplementations.Add(typeof(T));
        }

        /// <summary>
        /// Remove the default event processors
        /// </summary>
        public void ClearProcessors()
        {
            _eventProcessors = new List<Type>();
        }

        /// <summary>
        /// Adds an event processor
        /// </summary>
        /// <typeparam name="T"> The event processor to be used </typeparam>
        public void AddProcessor<T>() where T : IEventProcessor
        {
            _eventProcessors.Add(typeof(T));
        }

        /// <summary>
        /// Sets which directory to use as active journal directory
        /// </summary>
        public void UseJournalDirectory(string path)
        {
            _journalDirectory = path;
        }

        /// <summary>
        /// Sets which journal file to use, defaults to latest if not invoked
        /// </summary>
        public void UseJournalFile(string file)
        {
            _journal = file;
        }

        /// <summary>
        /// Sets which journal file to use, defaults to latest if not invoked
        /// </summary>
        [Obsolete("Use UseJournalFile instead")]
        public void UseJournal(string file) => UseJournalFile(file);
        
        /// <summary>
        /// Sets which directory to use as the options directory
        /// </summary>
        public void UseOptionsDirectory(string path)
        {
            _options = path;
        }

        /// <summary>
        /// Sets at which frequency EliteAPI should check for journal and status files updates
        /// </summary>
        public void UseTickFrequency(TimeSpan tickFrequency)
        {
            _tickFrequency = tickFrequency;
        }

        internal void AddServices(IServiceCollection services)
        {
            foreach (var implementation in _eventModuleImplementations) services.AddSingleton(implementation);

            foreach (var implementation in _eventProcessors) services.AddSingleton(typeof(IEventProcessor), implementation);

            services.AddSingleton<IEliteDangerousApiConfiguration>(Build());
        }

        private EliteDangerousApiConfiguration Build()
        {
            return new() {JournalPath = _journalDirectory, JournalFile = _journal, OptionsPath = _options, TickFrequency = _tickFrequency};
        }
    }
}