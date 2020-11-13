using System;
namespace VegetableWarehouse
{
    /// <summary>
    /// Vegetablr warehouse.
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// Containers of boxes of vegetables, stored in the warehouse.
        /// </summary>
        Container[] containers;

        /// <summary>
        /// Maximal number of the containers in the warehouse.
        /// </summary>
        int max_cnt;

        Random rnd = new Random();

        /// <summary>
        /// Fee for storing of the 1 container.
        /// </summary>
        public double Fee
        {
            get; private set;
        }

        public Warehouse()
        {
            max_cnt = 0;
            Fee = 0;
            containers = new Container[0];
        }

        public Warehouse(int max_cnt, double fee)
        {
            this.max_cnt = max_cnt;
            Fee = fee;
            containers = new Container[0];
        }

        /// <summary>
        /// Add container if it is rentable.
        /// </summary>
        /// <param name="container"> New container. </param>
        /// <returns> True if container has been added, false if not. </returns>
        public bool AddContainer(Container container)
        {
            container.Damage(rnd.NextDouble() / 2);
            if (container.Cost <= Fee)
                return false;
            if (containers.Length < max_cnt)
            {
                // Add new container.
                Array.Resize(ref containers, containers.Length + 1);
                containers[containers.Length - 1] = container;
            }
            else
            {
                // Trow away first container and add new.
                for (int i = 0; i < max_cnt - 1; ++i)
                    containers[i] = containers[i + 1];
                containers[max_cnt - 1] = container;
            }
            return true;
        }

        /// <summary>
        /// Delete container from the warehouse.
        /// </summary>
        /// <param name="id"> Id of the container. </param>
        /// <returns> True if that container was found and removed. </returns>
        public bool DeleteContainer(int id)
        {
            for (int i = 0; i < containers.Length; ++i)
            {
                if (containers[i].ID == id)
                {
                    for (int j = i; j < containers.Length - 1; ++j)
                        containers[j] = containers[j + 1];
                    Array.Resize(ref containers, containers.Length - 1);
                    return true;
                }
            }
            return false;
        }

        public Box[] Search(string id)
        {
            Box[] found_boxes = new Box[0];
            for (int i = 0; i < containers.Length; ++i)
            {
                Box[] boxes_in_container = containers[i].Search(id);
                for (int j = 0; j < boxes_in_container.Length; ++j)
                {
                    Array.Resize(ref found_boxes, found_boxes.Length + 1);
                    found_boxes[found_boxes.Length - 1] = boxes_in_container[j];
                }
            }
            return found_boxes;
        }

        /// <summary>
        /// Get info about the warehouse.
        /// </summary>
        /// <returns> Strings with info about containers. </returns>
        public string[] Info()
        {
            string[] info = new string[1];
            info[0] = "Склад овощей";
            for (int i = 0; i < containers.Length; ++i)
            {
                string[] c_info = containers[i].Info();
                for (int j = 0; j < c_info.Length; ++j)
                {
                    int len = info.Length;
                    Array.Resize(ref info, len + 1);
                    info[len] = "  " + c_info[j];
                }
            }
            return info;
        }
    }
}
