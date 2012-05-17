<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/logined.master" AutoEventWireup="true"
    CodeFile="findfriend.aspx.cs" Inherits="findfriend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/friend.css" rel="stylesheet" type="text/css" />
    <link href="Styles/findFriend.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="Scripts/SexyAlertBox/mootools.js" type="text/javascript"></script>
    <script src="Scripts/SexyAlertBox/sexyalertbox.v1.js" type="text/javascript"></script>
    <link href="Scripts/SexyAlertBox/sexyalertbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        window.addEvent('domready', function () {
            Sexy = new SexyAlertBox();
            //Sexy.error("aaaa", $time);
        });
    </script>
    <div id="friendNav">
        <ul>
            <li><a href="friend.aspx">Danh sách bạn bè</a></li>
            <li class="targetLnk"><a href="findfriend.aspx" style="color: White;">Tìm bạn</a></li>
            <li><a href="invitation.aspx">Lời mời kết bạn</a></li>
            <li><a href="notification.aspx">Thông báo</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <div>
            <asp:TextBox runat="server" ID="txtKeyword" CssClass="txtKeyword" />
            <asp:ImageButton ImageUrl="Images/interface/search.png" runat="server" CssClass="imgSearch"
                OnClick="SearchFrinend" />
        </div>
        <div>
            <asp:ListView ID="lvFriend" runat="server" GroupItemCount="5" OnItemCommand="MakeFriendShip">
                <LayoutTemplate>
                    <hr />
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
                        <div id="oneFriend">
                            <a href='personalpage.aspx?id=<%#Eval("AccID")%>'>
                                <img src='<%#SetAvatar(Convert.ToString(Eval("Avatar"))) %>' width="50px" height="50px" /></a>
                            <span id="txtName">
                                <%#Eval("Name") %></span>
                            <asp:Button ID="Button1" Text="Kết bạn" runat="server" CommandName="cmdMakeFriendShip"
                                CommandArgument='<%#Eval("AccID") %>' CssClass="btnAdd"/>
                        </div>
                    </td>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
