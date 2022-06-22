namespace ChillExe.Services
{
    public interface IService<T>
    {
        public T Get();

        public bool Save(T tElement);
    }
}
