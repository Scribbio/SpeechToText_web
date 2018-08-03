<%@ Page Title="Home Page" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SpeechToTextPOC._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Simple Speech-to-Text using System.Speech</h1>
        <p class="lead">System.Speech is...</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>
                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="English" />
                <asp:CheckBox ID="CheckBox2" runat="server" Text="French" />
            </h2>
            <h2>
                <asp:TextBox ID="TextBox1" runat="server" Height="153px" TextMode="MultiLine" Width="465px"></asp:TextBox>
            </h2>
            <h2>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Record" />
                &nbsp;<asp:Button ID="StopButton" runat="server" OnClick="StopButton_Click" Text="Stop" />
            </h2>
            <p>
                &nbsp;</p>
        </div>
        <div class="col-md-4">
            <h2>&nbsp;</h2>
            <p>
                &nbsp;</p>
        </div>
    </div>

</asp:Content>
