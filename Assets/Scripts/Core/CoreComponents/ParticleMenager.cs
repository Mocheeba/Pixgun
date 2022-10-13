using UnityEngine;

public class ParticleMenager : CoreComponent
{
   private Transform particleCointerner;

   protected override void Awake() {
        base.Awake();

        particleCointerner = GameObject.FindGameObjectWithTag("ParticleCointeiner").transform;
   }

   public GameObject StartParticles(GameObject particlePrefab, Vector2 position, Quaternion rotation)
   {
        return Instantiate(particlePrefab, position, rotation, particleCointerner);
   }

   public GameObject StartParticles(GameObject particlePrefab)
   {
        return StartParticles(particlePrefab, transform.position, Quaternion.identity);
   }

   public GameObject StartParticlesWithRandomRotation(GameObject particlePrefab)
   {
        var randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        return StartParticles(particlePrefab, transform.position, randomRotation);
   }
}


