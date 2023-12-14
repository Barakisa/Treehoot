namespace Treehoot.Api.Dtos
{
    public class PutPlaygroundQuizRequest
    {
        public int Code { get; set; }
        public Guid Id { get; set; }
        public string Action { get; set; }
    }
}
