using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCHASE : PlayerFSMState
{
    public override void BeginState()
    {
        base.BeginState();
        manager.anim.CrossFade("KK_Run");
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameLib.JJMove(manager.cc, manager.target, manager.stat);

        Vector3 diff = manager.marker.position - transform.position;
        diff.y = 0.0f;
        if (diff.magnitude < manager.stat.attackRange)
        {
            manager.SetState(PlayerState.ATTACK);
        }
    }
}
