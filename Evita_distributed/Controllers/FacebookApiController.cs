using Evita_distributed.Client;
using Evita_distributed.Endpoints;
using Evita_distributed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Evita_distributed.JsonParser.JsonParser;

namespace Evita_distributed.Controllers
{
    [Authorize]
    [RoutePrefix("api/Fb")]
    public class FacebookApiController : ApiController
    {
        
        protected Restclient AppClient = new Restclient();
        private FbEndpoints Enpoiint;

        public FacebookApiController() : base()
        {
            this.Enpoiint = new FbEndpoints();
        }


        [HttpGet]
        [Route("getFeed")]
        public FbFeedModel getFeed(string FbToken)
        {
            Enpoiint.fBAccesToken = FbToken;
            AppClient.endpoint = Enpoiint.GetFeedEndpoint();
            JSONParser<FbFeedModel> JsonModel = new JSONParser<FbFeedModel>();
            string values = AppClient.Request(HttpVerb.GET, Enpoiint.EndpointURL());
            FbFeedModel Feedd = new FbFeedModel();
            Feedd = JsonModel.parseJson(values);
            return Feedd;

        }

        [HttpGet]
        [Route("getlikes")]
        public FbLikesModel getlikes(string FbToken)
        {
            Enpoiint.fBAccesToken = FbToken;
            AppClient.endpoint = Enpoiint.GetLikeEndpoint();
            JSONParser<FbLikesModel> JsonModel = new JSONParser<FbLikesModel>();
            string values = AppClient.Request(HttpVerb.GET, Enpoiint.EndpointURL());
            FbLikesModel Feedd = new FbLikesModel();

            Feedd = JsonModel.parseJson(values);
            return Feedd;

        }
        [HttpGet]
        [Route("Getimage")]
        public FbImageModel Getimage(string FbToken,string postid)
        {
            Enpoiint.fBAccesToken = FbToken;
            AppClient.endpoint = Enpoiint.GetImageEndpoint(postid);
            JSONParser<FbImageModel> JsonModel = new JSONParser<FbImageModel>();
            string values = AppClient.Request(HttpVerb.GET, Enpoiint.EndpointURL());
            FbImageModel Feedd = new FbImageModel();

            Feedd = JsonModel.parseJson(values);
            return Feedd;

        }
        [HttpGet]
        [Route("PreferencesOfProfile")]
        
        public FbUserProfileModel PreferencesOfProfile(string Token, string useremail, bool Booleanemail, bool BooleanBirthday, bool BooleanName)
        {
            ProfilePreferenceModel PerformanceModel = new ProfilePreferenceModel();
            PerformanceModel.email = Booleanemail;
            PerformanceModel.birthday = BooleanBirthday;
            PerformanceModel.name = BooleanName;
            ProfilePreferenceModelsController PreferenceController = new ProfilePreferenceModelsController();
            if (PreferenceController.checkifexist(useremail)) { PreferenceController.Create(useremail, Booleanemail, BooleanBirthday, BooleanName); }
            else
            {
                PreferenceController.UpdatenewFeeld(useremail, Booleanemail, BooleanBirthday, BooleanName);
            }


            Enpoiint.fBAccesToken = Token;
            AppClient.endpoint = Enpoiint.GetProfileEndpoint(BooleanName, BooleanBirthday,  Booleanemail);



            String Data = AppClient.Request(HttpVerb.GET, Enpoiint.EndpointURL());
            JSONParser<FbUserProfileModel> jsonp = new JSONParser<FbUserProfileModel>();
            FbUserProfileModel fbm = new FbUserProfileModel();
            fbm = jsonp.parseJson(Data);
            return fbm;




        }



    }
}