using CarbonCuttersView.Models;

namespace CarbonCuttersView.Repository
{
    public class ProfileRepository
    {
        public ProfileModel getProfileById(int id)
        {
            return dataSource().Where(x => x.Id == id.ToString()).FirstOrDefault();
        }

        private List<ProfileModel> dataSource()
        {
            return new List<ProfileModel>()
            {
                new ProfileModel() { Id = 1.ToString(), Name = "" } }; 
        }
    }
}
