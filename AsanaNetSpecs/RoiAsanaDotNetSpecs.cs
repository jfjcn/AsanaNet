using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RoiCode.AsanaDotNet;

namespace AsanaNetSpecs
{
    [TestFixture]
    class When_using_the_Asana_Repository
    {

        [Test]
        public void _010_we_should_be_able_to_get_our_users_name()
        {
            var asanaRepository = new AsanaRepository();
            var myUser = asanaRepository.GetMe();
            Assert.That(myUser.Name, Is.Not.Null.Or.Empty);
        }

//        [Test]
//        public void _011_we_should_be_able_to_get_our_users_name_again_without_throwing_an_exception()
//        {
//            Action<string, string, string> errorAction = GetFailedAction();
//            var asanaService = GetAsanaService(errorAction);
//            asanaService.GetMe(request =>
//            {
//                var user = request as AsanaUser;
//                Assert.That(user.Name, Is.Not.Null.Or.Empty);
//            }).Wait();
//        }
//
//        [Test]
//        public void _020_we_should_be_able_to_get_at_least_one_workspace()
//        {
//            Action<string, string, string> errorAction = GetFailedAction();
//            var asanaService = GetAsanaService(errorAction);
//            var hasWorkspaces = false;
//            asanaService.GetWorkspaces(request =>
//            {
//                foreach (AsanaWorkspace asanaWorkspace in request)
//                {
//                    hasWorkspaces = true;
//                }
//            }).Wait();
//            Assert.That(hasWorkspaces);
//        }




    }
}
