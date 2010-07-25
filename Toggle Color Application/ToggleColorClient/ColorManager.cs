using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ToggleColorClient
{
    class ColorManager
    {
        private Color currentColor;


        public void In_ToggleColor()
        {
            this.currentColor = this.currentColor == Color.Green
                                    ? Color.Red
                                    : Color.Green;
            this.Out_CurrentColor(this.currentColor);
        }


        public void In_GetInitialColor()
        {
            this.currentColor = Color.Green;
            this.Out_CurrentColor(this.currentColor);
        }


        public event Action<Color> Out_CurrentColor;
    }
}
