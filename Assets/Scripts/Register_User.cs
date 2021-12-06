using UnityEngine;
using UnityEngine.UI;

public class Register_User : MonoBehaviour
{
    public InputField registerUserInput;
    public InputField registerPassInput;
    public Button enterButton;

    void Start()
    {
        enterButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.instance.loadData.Register(registerUserInput.text, registerPassInput.text));
        });


    }
}