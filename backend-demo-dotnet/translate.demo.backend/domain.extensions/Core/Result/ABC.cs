using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.extensions.Core.Result
{
  public abstract class BaseError
  {
    public readonly string Message;

    protected BaseError(string error) 
    { 
      Message = error ?? Messages.Core_Error_DefaultError; 
    }

  }

  public class OperationException : Exception
  {

    public OperationException(BaseError error) 
      : base (error.Message) { }

    public static OperationException From(string e)
      => new OperationException(new Error(e));

  }


}
