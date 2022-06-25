using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Registeration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public InputField fullnameField;
    public InputField addressField;
    public InputField phoneField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username",nameField.text);
        form.AddField("fullname", fullnameField.text);
        form.AddField("address", addressField.text);
        form.AddField("phone", phoneField.text);
        form.AddField("password", passwordField.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form))
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
                Debug.Log("User created succesfully!");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Hijab Materials");
            }
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >=5 && passwordField.text.Length >=6);
    }
}
