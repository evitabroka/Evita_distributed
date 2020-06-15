using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Evita_distributed.Endpoints
{
    public class FbEndpoints
    {
        string BaseLink = "https://graph.facebook.com/v7.0/";
        public string fBAccesToken;

      public string GetFeedEndpoint()
        {
            StringBuilder strb = new StringBuilder(BaseLink);
            strb.Append("me/feed?access_token=");
            strb.Append(fBAccesToken);
            return strb.ToString();
        }
        public string GetLikeEndpoint()
        {
            StringBuilder strb = new StringBuilder(BaseLink);
            strb.Append("me/likes?access_token=");
            strb.Append(fBAccesToken);
            return strb.ToString();
        }
        public string GetImageEndpoint(string postid)
        {
            StringBuilder strb = new StringBuilder(BaseLink);
            strb.Append(postid);
            strb.Append("?fields=full_picture,picture&access_token=");
            strb.Append(fBAccesToken);
            return strb.ToString();
        }

        public string GetProfileEndpoint(bool BooleanName , bool BooleanBirthday, bool Booleanemail)
        {
          


            StringBuilder strb = new StringBuilder(BaseLink);
            strb.Append("me?fields=");
            if (BooleanName) { strb.Append("name"); }
            if (BooleanName && Booleanemail || BooleanName && BooleanBirthday) { strb.Append(","); }
            if (Booleanemail) { strb.Append("email"); }
            if (Booleanemail && BooleanBirthday) { strb.Append(","); }
            if (BooleanBirthday) { strb.Append("birthday"); }
            strb.Append("&access_token=");



            strb.Append(fBAccesToken);
            return strb.ToString();
        }

        public Dictionary<string, string> EndpointURL()
        {
            return new Dictionary<string, string>
            {
                 { "Authorization", fBAccesToken }



            };

        }
    }
}