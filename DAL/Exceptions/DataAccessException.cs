using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DAL.Exceptions
{
    public class DataAccessException : Exception
    {
       public DataAccessException(Exception ex ,string customMessage, ILogger logger)
       {
           logger.LogError($"Main exception {ex.Message} developer custom exception {customMessage}");
       }
    }
}
