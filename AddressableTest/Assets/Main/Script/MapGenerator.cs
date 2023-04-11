using System.Collections;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MapGenerator : MonoBehaviour
{
    //  [SerializeField] private AddressableAssetEntry entry;
    //   [SerializeField] private AssetReference asset;
// [SerializeField]   private AssetLabelReference label;
    //  [SerializeField] private AddressableAssetGroup group;
    [SerializeField] private TextMeshProUGUI text;
    // private async void Start()
    // {
    //     //     asset.
    //     //   asset.
    //
    //     text.text = group.entries.Count.ToString();
    //     await Task.Delay(500);
    //     foreach (var item in group.entries)
    //     {
    //         text.text = "";
    //         item.labels.ToList().ForEach(x => text.text += x);
    //     }
    // }

    [SerializeField] private AssetReference testBuilding;

    private IEnumerator Start()
    {
        //   string key = "myprefab";
        AsyncOperationHandle<GameObject> loadOp = Addressables.LoadAssetAsync<GameObject>(testBuilding);
        yield return loadOp;
        if (loadOp.Status == AsyncOperationStatus.Succeeded)
        {
            var op = Addressables.InstantiateAsync(testBuilding);

            var dl = op.GetDownloadStatus();
            text.text = dl.Percent.ToString();
            if (op.IsDone) // <--- this will always be true.  A preloaded asset will instantiate synchronously. 
            {
                //...
                op.Result.transform.position=Vector3.zero;
                text.text = op.Result.name;
            }
            //...
        }
    }
}