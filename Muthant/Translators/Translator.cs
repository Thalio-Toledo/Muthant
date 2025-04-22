using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mystiqueMapper.Translators
{
    internal static class Translator
    {
        public static object Translate(Expression expression)
        {
            if(expression is UnaryExpression unaryExpression)
                expression = (MemberExpression)unaryExpression.Operand;

            if (expression is MemberExpression memberExpression)
                return memberExpression.Member.Name;

            throw new NotSupportedException($"O tipo de expressão '{expression.GetType()}' não é suportado.");
        }
    }
}
