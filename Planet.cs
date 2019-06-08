using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomicalCatalog
{
    public class Planet
    {
        /// <summary>
        /// Имя планеты
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Размер планеты
        /// </summary>
        public string Radius { get; set; }
        /// <summary>
        /// Экзопланеты, вращающиеся вокруг звезды
        /// </summary>
        public List<Star> List { get; set; }
        /// <summary>
        /// Фотография планеты
        /// </summary>
        public byte[] Photo { get; set; }
    }

    public class Star
    {
        /// <summary>
        /// Масса планеты
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        /// Цвет
        /// </summary>
        public string Colour { get; set; }
        /// <summary>
        /// Температура
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// Ускорение свободного падения
        /// </summary>
        public string Gravity { get; set; }

        public override string ToString()
        {
            return $"Масса: {Weight}, Цвет: {Colour}, Температура: {Temperature}, Ускорение свободного падения: {Gravity}";
        }
    }
}
