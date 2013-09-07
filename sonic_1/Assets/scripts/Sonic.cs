using UnityEngine;
using System;

public class Sonic : Entity
{	
	public Sonic ()
	{
		base.SetId();
		SetStateEngine(new StateEngine(this));
	}
	
	public override void SetAnimatingSprite(OTAnimatingSprite __sprite)
	{
		base.SetAnimatingSprite(__sprite);
		StandStill standstill = new StandStill();
		StateEngine().SetCurrentState(standstill);
		standstill.Enter(this);
	}
	
	public override void doStateUpdate(float __timeDelay = 0.0f)
	{
		_update(__timeDelay);
	}
	
	protected void _update(float __timeDelay)
	{
		StateEngine().Update(__timeDelay);
		base._update(__timeDelay);
	}
}

