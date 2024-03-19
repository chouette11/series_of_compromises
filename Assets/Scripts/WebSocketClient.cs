using UnityEngine;
using WebSocketSharp;

public class WebSocketClient : MonoBehaviour
{
    private WebSocket ws;

    // 受信した最新の位置データ
    public PositionData LatestPosition { get; set; }

    void Start()
    {
        // WebSocketサーバーのURLを指定して接続
        ws = new WebSocket("ws://35.77.220.248:8080");
        Debug.Log("open!");
        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("WebSocket Open");
        };

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("WebSocket Message Type: "  + ", Data: " + e.Data);
            Debug.Log(e.Data.GetType().ToString());
            Debug.Log(e.Data);

            if (!e.Data.Contains("サーバー")) {
                if (e.Data.Contains("flutter"))
                {
                    LatestPosition = JsonUtility.FromJson<PositionData>(e.Data);
                    Debug.Log(LatestPosition.y.ToString());
                }
            }
        };

        ws.OnError += (sender, e) =>
        {
            Debug.Log("WebSocket Error Message: " + e.Message);
        };

        ws.OnClose += (sender, e) =>
        {
            Debug.Log("WebSocket Close");
        };
        ws.Connect();
    }

    void OnDestroy()
    {
        if (ws != null)
        {
            ws.Close();
            ws = null;
        }
    }

    // サーバーにメッセージを送信するメソッド
    public void SendMessageToServer(SendPositionData data)
    {
            string json = JsonUtility.ToJson(data);
            ws.Send(json);
        
    }
}
