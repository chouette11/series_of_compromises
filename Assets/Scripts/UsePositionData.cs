using UnityEngine;


public class UsePositionData : MonoBehaviour
{
    public GameObject Enemyobject;
    public WebSocketClient webSocketClient;
    public GameObject tower;

    void Update()
    {
        //Debug.Log(webSocketClient.LatestPosition);
        if (webSocketClient.LatestPosition != null)
        {

            // 例えば、受け取った位置データを何かのGameObjectの位置として使用する

            string id = webSocketClient.LatestPosition.id;
            Vector3 newPosition = new Vector3(webSocketClient.LatestPosition.x * 16, webSocketClient.LatestPosition.y, webSocketClient.LatestPosition.z * 20);
            GameObject newGhost = Instantiate(Enemyobject, newPosition, tower.transform.rotation);
            newGhost.GetComponent<AssignedId>().id = id;
            //transform.position = newPosition;
            webSocketClient.LatestPosition = null;

        }
    }
}
