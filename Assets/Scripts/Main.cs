using UnityEngine;
using UnityEngine.UI;
public class Main : MonoBehaviour
{
    public static Main instance;
    public static Main test;
    public LoadData loadData;
    public UserInfo userInfo;
    public Login login;
    public GameObject box;
    public MessageBox msgBox;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        loadData = GetComponent<LoadData>();
        userInfo = GetComponent<UserInfo>();
    }

}
