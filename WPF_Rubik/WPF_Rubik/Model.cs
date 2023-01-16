using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Rubik
{
    public class Model
    {
        private int x = 1; // front
        private int y = 2; // side
        private int z = 3; // top


        // Any face plus opposite of that face will always equal to 7.
        public void X_To_Y() // front to side
        {
            int temp_x = x;
            int temp_y = y;

            // Any face plus opposite of that face will always equal to 7.
            x = Math.Abs(7 - temp_y);  // x will be opposite face of y
            y = temp_x;

        }

        public void Z_To_X() // top to front
        {
            int temp_x = x;
            int temp_z = z;

            // Any face plus opposite of that face will always equal to 7.
            x = temp_z;
            z = Math.Abs(7 - temp_x); // z will be opposite face of x
        }

        public int[] GetFaces()
        {
            int[] faces = { x, y, z };
            return faces;
        }
    }
}
