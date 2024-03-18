using UnityEngine;
using System;
using System.Threading;

public class ZombiePopulationModel : MonoBehaviour
{
    // Paramètres du modèle
    private int initialZombies = 1;
    private float zombieSpreadRate = 0.1f;
    private float armyAttackRate = 0.2f;
    private float armyGrowthinterval=10;
    private int armySize = 10;
    private float totalTime = 100f;
    private float timeStep = 1f;
    private float timeSinceLastArrival=0;

    // Événement déclenché à chaque étape de temps
    public event Action<int> OnPopulationUpdated;

    // Méthode pour initialiser la simulation
    void Start()
    {
        // Lancer la simulation
        StartCoroutine(SimulateZombiePopulation());
    }

    // Coroutine pour simuler l'évolution de la population de zombies
    System.Collections.IEnumerator SimulateZombiePopulation()
    {
        // Initialiser l'état du système
        int currentZombies = initialZombies;

        // Boucle à travers chaque étape de temps
        for (float t = 0; t <= totalTime; t += timeStep)
        {
            timeSinceLastArrival += timeStep;
            // Émettre l'événement pour signaler la mise à jour de la population
            OnPopulationUpdated?.Invoke(currentZombies);

            // Échantillonnage stochastique des transitions
            float spreadProbability = Mathf.Clamp01(zombieSpreadRate * timeStep);
            Debug.Log(zombieSpreadRate);
            float attackProbability = Mathf.Clamp01(armyAttackRate * timeStep);

            int newZombies = 0;
            if (timeSinceLastArrival > armyGrowthinterval) 
            {
                timeSinceLastArrival = 0;
                armySize += 10;
            }
            for (int i = 0; i < currentZombies; i++)
            {
                if (UnityEngine.Random.value < spreadProbability)
                {
                    newZombies++;
                }
            }

            int zombiesKilledByArmy = Mathf.RoundToInt(UnityEngine.Random.Range(0, armySize) * attackProbability);
            currentZombies += newZombies - zombiesKilledByArmy;

            // Attendre jusqu'à la prochaine étape de temps
            Debug.Log(currentZombies);
            yield return new WaitForSeconds(timeStep);
        }
    }
}