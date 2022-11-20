public class PoolableSaveable : BaseSaveable
{
    private string id = string.Empty;

    public override string Id => id;

    public void SetId(string id) => this.id = id;
}
