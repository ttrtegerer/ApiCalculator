using CalculatorViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpPost("Operation")]
        public IActionResult Operation([FromBody] CalculatorView model)
        {
            if (IsNumeric(model.first_number) && IsNumeric(model.last_number))
            {
                switch (model.operation)
                {
                    case "summ":
                        {
                            var sum = ConvertToDecimal(model.first_number) + ConvertToDecimal(model.last_number);
                            model.answer = sum;
                            return Ok(model.answer);
                        };
                        
                    case "multiply":
                        {
                            var mult = ConvertToDecimal(model.first_number) * ConvertToDecimal(model.last_number);
                            model.answer = mult;
                            return Ok(model.answer);
                        };
                    case "substract":
                        {
                            var sub = ConvertToDecimal(model.first_number) - ConvertToDecimal(model.last_number);
                            model.answer = sub;
                            return Ok(model.answer);
                        };
                    case "divide":
                        {
                            switch (model.last_number)
                            {
                                case "0":
                                    {
                                        return BadRequest("На ноль делить нельзя");
                                    }
                                default:
                                    {
                                        var div = ConvertToDecimal(model.first_number) / ConvertToDecimal(model.last_number);
                                        model.answer = div;
                                        return Ok(model.answer);
                                    }
                            }                  
                            

                        };
                    default:
                        return BadRequest("Неизвестная операция");

                }
            }

            return BadRequest("Invalid Input");
        }
        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber
                , System.Globalization.NumberStyles.Any
                , System.Globalization.NumberFormatInfo.InvariantInfo
                , out number);
            return isNumber;
        }
    }
}
