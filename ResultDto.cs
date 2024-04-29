namespace ConsoleApp;

// واسه زمانی که می خواهیم یدونه خروجی داشته باشیم
public class ResultDto<T> : ResultDto
{
    public T Value { get; set; }
    public override string ToString()
    {
        return $"IsSuccess: {IsSuccess}\nMessage: {Message}\n";
    }
}

// واسه زمانی که هیچ خروجی نداریم
public class ResultDto
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public override string ToString()
    {
        return $"IsSuccess: {IsSuccess}\nMessage: {Message}";
    }
}

// زمانی که یک کالکشنی از خروجی می خوهیم
public class ResultsDto<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public IEnumerable<T> Value { get; set; }
    public override string ToString()
    {
        return $"IsSuccess: {IsSuccess}\nMessage: {Message}\n";
    }
}