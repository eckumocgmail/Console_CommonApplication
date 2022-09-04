
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class UserGroupsTest : TestingElement
{
    public UserGroupsTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {

        
        return this.DoTest<UserGroupsService>((service) => {


            /*JArray GetMessagesForBusinessFunction(BusinessFunction function);
            List<UserPerson> GetPersons(int groupId);
            List<UserGroup> GetUserGroups(int userId);
            string GetUsername(int userId);
            bool IsUserInGroup(int groupId, int userId);
            void JoinToGroup(int groupId, int userId);
            void LeaveGroup(int groupId, int userId);
            void PublishIntoGroup(int userId, int groupId, UserMessage message);*/
            using (var db = AppProviderService.GetInstance().Get<AuthorizationDataModel>())
            {
                /*List<BusinessFunction> functions =
                    groups.GetBusinessFunctions(db.Users.First().ID);

                this.Info(groups.GetGroups());
                this.Messages.Add($"{typeof(UserGroupsService).GetTypeName()} умеет формировать формы по сведениям о бизнес-функциях пользовательских групп");
                */

                //groups.GetMessageProtocolsForUser(userId)
                //(service) => {


                    /*JArray GetMessagesForBusinessFunction(BusinessFunction function);
                    List<UserPerson> GetPersons(int groupId);
                    List<UserGroup> GetUserGroups(int userId);
                    string GetUsername(int userId);
                    bool IsUserInGroup(int groupId, int userId);
                    void JoinToGroup(int groupId, int userId);
                    void LeaveGroup(int groupId, int userId);
                    void PublishIntoGroup(int userId, int groupId, UserMessage message);*/
                   
                //}
            }
        });
            
 
    }
}
 