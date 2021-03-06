﻿//-----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlScalarExpressionVisitor.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------------------------------------
namespace Microsoft.Azure.Cosmos.Sql
{
    using System;

    internal abstract class SqlScalarExpressionVisitor
    {
        public abstract void Visit(SqlArrayCreateScalarExpression scalarExpression);
        public abstract void Visit(SqlArrayScalarExpression scalarExpression);
        public abstract void Visit(SqlBetweenScalarExpression scalarExpression);
        public abstract void Visit(SqlBinaryScalarExpression scalarExpression);
        public abstract void Visit(SqlCoalesceScalarExpression scalarExpression);
        public abstract void Visit(SqlConditionalScalarExpression scalarExpression);
        public abstract void Visit(SqlConversionScalarExpression scalarExpression);
        public abstract void Visit(SqlExistsScalarExpression scalarExpression);
        public abstract void Visit(SqlFunctionCallScalarExpression scalarExpression);
        public abstract void Visit(SqlGeoNearCallScalarExpression scalarExpression);
        public abstract void Visit(SqlInScalarExpression scalarExpression);
        public abstract void Visit(SqlLiteralScalarExpression scalarExpression);
        public abstract void Visit(SqlMemberIndexerScalarExpression scalarExpression);
        public abstract void Visit(SqlObjectCreateScalarExpression scalarExpression);
        public abstract void Visit(SqlPropertyRefScalarExpression scalarExpression);
        public abstract void Visit(SqlSubqueryScalarExpression scalarExpression);
        public abstract void Visit(SqlUnaryScalarExpression scalarExpression);
    }

    internal abstract class SqlScalarExpressionVisitor<TResult>
    {
        public abstract TResult Visit(SqlArrayCreateScalarExpression scalarExpression);
        public abstract TResult Visit(SqlArrayScalarExpression scalarExpression);
        public abstract TResult Visit(SqlBetweenScalarExpression scalarExpression);
        public abstract TResult Visit(SqlBinaryScalarExpression scalarExpression);
        public abstract TResult Visit(SqlCoalesceScalarExpression scalarExpression);
        public abstract TResult Visit(SqlConditionalScalarExpression scalarExpression);
        public abstract TResult Visit(SqlConversionScalarExpression scalarExpression);
        public abstract TResult Visit(SqlExistsScalarExpression scalarExpression);
        public abstract TResult Visit(SqlFunctionCallScalarExpression scalarExpression);
        public abstract TResult Visit(SqlGeoNearCallScalarExpression scalarExpression);
        public abstract TResult Visit(SqlInScalarExpression scalarExpression);
        public abstract TResult Visit(SqlLiteralScalarExpression scalarExpression);
        public abstract TResult Visit(SqlMemberIndexerScalarExpression scalarExpression);
        public abstract TResult Visit(SqlObjectCreateScalarExpression scalarExpression);
        public abstract TResult Visit(SqlPropertyRefScalarExpression scalarExpression);
        public abstract TResult Visit(SqlSubqueryScalarExpression scalarExpression);
        public abstract TResult Visit(SqlUnaryScalarExpression scalarExpression);
    }

    internal abstract class SqlScalarExpressionVisitor<TInput, TOutput>
    {
        public abstract TOutput Visit(SqlArrayCreateScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlArrayScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlBetweenScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlBinaryScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlCoalesceScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlConditionalScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlConversionScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlExistsScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlFunctionCallScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlGeoNearCallScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlInScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlLiteralScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlMemberIndexerScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlObjectCreateScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlPropertyRefScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlSubqueryScalarExpression scalarExpression, TInput input);
        public abstract TOutput Visit(SqlUnaryScalarExpression scalarExpression, TInput input);
    }
}
