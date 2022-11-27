<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PersonApp._Default" Async="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var popupWindow;

        function OpenPopup(personId) {
            popupWindow = popup("PopupPage.aspx?id=" + personId);
        }

        function popup(url) {
            var width = 1000;
            var height = 500;
            var left = (screen.width - width) / 2;
            var top = (screen.height - height) / 2;
            var params = 'width=' + width + ', height=' + height;
            params += ', top=' + top + ', left=' + left;
            params += ', directories=no';
            params += ', location=no';
            params += ', menubar=no';
            params += ', resizable=no';
            params += ', scrollbars=no';
            params += ', status=no';
            params += ', toolbar=no';
            newwin = window.open(url, 'windowname5', params);
            var lblFirstName = popup.document.getElementById("lblFirstName");
            var lblLastName = popup.document.getElementById("lblLastName");
            lblFirstName.innerHTML = personId;
            lblLastName.innerHTML = personId;
            popup.focus();
            if (window.focus) { newwin.focus() }
            return false;
        }

    </script>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
    <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid1" runat="server"
        OnNeedDataSource="RadGrid1_NeedDataSource" AllowAutomaticUpdates="True"
        AllowAutomaticInserts="True" AllowAutomaticDeletes="true"
        AllowSorting="true" OnInsertCommand="RadGrid1_InsertCommand"
        OnUpdateCommand="RadGrid1_UpdateCommand" OnDeleteCommand="RadGrid1_DeleteCommand" OnItemDataBound="RadGrid1_ItemDataBound" >
        <MasterTableView AllowMultiColumnSorting="true" AutoGenerateColumns="False" DataKeyNames="Id" CommandItemDisplay="Top">
            <Columns>
                <telerik:GridEditCommandColumn UniqueName="EditCommandColumn">
                </telerik:GridEditCommandColumn>
                <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="ID" SortExpression="Id" ReadOnly="true"
                    UniqueName="ID">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" HeaderText="Name" SortExpression="Name"
                    UniqueName="Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Age" DataType="System.Int32" HeaderText="Age" SortExpression="Age"
                    UniqueName="Age">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Type" DataType="System.Int32" HeaderText="Type" SortExpression="Type"
                    UniqueName="Type">
                </telerik:GridBoundColumn>

               <%-- <telerik:GridDropDownColumn UniqueName="Type" ListDataMember="PersonType"
                    SortExpression="AccessLevelID" ListTextField="Id" ListValueField="Id"
                    HeaderText="Type" DataField="Type">
                </telerik:GridDropDownColumn>--%>

                <telerik:GridButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete" ConfirmText="Delete this Person?" ConfirmDialogType="Classic"
                    ConfirmTitle="Delete" ButtonType="FontIconButton">
                </telerik:GridButtonColumn>
                
                <telerik:GridButtonColumn CommandName="ShowInfo" ButtonType="ImageButton" UniqueName="Info">
                </telerik:GridButtonColumn>

            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
