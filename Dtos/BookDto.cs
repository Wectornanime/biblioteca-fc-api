namespace biblioteca_fc_api.Dtos
{
    public class BookPostDto
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public float Value { get; set; }
        public int CategoryId { get; set; }
    }
}