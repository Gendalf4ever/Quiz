using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main instance;
    public LoadData loadData;
    public UserInfo userInfo;
    public Login login;
    public MessageBox messageBox;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        loadData = GetComponent<LoadData>();
        userInfo = GetComponent<UserInfo>();
        messageBox = GetComponent < MessageBox>();
    }
}
