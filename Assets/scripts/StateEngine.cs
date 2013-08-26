using UnityEngine;
using System.Collections;

public class StateEngine
{
	private Entity			m_pOwner;
	private State			m_pCurrentState;
	private State			m_pPreviousState;
	private State			m_pGlobalState;

	public StateEngine(Entity __owner)
	{
		SetOwner(__owner);
		SetCurrentState(null);
		SetPreviousState(null);
		SetGlobalState(null);
	}
	
	public void Update(float __timeDelay = 0.0f)
	{
//		Debug.Log("StateEngine._update : " + Owner().id);
		if (GlobalState() != null) GlobalState().Execute(m_pOwner, __timeDelay);
		if (CurrentState() != null) CurrentState().Execute(m_pOwner, __timeDelay);
	}
	
	public void ChangeState(State __newState, float __timeDelay = 0.0f)
	{
		m_pPreviousState = m_pCurrentState;
		if (m_pCurrentState != null) m_pCurrentState.Exit(m_pOwner, __timeDelay);
		m_pCurrentState = __newState;
		m_pCurrentState.Enter(m_pOwner, __timeDelay);
	}
	
	public void RevertToPreviousState()
	{
		ChangeState(m_pPreviousState);
	}
	
	public void SetOwner(Entity __owner)
	{
		m_pOwner = __owner;
	}
	
	public void SetPreviousState(State __state, float __timeDelay = 0.0f)
	{
		m_pPreviousState = __state;
	}
	
	public void SetCurrentState(State __state, float __timeDelay = 0.0f)
	{
		m_pCurrentState = __state;
	}
	
	public void SetGlobalState(State __state, float __timeDelay = 0.0f)
	{
		m_pGlobalState = __state;
	}
	
	public Entity Owner()
	{
		return m_pOwner;
	}
	
	public State CurrentState()
	{
		return m_pCurrentState;
	}
	
	public State PreviousState()
	{
		return m_pPreviousState;
	}
	
	public State GlobalState()
	{
		return m_pGlobalState;
	}
}
