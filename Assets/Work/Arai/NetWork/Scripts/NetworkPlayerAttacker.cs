using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

public class NetworkPlayerAttacker : NetworkBehaviour
{

    void Start()
    {
        if (!isLocalPlayer) return;
        player_controller_ = GetComponent<NetworkPlayerController>();
        var weapon_attacher = GetComponent<NetworkPlayerAttacher>();
        right_weapon_ = weapon_attacher.getRightWeapon;
        left_weapon_ = weapon_attacher.getLeftWeapon;
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        AttackWithWeapon(player_controller_.isInputRightAttack, right_weapon_);
        AttackWithWeapon(player_controller_.isInputLeftAttack, left_weapon_);
    }

    void AttackWithWeapon(bool input, Weapon weapon)
    {
        if (weapon == null) throw new Exception();
        if (input)
        {
            weapon.OnAttack();
        }
        else
        {
            weapon.OnNotAttack();
        }
    }


    NetworkPlayerController player_controller_ = null;
    Weapon right_weapon_ = null;
    Weapon left_weapon_ = null;
    Weapon back_weapon_ = null;
    Weapon melee_weapon_ = null;
}
