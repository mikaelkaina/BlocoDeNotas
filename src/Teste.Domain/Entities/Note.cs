using Teste.Domain.Exceptions;

namespace Teste.Domain.Entities;

public class Note
{
    public Guid Id { get; private set; }
    public string UserId { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string Content { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    protected Note() { } // EF

    public Note(string userId, string title, string content)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        SetTitle(title);
        SetContent(content);
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string title, string content)
    {
        SetTitle(title);
        SetContent(content);
        UpdatedAt = DateTime.UtcNow;
    }

    private void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Título é obrigatório");

        Title = title.Trim();
    }

    private void SetContent(string content)
    {
        Content = content?.Trim() ?? string.Empty;
    }
}
