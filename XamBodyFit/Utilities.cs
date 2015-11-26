

namespace XamBodyFit
{

    public class Utilities
    {
        public string uri = "http://dev2.cabotprojects.com/bodyfitAWS/webservices?procedure=";
        public string GetUri(string procedure)
        {

            switch (procedure)
            {
                case "initializeApp":
                    return uri += "initializeApp";
                default:
                    return uri += "initializeApp";
            }
        }
    }
}