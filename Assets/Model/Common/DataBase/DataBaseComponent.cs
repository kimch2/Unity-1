using MongoDB.Driver;
using System;
using UnityEngine;

public class UserInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString()
    {
        return $"Id:{Id}  Name:{Name}";
     }
}
namespace ETModel
{
    public class DataBaseComponent : MonoBehaviour
    {
        async void Start()
        {
            try
            {
                 var client = new MongoClient("mongodb://122.51.160.111:27017");
 
                var database = client.GetDatabase("userdata");
                var collection = database.GetCollection<UserInfo>("userinfo");
                UserInfo user = new UserInfo() { Id=0,Name="新呗呗"};
                 var data =  await collection.Find(x => x.Id == 0).FirstAsync();
                UnityEngine.Debug.LogError(data.ToString());
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.StackTrace);
            }
        }

 
       
    }
}