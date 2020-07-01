using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const string ERROR_MESSAGE = "cannot be zero or negative.";

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double length;
        private double width;
        private double height;

        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Length " + ERROR_MESSAGE);
                }
                this.length = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Width " + ERROR_MESSAGE);
                }
                width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Height " + ERROR_MESSAGE);

                }
                this.height = value;
            }
        }

        public double GetSurfaceArea()
        {
            var surfaceArea = 2 * (this.Length * this.Height) + 2 * (this.Length * this.Width) + 2 * (this.Height * this.Width);
            return surfaceArea;
        }

        public double GetLateralArea()
        {
            var lateralArea = 2 * (this.Length * this.height) + 2 * (this.Height * this.width);
            return lateralArea;
        }

        public double GetVolume()
        {
            var volume = this.Length * this.Height * this.Width;
            return volume;
        }


    }
}
