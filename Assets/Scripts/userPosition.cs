using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private float span = 0; 
    private WebSocketClient webSocketClient;

    private void Start()
    {
        Vector3 headPosition = transform.position;
        webSocketClient = GameObject.Find("WebsocketFloor").GetComponent<WebSocketClient>();
        SendPositionData sendPositionData = new SendPositionData(headPosition.x / 16, headPosition.y, headPosition.z / 20, "hero", "hero", true, "unity");
    }


    void Update()
    {
        span += Time.deltaTime;
        if (span >= 1f)
        {
            Vector3 headPosition = transform.position;
            Debug.Log("position");
            Debug.Log(headPosition.x);
            Debug.Log(headPosition.z);
            SendPositionData sendPositionData = new SendPositionData(headPosition.x / 16, headPosition.y, headPosition.z / 20, "hero", "hero", true, "unity");
            webSocketClient.SendMessageToServer(sendPositionData);
            Debug.Log("Player Position: " + headPosition);
            span = 0;
        }
    }
}
