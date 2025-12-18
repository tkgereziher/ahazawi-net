namespace Momona.Infrastructure.Files;

public class FileStorageService
{
    public Task<string> SaveFileAsync(Stream fileStream, string fileName)
    {
        // Implementation stub
        return Task.FromResult("path/to/file");
    }
}
