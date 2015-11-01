using UnityEngine;


public class EnemyAI : MonoBehaviour {

    private enum Distance
    {
        SHORT_DISTANCE,
        MIDDLE_DISTANCE,
        LONG_DISTANCE
    }

    private void ShortDistanceAction()
    {
        max_limit_distance_ = short_distance_ * short_distance_;
        min_limit_distance_ = 2;
        Move();
        Debug.Log("近距離");
    }

    private void MiddleDistanceAction()
    {
        max_limit_distance_ = middle_distance_ * middle_distance_;
        min_limit_distance_ = short_distance_ * short_distance_;
        Move();
        Debug.Log("中距離");
    }

    private void LongDistanceAction()
    {
        max_limit_distance_ = long_distance_ * long_distance_;
        min_limit_distance_ = middle_distance_ * middle_distance_;
        Move();
        Debug.Log("遠距離");
    }

    //距離の決定
    [SerializeField]
    private Distance distance_decision_ = Distance.SHORT_DISTANCE;
   
    //動く速さ
    [SerializeField]
    private float move_speed_ = 3.0f;
    
    //制限距離、最大最小
    private float max_limit_distance_;
    private float min_limit_distance_;

    [SerializeField]
    private float short_distance_ = 10.0f;

    [SerializeField]
    private float middle_distance_ = 50.0f;

    [SerializeField]
    private float long_distance_ = 100.0f;

    [SerializeField]
    private string target_tag_name_ = "Player";

    //移動する
    private void Move()
    {
        Vector3 target_of_direction = DistanceMeasurement();

        float distance_of_the_target = target_of_direction.sqrMagnitude;

        target_of_direction = target_of_direction.normalized;

        target_of_direction.y = 0f;

        if (distance_of_the_target >= max_limit_distance_)
        {
            PackDistance(target_of_direction);
        }
        else if (distance_of_the_target < min_limit_distance_)
        {
           SeparateDistance(target_of_direction);
        }
        else { KeepDistance(target_of_direction); }

        //プレイヤーの方向を向く
        transform.rotation = Quaternion.LookRotation(target_of_direction);
    }

    //距離を測る
    private Vector3 DistanceMeasurement()
    {
        Transform target = GameObject.FindGameObjectWithTag(target_tag_name_).transform;
        //ターゲットの位置
        Vector3 target_position = target.position;
        //方向と距離を求める
        Vector3 target_of_direction = target_position - transform.position;

        return target_of_direction;
    }
  
    //相手との距離を詰める
    private void PackDistance(Vector3 target_of_direction)
    {
        //プレイヤーに近づく
        transform.position += (target_of_direction * move_speed_ * Time.deltaTime);
    }

    //相手との距離を保つ
    private void KeepDistance(Vector3 target_of_direction)
    {
        //プレイヤーの方向を向く
        transform.rotation = Quaternion.LookRotation(target_of_direction);
    }

    //相手との距離を離す
    private void SeparateDistance(Vector3 target_of_direction)
    {
        //プレイヤーから遠ざかる
        transform.position -= (target_of_direction * move_speed_ * Time.deltaTime);
    }

    //相手との距離をブーストで詰める
    private void UseBoostPackDistance(Vector3 target_of_direction)
    {
        /*ブースト処理*/

        //プレイヤーに近づく
        transform.position += (target_of_direction * move_speed_ * Time.deltaTime);
    }

    //相手との距離をブーストで離す
    private void UseBoostSeparateDistance(Vector3 target_of_direction)
    {
        /*ブースト処理*/

        //プレイヤーから遠ざかる
        transform.position -= (target_of_direction * move_speed_ * Time.deltaTime);
    }

    //ジャンプして距離を離す
    private void UseJumpSeparateDistance(Vector3 target_of_direction)
    {
        /*ジャンプ処理*/

        //プレイヤーから遠ざかる
        transform.position -= (target_of_direction * move_speed_ * Time.deltaTime);
    }

    //ジャンプして攻撃をかわす
    private void UseJumpAvoid()
    {

    }


    //相手のロックオン圏外にでる
    private void MoveRockOnOutRange()
    {

    }
    
    //近距離武器を使用
    private void UseShortWeapons()
    {

    }
    //中距離武器を使用
    private void UseMiddleWeapons()
    {

    }
    //遠距離武器を使用
    private void UseLongWeapons()
    {

    }

    //僚機とともに行動する
    private void MoveWithMenber()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        switch (distance_decision_)
        {
            case Distance.SHORT_DISTANCE:
                ShortDistanceAction();
                break;
            case Distance.MIDDLE_DISTANCE:
                MiddleDistanceAction();
                break;
            case Distance.LONG_DISTANCE:
                LongDistanceAction();
                break;
        }

    }
}
