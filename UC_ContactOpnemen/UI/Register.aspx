<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebFormsIdentity.Register" %>

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
        <h4 style="font-size: medium">Registreer uw account</h4>
        <hr />
        <p>

            <asp:Literal runat="server" ID="StatusMessage" />
        </p>                
        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="UserName">Gebruikersnaam</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="UserName" />                
            </div>
        </div>
        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="Password">Wachtwoord</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />                
               
     <asp:CompareValidator ID="CompareValidator1" runat="server" 
     ControlToValidate="ConfirmPassword"
     ControlToCompare="Password"
     ErrorMessage="Wachtwoorden komen niet overeen" 
     ToolTip="Password must be the same" EnableTheming="True" SetFocusOnError="True" Display="None"/>
            </div>
        </div>
               
        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Bevestig wachtwoord</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />                

     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
             ControlToValidate="ConfirmPassword"
             ErrorMessage="'Bevestig wactwoord' is een verplicht veld"
             EnableClientScript="true"
             SetFocusOnError="true"
         >*</asp:RequiredFieldValidator>
               
                        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="Email">E-mailadres</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Email" />                

     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
             ControlToValidate="Email"
             ErrorMessage="Email is verplicht"
             EnableClientScript="true"
             SetFocusOnError="true"
         >*</asp:RequiredFieldValidator>
               
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" Display="None" ErrorMessage="Voer een geldig emailadres in" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
        </div>
                        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="Phonenumber">Telefoonnummer</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Phonenumber" />                

     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
             ControlToValidate="Phonenumber"
             ErrorMessage="Telefoonnummer is verplicht"
             EnableClientScript="true"
             SetFocusOnError="true"
         >*</asp:RequiredFieldValidator>
               
            </div>
        </div>
            </div>
        </div>
        <div>
            <div>
                        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="Role">Gebruikersrol</asp:Label>
            <div>
                <asp:DropDownList runat="server" ID="Role" >
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>Student</asp:ListItem>
                    <asp:ListItem>Supervisor</asp:ListItem>
                    <asp:ListItem>Teacher</asp:ListItem>
                    <asp:ListItem>User</asp:ListItem>
                </asp:DropDownList>
        <br />
        <p>
        
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registreer" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />

    </form>
</body>
</html>