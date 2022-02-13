<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Userwebapp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>All Users</title>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"  rel="stylesheet" type="text/css" />
    
    
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"  type="text/javascript"></script>
    <script type="text/javascript" src="scripts/jquery.blockUI.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        BlockUI("dvGrid");
        $.blockUI.defaults.css = {};
    });
    function BlockUI(elementID) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(function () {
            $("#" + elementID).block({ message: '<div align = "center">' + '<img src="images/loadingAnim.gif"/></div>',
                css: {},
                overlayCSS: { backgroundColor: '#000000', opacity: 0.6, border: '3px solid #63B2EB' }
            });
        });
        prm.add_endRequest(function () {
            $("#" + elementID).unblock();
        });
    };
   

    $(document).ready(function () {
        $(".datepick").each(function () {
            $(this).datepicker({
                dateFormat: 'dd/mm/yy'
            });
        });

        $(function () {
            $('[id*=ddlSkills]').multiselect({
                includeSelectAllOption: true
            });
        });
    });

    function pageLoad() {
        $(".datepick").each(function () {
            $(this).datepicker({
                dateFormat: 'dd/mm/yy'
            });
        });
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Users List</h2>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div id="dvGrid" style="padding: 10px; width: 450px">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound"
            DataKeyNames="UserID" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" PageSize = "2" AllowPaging ="true" OnPageIndexChanging = "OnPaging"
            OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
            Width="450">
            <Columns>
                <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DOB" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblDob" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDob" class='datepick' runat="server" Text='<%# Eval("DOB", "{0:dd/MM/yyyy}") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Designation" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDesignation" runat="server" Text='<%# Eval("Designation") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Skills" ItemStyle-Width="150">
                    <ItemTemplate>
                    <%# Eval("Skills") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ListBox ID="ddlSkills" runat="server" SelectionMode="Multiple">
                        <asp:ListItem Text="Skill 1" Value="Skill 1" />
                        <asp:ListItem Text="Skill 2" Value="Skill 2" />
                        <asp:ListItem Text="Skill 3" Value="Skill 3" />
                        <asp:ListItem Text="Skill 4" Value="Skill 4" />
                    </asp:ListBox>
                </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" />
            </Columns>
        </asp:GridView>
        <br />
        <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
            <tr>
                <td style="width: 150px">
                    Name:<br />
                    <asp:TextBox ID="txtName" runat="server" Width="140" />
                </td>
                <td style="width: 150px">
                    DOB:<br />
                    <asp:TextBox ID="txtDob" class='datepick' DataFormatString="{dd/MM/yyyy}" runat="server" Width="140" AutoComplete="off"  />
                </td>
                <td style="width: 150px">
                    Designation:<br />
                    <asp:TextBox ID="txtDesignation" runat="server" Width="140" />
                </td>
                <td style="width: 150px">
                    Skills:<br />                    
                    <asp:ListBox ID="ddlSkills" runat="server" SelectionMode="Multiple">
                        <asp:ListItem Text="Skill 1" Value="Skill 1" />
                        <asp:ListItem Text="Skill 2" Value="Skill 2" />
                        <asp:ListItem Text="Skill 3" Value="Skill 3" />
                        <asp:ListItem Text="Skill 4" Value="Skill 4" />
                    </asp:ListBox>
                </td>
                <td style="width: 150px">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</div>
    </form>
</body>
</html>
