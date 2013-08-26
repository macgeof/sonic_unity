using UnityEngine;
using System;

public class Sonic : Entity
{	
	public Sonic ()
	{
		base.SetId();
		SetStateEngine(new StateEngine(this));
		StandStill standstill = new StandStill();
		StateEngine().ChangeState(standstill);
	}
	
	public override void SetAnimatingSprite(OTAnimatingSprite __sprite)
	{
		base.SetAnimatingSprite(__sprite);
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
	
	public void Update()
	{
		//Debug.Log("Sonic updating : " + Input.GetAxis("Horizontal"));
	}
}

