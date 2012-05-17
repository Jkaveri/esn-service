<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="thongbao.aspx.cs" Inherits="Client_side_Thongbao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:Label ID="btnThongBao" runat="server" CssClass="txtThongbao">
        Chúc mừng bạn đã đăng ký thành công.<br />
        Click vào <a href="home.aspx">đây</a> để quay về trang chủ
    </asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
