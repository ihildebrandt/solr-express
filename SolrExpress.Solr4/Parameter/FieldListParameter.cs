﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SolrExpress.Core.Helper;
using SolrExpress.Core.Query;

namespace SolrExpress.Solr4.Parameter
{
    public sealed class FieldListParameter<T> : IParameter<List<string>>, IValidation
        where T : IDocument
    {
        private readonly Expression<Func<T, object>> _expression;

        /// <summary>
        /// Create a fields parameter
        /// </summary>
        /// <param name="expression">Expression used to find the property name</param>
        public FieldListParameter(Expression<Func<T, object>> expression)
        {
            this._expression = expression;
        }

        /// <summary>
        /// True to indicate multiple instances of the parameter, otherwise false
        /// </summary>
        public bool AllowMultipleInstances { get { return true; } }

        /// <summary>
        /// Execute the creation of the parameter "fl"
        /// </summary>
        /// <param name="container">Container to parameters to request to SOLR</param>
        public void Execute(List<string> container)
        {
            var fieldName = UtilHelper.GetFieldNameFromExpression(this._expression);

            var fieldList = container.FirstOrDefault(q => q.StartsWith("fl="));

            if (!string.IsNullOrWhiteSpace(fieldList))
            {
                container.Remove(fieldList);

                fieldList = string.Concat(fieldList, ",", fieldName);
            }
            else
            {
                fieldList = string.Concat("fl=", fieldName);
            }

            container.Add(fieldList);
        }

        /// <summary>
        /// Check for the parameter validation
        /// </summary>
        /// <param name="isValid">True if is valid, otherwise false</param>
        /// <param name="errorMessage">The error message, if applicable</param>
        public void Validate(out bool isValid, out string errorMessage)
        {
            isValid = true;
            errorMessage = string.Empty;

            var solrFieldAttribute = UtilHelper.GetSolrFieldAttributeFromPropertyInfo(this._expression);
            //TODO: Unit test
            if (solrFieldAttribute != null && !solrFieldAttribute.Stored)
            {
                isValid = false;
                errorMessage = "A field must be \"stored=true\" to be used in field list";
            }
        }
    }
}
