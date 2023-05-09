using CarbonCuttersCore;
using CarbonCuttersCore.Interface;

namespace CarbonCuttersMockData
{
    public class MockUsers : IUserCollection
    {
        private static readonly Random r = new Random();
        private UserGenerator UserGenerator = new();
        public List<User> users { get; private set; }

        public MockUsers(int minUsers, int maxUsers)
        {
            int userAmount = r.Next(minUsers, maxUsers);
            users = new();
            for (int i = 0; i < userAmount; i++)
                users.Add(UserGenerator.next());
        }

        public void add(User user)
        {
            users.Add(user);
        }

        public void add(List<User> users)
        {
            this.users.AddRange(users);
        }

        public void remove(User user)
        {
            users.Remove(user);
        }

        public void remove(List<User> users)
        {
            while (users.Count > 0)
                this.users.Remove(users[0]);
        }

        public User get(string id)
        {
            throw new NotImplementedException();
        }
    }
}