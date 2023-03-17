using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Amazon.GameSparks.Unity.DotNet;
using Amazon.GameSparks.Unity.Editor.Assets;
using Amazon.GameSparks.Unity.Generated;
using TMPro;

public class AstraBlockPlayer : MonoBehaviour
{
    [Header("GameSparks")]
    [SerializeField] private ConnectionScriptableObject connectionScriptableObject;

    [Header("UI Fields")]
    [SerializeField] private TextMeshProUGUI responseLabel;
    [SerializeField] public TextMeshProUGUI blockNumberText;
    
    
    private int blockNumberHour = 41447;
    private int blockNumber;


    public void GetSortedNFT()
    {
        blockNumber = Int32.Parse(blockNumberText.text);

        var getSortedNFTRequest = new AstraBlockDemoOperations.GetSortedNFTRequest(blockNumberHour, blockNumber);

        try
        {
            Debug.Log("Sending Sorted NFT Request");
            connectionScriptableObject.Connection.EnqueueGetSortedNFTRequest(
                getSortedNFTRequest,
                HandleSortedNFTRequest,
                error => { Debug.Log("Request failed: " + error);
                responseLabel.text = "Please enter a valid block number"; },
                () => { Debug.Log("Request timed out."); },
                TimeSpan.FromMinutes(2));
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            
        }
            
    }

    private void HandleSortedNFTRequest(Message<AstraBlockDemoOperations.GetSortedNFTResponse> response)
    {
        Debug.Log(response.Payload.result);
        responseLabel.text = response.Payload.result;
    }

}


