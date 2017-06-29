<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UIContact.aspx.cs" Inherits="UC_ContactOpnemen.UI.UIContact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
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
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

        <asp:Label ID="lbName" runat="server" Text="Naam"></asp:Label>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbName" ErrorMessage="Naam is verplicht">*</asp:RequiredFieldValidator>

        <asp:CheckBox ID="cbAnoniem" runat="server" AutoPostBack="True" OnCheckedChanged="cbAnoniem_CheckedChanged" Text="Anoniem" />

            

    <script type="text/javascript" language="javascript">
        function ConfirmOnClick()
        {
          if (confirm("U bent niet ingelogd, bericht toch versturen?")==true)
              return true
          else
              return false;
        }

    </script>

        <br />

        <asp:Label ID="lbEmail" runat="server" Text="E-mailadres"></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEmail" ErrorMessage="E-mailadres is verplicht">*</asp:RequiredFieldValidator>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbEmail" ErrorMessage=" Voer een geldig e-mailadres in" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>

        <br />

        <asp:Label ID="lbSubject" runat="server" Text="Onderwerp"></asp:Label>
        <asp:TextBox ID="tbSubject" runat="server"></asp:TextBox>

        <br />
        <br />

        <asp:Label ID="lbMessage" runat="server" Text="Bericht:"></asp:Label>
        <p>
        <asp:TextBox ID="tbMessage" runat="server" Height="150" TextMode="MultiLine" Width="200"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbMessage" ErrorMessage="Bericht dient ingevuld te zijn" SetFocusOnError="True">*</asp:RequiredFieldValidator>

        </p>
        <p>

        <asp:Button ID="btSend" runat="server" OnClick="btSend_Click" Text="Verzenden"/>
            
        </p>

        </div>
        <asp:GridView ID="gvGetSupervisors" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
