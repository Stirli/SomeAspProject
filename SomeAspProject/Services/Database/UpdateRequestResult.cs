namespace SomeAspProject.Services.Database
{
    public class UpdateRequestResult : DatabaseRequestResult
    {
        public UpdateRequestResult(int number)
        {
            Number = number;
        }

        public int Number { get; }
    }
}
