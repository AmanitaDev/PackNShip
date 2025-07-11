using System;
using GameTemplate.Utils;
using UnityEngine;

namespace GameTemplate.Systems.Currencies
{
    [System.Serializable]
    public class Currency
    {
        #region Variables

        public Sprite currencyImage;
        public int currencyAmount;
        public bool isBuyable;

        private int currencyId;

        public int CurrencyId
        {
            get => currencyId;
        }

        #endregion
        
        public void Initialize(int cId)
        {
            this.currencyId = cId;
            currencyAmount = UserPrefs.GetCurrency(currencyId, currencyAmount);
        }

        public void Reset(EventArgs args)
        {
            currencyAmount = 0;
            SetAmountToSave();
        }

        public void Spend(int spentAmount)
        {
            currencyAmount -= spentAmount;
            SetAmountToSave();
        }

        public void Earn(int earningsAmount)
        {
            currencyAmount += earningsAmount;
            SetAmountToSave();
        }

        public void SetAmountToSave()
        {
            UserPrefs.SetCurrency(currencyId, currencyAmount);
        }
        
        public int GetAmountFromSave()
        {
            return UserPrefs.GetCurrency(currencyId, currencyAmount);
        }
    }
}