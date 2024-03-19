using UnityEngine;


public class UsePositionData : MonoBehaviour
{
    public GameObject Enemyobject;
    public WebSocketClient webSocketClient;
    private GameObject enemy;

    void Update()
    {
        //Debug.Log(webSocketClient.LatestPosition);
        if (webSocketClient.LatestPosition != null)
        {

            // 例えば、受け取った位置データを何かのGameObjectの位置として使用する
            Vector3 newPosition = new Vector3(webSocketClient.LatestPosition.x * 16, webSocketClient.LatestPosition.y, 20 - webSocketClient.LatestPosition.z * 20);
            Instantiate(Enemyobject,newPosition, enemy.transform.rotation);
            //transform.position = newPosition;
            webSocketClient.LatestPosition = null;

        }
    }
}
