﻿namespace CarbonCuttersCore.Interface;

public interface IUserCollection
{
    List<User> users { get; }

    void add(User user);
    void add(List<User> users);
    void remove(User user);
    void remove(List<User> users);

    List<User> getAllUsers();


    User get(string id);
}
