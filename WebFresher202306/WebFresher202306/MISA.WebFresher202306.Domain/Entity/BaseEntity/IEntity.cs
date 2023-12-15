namespace WebFresher202306.Domain
{
    public interface IEntity<TKey>
    {
        TKey GetId();
        void SetId(TKey id);
    }
}
