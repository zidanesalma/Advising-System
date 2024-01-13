<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRequest.aspx.cs" Inherits="AdvisingSystem.Student.StudentRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-content: center;
            align-items: center;
            margin: 0;
            height: 100vh;
            text-align: center;
        }

        Button {
            display: block;
            margin: auto;
            text-align: center;
        }

        ListItem {
            font-weight: bold;
            font-family: 'Arial, sans-serif';
        }

        #backButton {
            position: fixed;
            bottom: 30px; /* Adjust this value to set the distance from the bottom */
            left: 30px; /* Adjust this value to set the distance from the right */
            background-color: #b3e0ff; /* Example background color */
            color: #000000; /* Example text color */
            padding: 10px; /* Example padding */
            text-decoration: none;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:RadioButtonList ID="RequestTypes" runat="server" OnSelectedIndexChanged="RequestTypes_SelectedIndexChanged" AutoPostBack="True">

                <asp:ListItem Text="Request credit hours" Value="@credit_hours|credit_hours|credit hours" />
                <asp:ListItem Text="Request course" Value="@courseID|course|course id" />

            </asp:RadioButtonList>
        </p>
        <asp:TextBox ID="Data" runat="server" Height="40px" Width="355px"></asp:TextBox>
        <p>
            <asp:TextBox ID="Comment" placeholder="Enter any comments" runat="server" Height="40px" Width="355px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" Height="35px" Width="155px" />
        </p>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StudentPortal.aspx" Style="font-size: 12pt; color: blue; text-decoration: none;">Back</asp:HyperLink>
        </div>
    </form>

</body>
</html>
