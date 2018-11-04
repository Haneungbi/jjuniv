using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class GameLib
{
    public static void JJMove(CharacterController cc, Transform target, CharacterStat stat)
    {
        Transform transform = cc.transform;

        //B-A는 A에서 B로 향하는 벡터.

        Vector3 dir = target.position - transform.position;
        dir.y = 0.0f;
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards
                (
                transform.rotation,
                Quaternion.LookRotation(dir),
                stat.turnSpeed * Time.deltaTime
                );
        }


        //transform.position = Vector3.MoveTowards(
        //    transform.position,
        //    manager.marker.position,
        //    manager.stat.moveSpeed * Time.deltaTime);

        Vector3 deltaMove = Vector3.MoveTowards(
            transform.position,
            target.position,
            stat.moveSpeed * Time.deltaTime) - transform.position;

        deltaMove.y = -stat.fallSpeed * Time.deltaTime;

        cc.Move(deltaMove);

        
    }
}
