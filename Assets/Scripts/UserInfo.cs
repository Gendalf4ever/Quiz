using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public string userID { get; private set; }
    string nickName;
    string userPassword;
    public string userLevel { get;  set; }
    string Coins;
   public string question { get; private set; }

    public void SetCredentials(string username, string userpassword)
    {
        nickName = username;
        userPassword = userpassword;
    }
    public void SetID(string id)
    {
        userID = id;
    }
    public void SetLevel(string level)
    {
        userLevel = level;
    }
    public void setQuestion(string quest)
    {
        question = quest;
    }
}
