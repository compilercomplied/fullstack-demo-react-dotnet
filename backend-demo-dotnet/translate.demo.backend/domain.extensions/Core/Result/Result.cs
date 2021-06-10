using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.extensions.Core.Result
{

  public class Result<T>
  {

    public readonly T Value;
    public readonly string Error;

    Result(T v = default, string e = default)
    {
      Value = v;
      Error = e;
    }

    public bool IsSuccess => string.IsNullOrEmpty(Error);

    public T Unwrap() => !IsSuccess 
      ? throw OperationException.From(Error)
      : Value;


    // --- Builders ------------------------------------------------------------
    public static Result<T> OK(T value) => new(v: value);

    public static Result<T> FAIL(string error) => new(e: error);

  }

}
