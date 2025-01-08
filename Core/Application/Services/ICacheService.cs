namespace Application.Services;

public interface ICacheService
{
    T GetAll<T>(string key);
    void Remove(string key);
    void Set<T>(string key, T value, TimeSpan expiration);
}