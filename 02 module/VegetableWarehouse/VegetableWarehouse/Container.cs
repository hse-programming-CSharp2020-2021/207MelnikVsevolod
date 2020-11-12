using System;
namespace VegetableWarehouse
{
    /// <summary>
    /// Container of boxes of vegetables.
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Id of the container.
        /// </summary>
        public int ID
        {
            get; private set;
        }

        /// <summary>
        /// Boxes stored in the container.
        /// </summary>
        Box[] boxes;

        /// <summary>
        /// Maximal mass that can be stored there.
        /// </summary>
        public double MaxMass
        {
            get; private set;
        }

        /// <summary>
        /// Cost of the all vegetables in the container in rubles.
        /// </summary>
        public double Cost
        {
            get
            {
                double cost = 0;
                for (int i = 0; i < boxes.Length; ++i)
                    cost += boxes[i].Price * boxes[i].Mass;
                return cost;
            }
        }

        double Mass
        {
            get
            {
                double mass = 0;
                for (int i = 0; i < boxes.Length; ++i)
                    mass += boxes[i].Mass;
                return mass;
            }
        }

        public Container()
        {
            this.ID = 0;
            MaxMass = 0;
            boxes = new Box[0];
        }

        public Container(int id, double max_mass)
        {
            this.ID = id;
            MaxMass = max_mass;
            boxes = new Box[0];
        }

        /// <summary>
        /// Add a box to container if it's possible.
        /// </summary>
        /// <param name="box"> New box. </param>
        /// <returns> True if the box was added, false - if not. </returns>
        public bool AddBox(Box box)
        {
            if (box.Mass + Mass > MaxMass)
                return false;
            Array.Resize(ref boxes, boxes.Length + 1);
            boxes[boxes.Length - 1] = box;
            return true;
        }

        /// <summary>
        /// Damage the container, that results in reduced price for each box.
        /// </summary>
        /// <param name="damage_coef"> Coefficient of the damage dealt. </param>
        public void Damage(double damage_coef)
        {
            for (int i = 0; i < boxes.Length; ++i)
                boxes[i].Price *= 1 - damage_coef;
        }

        /// <summary>
        /// Information about the container and all stored boxes.
        /// </summary>
        /// <returns></returns>
        public string[] Info()
        {
            string[] info = new string[2 + boxes.Length * 3];
            info[0] = "Контейнер №" + ID.ToString();
            info[1] = "Общая стоимость: " + Cost.ToString("F2") + "₽";
            for (int i = 0; i < boxes.Length; ++i)
            {
                string[] box_info = boxes[i].Info();
                for (int j = 0; j < 3; ++j)
                    info[2 + (i * 3 + j)] = "  " + box_info[j];
            }
            return info;
        }
    }
}
