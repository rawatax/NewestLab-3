<%@ Page Language="C#" Title="Students" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="Lab3.Students" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Students</h1>
    <br />
    <h3>New Student</h3>
    <form>
        <asp:Label ID="Errorlabel" runat="server"></asp:Label>
        <asp:Label ID="SuccessLabel" runat="server"></asp:Label>
        <br />
        <br />
        <label>First Name</label>
        <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="FirstName" Display="Static" ErrorMessage="First Name is required." ID="validateFirstName" runat="Server" ForeColor="Red" />
        <br />
        <br />
        <label>Last Name</label>
        <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="LastName" Display="Static" ErrorMessage="Last Name is required." ID="validateLastName" runat="Server" ForeColor="Red" />
        <br />
        <br />
        <label>Age</label>
        <asp:TextBox ID="Age" runat="server" type="number"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="Age" Display="Static" ErrorMessage="Age is required." ID="validateAge" runat="Server" ForeColor="Red" />
        <br />
        <br />
        <label>Notes</label>
        <asp:TextBox ID="Notes" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="Notes" ErrorMessage="Notes are required." ID="validateNotes" runat="Server" ForeColor="Red" />
        <br />
        <br />
        <label>Shirt Size</label>
        <asp:DropDownList ID="dropShirtSize" runat="server">
            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
            <asp:ListItem Value="1" Text="Small"></asp:ListItem>
            <asp:ListItem Value="2" Text="Medium"></asp:ListItem>
            <asp:ListItem Value="3" Text="Large"></asp:ListItem>
            <asp:ListItem Value="4" Text="Extra Large"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <label>Shirt Color</label>
        <asp:DropDownList ID="dropShirtColor" runat="server">
            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
            <asp:ListItem Value="1" Text="Green"></asp:ListItem>
            <asp:ListItem Value="2" Text="Yellow"></asp:ListItem>
            <asp:ListItem Value="3" Text="Blue"></asp:ListItem>
            <asp:ListItem Value="4" Text="Black"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <label>Teacher</label>
        <asp:DropDownList ID="teacherDropDown" runat="server" DataTextField="Event" DataValueField="TeacherID" AutoPostBack="true"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="SUBMIT" />
        <asp:Button ID="btnClear" OnClick="btnClear_Click" runat="server" Text="CLEAR" CausesValidation="false" />
        <asp:Button ID="btnPopulate" OnClick="btnPopulate_Click" runat="server" Text="POPULATE" CausesValidation="false" />
    </form>
    <br />
    <br />
    <h3>Find a Student:</h3>
    <asp:TextBox ID="searchStudent" runat="server" Style="width: 800px"></asp:TextBox>
    <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="SEARCH" CausesValidation="false" />
    <br />
    <br />
    <asp:Table ID="searchTable" runat="server"
        CellPadding="10"
        GridLines="Both"
        HorizontalAlign="Center">
        <asp:TableHeaderRow
            runat="server"
            Font-Bold="true">
            <asp:TableHeaderCell Width="100px">First Name</asp:TableHeaderCell>
            <asp:TableHeaderCell Width="100px">Last Name</asp:TableHeaderCell>
            <asp:TableHeaderCell Width="100px">Edit</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <%--FILE UPLOAD-------------------------------------------------------------------------------------------------------%>
             <h3>File Upload / Download from/to Database using ASP.NET</h3>
    <div>
        <table>
            <tr>
                <td>Select File : </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                <td>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" CausesValidation="false" /></td>
            </tr>
        </table>
        <br />
        <div>
            <%-- Add a Datalist for show uploaded files --%>
            <asp:DataList ID="FileList" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="FileList_ItemCommand">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td><%#Eval("FileName","File Name : {0}") %></td>
                        </tr>
                        <tr>
                            <td><%#String.Format("{0:0.00}",Convert.ToDecimal(Eval("FileSize"))/1024)%> KB</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton CausesValidation="false" ID="lbtnDownload" runat="server" CommandName="Download" CommandArgument=<%#Eval("FileID") %>>Download</asp:LinkButton></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
<%--END OF FILE UPLOAD--------------------------------------------------------------------------------%>
</asp:Content>
