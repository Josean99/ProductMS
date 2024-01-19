using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadRepositories
{
    public static class CacheKeys
    {
        public static string FindAll<T>() where T : class
        {
            return $"FindAll{typeof(T).Name}CacheKey";
        }

        public static string FindByCondition<T>(string expression) where T : class
        {
            string[] expressions = expression.Split('.');
            var expressionString = new StringBuilder();
            foreach ( var condition in expressions.Skip(1).ToArray() ) 
            {
                if (!condition.Contains("Equals"))
                {
                    expressionString.Append(condition.Split('=').First().Trim());
                }
            }
            return $"FindByCondition{typeof(T).Name}{expressionString}CacheKey";
        }
    }
}
