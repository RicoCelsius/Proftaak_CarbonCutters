using CarbonCuttersCore.DTO;

namespace CarbonCuttersCore;

public class NoEmission : Vehicle
{
    public noEmission type { get; private set; }

    public NoEmission(int emission, noEmission type) : base(emission)
    {
        this.type = type;
    }

    public NoEmission(DtoNoEmission Dto) : base(Dto.emission)
    {
        this.type = Dto.type;
    }
}
