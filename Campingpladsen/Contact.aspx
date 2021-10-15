<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Campingpladsen.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="style.css" rel="stylesheet" type="text/css" />
    <div class="container smol">
        <div class="row">
            <h2>Booking</h2>
            <div class="col-xs-6 form-group">
                <label for="Fname">First name</label>
                <asp:TextBox type="text" class="form-control" ID="Fname" runat="server" />
            </div>
            <div class="col-xs-6 form-group">
                <label for="Lname">Last name</label>
                <asp:TextBox type="text" class="form-control" ID="Lname" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-6 form-group">
                <label for="email">E-mail address</label>
                <asp:TextBox type="text" class="form-control" ID="email" runat="server" />
            </div>
            <div class="col-xs-6 form-group">
                <label for="number">Phone number</label>
                <asp:TextBox type="text" class="form-control" ID="number" placeholder="+45" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label for="address">Address</label>
            <asp:TextBox type="text" class="form-control" ID="address" runat="server" />
        </div>
        <div class="row">
            <div class="col-xs-6 form-group">
                <label for="Sdate">Start date</label>
                <asp:TextBox type="date" class="form-control" ID="Sdate" runat="server" />
            </div>
            <div class="col-xs-6 form-group">
                <label for="Edate">End date</label>
                <asp:TextBox type="date" class="form-control" ID="Edate" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-6 form-group">
                <label for="people">Amount of residents</label>
                <asp:TextBox type="number" class="form-control" ID="people" runat="server" />
            </div>
            <div class="col-xs-6 form-group">
                <label for="children">Children</label>
                <asp:TextBox type="number" class="form-control" ID="children" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label for="dogs">Dogs</label>
            <asp:TextBox type="number" class="form-control" ID="dogs" runat="server" />
        </div>
        <div class="row">
            <div class="form-group col-xs-6">
                <label for="availableSpots">Spot</label>
                <asp:DropDownList ID="availableSpots" runat="server">
                </asp:DropDownList>
            </div>
            <div classs="col-xs-6 form-group">
                <label for="cleaning">Cleaning</label>
                <asp:CheckBox ID="cleaning" runat="server" />
            </div>
        </div>
        <div class="row">
            <asp:Button ID="confirm" runat="server" class="btn btn-outline-primary" Text="Confirm" OnClick="Confirm_Reservation" />
        </div>
        <br />
    </div>
</asp:Content>
