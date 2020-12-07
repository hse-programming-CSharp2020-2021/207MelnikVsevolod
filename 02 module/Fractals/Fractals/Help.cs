using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fractals
{
    /// <summary>
    /// Help and manual window.
    /// </summary>
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Load window and display manual text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Help_Load(object sender, EventArgs e)
        {
            string[] lines = { "Управление: "
                             , " wasd - перемещение фрактала"
                             , " e - увеличить изображение"
                             , " q - уменьшить изображение"
                             , " пробел - вернуть фрактал в исходное состояние"
                             , ""
                             , "Цвет 1 - начальный цвет фрактала (доступно не для всех фракталов)"
                             , "Цвет 2 - конечный цвет фрактала"
                             , "Сохранить - сохранить фрактал в формате png"
                             , ""
                             , "При большой глубине рекурсии отрисовка может тормозить."
                             , "Весь дополнительный функционал реализован, также добавлен новый фрактал."
            };
            textBox1.Lines = lines;
            textBox1.Select(0, 0);
        }
    }
}
