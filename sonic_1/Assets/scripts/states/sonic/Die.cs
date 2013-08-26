using UnityEngine;
using System.Collections;
using System;

public class Die : State
{

	public Die() { }
	
	public override  void Enter(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Enter(__owner, __timeDelay);
		Sonic sonic = __owner as Sonic;
		if (sonic != null)
		{
			OTAnimatingSprite animatingSprite = sonic.AnimatingSprite();
			if (animatingSprite != null)
			{
				Debug.Log("Die.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("die");
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
	}
}
