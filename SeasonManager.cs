using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SeasonalObject : MonoBehaviour
{
    public GameObject obj; // The object in the scene
    public string tagName;  // Tag that identifies this object (Water, Grass, Ice, etc.)
    public enum Season { Autumn, Winter, Spring, Summer }

    public class SeasonManager : MonoBehaviour
    {
        [Header("Season Settings")]
        public Season currentSeason = Season.Autumn;

        [Header("Objects to Manage")]
        public List<SeasonalObject> objectsToManage = new List<SeasonalObject>();

        // Map seasons to active tags
        private Dictionary<Season, List<string>> seasonTagMap = new Dictionary<Season, List<string>>()
    {
        { Season.Autumn, new List<string>{ "Water" } },
        { Season.Winter, new List<string>{ "Ice" } },
        { Season.Spring, new List<string>{ "Water", "Grass" } },
        { Season.Summer, new List<string>{  } } // nothing active
    };

        private void Start()
        {
            ApplySeason(currentSeason);
        }

        public void SetSeason(Season season)
        {
            currentSeason = season;
            ApplySeason(currentSeason);
        }

        private void ApplySeason(Season season)
        {
            if (!seasonTagMap.ContainsKey(season)) return;

            List<string> activeTags = seasonTagMap[season];

            foreach (var seasonalObj in objectsToManage)
            {
                if (seasonalObj.obj == null) continue;

                seasonalObj.obj.SetActive(activeTags.Contains(seasonalObj.tagName));
            }

            Debug.Log("Season changed to " + season);
        }
    }
}
