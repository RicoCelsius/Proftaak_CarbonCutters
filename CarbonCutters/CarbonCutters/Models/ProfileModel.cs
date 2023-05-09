using CarbonCuttersCore;

namespace CarbonCuttersView.Models
{
    public class ProfileModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }
        public List <ScoreData> ScoreDataList { get; set; }
        public int Score { get; set; }


        public ProfileModel()
        {

        }
    }


}
