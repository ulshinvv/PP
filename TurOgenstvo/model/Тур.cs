using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurOgenstvo.model
{
    public class Тур
    {
        public int Номер {  get; set; }
        public string Наименование {  get; set; }
        public int Цена {  get; set; }
        public int Тип_Тура {  get; set; }
        public int ОтельID {  get; set; }
        public string Типы { get; set; }
    }
}
