namespace biblioteca_fc_api.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public float Value { get; set; }
        public int CategoryId { get; set; }

        public virtual CategoryModel? Category { get; set; }
    }
}