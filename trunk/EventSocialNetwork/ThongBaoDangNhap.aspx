<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ThongBaoDangNhap.aspx.cs" Inherits="ThongBaoDangNhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:Label ID="btnThongBao" runat="server" CssClass="txtThongbao">
        Đăng nhập thất bại. Tài khoản chưa được đăng ký hoặc chưa kích hoạt.
        Vui lòng kiểm tra hòm thư để kích hoạt tài khoản.<br />
        Hoặc click vào <a href="home.aspx">đây</a> để đăng ký.
    </asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
