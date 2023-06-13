using CarbonCuttersCore.DTO;

namespace CarbonCuttersCore
{

    public class Airplane : Vehicle
    {
        public airplane type { get; private set; }

        public Airplane(int emission, airplane type) : base(emission)
        {
            this.type = type;
        }

        public Airplane(DtoAirplane Dto) : base(Dto.emission)
        {
            this.type = Dto.type;
        }
    }
}