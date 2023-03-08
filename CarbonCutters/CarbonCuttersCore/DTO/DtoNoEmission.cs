namespace CarbonCuttersCore.DTO;

internal class DtoNoEmission : DtoVehicle
{
    public noEmission type { get; private set; }

    public DtoNoEmission(int emission, noEmission type) : base(emission)
    {
        this.type = type;
    }

    public DtoNoEmission(NoEmission noEmission) : base(noEmission.emission)
    {
        this.type = noEmission.type;
    }
}
