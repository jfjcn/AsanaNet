using System;
using System.Configuration;
using NUnit.Framework;
using RoiCode.AsanaDotNet;

namespace AsanaNetSpecs
{
    [TestFixture]
    class When_using_the_Asana_Repository
    {

        protected static AsanaRepository AsanaRepository =
            new AsanaRepository(ConfigurationManager.AppSettings["AsanaPersonalAccessToken"]);

        protected static long AsanaMainUserId =
                    Convert.ToInt64(ConfigurationManager.AppSettings["AsanaMainUserId"]);

        protected static long BulletJournalWorkspaceId =
                            Convert.ToInt64(ConfigurationManager.AppSettings["BulletJournalWorkspaceId"]);

        protected static long BulletJournalDailyId =
                    Convert.ToInt64(ConfigurationManager.AppSettings["BulletJournalDailyId"]);

        protected static long BulletJournalWeeklyId =
                    Convert.ToInt64(ConfigurationManager.AppSettings["BulletJournalWeeklyId"]);

        protected static long BulletJournalMontlyId =
                    Convert.ToInt64(ConfigurationManager.AppSettings["BulletJournalMontlyId"]);

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
            var myWorkspaces = AsanaRepository.GetMyWorkspaces();
            var hasWorkspaces = false;
            foreach (AsanaWorkspace asanaWorkspace in myWorkspaces)
            {
                hasWorkspaces = true;
            }
            Assert.That(hasWorkspaces);
        }

        [Test]
        public void _030_we_should_be_able_to_get_all_our_tasks_from_our_bullet_journal_workspace()
        {
            var myTasks = AsanaRepository.GetMyTasksForMyWorkspaceWithId(BulletJournalWorkspaceId);
            var taskCounter = 0;
            foreach (AsanaTask asanaProject in myTasks)
            {
                taskCounter++;
            }
            Assert.That(taskCounter, Is.GreaterThan(3));
        }

        [Test]
        public void _040_we_should_be_able_to_get_all_our_tasks_for_a_few_projects()
        {
            var projectIdsToGet = new[] { BulletJournalDailyId, BulletJournalWeeklyId, BulletJournalMontlyId };
            var myProjects = AsanaRepository.GetMyTasksForProjectsWithId(projectIdsToGet);
            var projectCounter = 0;
            foreach (AsanaProject asanaProject in myProjects)
            {
                projectCounter++;
            }
            Assert.That(projectCounter, Is.EqualTo(projectIdsToGet.Length));
        }

        [Test]
        public void _050_we_should_be_able_to_create_a_new_task()
        {
            var userToWhichToAssignTask =
                new AsanaUser()
                {
                    ID = AsanaMainUserId
                };

            var projectToWhichToAddTask =
                new AsanaProject()
                {
                    ID = BulletJournalDailyId
                };

            var newlyCreatedTask =
                AsanaRepository.CreateAsanaTask(
                    "new task created from specs",
                    userToWhichToAssignTask,
                    projectToWhichToAddTask);

            Assert.That(newlyCreatedTask.ID, Is.GreaterThan(0));
        }






    }
}
