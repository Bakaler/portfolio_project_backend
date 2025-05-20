public readonly struct ErrorCode
{
    public int Code { get; }
    public string Category { get; }

    public ErrorCode(int code, string category)
    {
        Code = code;
        Category = category;
    }

    public override string ToString() => $"{Category}:{Code}";
}