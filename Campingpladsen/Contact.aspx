<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Campingpladsen.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Checkout form</h2>
    <div class="container-fluid">
        <div class="col-xs-12">
            <div class="row">
                <div class="col-xs-6">
                    <label for="Fname">First name</label>
                    <input type="text" class="form-control" id="Fname" />
                </div>
                <div class="col-xs-6">
                    <label for="Lname">Last name</label>
                    <input type="text" class="form-control" id="Lname" />
                </div>
            </div>
            <label for="email">E-mail address</label>
            <input type="text" class="form-control" id="email" />
            <label for="number">Phone number</label>
            <input type="text" class="form-control" id="number" placeholder="+45" />
            <label for="address">Address</label>
            <input type="text" class="form-control" id="address" />
            <div class="row">
                <div class="col-xs-6">
                    <label for="Sdate">Start date</label>
                    <input type="date" class="form-control" id="Sdate" />
                </div>
                <div class="col-xs-6">
                    <label for="Edate">End date</label>
                    <input type="date" class="form-control" id="Edate" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
