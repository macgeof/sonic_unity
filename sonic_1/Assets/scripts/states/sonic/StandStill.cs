using UnityEngine;
using System.Collections;

public class StandStill : State
{	
	public StandStill()
	{
		minimumTimeInState = 1.0f;
		minimumHorizontal = 0.01f;
		maximumHorizontal = 0f;
		minimumVertical = 0f;
		maximumVertical = 0f;
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
				Debug.Log("StandStill.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("stand_still");
			}
		}
	}
	
	public override void Execute(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Execute(__owner, __timeDelay);
		Vector2 motion = __owner.Motion;
		Debug.Log("StandStill.Execute() : " + __owner.id + " :  motion x = " + motion.x);
		Sonic sonic;
		if ((motion.x > 0 && motion.x > minimumHorizontal) || (motion.x < 0 && motion.x < -minimumHorizontal))
		{
			sonic = __owner as Sonic;
			Walk walk = new Walk();
			sonic.StateEngine().ChangeState(walk, __timeDelay);
			return;
		}
		if (motion.y < 0)
		{
			sonic = __owner as Sonic;
			Crouch crouch = new Crouch();
			sonic.StateEngine().ChangeState(crouch, __timeDelay);
			return;
		}
		if (motion.y > 0)
		{
			sonic = __owner as Sonic;
			LookUp lookup = new LookUp();
			sonic.StateEngine().ChangeState(lookup, __timeDelay);
			return;
		}
		int chance = probability.Next(100);
		if (chance >= 99 && timeInState > minimumTimeInState)
		{
			Debug.Log("StandStill.Execute() : changing state to anim");
			sonic = __owner as Sonic;
			StandAnim standanim = new StandAnim();
			sonic.StateEngine().ChangeState(standanim, __timeDelay);
			return;
		}
		chance = probability.Next(100);
		if (chance >= 99 && timeInState > minimumTimeInState)
		{
			Debug.Log("StandStill.Execute() : changing state to bored");
			sonic = __owner as Sonic;
			Bored bored = new Bored();
			sonic.StateEngine().ChangeState(bored, __timeDelay);
			return;
		}
	}
	
	public override void Exit(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Exit(__owner, __timeDelay);
	}
}
