namespace Msi.Tree
{
    public interface IMsiNode
    {
        MsiState State { get; }
        IMsiNode Parent { get; set; }
        string Message { get; }
        float Score { get;}
        IMsiNode[] Decide(float score);
    }
}
