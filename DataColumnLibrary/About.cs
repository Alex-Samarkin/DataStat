using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataColumnLibrary
{
    public class About
    {
        public string Author { get; set; } = "Самаркин А.И.";
        public string Description { get; set; } = "Библиотека для работы с данными в виде колонки";
        public string Name { get; set; } = "DataColumn";
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
