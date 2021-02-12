using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
 public interface IDataResult <T> : IResult //Interfaces implement in this ways
    {

        T Data { get; }
    }
}
