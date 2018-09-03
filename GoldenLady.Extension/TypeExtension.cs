using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GoldenLady.Extension
{

    public static class TypeExtension
    {
        /// <summary>
        /// 搜索其参数与指定数组中的类型匹配的公共实例构造函数，并返加该构造函数的委托
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">类型</param>
        /// <param name="parameterTypes">指定参数数组</param>
        /// <returns></returns>
        public static Func<object[],T> CreateInstanceDelegate<T>(this Type type, params Type[] parameterTypes)
        {
            //根据参数类型数组来获取构造函数
            var constructor = type.GetConstructor(parameterTypes);
            //创建lambda表达示参数
            var lambdaParamsExp = Expression.Parameter(typeof(object[]), "_args");
            //转换参数为构造函数可用的类型
            var paramsExp = new Expression[parameterTypes.Length];
            for (int i = 0; i < parameterTypes.Length; ++i)
            {
                var oneParamExp = BinaryExpression.ArrayIndex(lambdaParamsExp, Expression.Constant(i, typeof(int)));
                paramsExp[i] = Expression.Convert(oneParamExp, parameterTypes[i]);
            }
            //创建构造函数表达式
            var newExp = Expression.New(constructor, paramsExp);
            //创建Func<object[],object>并返回
            return Expression.Lambda<Func<object[], T>>(newExp, lambdaParamsExp).Compile();
        }
        /// <summary>
        /// 搜索其无参数的公共实例构造函数，并返加该构造函数的委托
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Func<T> CreateInstanceDelegate<T>(this Type type)
        {
            var newExp = Expression.New(type);
            return Expression.Lambda<Func<T>>(newExp, null).Compile();
        }
    }
}
