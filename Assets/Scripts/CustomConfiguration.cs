using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomConfiguration : MonoBehaviour
{
    private string context;

    private string userName;

    private string scenario;

    private int score;

    private GameObject scoreTextField;
    void Start()
    {
        LogFieldValue("context", context);
        LogFieldValue("userName", userName);
        LogFieldValue("scenario", scenario);
        var userNameTextField = GameObject.Find("UserNameTextField");
        userNameTextField.GetComponent<UnityEngine.UI.Text>().text = userName;
        scoreTextField = GameObject.Find("ScoreTextField");
        OnScoreChanged();
    }

    void LogFieldValue(string fieldName, string value) {
        if (string.IsNullOrEmpty(value)){
            Debug.Log(string.Format("Property '{0}' was null or empty", fieldName));
        }else{
            Debug.Log(string.Format("Property '{0}' is '{1}'", fieldName,value));
        }
    }

    public void SetContext(string value)
    {
        context = value;
    }

    public void SetUserName(string value)
    {
        userName = value;
    }

    public void SetScenario(string value)
    {
        scenario = value;
    }

    [System.Serializable]
    public class UserScoreUpdateDTO
    {
        public string userName;
        public string scenario;
        public int score;
    }

    string GeneratePutPointPathREST(string context)
    {
        return context + "/api/scores/" + userName;
    }

    public void IncrementScore() {
        score++;
        OnScoreChanged();
    }

    public void DecrementScoreIfLargerThanZero()
    {
        if (score > 0) {
            score--;
            OnScoreChanged();
        }
    }

    private void OnScoreChanged() {
        scoreTextField.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }

    public void SendScoreDataToServer()
    {
        if (string.IsNullOrEmpty(context)){
            Debug.Log("Cannot send data to server. Property 'context' was null or empty");
            return;
        }
        if (string.IsNullOrEmpty(userName))
        {
            Debug.Log("Cannot send data to server. Property 'userName' was null or empty");
            return;
        }
        if (string.IsNullOrEmpty(scenario))
        {
            Debug.Log("Cannot send data to server. Property 'scenario' was null or empty");
            return;
        }
        var targetAddr = GeneratePutPointPathREST(context);
        var dto = new UserScoreUpdateDTO
        {
            userName = userName,
            scenario = scenario,
            score = score
        };
        Debug.Log(string.Format("Starting coroutine to PUT '{0}' with body '{1}'", targetAddr, dto.ToString()));
        StartCoroutine(SendScorePutRequest(dto, targetAddr));
    }

    IEnumerator SendScorePutRequest(UserScoreUpdateDTO dto, string targetAddress)
    {
        byte[] rawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(dto));
        using (var webRequest = UnityEngine.Networking.UnityWebRequest.Put(targetAddress, rawData))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(string.Format("Sending data FAILED: {0}", webRequest.error));
            }
            else
            {
                Debug.Log("Sending data SUCCEEDED");
            }
        }
    }
}
