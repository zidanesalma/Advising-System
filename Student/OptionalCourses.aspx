<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OptionalCourses.aspx.cs" Inherits="AdvisingSystem.OptionalCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="noAlign.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:DropDownList ID="DropDownList1" AutoPostBack="True" OnSelectedIndexChanged="ddlFirst_SelectedIndexChanged" runat="server"  placeholder="Choose Your Semester" Height="40px" Width="355px" >
                </asp:DropDownList>
            </p>

            <table id ="table1" runat="server">
                <tr>                    
                    <th>Course Name</th>
                    <th>Course ID</th>            
                </tr>
            </table>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StudentPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
