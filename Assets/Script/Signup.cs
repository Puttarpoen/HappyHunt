using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Signup : MonoBehaviour
{
    [Header("Register")]
    public InputField rUsername;
    public InputField rEmail;
    public InputField rPassword;
    public InputField rPasswordconfirm;

    [Header("Login")]
    public InputField lEmail;
    public InputField lPassword;

    public void Login()
    {
        if (lEmail.text != "" && lPassword.text != "" && GameService.instance)
        {
            GameService.instance.Login(lEmail.text, lPassword.text);
        }
        else
        {
            Debug.Log("Req");
        }
    }


    public void Register()
    {
        if (rPassword.text != rPasswordconfirm.text)
        {
            Debug.Log("password not same");
            return;
        }
        if (rEmail.text != "" && rUsername.text != "" && rPassword.text != "" && GameService.instance)
        {
            GameService.instance.Register(rUsername.text, rEmail.text, rPassword
.text);
        }
        else
        {
            Debug.Log("Req");
        }
    }


    public void CheckCharacter(InputField input)
    {
        input.text = Regex.Replace(input.text, @"[^a-zA-Z0-9 ]", "");
    }
    public void CheckEmail(InputField input)
    {
        input.text = Regex.Replace(input.text, @"[^a-zA-Z0-9@. ]", "");
    }
}
