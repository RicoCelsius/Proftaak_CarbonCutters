using CarbonCuttersCore;

namespace CarbonCuttersView.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }
        public int Score { get; set; }
        public string user_id { get; set; }
        public User user { get; set; }

        public ProfileModel()
        {

        }
    }
}
