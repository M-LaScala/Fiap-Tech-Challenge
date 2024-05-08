namespace Tech.Challenge.Grupo27.Common.Telemetria
{
    internal class TelemetryMiddleware
    {
        private static bool IRequestWitchBody(HttpRequestMessage r) => r.Method == HttpMethod.Post || r.Method == HttpMethod.Put;           
    }
}
