﻿using SolrExpress.Core.Search.Parameter;
using SolrExpress.Extension;
using SolrExpress.Search;
using SolrExpress.Search.Parameter;
using SolrExpress.Search.Query;
using SolrExpress.Utility;
using System;
using System.Linq.Expressions;

namespace SolrExpress.Extension
{
    public static class DocumentSearchExtension
    {
        /// <summary>
        /// Create a not mapped parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="name">Name of parameter</param>
        /// <param name="value">Value of parameter</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Any<TDocument>(this DocumentSearch<TDocument> documentSearch, string name, string value)
            where TDocument : IDocument
        {
            Checker.IsNullOrWhiteSpace(name);
            Checker.IsNullOrWhiteSpace(value);

            var parameter = documentSearch.ServiceProvider.GetService<IAnyParameter<TDocument>>();
            parameter.Name(name);
            parameter.Value(value);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a boost parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="query">Query used to make boost</param>
        /// <param name="boostFunction">Boost type used in calculation</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Boost<TDocument>(this DocumentSearch<TDocument> documentSearch, ISearchQuery<TDocument> query, BoostFunctionType boostFunction = BoostFunctionType.Boost)
            where TDocument : IDocument
        {
            Checker.IsNull(query);
            Checker.IsNull(boostFunction);
            
            var parameter = documentSearch.ServiceProvider.GetService<IBoostParameter<TDocument>>();
            parameter.BoostFunctionType(boostFunction);
            parameter.Query(query);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a facet field parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="fieldExpression">Expression used to find field name</param>
        /// <param name="instance">Instance of facet ready to configure</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> FacetField<TDocument>(this DocumentSearch<TDocument> documentSearch, Expression<Func<TDocument, object>> fieldExpression, Action<IFacetFieldParameter<TDocument>> instance = null)
            where TDocument : IDocument
        {
            Checker.IsNull(fieldExpression);

            var parameter = documentSearch.ServiceProvider.GetService<IFacetFieldParameter<TDocument>>();
            parameter.FieldExpression(fieldExpression);

            instance?.Invoke(parameter);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a facet limit parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="value">Value of limit</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> FacetLimit<TDocument>(this DocumentSearch<TDocument> documentSearch, int value)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<IFacetLimitParameter<TDocument>>();
            parameter.Value(value);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a facet query parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="aliasName">Name of alias added in query</param>
        /// <param name="query">Query used to make facet</param>
        /// <param name="instance">Instance of facet ready to configure</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> FacetQuery<TDocument>(this DocumentSearch<TDocument> documentSearch, string aliasName, ISearchQuery<TDocument> query, Action<IFacetQueryParameter<TDocument>> instance = null)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<IFacetQueryParameter<TDocument>>();
            parameter.AliasName(aliasName);
            parameter.Query(query);

            instance?.Invoke(parameter);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a facet range parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="aliasName">Name of alias added in query</param>
        /// <param name="fieldExpression">Expression used to find field name</param>
        /// <param name="gap">Size of each range bucket to make facet</param>
        /// <param name="start">Lower bound to make facet</param>
        /// <param name="end">Upper bound to make facet</param>
        /// <param name="instance">Instance of parameter ready to configure</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> FacetRange<TDocument>(this DocumentSearch<TDocument> documentSearch, string aliasName, Expression<Func<TDocument, object>> fieldExpression, string gap, string start, string end, Action<IFacetRangeParameter<TDocument>> instance = null)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<IFacetRangeParameter<TDocument>>();
            parameter.AliasName(aliasName);
            parameter.FieldExpression(fieldExpression);
            parameter.Gap(gap);
            parameter.Start(start);
            parameter.End(end);

            instance?.Invoke(parameter);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a facet range parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="aliasName">Name of alias added in query</param>
        /// <param name="fieldExpression">Expression used to find field name</param>
        /// <param name="centerPoint">Center point to spatial filter</param>
        /// <param name="distance">Distance from center point</param>
        /// <param name="instance">Instance of parameter ready to configure</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> FacetSpatial<TDocument>(this DocumentSearch<TDocument> documentSearch, string aliasName, Expression<Func<TDocument, object>> fieldExpression, GeoCoordinate centerPoint, decimal distance, Action<IFacetSpatialParameter<TDocument>> instance = null)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<IFacetSpatialParameter<TDocument>>();
            parameter.AliasName(aliasName);
            parameter.FieldExpression(fieldExpression);
            parameter.CenterPoint(centerPoint);
            parameter.Distance(distance);

            instance?.Invoke(parameter);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a fields parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="fieldExpressions">Expressions used to find fields name</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Fields<TDocument>(this DocumentSearch<TDocument> documentSearch, params Expression<Func<TDocument, object>>[] fieldExpressions)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<IFieldsParameter<TDocument>>();
            parameter.FieldExpressions(fieldExpressions);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a filter parameter in commom case (field equals value, field with value in collection)
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="fieldExpression">Expression used to find field name</param>
        /// <param name="values">Values to find</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Filter<TDocument, TValue>(this DocumentSearch<TDocument> documentSearch, Expression<Func<TDocument, object>> fieldExpression, params TValue[] values)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<IFilterParameter<TDocument>>();
            // TODO: Configure search
            ISearchQuery<TDocument> search = null;

            parameter.Query(search);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a filter parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="fieldExpression">Expression used to find field name</param>
        /// <param name="instance">Instance of parameter ready to configure</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Filter<TDocument>(this DocumentSearch<TDocument> documentSearch, Expression<Func<TDocument, object>> fieldExpression, Action<IFilterParameter<TDocument>> instance)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<IFilterParameter<TDocument>>();
            // TODO: Configure search
            ISearchQuery<TDocument> search = null;

            parameter.Query(search);

            instance?.Invoke(parameter);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a limit parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="value">Value of limit</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Limit<TDocument>(this DocumentSearch<TDocument> documentSearch, long value)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<ILimitParameter<TDocument>>();
            parameter.Value(value);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a minimum should match
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="value">Expression used to make mm parameter</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> MinimumShouldMatch<TDocument>(this DocumentSearch<TDocument> documentSearch, string value)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<IMinimumShouldMatchParameter<TDocument>>();
            parameter.Value(value);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a offset parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="value">Value of offset</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Offset<TDocument>(this DocumentSearch<TDocument> documentSearch, long value)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<IOffsetParameter<TDocument>>();
            parameter.Value(value);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a limit and a offset parameters
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="itemsPerPage">Quantity of items in one page</param>
        /// <param name="currentPage">Current page</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Page<TDocument>(this DocumentSearch<TDocument> documentSearch, long itemsPerPage, long currentPage)
            where TDocument : IDocument
        {
            documentSearch.Limit(itemsPerPage);
            documentSearch.Offset((currentPage - 1) * itemsPerPage);

            return documentSearch;
        }

        /// <summary>
        /// Create a query field parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="expression">Query used to make query field</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> QueryField<TDocument>(this DocumentSearch<TDocument> documentSearch, string expression)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<IQueryFieldParameter<TDocument>>();
            parameter.Expression(expression);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a query parameter in commom case (field equals value, field with value in collection)
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="fieldExpression">Expression used to find field name</param>
        /// <param name="values">Values to find</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Query<TDocument, TValue>(this DocumentSearch<TDocument> documentSearch, Expression<Func<TDocument, object>> fieldExpression, params TValue[] values)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<IQueryParameter<TDocument>>();
            // TODO: Configure search
            ISearchQuery<TDocument> search = null;

            parameter.Value(search);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a query parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="fieldExpression">Expression used to find field name</param>
        /// <param name="instance">Instance of parameter ready to configure</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Query<TDocument>(this DocumentSearch<TDocument> documentSearch, Expression<Func<TDocument, object>> fieldExpression, Action<IQueryParameter<TDocument>> instance)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<IQueryParameter<TDocument>>();
            // TODO: Configure search
            ISearchQuery<TDocument> search = null;

            parameter.Value(search);

            instance?.Invoke(parameter);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a sort parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="fieldExpression">Expression used to find field name</param>
        /// <param name="ascendent">True to ascendent order, otherwise false</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Sort<TDocument>(this DocumentSearch<TDocument> documentSearch, Expression<Func<TDocument, object>> fieldExpression, bool ascendent)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<ISortParameter<TDocument>>();
            parameter.FieldExpression(fieldExpression);
            parameter.Ascendent(ascendent);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a sort parameter configured to do a random sort
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> SortRandomly<TDocument>(this DocumentSearch<TDocument> documentSearch)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<ISortRandomlyParameter<TDocument>>();

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a spatial filter parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="fieldExpression">Expression used to find field name</param>
        /// <param name="functionType">Function used in spatial filter</param>
        /// <param name="centerPoint">Center point to spatial filter</param>
        /// <param name="distance">Distance from center point</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> SpatialFilter<TDocument>(this DocumentSearch<TDocument> documentSearch, Expression<Func<TDocument, object>> fieldExpression, GeoCoordinate centerPoint, decimal distance, SpatialFunctionType functionType = SpatialFunctionType.Bbox)
            where TDocument : IDocument
        {
            var parameter = documentSearch.ServiceProvider.GetService<ISpatialFilterParameter<TDocument>>();
            parameter.FieldExpression(fieldExpression);
            parameter.FunctionType(functionType);
            parameter.CenterPoint(centerPoint);
            parameter.Distance(distance);

            documentSearch.Add(parameter);

            return documentSearch;
        }
    }
}