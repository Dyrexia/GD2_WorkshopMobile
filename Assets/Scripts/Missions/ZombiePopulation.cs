using UnityEngine;
using System;
using System.Threading;

public class ZombiePopulationModel : MonoBehaviour
{
    // Param�tres du mod�le
    private int initialZombies = 1;
    private float zombieSpreadRate = 0.1f;
    private float armyAttackRate = 0.2f;
    private float armyGrowthinterval=10;
    private int armySize = 10;
    private float totalTime = 100f;
    private float timeStep = 1f;
    private float timeSinceLastArrival=0;

    // �v�nement d�clench� � chaque �tape de temps
    public event Action<int> OnPopulationUpdated;

    // M�thode pour initialiser la simulation
    void Start()
    {
        // Lancer la simulation
        StartCoroutine(SimulateZombiePopulation());
    }

    // Coroutine pour simuler l'�volution de la population de zombies
    System.Collections.IEnumerator SimulateZombiePopulation()
    {
        // Initialiser l'�tat du syst�me
        int currentZombies = initialZombies;

        // Boucle � travers chaque �tape de temps
        for (float t = 0; t <= totalTime; t += timeStep)
        {
            timeSinceLastArrival += timeStep;
            // �mettre l'�v�nement pour signaler la mise � jour de la population
            OnPopulationUpdated?.Invoke(currentZombies);

            // �chantillonnage stochastique des transitions
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

            // Attendre jusqu'� la prochaine �tape de temps
            Debug.Log(currentZombies);
            yield return new WaitForSeconds(timeStep);
        }
    }
}