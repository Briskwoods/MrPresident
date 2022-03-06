using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    public int Economy_Value;
    [SerializeField] TextMeshProUGUI Economy_UI_Text;
    [SerializeField] GameObject MoneyUI_Prefab;
    [SerializeField] Canvas MainCanvas;
    public Transform Spawned_Cash_UI_Target;
    int CashToAddPerInterval = 0;

    public void Start()
    {
        //Check if we are a new game instance
        Economy_Value = ControlManager.Instance.PlayerPrefs_Manager_Script.CheckEconomy();

        //Show economy value
        Economy_UI_Text.text = "$" + FormatNumber(Economy_Value).ToString();
    }

    //Numbers Format
    string FormatNumber(long num)
    {
        if (num >= 100000000)
        {
            return (num / 1000000D).ToString("0.#M");
        }
        if (num >= 1000000)
        {
            return (num / 1000000D).ToString("0.#M");
        }
        if (num >= 100000)
        {
            return (num / 1000D).ToString("0.#k");
        }
        if (num >= 10000)
        {
            return (num / 1000D).ToString("0.#k");
        }

        return num.ToString("#,0");
    }
        
    public void IncreaseEconomy(int value, Vector3 Position) 
    {
        CashToAddPerInterval = value / 22;
        GameObject BlastMoney = Instantiate(MoneyUI_Prefab);
        BlastMoney.transform.SetParent(MainCanvas.transform);
        BlastMoney.transform.localPosition = Position;
        BlastMoney.GetComponent<Blast_UI_Items>().isCash = true;
        BlastMoney.transform.localScale = new Vector3(1,1,1);
        BlastMoney.GetComponent<Blast_UI_Items>().Target = Spawned_Cash_UI_Target;
    }

    public void ItemReachedDestination() 
    {
        Economy_Value = Economy_Value + CashToAddPerInterval;
        Economy_UI_Text.text = "$" + FormatNumber(Economy_Value).ToString();

        ControlManager.Instance.PlayerPrefs_Manager_Script.UpdateEconomy(Economy_Value);
    }
}
