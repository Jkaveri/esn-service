<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="home.aspx.cs" Inherits="Client_side_home1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../styles/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <h2 id="register">
        Đăng ký</h2>
    <hr />
    <table border="1" cellpadding="0" cellspacing="0">
        <tr>
            <td><asp:Label ID="Label7" Text="Họ và tên: " runat="server" />
            </td>
            <td><asp:TextBox ID="txtName" runat="server" CssClass="txtRegister" />
            </td>
        </tr>

        <tr>
            <td><asp:Label ID="Label8" Text="Email: " runat="server" />
            </td>
            <td> <asp:TextBox ID="txtEmail" runat="server" CssClass="txtRegister" />
            </td>
        </tr>

        <tr>
            <td><asp:Label ID="Label9" Text="Mật khẩu: " runat="server" />
            </td>
            <td><asp:TextBox ID="txtPassword" runat="server" CssClass="txtRegister" TextMode="Password" />
            </td>
        </tr>

        <tr>
            <td><asp:Label ID="Label10" Text="Nhập lại mật khẩu: " runat="server" />
            </td>
            <td><asp:TextBox ID="txtRePassWord" runat="server" CssClass="txtRegister" TextMode="Password" />
            </td>
        </tr>

        <tr>
            <td><asp:Label ID="Label11" Text="Giới tính: " runat="server" />
            </td>
            <td><asp:DropDownList ID="ddlGender" runat="server" CssClass="ddlGender">
            <asp:ListItem Selected="True">Nam</asp:ListItem>
            <asp:ListItem Value="Nu">Nữ</asp:ListItem>
        </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td><asp:Label ID="Label1" Text="Ngày sinh: " runat="server" />
            </td>
            <td><asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="ddlDayOfBirth" runat="server" CssClass="ddlDOB">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMonthOfBirth" runat="server" OnSelectedIndexChanged="ddlMonthOfBirth_SelectedIndexChanged"
                    AutoPostBack="true" CssClass="ddlDOB">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlYearOfBirth" runat="server" OnSelectedIndexChanged="ddlYearOfBirth_SelectedIndexChanged"
                    AutoPostBack="true" CssClass="ddlYOB">
                </asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnSignUp" runat="server" Text="Đăng ký" OnClick="btnSignUp_Click"
        CssClass="btnRegister" /><br />
    <asp:Label ID="lblValidateShow" runat="server" Text="" Visible="false" BorderWidth="1px"
        BorderColor="Red" />
</asp:Content>
