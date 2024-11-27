using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurOgenstvo.model
{
    internal class Клиент
    {
        public int КлиентID {  get; set; }
        public string Имя {  get; set; }
        public string Фамилия {  get; set; }
        public string Отчество {  get; set; }
        public string Телефон { get; set; }
        public string Email {  get; set; }
    }
}
