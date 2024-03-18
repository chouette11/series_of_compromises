using UnityEngine;
using WebSocketSharp;

public class WebSocketClient : MonoBehaviour
{
    private WebSocket ws;

    // 受信した最新の位置データ
    public PositionData LatestPosition { get; private set; }

    void Start()
    {
        // WebSocketサーバーのURLを指定して接続
        ws = new WebSocket("ws://192.168.128.176:8080");
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
           
            LatestPosition = JsonUtility.FromJson<PositionData>(e.Data);
            Debug.Log(LatestPosition.y.ToString());
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
    public void SendMessageToServer(string message)
    {
        if (ws != null && ws.IsAlive)
        {
            ws.Send(message);
        }
    }
}
