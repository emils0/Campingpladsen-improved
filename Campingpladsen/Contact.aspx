<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Campingpladsen.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="style.css" rel="stylesheet" type="text/css" />
    <h2>Checkout form</h2>
    <div class="container-fluid">
        <div class="col-xs-12 centered"
            <div class="row">
                <div class="col-xs-6">
                    <label for="Fname">First name</label>
                    <asp:TextBox type="text" class="form-control" ID="Fname" runat="server" />
                </div>
                <div class="col-xs-6">
                    <label for="Lname">Last name</label>
                    <asp:TextBox type="text" class="form-control" ID="Lname" runat="server" />
                </div>
            </div>
            <label for="email">E-mail address</label>
            <asp:TextBox type="text" class="form-control" ID="email" runat="server" />
            <label for="number">Phone number</label>
            <asp:TextBox type="text" class="form-control" ID="number" placeholder="+45" runat="server" />
            <label for="address">Address</label>
            <asp:TextBox type="text" class="form-control" ID="address" runat="server" />
            <div class="row">
                <div class="col-xs-6">
                    <label for="Sdate">Start date</label>
                    <asp:TextBox type="date" class="form-control" ID="Sdate" runat="server" />
                    &nbsp;
                </div>
                <div class="col-xs-6">
                    <label for="Edate">End date</label>
                    <asp:TextBox type="date" class="form-control" ID="Edate" runat="server" />
                </div>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Confirm_Reservation" />>
        </div>
    </div>
</asp:Content>
