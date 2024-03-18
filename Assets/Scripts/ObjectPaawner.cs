using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Inspectorから割り当てる

    void Start()
    {
        // ランダムなX座標とY座標を生成
        float randomX = Random.Range(0f, 100f);
        float randomY = Random.Range(0f, 100f);

        // 生成する位置を設定
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        // オブジェクトを生成
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }
}
