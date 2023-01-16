using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1_Dice;

namespace cube
{
    internal class Controller
    {
        Model model;
        View view;
        public Controller(Model model , View view)
        {
            this.model = model;
            this.view = view;
        }

    }
}
