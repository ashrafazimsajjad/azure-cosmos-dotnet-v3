﻿//-----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlObjectCreateScalarExpression.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------------------------------------
namespace Microsoft.Azure.Cosmos.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal sealed class SqlObjectCreateScalarExpression : SqlScalarExpression
    {
        private SqlObjectCreateScalarExpression(IEnumerable<SqlObjectProperty> properties)
            : base(SqlObjectKind.ObjectCreateScalarExpression)
        {
            if (properties == null)
            {
                throw new ArgumentNullException($"{nameof(properties)} must not be null.");
            }

            foreach (SqlObjectProperty property in properties)
            {
                if (property == null)
                {
                    throw new ArgumentException($"{nameof(properties)} must not have null items.");
                }
            }

            this.Properties = new List<SqlObjectProperty>(properties);
        }

        public IEnumerable<SqlObjectProperty> Properties
        {
            get;
        }

        public static SqlObjectCreateScalarExpression Create(params SqlObjectProperty[] properties)
        {
            return new SqlObjectCreateScalarExpression(properties);
        }

        public static SqlObjectCreateScalarExpression Create(IEnumerable<SqlObjectProperty> properties)
        {
            return new SqlObjectCreateScalarExpression(properties);
        }

        public override void Accept(SqlObjectVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override TResult Accept<TResult>(SqlObjectVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }

        public override TResult Accept<T, TResult>(SqlObjectVisitor<T, TResult> visitor, T input)
        {
            return visitor.Visit(this, input);
        }

        public override void Accept(SqlScalarExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override TResult Accept<TResult>(SqlScalarExpressionVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }

        public override TResult Accept<T, TResult>(SqlScalarExpressionVisitor<T, TResult> visitor, T input)
        {
            return visitor.Visit(this, input);
        }
    }
}
