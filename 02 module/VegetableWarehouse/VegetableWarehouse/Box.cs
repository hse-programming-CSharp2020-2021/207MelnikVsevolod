using System;
namespace VegetableWarehouse
{
    /// <summary>
    /// Box of vegetables.
    /// </summary>
    public class Box
    {
        /// <summary>
        /// Id of the box.
        /// </summary>
        public string ID
        {
            get; private set;
        }

        /// <summary>
        /// Mass of the vegetables.
        /// Can't be changed from the outside.
        /// </summary>
        public double Mass
        {
            get; private set;
        }

        /// <summary>
        /// Price per kilogram in rubles.
        /// </summary>
        public double Price
        {
            get; set;
        }

        public Box()
        {
            Mass = Price = 0;
            ID = "Неизвестные овощи 1";
        }

        public Box(string id, double mass, double price)
        {
            Mass = mass;
            Price = price;
            this.ID = id;
        }

        /// <summary>
        /// Information about the box: mass and price per kg.
        /// </summary>
        /// <returns> Strings with information about the box. </returns>
        public string[] Info()
        {
            string[] info = new string[3] {
                ID,
                " Масса овощей: " + Mass.ToString("F3") + "кг",
                " Цена за килограмм: " + Price.ToString("F2") + "₽/кг" };
            return info;
        }
    }
}
