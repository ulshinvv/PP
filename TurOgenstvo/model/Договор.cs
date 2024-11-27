using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurOgenstvo.model
{
    internal class Договор
    {
        public int Номер {  get; set; }
        public string Дата {  get; set; }
        public int Цена { get; set; }
        public string Статус { get; set; }
        public int ТурID { get; set; }
        public int КлиентID { get; set; }
    }
}
