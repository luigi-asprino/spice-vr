using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SampleScene : MonoBehaviour
{
    AsyncOperationHandle<GameObject> opHandle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadCharacter()
    {
        opHandle = Addressables.LoadAssetAsync<GameObject>("AsiaticChildFemale");
        opHandle.Completed += handle => {
            Debug.Log(" addressables loaded");
                                            GameObject obj = opHandle.Result;
                                            Instantiate(obj, transform.parent);
                                           };

    }

}
