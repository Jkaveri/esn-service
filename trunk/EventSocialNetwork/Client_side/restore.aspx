<%@ Page Language="C#" AutoEventWireup="true" CodeFile="restore.aspx.cs" Inherits="Client_side_home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mạng xã hội sự kiện</title>
    <link href="~/styles/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <!-- HEADER -->
        <div id="bg_header">
            <div id="header">
                <a href="#">
                    <img src="../Images/login.png" id="imgLogin" /></a>
                <div id="login">
                    <asp:Label Text="Email: " runat="server" ID="emailLogin" />
                    <asp:TextBox runat="server" />
                    <asp:Label Text="Mật khẩu: " runat="server" ID="passLogin" />
                    <asp:TextBox runat="server" TextMode="Password" />
                    <a href="#" id="recoverPass">Quên mật khẩu</a> <a href="#" id="lnkLogin">Đăng nhập</a>
                </div>
            </div>
            <!--End #header-->
        </div>
        <!--End #bg_header-->
        <!-- CONTENT -->
        <div id="bg_content">
            <div id="content">
                <div id="primary">
                    <img src="../Images/iphone.jpg" id="iphone" />
                    <a href="#" id="lnkIphone">Iphone</a>
                    <img src="../Images/android.jpg" id="android" />
                    <a href="#" id="lnkAndroid">Android</a>
                </div>
                <div id="sidebar">
                    <h2 id="register">
                        Đăng ký</h2>
                    <hr />
                    <div class="frmRegister">
                        <asp:Label Text="Họ và tên: " runat="server" />
                        <asp:TextBox runat="server" CssClass="txtRegister" /></div>
                    <div class="frmRegister">
                        <asp:Label ID="Label1" Text="Email: " runat="server" />
                        <asp:TextBox runat="server" CssClass="txtRegister" /></div>
                    <div class="frmRegister">
                        <asp:Label Text="Mật khẩu: " runat="server" />
                        <asp:TextBox runat="server" CssClass="txtRegister" /></div>
                    <div class="frmRegister">
                        <asp:Label Text="Nhập lại mật khẩu: " runat="server" />
                        <asp:TextBox runat="server" CssClass="txtRegister" /></div>
                    <div class="frmRegister" id="gender">
                        <asp:Label Text="Giới tính: " runat="server" />
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Text="Nam" />
                            <asp:ListItem Text="Nữ" />
                        </asp:DropDownList>
                    </div>
                    <div>
                        <a href="#" id="btnRegister">Đăng ký</a></div>
                </div>
            </div>
        </div>
        <div id="bg_footer">
            <div id="footer">
                <img src="../Images/logo_footer.gif" id="img_footer" />
                <p id="copyright">
                    © 2012 - Bản quyền thuộc về Aprotrain Aptech</p>
            </div>
            <!--End #footer-->
        </div>
        <!--End #bg_footer-->
    </div>
    <!--End #container-->
    </form>
</body>
</html>
