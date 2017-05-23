using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using System.Collections.Generic;

public class LogIn : MonoBehaviour
{
    public Text username;
    public Text password;
    public GameObject errorText;

    public void LogInUser()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
            return;

        StartCoroutine(CheckUserData());
    }

    IEnumerator CheckUserData()
    {
        string URL = "http://qrquest.com.ua/api/mobile/login?login=" + username.text + "&password=" + password.text;

        WWW www = new WWW(URL);
        while (!www.isDone)
        {
            Debug.Log("while");
            yield return null;
        }

        if (!string.IsNullOrEmpty(www.error))
        {
            //Response res = new Response();
            //res.data = new Data();
            //res.data.errors = new string[2] { "Mike", "Jihn" };
            //string str = JsonUtility.ToJson(res);

            //Response response = JsonUtility.FromJson<Response>(www.text);
            Debug.Log(www.error);
            Debug.Log(www.text);
            errorText.SetActive(true);
            yield break;
        }

        Debug.Log("ready");
        //XDocument xml = XDocument.Parse(www.text);
        //IEnumerable<XElement> elements = xml.Elements("team");

        //foreach (XElement item in elements)
        //{
        //    item.GetDefaultNamespace();
        //}
        LoadingScreenManager.LoadScene(1);

        yield return null;
    }
}

//public class Response
//{
//    public Data data;
//}

//public class Data
//{
//    public string[] errors;
//}
