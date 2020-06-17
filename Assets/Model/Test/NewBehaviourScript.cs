  
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = UnityEngine.AddressableAssets.Addressables.RuntimePath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
