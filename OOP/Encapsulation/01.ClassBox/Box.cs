using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        private string mesaage = "{0} cannot be zero or negative.";

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }


        public double Length
        {
            get { return this.length; }
            private set
            {
                ValidateValue(value,nameof(this.Length));
                this.length = value;
            }
        }

        public double Width
        {
            get { return this.width; }
          private  set
            {
                ValidateValue(value,nameof(this.Width));
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
           private set
            {
                ValidateValue(value,nameof(this.Height));
                this.height = value;
            }

        }

        public void ValidateValue(double value,string sideName)
        {
            if (value <= 0)
            {
                throw new InvalidOperationException(String.Format(mesaage,sideName));
            }
        }

        public double GetVolume()
        {
            var volume = this.Length * this.Width * this.Height;
            return volume;
        }

        public double GetSurfaceArea()
        {
            var surfaceArea = 2 * ((this.Length * this.Width) + (this.Length * this.Height) + (this.Width * this.Height));
            return surfaceArea;
        }

        public double GetLateralArea()
        {
            var lateralArea = 2 * ((this.Length * this.Height) + (this.Width * this.Height));
            return lateralArea;
        }
    }
}
