using UnityEngine;
using System.Collections;
using System;

public class LookUp : State
{

	public LookUp() { }
	
	public override  void Enter(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Enter(__owner, __timeDelay);
		Sonic sonic = __owner as Sonic;
		if (sonic != null)
		{
			OTAnimatingSprite animatingSprite = sonic.AnimatingSprite();
			if (animatingSprite != null)
			{
				Debug.Log("LookUp.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("look_up");
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
		Debug.Log("LookUp.Exit() : changing state to still");
		Sonic sonic = __owner as Sonic;
		StandStill standstill = new StandStill();
		sonic.StateEngine().ChangeState(standstill, __timeDelay);
	}
}
