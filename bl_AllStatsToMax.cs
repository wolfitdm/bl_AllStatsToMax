using Den.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.Rendering.VolumeComponent;

namespace BitchLand//must have this namespace
{
	class bl_AllStatsToMaxModDoWork 
	{
		public bl_AllStatsToMaxModDoWork() 
		{ 
		}
		
		public void OnEnable()
		{
			doWork();
		}

        public void OnDisable()
        {

        }

        public void doWork()
		{
            string allStatsToMaxModString = "bl_AllStatsToMaxModDoWork.doWork() Set all skills to max";
            Main.Instance.GameplayMenu.ShowNotification(allStatsToMaxModString);
            Debug.Log((object)allStatsToMaxModString);
			int add = 3000;
			Main.Instance.Player.SexSkills += add;
			Main.Instance.Player.WorkSkills += add;
			Main.Instance.Player.ArmySkills += add;
			Main.Instance.Player.Money += add;
			int workMax = Main.Instance.Player.WorkXpThisLvlMax;
			int sexMax = Main.Instance.Player.SexXpThisLvlMax;
			int armyMax = Main.Instance.Player.ArmyXpThisLvlMax;
			workMax = workMax >= 0 ? workMax : add;
            sexMax = sexMax >= 0 ? sexMax : add;
            armyMax = armyMax >= 0 ? armyMax : add;
            Main.Instance.Player.SexXpThisLvl = sexMax;
            Main.Instance.Player.WorkXpThisLvl = workMax;
            Main.Instance.Player.ArmyXpThisLvl = armyMax;
            Main.Instance.Player.Hunger = 75;
            Main.Instance.Player.Energy = 75;
			Main.Instance.Player.Toilet = 75;
			Main.Instance.Player.Favor = 75;
        }

		public static bl_AllStatsToMaxModDoWork Instance = new bl_AllStatsToMaxModDoWork();
    }

	public class Mod//must have this class name
	{
		public static bl_AllStatsToMaxMod ThisMod;

		public static void Init() //must have this name, and MUST be static
		{
			ThisMod = Main.Instance.gameObject.AddComponent<bl_AllStatsToMaxMod>();
		}



		public static void EnableMod(bool value)
		{
			if(value)
			{//mod was enabled in the settings
				bl_AllStatsToMaxModDoWork.Instance.OnEnable();
            }
			else
			{
				bl_AllStatsToMaxModDoWork.Instance.OnDisable();
			}
		}
	}

	public class bl_AllStatsToMaxMod : MonoBehaviour
	{
		public void Start()
		{
            bl_AllStatsToMaxModDoWork.Instance.OnEnable();
        }

	}
}

