using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MapGenerator : MonoBehaviour
{
    //  [SerializeField] private AddressableAssetEntry entry;
    //   [SerializeField] private AssetReference asset;
// [SerializeField]   private AssetLabelReference label;
    [SerializeField] private AddressableAssetGroup group;
    [SerializeField] private TextMeshProUGUI text;

    private async void Start()
    {
        //     asset.
        //   asset.

        text.text = group.entries.Count.ToString();
        await Task.Delay(500);
        foreach (var item in group.entries)
        {
            text.text = "";
            item.labels.ToList().ForEach(x => text.text += x);
            await Task.Delay(300);
        }
    }
}