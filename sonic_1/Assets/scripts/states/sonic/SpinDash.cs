using UnityEngine;
using System.Collections;
using System;

public class SpinDash : State
{

	public SpinDash() { }
	
	public override  void Enter(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Enter(__owner, __timeDelay);
		Sonic sonic = __owner as Sonic;
		if (sonic != null)
		{
			OTAnimatingSprite animatingSprite = sonic.AnimatingSprite();
			if (animatingSprite != null)
			{
				Debug.Log("SpinDash.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("stand_anim");
			}
		}
	}
	
	public override void Execute(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Execute(__owner, __timeDelay);
	}
	
	public override void Exit(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Exit(__owner, __timeDelay);
		Debug.Log("SpinDash.Exit() : changing state to spin");
		Sonic sonic = __owner as Sonic;
		Spin spin = new Spin();
		sonic.StateEngine().ChangeState(spin);
	}
}
