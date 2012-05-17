<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/logined.master" AutoEventWireup="true"
    CodeFile="changePassword.aspx.cs" Inherits="changePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/changePwd.css" rel="stylesheet" type="text/css" />
    <link href="Styles/friend.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="friendNav">
        <ul>
            <li><a href="profile.aspx">Quay lại</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <h2 id="txtHeader">
        Đổi mật khẩu</h2>
    <hr />
    <div id="changePwd">
        <table border="0" cellpadding="0" cellspacing="15">
            <tr>
                <td>
                    <asp:Label ID="lblOldPass" Text="Mật khẩu cũ: " runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRePass" Text="Nhập lại mật khẩu: " runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtRePass" runat="server" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNewPass" Text="Mật khẩu mới: " runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" />
                </td>
            </tr>
        </table>
        <asp:Button ID="btnAccept" runat="server" Text="Đồng ý" OnClick="btnAccept_Click"
            CssClass="btnAccept" />
        <asp:Button ID="btnCancel" runat="server" Text="Hủy" OnClick="btnCancel_Click" CssClass="btnCancel" />
        <asp:Label ID="lblValidateShow" runat="server" Text="" Visible="false" BorderWidth="1px"
            BorderColor="Red" />
    </div>
</asp:Content>
