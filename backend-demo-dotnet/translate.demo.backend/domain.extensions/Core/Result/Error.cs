using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.extensions.Core.Result
{

  public class Error : BaseError
  {

    public Error(string message) : base(message) { }

  }

}
