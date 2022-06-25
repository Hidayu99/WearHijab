using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginUser());
    }

    IEnumerator LoginUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);


    using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form))
    {
    yield return www.SendWebRequest();
    // isNetworkError always comes true, else is to check for logs
    if (www.isNetworkError || www.isHttpError)
    {
        Debug.Log(www.error);

    }
    else
    {
                Debug.Log(www.downloadHandler.text);
            }
    if (www.downloadHandler.text == "0")
         {
         //DBManager.username = nameField.text;
        
         UnityEngine.SceneManagement.SceneManager.LoadScene("Hijab Materials");
        }
    else
            {
                Debug.Log(www.downloadHandler.text);
            }
    }
}


    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 5 && passwordField.text.Length >= 6);
    }

}
