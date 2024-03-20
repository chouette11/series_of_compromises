using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class weaponchanger : MonoBehaviour
{


  public GameObject weapon; // 現在持っているオブジェクト
  public GameObject weapon1;
  public GameObject weapon2; // 入れ替える新しいオブジェクトのプレハブ
  private WebSocketClient webSocketClient;


  private GameObject currentObject;

  private int weaponeNumber = 1;
  // オブジェクトを入れ替えるメソッド
  void Start()
  {
    webSocketClient = GameObject.Find("WebsocketFloor").GetComponent<WebSocketClient>();
  }
  public void SwapObject()
  {
    // if (currentObject != null)
    // {
    //     Destroy(currentObject); // 現在のオブジェクトを削除
    // }

    // 新しいオブジェクトを手の位置にインスタンス化

  }
  void Update()
  {
    if (webSocketClient.weaponNumber != 4 && weaponeNumber != webSocketClient.weaponNumber)
    {
      if (webSocketClient.weaponNumber == 0)
      {
        Destroy(currentObject);
        currentObject = Instantiate(weapon, transform.position, transform.rotation, transform);
        weaponeNumber = webSocketClient.weaponNumber;

        webSocketClient.weaponNumber = 4;

      }
      else if (webSocketClient.weaponNumber == 1)
      {
        Destroy(currentObject);
        currentObject = Instantiate(weapon1, transform.position, transform.rotation, transform);
        weaponeNumber = webSocketClient.weaponNumber;

        webSocketClient.weaponNumber = 4;
      }
      else if (webSocketClient.weaponNumber == 2)
      {
        Destroy(currentObject);
        currentObject = Instantiate(weapon2, transform.position, transform.rotation, transform);
        weaponeNumber = webSocketClient.weaponNumber;

        webSocketClient.weaponNumber = 4;
      }

    }

  }


}
