using UnityEngine;
using System.Collections.Generic;
using System;

public class EntityManager
{	
	private static bool ALLOW_INSTANTIATION = false;
	private static EntityManager INSTANCE = null;
	private static readonly object padlock = new object();
	
	private List<Entity> entities;
	
	public EntityManager()
	{
		if (ALLOW_INSTANTIATION)
		{
			entities = new List<Entity>();
		}
		else
		{
			throw new System.Exception("Singleton : access via getInstance");
		}
	}
	
	public static EntityManager getInstance()
	{
		lock(padlock)
		{
			if (INSTANCE == null)
			{
				ALLOW_INSTANTIATION = true;
				INSTANCE = new EntityManager();
				ALLOW_INSTANTIATION = false;
			}
			return INSTANCE;
		}
	}
	
	public bool addEntity(Entity __entity)
	{
		bool added = false;
		
		if (entities == null)
		{
			entities = new List<Entity>();
		}
		if (!entities.Contains(__entity))
		{
			entities.Add(__entity);
			added = true;
		}
		return added;
	}
	
	public int removeEntity(Entity __entity)
	{
		int removed = -1;
		if (entities != null)
		{
			int index = entities.IndexOf(__entity);
			if (index >= 0)
			{
				removed = index;
			}
		}
		return removed;
	}
	
	public Entity getEntityById(int __id)
	{
		Entity __foundEntity = null;
		if (entities != null && entities.Count > 0)
		{
			foreach (Entity __entity in entities)
			{
				if (__entity.id == __id)
				{
					__foundEntity = __entity;
				}
			}
		}
		return __foundEntity;
	}
	
	public Entity getEntityByName(string __name)
	{
		Entity __foundGO = null;
		if (entities != null && entities.Count > 0)
		{
			foreach (Entity __entity in entities)
			{
				if (__entity.name == __name)
				{
					__foundGO = __entity;
				}
			}
		}
		return __foundGO;
	}
	
	// Update is called once per frame
	public void update (float __timeDelay = 0.0f) {
		foreach (Entity __entity in entities)
		{
			__entity.doStateUpdate(__timeDelay);
		}
	}
}
