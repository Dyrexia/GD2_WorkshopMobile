using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class Zombie_Return : MonoBehaviour
{
    public List<ItemData> MissionGains = new List<ItemData>();
    private string[] bodyparts = { "Tête","Torse","Bras droit","Bras gauche","Jambe droite","Jambe gauche" };
    private ZombieData Zombie ;
    public Transform SpawnItemRecompense;
    public Button ButtonPrefab;
    public SpriteLibrary SpriteLibrary;
    public TextMeshProUGUI Stat;
    private void OnEnable()
    {
        Zombie = MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie];
        GenerateItems((Zombie.GetExpectedReturn() - Zombie.GetDepartureTime()).TotalSeconds);
    }
    public void AcceptEnd()
    {
        Debug.Log("IsReturning est false");
        Zombie.IsReturning = false;
    }
    public void GenerateItems(double MissionDuration)
    {
        Stat.text = MissionEndStats((int)MissionDuration).ToString();

        int items = ((int)MissionDuration/60)*2 + 1;
        Debug.Log(items);
        for (int i = 0; i < items; i++)
        {
            int levelModifier = Mathf.Max((Zombie.GetIntelligence() / 6) + UnityEngine.Random.Range(-1, 2)+(int)MathF.Round(Zombie.MissionDifficulty)/2,0);
            MissionGains.Add(new ItemData(bodyparts[UnityEngine.Random.Range(0,bodyparts.Length)],Mathf.Min(levelModifier,15)));

        }
        foreach (ItemData item in MissionGains)
        {
            ItemWrapper itemWrapper = new ItemWrapper();
            itemWrapper.ItemData = item;
            MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items.Add(itemWrapper);
            Button newButton = Instantiate(ButtonPrefab, SpawnItemRecompense);
            Debug.Log(GetComponent<SpriteLibrary>().GetSprite(item.Bodypart, item.SkinLabel));
            newButton.GetComponent<UI_ImageRecompense>().Initialize(SpriteLibrary.GetSprite(item.Bodypart, item.SkinLabel),item.Level) ;
            newButton.gameObject.SetActive(true);
        }
        MissionGains.Clear();
    }
    public int MissionEndStats(int t)
    {
        return Mathf.FloorToInt(((2/3)*Zombie.GetInfection()*Zombie.GetPower()*t*Mathf.Sqrt(t)-(Mathf.Pow(t-Zombie.GetStealth(),Zombie.MissionDifficulty+1)/(Zombie.MissionDifficulty+3))) / Zombie.GetPower());
    }


}
