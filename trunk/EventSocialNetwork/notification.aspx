<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/logined.master" AutoEventWireup="true"
    CodeFile="notification.aspx.cs" Inherits="notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/friend.css" rel="stylesheet" type="text/css" />
    <link href="Styles/notification.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="friendNav">
        <ul>
            <li><a href="friend.aspx">Danh sách bạn bè</a></li>
            <li><a href="findfriend.aspx">Tìm bạn</a></li>
            <li><a href="invitation.aspx">Lời mời kết bạn</a></li>
            <li class="targetLnk"><a href="notification.aspx" style="color: White; ">Thông báo</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <div>
            <asp:ListView ID="lvNotification" runat="server" OnItemCommand="Action">
                <LayoutTemplate>
                    <table cellpadding="20px">
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
                        <table border="0" cellpadding="0" cellspacing="8">
                            <tr id="notification">
                                <td>
                                    <a href='personalpage.aspx?id=<%#Eval("AccID")%>'>
                                        <img src='<%#SetAvatar(Convert.ToString(Eval("Avatar"))) %>' width="50px" height="50px"/></a>
                                </td>
                                <td id="text">
                                    <%#string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:dddd, d MMMM, yyyy}", Eval("DayCreate"))%><br />
                                    <%#Eval("Name") %>
                                    <%#Eval("Description") %><br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
