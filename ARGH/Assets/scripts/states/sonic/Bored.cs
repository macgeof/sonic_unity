using UnityEngine;
using System.Collections;
using System;

public class Bored : State
{

	public Bored()
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
				Debug.Log("Bored.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("bored");
			}
		}
	}
	
	public override void Execute(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Execute(__owner, __timeDelay);
		if (Input.GetAxis("Horizontal") != 0)
		{
			Sonic sonic = __owner as Sonic;
			Walk walk = new Walk();
			sonic.StateEngine().ChangeState(walk, __timeDelay);
			return;
		}
		int chance = probability.Next(	100);
		if (chance >= 99 && timeInState > minimumTimeInState)
		{
			Debug.Log("Bored.Execute() : changing state to still");
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
