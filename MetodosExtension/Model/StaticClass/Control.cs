using MetodosExtension.Model.Class;
using MetodosExtension.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.StaticClass
{
    public static class Control
    {
        #region Delegates

        public delegate void voidFunction();
        public delegate void voidFunctionWithParam<T>(T parameter) where T : IParameter;
        public delegate T genericFunction<T>();
        public delegate TOut genericWithParam<TIn, TOut>(TIn param);

        #endregion

        #region Public Methdos

        public static IResponse RunMethod(Func<IParameter, IResponse> function, IParameter parametro)
        {
            IResponse response = new Response();
            try
            {
                response = function(parametro);
            }
            catch (Exception ex)
            {
                response.SetError(ex.Message);
            }
            return response;
        }
        public static IResponse RunMethod(Func<IResponse> function)
        {
            IResponse response = new Response();
            try
            {
                response = function();
            }
            catch (Exception ex)
            {
                response.SetError(ex.Message);
            }
            return response;
        }
        public static IResponse RunMethod<T>(genericFunction<T> function, out T output)
        {
            IResponse response = new Response();
            output = (T)default;
            try
            {
                output = function();
            }
            catch (Exception ex)
            {
                response.SetError(ex.Message);
            }
            return response;
        }
        public static IResponse RunMethod<TIn, TOut>(genericWithParam<TIn, TOut> function, TIn param, out TOut output)
        {
            IResponse response = new Response();
            output = (TOut)default;
            try
            {
                output = function(param);
            }
            catch (Exception ex)
            {
                response.SetError(ex.Message);
            }
            return response;
        }
        public static IResponse RunMethod(voidFunction funcion)
        {
            IResponse response = new Response();
            try
            {
                funcion();
            }
            catch (Exception ex)
            {
                response.SetError(ex.Message);
            }
            return response;
        }
        public static IResponse RunMethod<T>(voidFunctionWithParam<T> funcion, T parameter) where T : IParameter
        {
            IResponse response = new Response();
            try
            {
                funcion(parameter);
            }
            catch (Exception ex)
            {
                response.SetError(ex.Message);
            }
            return response;
        }

        #endregion
    }
}
