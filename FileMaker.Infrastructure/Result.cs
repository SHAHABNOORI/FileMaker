using FileMaker.Infrastructure.Enums;

namespace FileMaker.Infrastructure
{
    public class Result
    {
        public ResultType Type  { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}