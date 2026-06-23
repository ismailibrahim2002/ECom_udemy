using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_lib.Dtos
{
    public class ResponseDto
    {
        public ResponseDto(bool _success = false, string _msessage = null!)
        {
            Success = _success;
            Msessage= _msessage;


        }
        public bool Success { get; set; }
        public string Msessage { get; set; }
    }

}
