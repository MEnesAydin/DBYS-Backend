namespace Entities.RequestFeatures;

public class MetaData
{
    public int CurrentPage { get; set; }
    public int TotalPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public bool Previous => CurrentPage > 1;
    public bool Next => CurrentPage < TotalPage;

}