using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Helpers
{
    public static class BlogHelper
    {
        public static String ShortContentFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, int length)
            where TModel:class
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            try
            {
               var metadata = ModelMetadata.FromLambdaExpression(expression,htmlHelper.ViewData);
          
                String content = (metadata.Model as String);
               if (content.Length > length)
                   return content.Substring(0, length);
               else
                   return content;
            }
            catch (Exception exp)
            {
            }
            return null;
                //return NewTextBox(htmlHelper, name, metadata.Model as string);
        }
 
    }
}