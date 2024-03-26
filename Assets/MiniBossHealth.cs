using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossHealth : MonoBehaviour
{
    public int health = 30;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}
}
