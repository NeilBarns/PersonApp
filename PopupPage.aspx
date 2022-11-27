<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="PopupPage.aspx.cs" Inherits="PersonApp.PopupPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>PopupPage</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <div class="card">
        <div class="card-header d-flex justify-content-center">
            <h3 class="card-title">SGCIS Test Page 2</h3>
        </div>
        <div class="card-body">
            <div class="row px-4" style="padding: 1rem 0rem;">
                <div class="col-6 col-lg d-flex justify-content-center">
                    <b><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></b>
                </div>
                <div class="col-6 col-lg d-flex justify-content-center">
                    <b><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></b>
                </div>
                <div class="col-6 col-lg d-flex justify-content-center">
                    <b><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></b>
                </div>
            </div>
            <figure class="highcharts-figure">
                <div id="container"></div>
            </figure>
        </div>
    </div>
     <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>
    <script src="https://code.highcharts.com/modules/export-data.js"></script>
    <script src="https://code.highcharts.com/modules/accessibility.js"></script>
    <script>
        Highcharts.chart('container', {
            chart: {
                type: 'column'
            },
            title: {
                text: ' '
            },
            xAxis: {
                categories: <%=dateData%>,
                crosshair: true
            },
            plotOptions: {
                column: {
                    pointPadding: 0.2,
                    borderWidth: 0
                }
            },
            series: [{
                data: <%=intData%>,
            }]
        });
    </script>
    <script src="Scripts/WebForms/jquery-3.4.1.min.js"></script>
    <script src="Scripts/WebForms/bootstrap.min.js"></script>
</body>
</html>
