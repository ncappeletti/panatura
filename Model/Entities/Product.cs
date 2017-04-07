namespace panatura.Model.Entities
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}