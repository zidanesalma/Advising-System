<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pendingRequests.aspx.cs" Inherits="Advising_System.pendingRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="noAlign.css"/>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <table id ="table2" runat="server">
                <tr>                    
                    <th>Request ID</th>
                    <th>Request Type</th>
                    <th>Comment </th>            
                    <th>Status Code</th>
                    <th>Credit Hours</th>                    
                    <th>Student ID</th>
                    <th>Advisor ID</th>
                    <th>Course ID</th>
                  
                </tr>
            </table>
            <p>    
                <asp:Button ID="request2" runat="server" OnClick="View_pendingRequests" Width="155px" Height="35px" Text="View pending requests" />
            </p>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdvisorPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>