<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master"
    AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="Client_side_home1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../styles/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <img src="../Images/iphone.jpg" id="iphone" />
    <a href="#" id="lnkIphone">Iphone</a>
    <img src="../Images/android.jpg" id="android" />
    <a href="#" id="lnkAndroid">Android</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <h2 id="register">
        Đăng ký</h2>
    <hr />
    <div class="frmRegister">
        <asp:Label ID="Label1" Text="Họ và tên: " runat="server" />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="txtRegister" /></div>
    <div class="frmRegister">
        <asp:Label ID="Label2" Text="Email: " runat="server" />
        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtRegister" /></div>
    <div class="frmRegister">
        <asp:Label ID="Label3" Text="Mật khẩu: " runat="server" />
        <asp:TextBox ID="TextBox3" runat="server" CssClass="txtRegister" /></div>
    <div class="frmRegister">
        <asp:Label ID="Label4" Text="Nhập lại mật khẩu: " runat="server" />
        <asp:TextBox ID="TextBox4" runat="server" CssClass="txtRegister" /></div>
    <div class="frmRegister" id="gender">
        <asp:Label ID="Label5" Text="Giới tính: " runat="server" />
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="Nam" />
            <asp:ListItem Text="Nữ" />
        </asp:DropDownList>
    </div>
    <div>
       <a href="#" id="btnRegister">Đăng ký</a>
</asp:Content>
