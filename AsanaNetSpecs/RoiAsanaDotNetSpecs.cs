using NUnit.Framework;
using RoiCode.AsanaDotNet;

namespace AsanaNetSpecs
{
    [TestFixture]
    class When_using_the_Asana_Repository
    {

        protected static AsanaRepository AsanaRepository = new AsanaRepository();

        [Test]
        public void _010_we_should_be_able_to_get_our_users_name()
        {
            var myUser = AsanaRepository.GetMe();
            Assert.That(myUser.Name, Is.Not.Null.Or.Empty);
        }

        [Test]
        public void _011_we_should_be_able_to_get_our_users_name_again_without_throwing_an_exception()
        {
            var myUser = AsanaRepository.GetMe();
            Assert.That(myUser.Name, Is.Not.Null.Or.Empty);
        }

        [Test]
        public void _020_we_should_be_able_to_get_at_least_one_workspace()
        {
            var myWorkspaces = AsanaRepository.GetWorkspaces();
            var hasWorkspaces = false;
            foreach (AsanaWorkspace asanaWorkspace in myWorkspaces)
            {
                hasWorkspaces = true;
            }
            Assert.That(hasWorkspaces);
        }




    }
}
