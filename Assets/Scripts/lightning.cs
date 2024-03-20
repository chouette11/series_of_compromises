using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    // Start is called before the first frame update
        /// </summary>
    [SerializeField]
    private float m_bulletSpeed = 27.0f;

     public GameObject breakEffect;
    void Update()
    {
        //弾を前に進ませる
        transform.position +=
            transform.forward * m_bulletSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy"){
            Destroy(gameObject);
            //弾(引数オブジェクト)を削除
            Destroy(collision.gameObject);
 
            //エフェクトを発生させる
            GenerateEffect();

        }
      
            //敵(スクリプトがアタッチされているオブジェクト自身)を削除
    
 
    }
 
    //エフェクトを生成する
    void GenerateEffect()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = gameObject.transform.position;
    }
}
