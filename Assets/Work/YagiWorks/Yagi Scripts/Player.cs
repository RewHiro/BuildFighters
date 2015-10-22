using UnityEngine;
using System.Collections;




/*
 *	プレーヤークラス
 *	Maruchu
 *
 *	キャラクターの移動、メカニム(モーション)の制御など
 */
public class Player : MonoBehaviour
{



    public GameObject playerObject = null;      //動かす対象のモデル
    public GameObject bulletObject = null;      //弾プレハブ

    public Transform bulletStartPosition = null;        //弾の発射位置を取得するボーン



    private static readonly float MOVE_Z_FRONT = 10.0f; //前進の速度
    private static readonly float MOVE_Z_BACK = -3.0f;  //後退の速度

    private static readonly float ROTATION_Y_KEY = 360.0f;  //回転の速度(キーボード)
    private static readonly float ROTATION_Y_MOUSE = 720.0f;    //回転の速度(マウス)

    private float m_rotationY = 0.0f;       //プレーヤーの回転角度

    private bool m_mouseLockFlag = true;        //マウスを固定する機能




    /*
	 *	毎フレーム呼び出される関数
	 */
    private void Update()
    {

        //マウスロック処理
        CheckMouseLock();

        //移動処理
        CheckMove();
    }


    /*
	 *	マウスロック処理のチェック
	 */
    private void CheckMouseLock()
    {

        //Escキーをおした時の動作
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //フラグをひっくり返す
            m_mouseLockFlag = !m_mouseLockFlag;
        }

        //マウスロックされてる？
        if (m_mouseLockFlag)
        {
            //ロックしていたらロック解除
            Screen.lockCursor = true;
            Cursor.visible = false;
        }
        else
        {
            //ロック解除されていたらロック
            Screen.lockCursor = false;
            Cursor.visible = true;
        }
    }
    /*
 *	移動処理のチェック
 */
    private void CheckMove()
    {

        //回転
        {
            //このフレームで動く回転量
            float addRotationY = 0.0f;

            //キー操作による回転
            if (Input.GetKey(KeyCode.Q))
            {
                addRotationY = -ROTATION_Y_KEY;
            }
            else
            if (Input.GetKey(KeyCode.E))
            {
                addRotationY = ROTATION_Y_KEY;
            }

            //マウスの移動量による回転
            if (m_mouseLockFlag)
            {
                //移動量を取得して角度に渡す
                addRotationY += (Input.GetAxis("Mouse X") * ROTATION_Y_MOUSE);
            }

            //現在の角度に加算する
            m_rotationY += (addRotationY * Time.deltaTime);     //移動量、回転量には Time.deltaTime を掛けて実行環境(フレーム数の差)による違いが出ないようにする

            //オイラー角で入れる
            transform.rotation = Quaternion.Euler(0, m_rotationY, 0);       //Y軸回転でキャラの向きを横に動かせる
        }

        //移動
        Vector3 addPosition = Vector3.zero;     //移動量(z の値はメカニムにも渡す)
        {
            /*
				Vector3.zero は new Vector3( 0f, 0f, 0f) と同じです
				ほかにもいろいろあるので下記のページを参照してほしい
				http://docs.unity3d.com/ScriptReference/Vector3.html
			 */

            //キー操作から移動する量を取得する
            Vector3 vecInput = new Vector3(0f, 0, Input.GetAxisRaw("Vertical"));        //Zに前後の入力を入れます(Wキー、Sキー、ゲームパッドの入力など)

            //Z に何か値が入っているか確認する
            if (vecInput.z > 0)
            {
                //前進
                addPosition.z = MOVE_Z_FRONT;
            }
            else
            if (vecInput.z < 0)
            {
                //後退
                addPosition.z = MOVE_Z_BACK;
            }

            //移動量をTransformに渡して移動させる
            transform.position += ((transform.rotation * addPosition) * Time.deltaTime);
            /*
				Vector3にtransform.rotationを掛けると、その方向へ曲げてくれる
				この時、Vector3 は Z+ の方向を正面として考える
			 */
        }

        //射撃
        bool shootFlag;
        {
            //射撃ボタン(クリック)押しているか確認する
            if (Input.GetButtonDown("Fire1"))
            {
                //撃つ処理
                shootFlag = true;

                //弾を発車する位置のボーンはあるか確認する
                if (null != bulletStartPosition)
                {
                    //弾を生成する位置を指定する
                    Vector3 vecBulletPos = bulletStartPosition.position;
                    //進行方向に少し前へ
                    vecBulletPos += (transform.rotation * Vector3.forward);
                    //Yは高さを適当に上げる
                    vecBulletPos.y = 1.0f;

                    //弾を生成する
                    Instantiate(bulletObject, vecBulletPos, transform.rotation);
                }
            }
            else
            {
                //撃たない処理
                shootFlag = false;
            }
        }


        //メカニム(モーション)
        {
            //アニメーターを取得
            Animator animator = playerObject.GetComponent<Animator>();

            //Animatorで設定した値を渡す
            animator.SetFloat("SpeedZ", addPosition.z); //Z(前後の移動量)
            animator.SetBool("Shoot", shootFlag);       //射撃フラグ
        }
    }




}
