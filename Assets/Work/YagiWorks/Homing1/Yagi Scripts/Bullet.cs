using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public float rotateSpeed = 10f;
    public float speed = 1.0f;

    void Update()
    {
        GameObject player = GameObject.Find("Player");
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        var moveDirectionYzero = -moveDirection;
        moveDirectionYzero.y = 0;

        //ベクトルの２乗の長さを返しそれが0.001以上なら方向を変える（０に近い数字なら方向を変えない） 
        if (moveDirectionYzero.sqrMagnitude > 0.001)
        {

            //２点の角度をなだらかに繋げながら回転していく処理（stepがその変化するスピード） 
            float rotate_step = rotateSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, moveDirectionYzero, rotate_step, 0f);

            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}