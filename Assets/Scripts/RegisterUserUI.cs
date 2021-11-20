using UnityEngine;
using UnityEngine.UI;
public class RegisterUserUI : MonoBehaviour
{
    public Text welcomeText;
    public InputField loginField;
    public InputField passwordField;
    public Button enterButton;
    public Button registerButton;
    public Button registerEnterButton;
    public InputField registerLoginField;
    public InputField registerPasswordField;

    // Start is called before the first frame update
    void Start()
    {
        registerButton.onClick.AddListener(() =>
        {
            enterButton.gameObject.SetActive(false);
            welcomeText.text = "Create new user";
            welcomeText.fontSize = 80;
            loginField.gameObject.SetActive(false);
            passwordField.gameObject.SetActive(false);
            registerButton.gameObject.SetActive(false);
            registerEnterButton.gameObject.SetActive(true);
            registerLoginField.gameObject.SetActive(true);
            registerPasswordField.gameObject.SetActive(true);
        });
        }

   
}
