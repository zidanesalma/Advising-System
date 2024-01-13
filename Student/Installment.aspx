<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Installment.aspx.cs" Inherits="AdvisingSystem.Installment" %>

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
                    <th>Payment ID</th>
                    <th>Start Date</th>            
                    <th>Deadline</th>
                    <th>Amount</th> 
                    <th>Status</th>
                </tr>
            </table>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StudentPortal.aspx" style="text-decoration: none;" >Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>

