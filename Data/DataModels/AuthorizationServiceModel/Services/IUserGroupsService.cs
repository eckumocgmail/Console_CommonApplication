using ApplicationDb.Entities;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;

using System.Collections.Generic;

public interface IUserGroupsService
{
    IActionResult Complete(UserGroups entity);
    List<BusinessFunction> GetBusinessFunctions(int userId);
    UserGroup GetGroup(int id);
    List<UserGroupMessage> GetGroupMessages(int groupId, int page, int size);
    List<UserGroup> GetGroups();
    List<MessageProtocol> GetMessageProtocolsForUser(int userId);
    JArray GetMessagesForBusinessFunction(BusinessFunction function);
    List<UserPerson> GetPersons(int groupId);
    List<UserGroup> GetUserGroups(int userId);
    string GetUsername(int userId);
    bool IsUserInGroup(int groupId, int userId);
    void JoinToGroup(int groupId, int userId);
    void LeaveGroup(int groupId, int userId);
    void PublishIntoGroup(int userId, int groupId, UserMessage message);
}