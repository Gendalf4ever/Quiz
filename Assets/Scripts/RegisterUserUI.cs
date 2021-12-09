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
    public Button backButton;
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
            backButton.gameObject.SetActive(true);
        });
        backButton.onClick.AddListener(() =>
        {
            enterButton.gameObject.SetActive(true); //!
            welcomeText.text = "Login user";
            welcomeText.fontSize = 80;
            loginField.gameObject.SetActive(true);
            passwordField.gameObject.SetActive(true);
            registerButton.gameObject.SetActive(true);
            registerEnterButton.gameObject.SetActive(false);
            registerLoginField.gameObject.SetActive(false);
            registerPasswordField.gameObject.SetActive(false);
            backButton.gameObject.SetActive(false);
        });
    }

    
}


