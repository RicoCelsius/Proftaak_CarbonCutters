using CarbonCuttersCore.Interface;

namespace CarbonCuttersCore;

public class UserCollection : IUserCollection
{
    public List<User> users { get; private set; }

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
}
