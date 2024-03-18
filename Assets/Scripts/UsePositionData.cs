using UnityEngine;


public class UsePositionData : MonoBehaviour
{
    public WebSocketClient webSocketClient;

    void Update()
    {
        //Debug.Log(webSocketClient.LatestPosition);
        if (webSocketClient.LatestPosition != null)
        {
            // 例えば、受け取った位置データを何かのGameObjectの位置として使用する
            Vector3 newPosition = new Vector3(webSocketClient.LatestPosition.x, webSocketClient.LatestPosition.y, webSocketClient.LatestPosition.z);
            transform.position = newPosition;
        }
    }
}
