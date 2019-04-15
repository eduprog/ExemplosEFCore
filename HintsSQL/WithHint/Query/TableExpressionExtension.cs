﻿using Microsoft.EntityFrameworkCore.Query.Expressions;
using Remotion.Linq.Clauses;

namespace Ralms.EntityFrameworkCore.Extensions.With.Query
{
    public class TableExpressionExtension : TableExpression
    {
        public virtual string Hint { get; }
        public TableExpressionExtension(
            string table, 
            string schema, 
            string alias, 
            string withHint,
            IQuerySource querySource) 
            :base(table,schema,alias,querySource)
        {
            Hint = withHint;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return GetType().GetHashCode() ^ (base.GetHashCode() * 397);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() 
                && Equals((TableExpressionExtension)obj);
        }

        private bool Equals(TableExpressionExtension oldExpression)
            => string.Equals(Table, oldExpression.Table)
               && string.Equals(Schema, oldExpression.Schema)
               && string.Equals(Alias, oldExpression.Alias)
               && Equals(QuerySource, oldExpression.QuerySource);

        public override string ToString()
            => Table + " " + Alias + (!string.IsNullOrWhiteSpace(Hint) ? $" WITH ({Hint})" : "");
    }
}
