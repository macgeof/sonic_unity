using UnityEngine;
using System.Collections;
using System;

public class Drown : State
{

	public Drown() { }
	
	public override  void Enter(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Enter(__owner, __timeDelay);
		Sonic sonic = __owner as Sonic;
		if (sonic != null)
		{
			OTAnimatingSprite animatingSprite = sonic.AnimatingSprite();
			if (animatingSprite != null)
			{
				Debug.Log("Drown.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("drown");
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
		Sonic sonic = __owner as Sonic;
		if (sonic != null)
		{
			StateEngine stateEngine = sonic.StateEngine();
			Die dieState = new Die();
			stateEngine.SetCurrentState(dieState, __timeDelay);
		}
	}
}
