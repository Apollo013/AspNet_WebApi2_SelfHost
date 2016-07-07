namespace OWINSelfHost.Models.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static int currentId = 0;

        public Company()
        {
            currentId++;
            this.Id = currentId;
        }

        public override string ToString()
        {
            return $"ID: {Id} : Name: {Name}";// this.Id + " : " + this.Name;
        }
    }
}
