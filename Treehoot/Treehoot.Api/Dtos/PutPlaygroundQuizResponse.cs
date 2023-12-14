namespace Treehoot.Api.Dtos
{
    public class PutPlaygroundQuizResponse
    {
        public bool Success { get; set; }
        public string Action { get; set; }
        public int? Code { get; set; }
        public Guid? Id { get; set; }

    }
}
