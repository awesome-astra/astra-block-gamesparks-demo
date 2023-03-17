


using System;
using Amazon.GameSparks.Unity.DotNet;
using Amazon.GameSparks.Unity.EngineIntegration;
using Newtonsoft.Json;

namespace Amazon.GameSparks.Unity.Generated
{
    public static class AstraBlockDemoOperations
    {

        public sealed class GetSortedNFTRequest
        {
            [JsonProperty]
            public int input1 { get; }
            [JsonProperty]
            public int input2 { get; }

            public GetSortedNFTRequest(
                int input1,
                int input2)
            {
                this.input1 = input1;
                this.input2 = input2;
            }

            public override string ToString()
            {
                return string.Concat(
                   $"{nameof(input1)}: { input1 }", Environment.NewLine,
                   $"{nameof(input2)}: { input2 }");
            }
        }

        public sealed class GetSortedNFTResponse
        {
            [JsonProperty]
            public string result { get; }

            public GetSortedNFTResponse(
                string result)
            {
                this.result = result;
            }

            public override string ToString()
            {
                return string.Concat(
                   $"{nameof(result)}: { result }");
            }
        }

        public static void EnqueueGetSortedNFTRequest(
            this Connection connection,
            GetSortedNFTRequest payload,
            Action<Message<GetSortedNFTResponse>> handleResponse,
            Action<Message<DefaultError>> handleError,
            Action handleTimeout,
            TimeSpan timeout)
        {
            connection.SendRequest(
                new Message<GetSortedNFTRequest>("Custom.Game.GetSortedNFT", payload),
                timeout,
                handleResponse,
                handleError,
                handleTimeout);
        }


    }
}
