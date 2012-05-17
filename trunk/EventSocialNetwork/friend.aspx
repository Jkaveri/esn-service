<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/logined.master" AutoEventWireup="true"
    CodeFile="friend.aspx.cs" Inherits="friend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/friend.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="friendNav">
        <ul>
            <li class="targetLnk"><a href="friend.aspx" style="color: White;">Danh sách bạn bè</a></li>
            <li><a href="findfriend.aspx">Tìm bạn</a></li>
            <li><a href="invitation.aspx">Lời mời kết bạn</a></li>
            <li><a href="notification.aspx">Thông báo</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <div>
            <asp:ListView ID="lvFriend" runat="server" EnableTheming="true" OnItemCommand="Action">
                <LayoutTemplate>
                    <table border="0" cellspacing="10" cellpadding="0">
                        <tr id="groupPlaceholder" runat="server">
                        </tr>
                    </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <tr>
                        <td id="itemPlaceholder" runat="server">
                        </td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td>
                        <table id="tblInfo">
                            <tr>
                                <td>
                                    <a href='personalpage.aspx?id=<%#Eval("AccID")%>'>
                                        <img src='<%#SetAvatar(Convert.ToString(Eval("Avatar"))) %>' width="50px" height="50px"/></a>
                                    <img src='<%#"Images/Icon/" + setIcon(true) %>' />
                                </td>
                                <td id="txtName">
                                    <%#Eval("Name")%>
                                </td>
                                <td>
                                    <asp:Button Text="Hủy kết nối bạn bè" CssClass="btnCancel" runat="server" CommandName="cmdUnFriend" CommandArgument='<%#Eval("AccID")%>' />
                                </td>
                            </tr>
                        </table>
                    </td>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
