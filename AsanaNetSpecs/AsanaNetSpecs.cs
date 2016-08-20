using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsanaNet;
using NUnit.Framework;

namespace AsanaNetSpecs
{
    [TestFixture]
    class When_using_the_Asana_Service
    {

        protected static readonly string AsanaPersonalAccessToken =
            ConfigurationManager.AppSettings["AsanaPersonalAccessToken"];

        [Test]
        public void _001_our_Personal_Access_Token_should_not_be_null_or_empty()
        {
            Assert.That(AsanaPersonalAccessToken, Is.Not.Null.Or.Empty);
        }

        [Test]
        public void _010_we_should_be_able_to_get_our_users_name()
        {
            Action<string, string, string> errorAction = GetFailedAction();
            var asanaService = GetAsanaService(errorAction);
            asanaService.GetMe(request =>
            {
                var user = request as AsanaUser;
                Assert.That(user.Name, Is.Not.Null.Or.Empty);
            });
        }

        private static Action<string, string, string> GetFailedAction()
        {
            return (requestString, error, responseContent) =>
            {
                Assert.Fail("Error when calling: {0} \n{1}\n{2}", requestString, error, responseContent);
            };
        }

        private static Asana GetAsanaService(Action<string,string, string> errorCallbackAction)
        {
            return new Asana(AsanaPersonalAccessToken, AuthenticationType.Basic, errorCallbackAction);
        }
    }
}
