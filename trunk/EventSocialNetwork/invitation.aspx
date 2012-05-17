<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/logined.master" AutoEventWireup="true"
    CodeFile="invitation.aspx.cs" Inherits="message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/friend.css" rel="stylesheet" type="text/css" />
    <link href="Styles/invitation.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="friendNav">
        <ul>
            <li><a href="friend.aspx">Danh sách bạn bè</a></li>
            <li><a href="findfriend.aspx">Tìm bạn</a></li>
            <li class="targetLnk"><a href="invitation.aspx" style="color: White; ">Lời mời kết bạn</a></li>
            <li><a href="notification.aspx" style="color: White; ">Thông báo</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <div>
            <asp:ListView ID="lvInvitation" runat="server" OnItemCommand="Action">
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
                        <table border="0" cellpadding="0" cellspacing="15">
                            <tr>
                                <td id="avatar">
                                   <a href='personalpage.aspx?id=<%#Eval("AccID")%>'>
                                        <img src='<%#SetAvatar(Convert.ToString(Eval("Avatar"))) %>' width="50px" height="50px"/></a>
                                </td>
                                <td id="txtInfo">
                                    <span id="txtName"><%#Eval("Name")%><br /></span>
                                    <asp:Button ID="Button1" CssClass="Button1" Text="Đồng ý" runat="server" CommandName="cmdAgree" CommandArgument='<%#Eval("AccID") + "&" + Eval("ActiID") %>' />
                                    <asp:Button ID="Button2" CssClass="Button2" Text="Không đồng ý" runat="server" CommandName="cmdDisagree"
                                        CommandArgument='<%#Eval("AccID") + "&" + Eval("ActiID") %>' />
                                </td>
                            </tr>
                        </table>
                    </td>
                </ItemTemplate>
            </asp:ListView>
        </div>
</asp:Content>
