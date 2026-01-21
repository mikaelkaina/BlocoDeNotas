using Teste.Domain.Entities;
using Teste.Domain.Exceptions;

namespace Domain.Tests;

public class NotesTests
{
    [Fact]
    public void Constructor_DeveCriarNotaComDadosValidos()
    {
        // Arrange
        var userId = "user-123";
        var title = "Minha nota";
        var content = "Conteúdo";

        // Act
        var note = new Note(userId, title, content);

        // Assert
        Assert.NotEqual(Guid.Empty, note.Id);
        Assert.Equal(userId, note.UserId);
        Assert.Equal(title, note.Title);
        Assert.Equal(content, note.Content);
        Assert.True(note.CreatedAt <= DateTime.UtcNow);
        Assert.Null(note.UpdatedAt);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_DeveLancarExcecao_QuandoTituloInvalido(string title)
    {
        // Arrange
        var userId = "user-123";
        var content = "conteudo";

        // Act
        var exception = Assert.Throws<DomainException>(() =>
            new Note(userId, title!, content)
        );

        // Assert
        Assert.Equal("Título é obrigatório", exception.Message);
    }

    [Fact]
    public void Constructor_DeveAplicarTrimNoTitulo()
    {
        // Arrange
        var note = new Note("user", "   titulo   ", "conteudo");

        // Assert
        Assert.Equal("titulo", note.Title);
    }

    [Fact]
    public void Constructor_DeveAplicarTrimNoConteudo()
    {
        // Arrange
        var note = new Note("user", "titulo", "   conteudo   ");

        // Assert
        Assert.Equal("conteudo", note.Content);
    }

    [Fact]
    public void Constructor_DevePermitirConteudoNulo()
    {
        // Act
        var note = new Note("user", "titulo", null);

        // Assert
        Assert.Equal(string.Empty, note.Content);
    }

    [Fact]
    public void Update_DeveAtualizarTituloEConteudo()
    {
        // Arrange
        var note = new Note("user", "titulo", "conteudo");

        // Act
        note.Update("novo titulo", "novo conteudo");

        // Assert
        Assert.Equal("novo titulo", note.Title);
        Assert.Equal("novo conteudo", note.Content);
        Assert.NotNull(note.UpdatedAt);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Update_DeveLancarExcecao_QuandoTituloInvalido(string title)
    {
        // Arrange
        var note = new Note("user", "titulo", "conteudo");

        // Act
        var exception = Assert.Throws<DomainException>(() =>
            note.Update(title!, "novo conteudo")
        );

        // Assert
        Assert.Equal("Título é obrigatório", exception.Message);
    }

    [Fact]
    public void Update_DeveAtualizarData()
    {
        // Arrange
        var note = new Note("user", "titulo", "conteudo");
        var createdAt = note.CreatedAt;

        // Act
        note.Update("novo", "novo");

        // Assert
        Assert.True(note.UpdatedAt > createdAt);
    }
}
