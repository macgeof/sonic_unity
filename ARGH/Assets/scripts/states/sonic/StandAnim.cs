using UnityEngine;
using System.Collections;
using System;

public class StandAnim : State
{

	public StandAnim()
	{
		minimumTimeInState = 1f;
	}
	
	public override  void Enter(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Enter(__owner, __timeDelay);
		Sonic sonic = __owner as Sonic;
		if (sonic != null)
		{
			OTAnimatingSprite animatingSprite = sonic.AnimatingSprite();
			if (animatingSprite != null)
			{
				Debug.Log("StandAnim.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("stand_anim");
			}
		}
	}
	
	public override void Execute(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Execute(__owner, __timeDelay);
		int chance = probability.Next(	100);
		if (chance >= 99 && timeInState > minimumTimeInState)
		{
			Debug.Log("StandAnim.Execute() : changing state to still");
			Sonic sonic = __owner as Sonic;
			StandStill standstill = new StandStill();
			sonic.StateEngine().ChangeState(standstill, __timeDelay);
		}
	}
	
	public override void Exit(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Exit(__owner, __timeDelay);
	}
}
