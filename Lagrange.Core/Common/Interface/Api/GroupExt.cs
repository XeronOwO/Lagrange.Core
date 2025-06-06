using Lagrange.Core.Common.Entity;
using Lagrange.Core.Message;
using Lagrange.Core.Message.Entity;

namespace Lagrange.Core.Common.Interface.Api;

public static class GroupExt
{
    /// <summary>
    /// Mute the member in the group, Bot must be admin
    /// </summary>
    /// <param name="bot">target BotContext</param>
    /// <param name="groupUin">The uin for target group</param>
    /// <param name="targetUin">The uin for target member in such group</param>
    /// <param name="duration">The duration in seconds, 0 for unmute member</param>
    /// <returns>Successfully muted or not</returns>
    public static Task<bool> MuteGroupMember(this BotContext bot, uint groupUin, uint targetUin, uint duration)
        => bot.ContextCollection.Business.OperationLogic.MuteGroupMember(groupUin, targetUin, duration);

    /// <summary>
    /// Mute the group
    /// </summary>
    /// <param name="bot">target BotContext</param>
    /// <param name="groupUin">The uin for target group</param>
    /// <param name="isMute">true for mute and false for unmute</param>
    /// <returns>Successfully muted or not</returns>
    public static Task<bool> MuteGroupGlobal(this BotContext bot, uint groupUin, bool isMute)
        => bot.ContextCollection.Business.OperationLogic.MuteGroupGlobal(groupUin, isMute);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bot">target BotContext</param>
    /// <param name="groupUin">The uin for target group</param>
    /// <param name="targetUin">The uin for target member in such group</param>
    /// <param name="rejectAddRequest">whether the kicked member can request</param>
    /// <returns>Successfully kicked or not</returns>
    public static Task<bool> KickGroupMember(this BotContext bot, uint groupUin, uint targetUin, bool rejectAddRequest)
        => bot.ContextCollection.Business.OperationLogic.KickGroupMember(groupUin, targetUin, rejectAddRequest, "");

    public static Task<bool> KickGroupMember(this BotContext bot, uint groupUin, uint targetUin, bool rejectAddRequest, string reason)
        => bot.ContextCollection.Business.OperationLogic.KickGroupMember(groupUin, targetUin, rejectAddRequest, reason);

    public static Task<bool> SetGroupAdmin(this BotContext bot, uint groupUin, uint targetUin, bool isAdmin)
        => bot.ContextCollection.Business.OperationLogic.SetGroupAdmin(groupUin, targetUin, isAdmin);

    // 300204 Check group manager:Not an administrator
    public static Task<(int, string?)> SetGroupTodo(this BotContext bot, uint groupUin, uint sequence)
        => bot.ContextCollection.Business.OperationLogic.SetGroupTodo(groupUin, sequence);

    public static Task<(int, string?)> RemoveGroupTodo(this BotContext bot, uint groupUin)
        => bot.ContextCollection.Business.OperationLogic.RemoveGroupTodo(groupUin);

    public static Task<(int, string?)> FinishGroupTodo(this BotContext bot, uint groupUin)
        => bot.ContextCollection.Business.OperationLogic.FinishGroupTodo(groupUin);

    public static Task<BotGetGroupTodoResult> GetGroupTodo(this BotContext bot, uint groupUin)
        => bot.ContextCollection.Business.OperationLogic.GetGroupTodo(groupUin);

    public static Task<bool> SetGroupBot(this BotContext bot, uint targetUin, uint On, uint groupUin)
        => bot.ContextCollection.Business.OperationLogic.SetGroupBot(targetUin, On, groupUin);

    [Obsolete("Cosider using SetGroupBotHD(BotContext, uint, uint, string?, string?) instead")]
    public static Task<bool> SetGroupBotHD(this BotContext bot, uint targetUin, uint groupUin)
        => bot.SetGroupBotHD(targetUin, groupUin, null, null);
    public static Task<bool> SetGroupBotHD(this BotContext bot, uint targetUin, uint groupUin, string? data_1, string? data_2)
        => bot.ContextCollection.Business.OperationLogic.SetGroupBotHD(targetUin, groupUin, data_1, data_2);

    public static Task<bool> RenameGroupMember(this BotContext bot, uint groupUin, uint targetUin, string targetName)
        => bot.ContextCollection.Business.OperationLogic.RenameGroupMember(groupUin, targetUin, targetName);

    public static Task<bool> RenameGroup(this BotContext bot, uint groupUin, string targetName)
        => bot.ContextCollection.Business.OperationLogic.RenameGroup(groupUin, targetName);

    public static Task<bool> RemarkGroup(this BotContext bot, uint groupUin, string targetRemark)
        => bot.ContextCollection.Business.OperationLogic.RemarkGroup(groupUin, targetRemark);

    public static Task<bool> LeaveGroup(this BotContext bot, uint groupUin)
        => bot.ContextCollection.Business.OperationLogic.LeaveGroup(groupUin);

    public static Task<bool> InviteGroup(this BotContext bot, uint groupUin, Dictionary<uint, uint?> invitedUins)
        => bot.ContextCollection.Business.OperationLogic.InviteGroup(groupUin, invitedUins);

    public static Task<bool> SetGroupRequest(this BotContext bot, BotGroupRequest request, bool accept = true, string reason = "")
        => bot.ContextCollection.Business.OperationLogic.SetGroupRequest(request.GroupUin, request.Sequence, (uint)request.EventType, accept, reason);

