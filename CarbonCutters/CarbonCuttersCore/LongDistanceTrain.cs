using CarbonCuttersCore.DTO;

namespace CarbonCuttersCore
{

    public class LongDistanceTrain : Vehicle
    {
        public longDistanceTrain type { get; private set; }

        public LongDistanceTrain(int emission, longDistanceTrain type) : base(emission)
        {
            this.type = type;
        }

        public LongDistanceTrain(DtoLongDistanceTrain Dto) : base(Dto.emission)
        {
            this.type = Dto.type;
        }
    }
}