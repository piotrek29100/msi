namespace MSI.Tree
{
    public enum Branch
    {
        Yes,No
    }
    public interface IMsiNode
    {
        Branch CurrentBranch { get; set; }
        MsiState State { get; }
        IMsiNode Parent { get; set; }
        string Message { get; }
        float Score { get;}
        IMsiNode[] Decide(float score);
    }
}
