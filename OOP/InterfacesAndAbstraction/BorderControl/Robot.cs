
namespace BorderControl
{
    public class Robot : Unit
    {
        private string model;
        private int id;

        public Robot(string name, string id)
            : base(name, id)
        {
            this.Model = base.Name;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }




    }
}