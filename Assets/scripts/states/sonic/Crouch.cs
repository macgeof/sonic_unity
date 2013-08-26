using UnityEngine;
using System.Collections;
using System;

public class Crouch : State
{

	public Crouch() { }
	
	public override  void Enter(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Enter(__owner, __timeDelay);
		Sonic sonic = __owner as Sonic;
		if (sonic != null)
		{
			OTAnimatingSprite animatingSprite = sonic.AnimatingSprite();
			if (animatingSprite != null)
			{
				Debug.Log("Crouch.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("crouch");
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
		Debug.Log("Crouch.Exit() : changing state to still");
		Sonic sonic = __owner as Sonic;
		StandStill standstill = new StandStill();
		sonic.StateEngine().ChangeState(standstill, __timeDelay);
	}
}
