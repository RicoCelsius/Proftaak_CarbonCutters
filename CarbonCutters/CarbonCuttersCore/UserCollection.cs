using CarbonCuttersCore.Interface;

namespace CarbonCuttersCore;

public class UserCollection : IUserCollection
{
    private IUserCollection DBusers { get; set; }
    public List<User> users { get; private set; }

    public UserCollection(IUserCollection dBusers)
    {
        DBusers = dBusers;
        users = dBusers.users;
    }

    public void add(User user)
    {
        users.Add(user);
        DBusers.add(user);
    }

    public void add(List<User> users)
    {
        this.users.AddRange(users);
        DBusers.add(users);
    }

    public void remove(User user)
    {
        users.Remove(user);
        DBusers.remove(user);
    }

    public void remove(List<User> users)
    {
        while (users.Count > 0)
            this.users.Remove(users[0]);
        DBusers.remove(users);
    }

    public List<User> GetSortedUsersByScore()
    {
        List<User> sortedList = users.OrderBy(x => -x.score.points).ToList();
        return sortedList;
    }

    public User get(string id)
    {
        return DBusers.get(id);
    }
}
