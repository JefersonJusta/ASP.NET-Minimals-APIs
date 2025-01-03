using MinimalApi.Dominio.Enuns;

namespace MinimalApi.Dominio.ModelViews;

public record AdministradorModel
{
    public int Id {get;set;} = default!;
    public string Email {get;set;} = default!;
    public String Perfil {get;set;} = default!;
}