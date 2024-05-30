namespace biblioteca_fc_api.Dtos
{
    public class CreateBookDto
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public float Value { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateBookDto
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public float Value { get; set; }
        public int CategoryId { get; set; }
    }

    public class ResponseBookDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public float Value { get; set; }
        public int CategoryId { get; set; }
    }
    
}