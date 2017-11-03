<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/admin.Master" CodeBehind="plantilla2.aspx.vb" Inherits="hotel.plantilla2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table cellspacing="0" style="border-collapse:collapse;" id="GridView1" cssclass="footable">
        <thead>
            <tr>
                <th scope="col" data-class="expand">First Name</th><th scope="col">Last Name</th>
                <th scope="col" data-hide="phone,tablet" style="display: table-cell;">Email</th>
                <th scope="col" data-hide="phone,tablet" style="display: table-cell;">Address</th>
                <th scope="col" data-hide="phone" style="display: table-cell;">Contact</th>
            </tr>
        </thead>
        <tbody>
            <tr class="">
                <td class="expand">Lorem</td>
                <td>ipsum</td>
                <td style="display: table-cell;">lorem@techbrij.com</td>
                <td style="display: table-cell;">
                    <span id="GridView1_Label1_0">Main Street</span>
                </td>
                <td style="display: table-cell;">1234567890</td>
            </tr>
            </tbody>
    </table>
</asp:Content>
