using System;
using System.ComponentModel.DataAnnotations;

namespace CalculatorViewModel
{
    public class CalculatorView
    {
        [Required(ErrorMessage = "Введите Первую цифру")]
        public string first_number { get; set; }

        [Required(ErrorMessage = "Введите Вторую цифру")]
        public string last_number { get; set; }

        [Required(ErrorMessage = "Введите Операцию")]
        public string operation { get; set; }

        public decimal answer { get; set; }
    }
}
