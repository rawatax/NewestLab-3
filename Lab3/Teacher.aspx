<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="Lab3.Teacher" MasterPageFile="~/Site.Master" Title="Teachers" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Register a Teacher</h1>
    <br />
    <form>
        <asp:Label ID="Errorlabel" runat="server"></asp:Label>
        <asp:Label ID="SuccessLabel" runat="server"></asp:Label>
        <br />
        <br />
        <label>First Name</label>
        <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="FirstName" Display="Static" ErrorMessage="First Name is required." ID="validateFirstName" runat="Server" ForeColor="Red" />
        <label>Last Name</label>
        <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="LastName" Display="Static" ErrorMessage="Last Name is required." ID="validateLastName" runat="Server" ForeColor="Red" />
        <br />
        <br />
        <label>Phone Number</label>
        <asp:TextBox ID="PhoneNumber" runat="server" type="number"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="PhoneNumber" Display="Static" ErrorMessage="Phone Number is required." ID="validatePhoneNumber" runat="Server" ForeColor="Red" />
        <label>Email</label>
        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="Email" Display="Static" ErrorMessage="Email is required." ID="validateEmail" runat="Server" ForeColor="Red" />
        <br />
        <br />
        <label>Grade</label>
        <asp:DropDownList ID="dropGrade" runat="server">
            <asp:ListItem Value="1" Text="1"></asp:ListItem>
            <asp:ListItem Value="2" Text="2"></asp:ListItem>
            <asp:ListItem Value="3" Text="3"></asp:ListItem>
            <asp:ListItem Value="4" Text="4"></asp:ListItem>
            <asp:ListItem Value="5" Text="5"></asp:ListItem>
            <asp:ListItem Value="6" Text="6"></asp:ListItem>
            <asp:ListItem Value="7" Text="7"></asp:ListItem>
            <asp:ListItem Value="8" Text="8"></asp:ListItem>
            <asp:ListItem Value="9" Text="9"></asp:ListItem>
            <asp:ListItem Value="10" Text="10"></asp:ListItem>
            <asp:ListItem Value="11" Text="11"></asp:ListItem>
            <asp:ListItem Value="12" Text="12"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="schoolDropDown" runat="server" AutoPostBack="true"></asp:DropDownList>
        <br />
        <br />
        <label>Username</label>
        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="UserName" Display="Static" ErrorMessage="UserName is required." ID="validateUserName" runat="Server" ForeColor="Red" />
        <br />
        <br />
        <label>Password</label>
        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="Password" Display="Static" ErrorMessage="Password is required." ID="validatePassword" runat="Server" ForeColor="Red" />
        <label>Re-enter password</label>
        <asp:TextBox ID="Password2" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="Password2" Display="Static" ErrorMessage="Please re-enter password." ID="validatePassword2" runat="Server" ForeColor="Red" />
        <br />
        <br />
        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="SUBMIT" />
        <asp:Button ID="btnClear" OnClick="btnClear_Click" runat="server" Text="CLEAR" CausesValidation="false" />
    </form>
</asp:Content>
