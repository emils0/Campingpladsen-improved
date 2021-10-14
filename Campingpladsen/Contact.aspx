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
        <%--Dates--%>
        <div class="row">
            <div class="col-xs-6 form-group">
                <label for="Sdate">Start date</label>
                <asp:TextBox type="date" class="form-control" ID="Sdate" runat="server" />
                &nbsp;
            </div>
            <div class="col-xs-6 form-group">
                <label for="Edate">End date</label>
                <asp:TextBox type="date" class="form-control" ID="Edate" runat="server" />
            </div>
        </div>
        <%--Adults--%>
        <div class="row">
            <div class="col-xs-6 form-group">
                <label for="Voksen">Adults</label>
                <asp:TextBox type="number" class="form-control" ID="Voksen" runat="server" value="0" />
            </div>
            <div class="col-xs-6 form-group">
                <label for="BadelandVoksen">Pool tickets: Adult (per day per person)</label>
                <asp:TextBox type="number" class="form-control" ID="BadelandVoksen" runat="server" value="0" />
            </div>
        </div>
        <%--Kids--%>
        <div class="row">
            <div class="col-xs-6 form-group">
                <label for="Barn">Children</label>
                <asp:TextBox type="number" class="form-control" ID="Barn" runat="server" value="0" />
            </div>
            <div class="col-xs-6 form-group">
                <label for="BadelandBarn">Pool tickets: Child (per day per person)</label>
                <asp:TextBox type="number" class="form-control" ID="BadelandBarn" runat="server" value="0" />
            </div>
        </div>
        <%--Dogs--%>
        <div class="row">
            <div class="form-group col-xs-6">
                <label for="Hund">Dogs</label>
                <asp:TextBox type="number" class="form-control" ID="Hund" runat="server" value="0" />
            </div>
            <div class="form-group col-xs-6">
                <label for="Bikes">Bike rental (per person per day)</label>
                <asp:TextBox type="number" class="form-control" ID="Bikes" runat="server" value="0" />
            </div>
        </div>
        <div class="row">
            <div class="form-group col-xs-3">
                <label for="spotType">Spot type</label>
                <asp:DropDownList ID="spotType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="spotType_SelectedIndexChanged">
                    <asp:ListItem Value="#">Please Select</asp:ListItem>
                    <asp:ListItem Value="Stor plads">Stor plads </asp:ListItem>
                    <asp:ListItem Value="Lille plads">Lille plads</asp:ListItem>
                    <asp:ListItem Value="Hytte">Hytte</asp:ListItem>
                    <asp:ListItem Value="Luksus hytte">Luksus hytte</asp:ListItem>
                    <asp:ListItem Value="Telt plads">Teltplads</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group col-xs-3">
                <label for="availableSpots">Spot NR</label>
                <asp:DropDownList ID="availableSpots" runat="server">
                </asp:DropDownList>
            </div>
            <div classs="col-xs-6 form-group">
                <label for="cleaning">Endcleaning (only for huts)</label>
                <asp:CheckBox ID="cleaning" runat="server"/>
            </div>
            <div classs="col-xs-6 form-group">
                <label for="Bedlinen">Bedlinen rental</label>
                <asp:CheckBox ID="Bedlinen" runat="server" />
            </div>
        </div>
        <div class="row">
            <asp:Button ID="confirm" runat="server" class="btn btn-outline-primary" Text="Confirm" OnClick="Confirm_Reservation" />
        </div>
        <br />
    </div>
</asp:Content>
