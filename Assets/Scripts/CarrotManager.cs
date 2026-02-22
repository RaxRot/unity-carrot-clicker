using System;
using TMPro;
using UnityEngine;

public class CarrotManager : MonoBehaviour
{
   private const string TotalKey = "totalCarrotsCount";

   [Header("Data")] 
   [SerializeField] private double totalCarrotsCount;
   [SerializeField] private int carrotIncrement = 1;
   
   [Header("Elements")]
   [SerializeField]private TextMeshProUGUI carrotText;
   private const string CARROT_TEXT="Carrots";
   public static Action<double> onCarrotChanged;

   private void Awake()
   {
      LoadData();
   }

   private void OnDestroy()
   {
      SaveData();
   }

   private void OnEnable()
   {
      InputManager.onCarrotClicked += CarrotClickCallBack;
   }

   private void OnDisable()
   {
      InputManager.onCarrotClicked -= CarrotClickCallBack;
   }

   private void CarrotClickCallBack()
   {
      totalCarrotsCount+=carrotIncrement;
      UpdateCarrotText(totalCarrotsCount);
      
      onCarrotChanged?.Invoke(totalCarrotsCount);
   }

   private void SaveData()
   {
      PlayerPrefs.SetString(TotalKey, totalCarrotsCount.ToString());
   }

   private void LoadData()
   {
      if (PlayerPrefs.HasKey(TotalKey))
      {
         String saved = PlayerPrefs.GetString(TotalKey);
         totalCarrotsCount = Convert.ToDouble(saved);  
      }
      else
      {
         totalCarrotsCount = 0;
      }
      
      UpdateCarrotText(totalCarrotsCount);
      onCarrotChanged?.Invoke(totalCarrotsCount);
   }

   private void UpdateCarrotText(double carrotsCount)
   {
      carrotText.text=CARROT_TEXT+"\n" + carrotsCount;
   }
}
