namespace Entities.RequestFeatures;

public class PagedList<T>
{
    public List<T> List { get; set; }
    public MetaData MetaData { get; set; }

    public PagedList(List<T> pagedList, MetaData metaData)
    {
        this.List = pagedList;
        MetaData = metaData;
    }
}