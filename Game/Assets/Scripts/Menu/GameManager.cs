// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class GameManager : MonoBehaviour
// {
//     public Text NameText;
//     public Text CoinText;
//     private YandexSDK SDK;


//     public GameObject ScrollView;
//     public GameObject _fab;

//     [SerializeField] private int coins;

//     private void Start()
//     {
//         SDK = YandexSDK.Instance;
//         SDK.AuthSuccess += SettingMame;
//         SDK.RewardGet += Rewarded;
//         SDK.DataGet += SettingData;
//         UpdateCoinsText();
//     }
    

//     public void UpdateCoinsText()
//     {
//         CoinText.text = coins.ToString();
//     }
//     public void Auth()
//     {
//         SDK.Authenticate();
//     }
//     public void GetData()
//     {
//         SDK.GettingData();
//     }
//     public void SetData()
//     {
//         UserGameData UD = new UserGameData(coins);
//         SDK.SettingData(JsonUtility.ToJson(UD));
//     }
//     public void ShowCommon()
//     {
//         SDK.ShowCommonAdvertisment();
//     }
//     public void ShowReward()
//     {
//         SDK.ShowRewardAdvertisment();
//     }
    
//     public void GetLeaderBoardEntries() => SDK.getLeaderEntries();
//     public void SetLeaderBoard() => SDK.setLeaderScore(coins);
    
//     public void AddCoin()
//     {
//         coins++;
//         UpdateCoinsText();
//         SetLeaderBoard();
//     }
//     private void SettingData()
//     {
//         coins = SDK.GetUserGameData.Coin;
//         UpdateCoinsText();
//     }
//     private void SettingMame()
//     {
//         NameText.text = SDK.GetUserData.Name;
//     }
//     private void Rewarded()
//     {
//         coins++;
//         UpdateCoinsText();
//     }
    
    
//     private void ClearEntri()
//     {
//         if (ScrollView.transform.childCount > 0)
//         {
//             foreach (Transform child in ScrollView.transform)
//             {
//                 Destroy(child.gameObject);
//             }
//         }
//     }
// }