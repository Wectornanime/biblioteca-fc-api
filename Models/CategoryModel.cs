namespace biblioteca_fc_api.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<BookModel>? Books { get; set; }
    }
}