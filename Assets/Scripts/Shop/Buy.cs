using com.amazon.device.iap.cpt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{

    public Button buyButton;

    // Start is called before the first frame update
    void Start()
    {
        GetUserData();

        buyButton.onClick.AddListener(Purchase);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetUserData()
    {
        // Obtain object used to interact with plugin
        IAmazonIapV2 iapService = AmazonIapV2Impl.Instance;

        // Call synchronous operation with no input
        RequestOutput response = iapService.GetUserData();

        // Get return value
        string requestIdString = response.RequestId;
    }

    void Purchase()
    {
        // Obtain object used to interact with plugin
        IAmazonIapV2 iapService = AmazonIapV2Impl.Instance;

        // Construct object passed to operation as input
        SkuInput request = new SkuInput();

        // Set input value
        request.Sku = "sku";

        // Call synchronous operation with input object
        RequestOutput response = iapService.Purchase(request);

        // Get return value
        string requestIdString = response.RequestId;
    }
}
