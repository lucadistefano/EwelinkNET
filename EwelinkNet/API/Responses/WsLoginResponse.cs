using System.Dynamic;

namespace EwelinkNet.API.Responses
{
    public class WsLoginResponse
    {
        public int error { get; set; }
        public string apikey { get; set; }
        public string sequence { get; set; }
        public dynamic config { get; set; } = new ExpandoObject();
    }
}