    public static Task<bool> SetGroupFilteredRequest(this BotContext bot, BotGroupRequest request, bool accept = true, string reason = "")
        => bot.ContextCollection.Business.OperationLogic.SetGroupFilteredRequest(request.GroupUin, request.Sequence, (uint)request.EventType, accept, reason);

    public static Task<bool> SetFriendRequest(this BotContext bot, BotFriendRequest request, bool accept = true)
        => bot.ContextCollection.Business.OperationLogic.SetFriendRequest(request.SourceUid, accept);

    public static Task<bool> GroupPoke(this BotContext bot, uint groupUin, uint friendUin)
        => bot.ContextCollection.Business.OperationLogic.GroupPoke(groupUin, friendUin);

    public static Task<bool> SetEssenceMessage(this BotContext bot, MessageChain chain)
        => bot.ContextCollection.Business.OperationLogic.SetEssenceMessage(chain.GroupUin ?? 0, chain.Sequence, (uint)(chain.MessageId & 0xFFFFFFFF));

    public static Task<bool> RemoveEssenceMessage(this BotContext bot, MessageChain chain)
        => bot.ContextCollection.Business.OperationLogic.RemoveEssenceMessage(chain.GroupUin ?? 0, chain.Sequence, (uint)(chain.MessageId & 0xFFFFFFFF));

    public static Task<bool> GroupSetSpecialTitle(this BotContext bot, uint groupUin, uint targetUin, string title)
        => bot.ContextCollection.Business.OperationLogic.GroupSetSpecialTitle(groupUin, targetUin, title);

    public static Task<bool> GroupSetMessageReaction(this BotContext bot, uint groupUin, uint sequence, string code)
        => bot.ContextCollection.Business.OperationLogic.SetMessageReaction(groupUin, sequence, code, true);

    public static Task<bool> GroupSetMessageReaction(this BotContext bot, uint groupUin, uint sequence, string code, bool isSet)
        => bot.ContextCollection.Business.OperationLogic.SetMessageReaction(groupUin, sequence, code, isSet);

    public static Task<bool> GroupSetAvatar(this BotContext bot, uint groupUin, ImageEntity imageEntity)
        => bot.ContextCollection.Business.OperationLogic.GroupSetAvatar(groupUin, imageEntity);

    public static Task<(uint, uint)> GroupRemainAtAll(this BotContext bot, uint groupUin)
        => bot.ContextCollection.Business.OperationLogic.GroupRemainAtAll(groupUin);

    #region Group File System

    public static Task<ulong> FetchGroupFSSpace(this BotContext bot, uint groupUin)
        => bot.ContextCollection.Business.OperationLogic.FetchGroupFSSpace(groupUin);

    public static Task<uint> FetchGroupFSCount(this BotContext bot, uint groupUin)
        => bot.ContextCollection.Business.OperationLogic.FetchGroupFSCount(groupUin);

    public static Task<List<IBotFSEntry>> FetchGroupFSList(this BotContext bot, uint groupUin, string targetDirectory = "/")
        => bot.ContextCollection.Business.OperationLogic.FetchGroupFSList(groupUin, targetDirectory);

    public static Task<string> FetchGroupFSDownload(this BotContext bot, uint groupUin, string fileId)
        => bot.ContextCollection.Business.OperationLogic.FetchGroupFSDownload(groupUin, fileId);

    public static Task<(int RetCode, string RetMsg)> GroupFSMove(this BotContext bot, uint groupUin, string fileId, string parentDirectory, string targetDirectory)
        => bot.ContextCollection.Business.OperationLogic.GroupFSMove(groupUin, fileId, parentDirectory, targetDirectory);

    public static Task<(int RetCode, string RetMsg)> GroupFSDelete(this BotContext bot, uint groupUin, string fileId)
        => bot.ContextCollection.Business.OperationLogic.GroupFSDelete(groupUin, fileId);

    public static Task<(int RetCode, string RetMsg)> GroupFSCreateFolder(this BotContext bot, uint groupUin, string name)
        => bot.ContextCollection.Business.OperationLogic.GroupFSCreateFolder(groupUin, name);

    public static Task<(int RetCode, string RetMsg)> GroupFSDeleteFolder(this BotContext bot, uint groupUin, string folderId)
        => bot.ContextCollection.Business.OperationLogic.GroupFSDeleteFolder(groupUin, folderId);

    public static Task<(int RetCode, string RetMsg)> GroupFSRenameFolder(this BotContext bot, uint groupUin, string folderId, string newFolderName)
        => bot.ContextCollection.Business.OperationLogic.GroupFSRenameFolder(groupUin, folderId, newFolderName);

    public static async Task<bool> GroupFSUpload(this BotContext bot, uint groupUin, FileEntity fileEntity, string targetDirectory = "/")
        => (await GroupFSUploadWithResult(bot, groupUin, fileEntity, targetDirectory)).IsSuccess;

    public static Task<OperationResult<object>> GroupFSUploadWithResult(this BotContext bot, uint groupUin, FileEntity fileEntity, string targetDirectory = "/")
        => bot.ContextCollection.Business.OperationLogic.GroupFSUploadWithResult(groupUin, fileEntity, targetDirectory);

    #endregion
}