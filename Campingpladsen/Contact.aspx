<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Campingpladsen.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="style.css" rel="stylesheet" type="text/css" />
    <h2>Checkout form</h2>
    <div class="container smol centered">
        <div class="row">
            <div class="col-md-6 form-group">
                <label for="Fname">First name</label>
                <asp:TextBox type="text" class="form-control" ID="Fname" runat="server" />
            </div>
            <div class="col-md-6 form-group">
                <label for="Lname">Last name</label>
                <asp:TextBox type="text" class="form-control" ID="Lname" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 form-group">
                <label for="email">E-mail address</label>
                <asp:TextBox type="text" class="form-control" ID="email" runat="server" />
            </div>
            <div class="col-md-6 form-group">
                <label for="number">Phone number</label>
                <asp:TextBox type="text" class="form-control" ID="number" placeholder="+45" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label for="address">Address</label>
            <asp:TextBox type="text" class="form-control" ID="address" runat="server" />
        </div>
        <div class="row">
            <div class="col-md-6 form-group">
                <label for="Sdate">Start date</label>
                <asp:TextBox type="date" class="form-control" ID="Sdate" runat="server" />
                &nbsp;
            </div>
            <div class="col-md-6 form-group">
                <label for="Edate">End date</label>
                <asp:TextBox type="date" class="form-control" ID="Edate" runat="server" />
            </div>
        </div>
        <asp:Button ID="confirm" runat="server" class="btn btn-outline-primary" Text="Confirm" OnClick="Confirm_Reservation" />
    </div>
</asp:Content>
