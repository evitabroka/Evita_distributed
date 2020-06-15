using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Evita_distributed.Models;

namespace Evita_distributed.Controllers
{
    public class ProfilePreferenceModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public bool Create(String email, bool valueEmail, bool valueBirthDate, bool valuename)
        {
            try
            {
                var userlog = db.Users.FirstOrDefault(x => x.UserName == email);
                ProfilePreferenceModel pm = new ProfilePreferenceModel();
                pm.email = valueEmail;
                pm.birthday = valueBirthDate;
                pm.name = valuename;
                pm.userID = userlog.Id;
                pm.User = userlog;



                if (ModelState.IsValid)
                {



                    db.ProfilePreferenceModels.Add(pm);
                    db.SaveChanges();

                }




                return true;
            }
            catch (Exception e)
            {



                return false;
            }
        }
        public bool checkifexist(string Useremail)
        {




            var logeduser = db.Users.FirstOrDefault(x => x.Email == Useremail);
           
            if (db.ProfilePreferenceModels.FirstOrDefault(x => x.userID == logeduser.Id) == null)
            {

                return true;
            }
            else { return false; }




        }



        public void UpdatenewFeeld(String email, bool valueEmail, bool valueBirthDate, bool valuename)
        {
            var user = db.Users.FirstOrDefault(x => x.Email == email);
            var actualuser = db.ProfilePreferenceModels.FirstOrDefault(x => x.userID == user.Id);
            actualuser.email = valueEmail;
            actualuser.name = valuename;
            actualuser.birthday = valueBirthDate;
            db.SaveChanges();



        }
    }
}
