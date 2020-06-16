using Evita_distributed.Client;
using Evita_distributed.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evita_distributed.Controllers
{
    public class TwitterAPIController : Controller
    {
        protected Restclient AppClient = new Restclient();
        private TwEndpoint Endpoint;

        public TwitterAPIController() : base()
        {
            this.Endpoint = new TwEndpoint();
        }

        //[HttpGet]
        //[Route("getFeed")]
        //public FbFeedModel getFeed(string FbToken)
        //{
        //    Enpoiint.fBAccesToken = FbToken;
        //    AppClient.endpoint = Enpoiint.GetFeedEndpoint();
        //    JSONParser<FbFeedModel> JsonModel = new JSONParser<FbFeedModel>();
        //    string values = AppClient.Request(HttpVerb.GET, Enpoiint.EndpointURL());
        //    FbFeedModel Feedd = new FbFeedModel();
        //    Feedd = JsonModel.parseJson(values);
        //    return Feedd;

        //}

    }
}