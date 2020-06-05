using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int? weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine, weight)
        {
            this.Color = color;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            private set { this.engine = value; }
        }

        public int? Weight
        {
            get { return this.weight; }
            private set { this.weight = value; }
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var weightString = this.Weight.HasValue ? this.Weight.ToString() : "n/a";
            var colorString = string.IsNullOrEmpty(this.Color) ? "n/a" : this.Color;
            var displacementString = this.Engine.Displacement.HasValue ?
                this.Engine.Displacement.ToString() : "n/a";
            var efficiencyString = string.IsNullOrEmpty(this.Engine.Efficiency) ?
                "n/a" : this.Engine.Efficiency;

            sb.AppendLine(String.Format("{0}:", this.Model))
                .AppendLine(string.Format("  {0}:", this.Engine.Model))
                .AppendLine(string.Format("    Power: {0}", this.Engine.Power))
                .AppendLine(string.Format("    Displacement: {0}", displacementString))
                .AppendLine(string.Format("    Efficiency: {0}", efficiencyString))
                .AppendLine(string.Format("  Weight: {0}", weightString))
                .AppendLine(string.Format("  Color: {0}", colorString));

            return sb.ToString().TrimEnd();
        }

    }
}
