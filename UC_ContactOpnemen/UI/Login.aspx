<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormsIdentity.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body style="font-family: Arial, Helvetica, sans-serif; font-size: small">
   <form id="form1" runat="server">

      <div>
                 <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="False" IncludeStyleBlock="False" Orientation="Horizontal" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px">
                     <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                     <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                     <DynamicMenuStyle BackColor="#FFFBD6" />
                     <DynamicSelectedStyle BackColor="#FFCC66" />
                    <Items>
                        <asp:MenuItem NavigateUrl="~/UI/Login.aspx" Text="Login"/>
                        <asp:MenuItem NavigateUrl="~/UI/Register.aspx" Text="Registreer"/>
                        <asp:MenuItem NavigateUrl="~/UI/UIContact.aspx" Text="Contact"/>                        
                    </Items>
                     <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                     <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                     <StaticSelectedStyle BackColor="#FFCC66" />
                </asp:Menu>
         <h4 style="font-size: medium">Log In</h4>
         <hr />
         <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
            <p>
               <asp:Literal runat="server" ID="StatusText" />
            </p>
         </asp:PlaceHolder>
         <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false">
            <div style="margin-bottom: 10px">
               <asp:Label runat="server" AssociatedControlID="UserName">Gebruikersnaam</asp:Label>
               <div>
                  <asp:TextBox runat="server" ID="UserName" />
               </div>
            </div>
            <div style="margin-bottom: 10px">
               <asp:Label runat="server" AssociatedControlID="Password">Wachtwoord</asp:Label>
               <div>
                  <asp:TextBox runat="server" ID="Password" TextMode="Password" />
               </div>
            </div>
            <div style="margin-bottom: 10px">
               <div>
                  <asp:Button runat="server" OnClick="SignIn" Text="Inloggen" />
               </div>
            </div>
         </asp:PlaceHolder>
         <asp:PlaceHolder runat="server" ID="LogoutButton" Visible="false">
            <div>
               <div>
                  <asp:Button runat="server" OnClick="SignOut" Text="Uitloggen" />
               </div>
            </div>
         </asp:PlaceHolder>
      </div>
   </form>
</body>
</html>