﻿namespace SolrExpress.Core.Search.Parameter
{
    public abstract class BaseLimitParameter<TDocument> : ILimitParameter<TDocument>
        where TDocument : IDocument
    {
        /// <summary>
        /// True to indicate multiple instances of the parameter, otherwise false
        /// </summary>
        public bool AllowMultipleInstances { get; } = false;

        /// <summary>
        /// Value of limit
        /// </summary>
        public long Value { get; private set; }

        /// <summary>
        /// Configure current instance
        /// </summary>
        /// <param name="value">Value of limit</param>
        public ILimitParameter<TDocument> Configure(long value)
        {
            this.Value = value;

            return this;
        }
    }
}
