using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_lib.Exceptions
{
    public class ItemNotFoundEx (string msg) : Exception(msg)
    {
    }
}
