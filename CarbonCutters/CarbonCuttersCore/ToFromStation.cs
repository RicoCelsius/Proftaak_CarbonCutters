using CarbonCuttersCore.DTO;

namespace CarbonCuttersCore
{

    public class ToFromStation : Vehicle
    {
        public toFromStation type { get; private set; }

        public ToFromStation(int emission, toFromStation type) : base(emission)
        {
            this.type = type;
        }

        public ToFromStation(DtoToFromStation Dto) : base(Dto.emission)
        {
            this.type = Dto.type;
        }
    }
}