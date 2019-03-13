using System;
using System.Collections.Generic;
using System.Linq;

namespace BinXiangHealth.EMT.Hosp.ProxyApi
{
    public static class ExceptionExtensions
    {
        public static string[] GetErrorMessages(this Exception ex)
        {
            var errors = new List<string>();

            var error = ex;
            for (; ; )
            {
                if (error == null)
                {
                    break;
                }

                errors.Add(error.Message);
                error = error.InnerException;
            }

            return errors?.OrderByDescending(p => p)?.ToArray();
        }
    }
}
