using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace Main.Script
{
    public class AssetsLoader : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _percentText;
        [SerializeField] private TextMeshProUGUI _sizeText;

        public IEnumerator Start()
        {
            Debug.Log("start called");
            string key = "building";
            // Clear all cached AssetBundles
            // WARNING: This will cause all asset bundles to be re-downloaded at startup every time and should not be used in a production game
            // Addressables.ClearDependencyCacheAsync(key);

            //Check the download size
            AsyncOperationHandle<long> getDownloadSize = Addressables.GetDownloadSizeAsync(key);
            yield return getDownloadSize;
            Debug.Log("dl size:::"+getDownloadSize.Result);
            _sizeText.text ="dl size:::"+ getDownloadSize.Result.ToString();
            //If the download size is greater than 0, download all the dependencies.
            if (getDownloadSize.Result > 0)
            { 
                downloadDependencies = Addressables.DownloadDependenciesAsync(key);
                yield return downloadDependencies;
            }

            _percentText.text = "downlaod finished";
            yield return new  WaitForSeconds(1);
            SceneManager.LoadScene("GamePlay");
        }


        private AsyncOperationHandle downloadDependencies;

        private void Update()
        {
            Debug.Log(downloadDependencies.GetDownloadStatus().Percent);
            _percentText.text = downloadDependencies.GetDownloadStatus().Percent.ToString();
        }
    }
}