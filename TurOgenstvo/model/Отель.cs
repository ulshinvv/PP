using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurOgenstvo.model
{
    internal class Отель
    {
        public int ОтельID {  get; set; }
        public string Название { get; set; }
        public int Звезды {  get; set; }
        public int Тип_Питания { get; set; }
    }
}
