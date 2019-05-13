﻿//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Azure.Cosmos.Linq
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary> 
    /// This class serve as LINQ query provider imlementing IQueryProvider.
    /// </summary> 
    internal sealed class CosmosLINQQueryProvider : IQueryProvider
    {
        private readonly CosmosContainerCore container;
        private readonly CosmosQueryClient queryClient;
        private readonly CosmosJsonSerializer cosmosJsonSerializer;
        private readonly QueryRequestOptions cosmosQueryRequestOptions;

        public CosmosLINQQueryProvider(
           CosmosContainerCore container,
           CosmosJsonSerializer cosmosJsonSerializer,
           CosmosQueryClient queryClient,
           QueryRequestOptions cosmosQueryRequestOptions)
        {
            this.container = container;
            this.cosmosJsonSerializer = cosmosJsonSerializer;
            this.queryClient = queryClient;
            this.cosmosQueryRequestOptions = cosmosQueryRequestOptions;
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new CosmosLINQQuery<TElement>(
                this.container,
                this.cosmosJsonSerializer,
                this.queryClient,
                this.cosmosQueryRequestOptions,
                expression);
        }

        public IQueryable CreateQuery(Expression expression)
        {
            Type expressionType = TypeSystem.GetElementType(expression.Type);
            Type DocumentQueryType = typeof(CosmosLINQQuery<bool>).GetGenericTypeDefinition().MakeGenericType(expressionType);
            return (IQueryable)Activator.CreateInstance(
                DocumentQueryType,
                this.container,
                this.cosmosJsonSerializer,
                this.queryClient,
                this.cosmosQueryRequestOptions,
                expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            Type CosmosQueryType = typeof(CosmosLINQQuery<bool>).GetGenericTypeDefinition().MakeGenericType(typeof(TResult));
            CosmosLINQQuery<TResult> cosmosLINQQuery = (CosmosLINQQuery<TResult>)Activator.CreateInstance(
                CosmosQueryType,
                this.container,
                this.cosmosJsonSerializer,
                this.queryClient,
                this.cosmosQueryRequestOptions,
                expression);

            return cosmosLINQQuery.ToList().FirstOrDefault();
        }

        //Sync execution of query via direct invoke on IQueryProvider.
        public object Execute(Expression expression)
        {
            Type CosmosQueryType = typeof(CosmosLINQQuery<bool>).GetGenericTypeDefinition().MakeGenericType(typeof(object));
            CosmosLINQQuery<object> documentQuery = (CosmosLINQQuery<object>)Activator.CreateInstance(
                CosmosQueryType,
                this.container,
                this.cosmosJsonSerializer,
                this.queryClient,
                this.cosmosQueryRequestOptions);

            return documentQuery.ToList().FirstOrDefault();
        }
    }
}
