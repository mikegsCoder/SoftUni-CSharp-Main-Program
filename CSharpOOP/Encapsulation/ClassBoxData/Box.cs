using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const string INVALID_SIDE_EXC_MSG = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length 
        {
            get => this.length;
            private set 
            {
                this.ValidateSide(value, nameof(Length));
                this.length = value;
            } 
        }
        public double Width
        {
            get => this.width;
            private set
            {
                this.ValidateSide(value, nameof(Width));
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                this.ValidateSide(value, nameof(Height));
                this.height = value;
            }
        }

        public double CalculateVolume() => this.Length * this.Width * this.Height;
        public double CalculateLateralSurfaceArea() =>
            2 * (this.Width * this.Height + this.Height * this.Length);
        public double CalculateSurfaceArea() =>
            2 * (this.Length * this.Width + this.Width * this.Height + this.Height * this.Length);
 
        private void ValidateSide(double side, string paramName)
        {
            if (side <= 0)
            {
                throw new ArgumentException(String.Format(INVALID_SIDE_EXC_MSG, paramName));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Surface Area - {this.CalculateSurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {this.CalculateLateralSurfaceArea():f2}")
                .AppendLine($"Volume - {this.CalculateVolume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
