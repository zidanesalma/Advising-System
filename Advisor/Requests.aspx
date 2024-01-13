<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Requests.aspx.cs" Inherits="Advising_System.Requests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="noAlign.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id ="table1" runat="server">
                <tr>                    
                    <th>Request ID</th>
                    <th>Request Type</th>
                    <th>Comment ID</th> 
                    <th>Status</th> 
                    <th> Credit Hours</th>                    
                    <th>Course ID</th>
                     <th>Student ID</th>
                    <th>Advisor ID</th>
                  
                </tr>
            </table>
            <p>
                <asp:TextBox ID="advisor_id" placeholder="Enter advisor id" Width="355px" Height="40px" runat="server" ></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="request" runat="server" Width="155px" Height="35px" OnClick="View_Requests" Text="View requests" />
            </p>        
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdvisorPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>