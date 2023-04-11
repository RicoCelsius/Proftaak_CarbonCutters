using CarbonCuttersCore;
using CarbonCuttersCore.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Numerics;

namespace CarbonCuttersDAL;

public class UserCollectionDal : IUserCollection
{
    private string ConnectionString = @"Server=tcp:carboncutters.database.windows.net,1433;Initial Catalog=carboncutters;Persist Security Info=False;User ID=carboncutters;Password=G8!bjJGRhXwY!Yz7YDKn;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public List<User> users { get; set; }


    public UserCollectionDal()
    {
        users = new List<User>();
        UpdateUsers();
    }

    private void UpdateUsers()
    {
        List<User> temp = new List<User>();
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = new SqlCommand(
            "select [full_name],[picture],[address],[score],[authzero_user_id] from [dbo].[application_user]",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                string name = "not set";
                if (!reader.IsDBNull(0))
                    name = reader.GetString(0);

                string picture = "not set";
                if (!reader.IsDBNull(1))
                    picture = reader.GetString(1);

                string adress = "not set";
                if(!reader.IsDBNull(2))
                    adress = reader.GetString(2);

                int score = 0;
                if (!reader.IsDBNull(3))
                    score = reader.GetInt32(3);

                string id = "not set";
                if (!reader.IsDBNull(4))
                    id = reader.GetString(4);

                User user = new(id, name, picture, adress, new Score(score), new TripCollection(), new VehicleCollection());
                temp.Add(user);
            }

        connection.Close();
        users = temp;
    }

    public List<User> GetSortedUsersByScore()
    {
        List<User> sortedList = users.OrderBy(x => -x.score.points).ToList();
        return sortedList;
    }

    public void add(User user)
    {
        throw new NotImplementedException();
    }

    public void add(List<User> users)
    {
        throw new NotImplementedException();
    }

    public void remove(User user)
    {
        throw new NotImplementedException();
    }

    public void remove(List<User> users)
    {
        throw new NotImplementedException();
    }
}